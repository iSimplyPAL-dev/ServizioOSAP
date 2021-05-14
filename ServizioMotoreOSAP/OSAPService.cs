using System;
using System.Collections;
using IRemInterfaceOSAP;
using log4net;

namespace ServizioMotoreOSAP
{
    /// <summary>
    /// Classe rende disponibili le interfacce di calcolo 
    /// </summary>
    public class OSAPService:MarshalByRefObject, IRemotingInterfaceOSAP
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(OSAPService));
										
		public OSAPService()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		//*** 20130610 - ruolo supplettivo ***
		public CalcoloResult CalcolaOSAP (Ruolo.E_TIPO TipoRuolo, Articolo Immobile,Categorie[] arrCategorie, TipologieOccupazioni[] arrTipologieOccupazioni,Agevolazione[] arrAgevolazioni, Tariffe[] arrTariffe, CalcoloResult ArticoloPrecedente)
		{
			CalcoloResult Result = new CalcoloResult ();
			try
			{
				//calcolo l'importo derivante da dichiarazione
				Result=CalcolaImportoOSAP(Immobile,arrCategorie,arrTipologieOccupazioni,arrAgevolazioni,arrTariffe);

				if (TipoRuolo==Ruolo.E_TIPO.SUPPLETIVO)
				{
					if (ArticoloPrecedente!=null)
					{
						//Log.Debug("CalcolaOSAP::IdArticolo::"+ Immobile.IdArticolo.ToString() +"::importo calcolato da dich::"+Result.ImportoCalcolato.ToString()+"::Importo precedente::"+ArticoloPrecedente.ImportoCalcolato.ToString());
						Result.ImportoCalcolato-=ArticoloPrecedente.ImportoCalcolato;
						Result.ImportoLordo-=ArticoloPrecedente.ImportoLordo;
					}
					//else
					//{
						//Log.Debug("CalcolaOSAP::IdArticolo::"+ Immobile.IdArticolo.ToString() +"::manca articolo precedente");
					//}
				}
				//Log.Debug("CalcolaOSAP::IdArticolo::"+ Immobile.IdArticolo.ToString() +"::importo calcolato::"+Result.ImportoCalcolato.ToString());
				Result.Result = E_CALCOLORESULT.OK;
			}
			catch (Exception)
			{
				Result.Result = E_CALCOLORESULT.ERRORECALCOLO;
			}

			return Result;
		}

		//*** ***

		private CalcoloResult CalcolaImportoOSAP (Articolo Immobile,Categorie[] arrCategorie, TipologieOccupazioni[] arrTipologieOccupazioni,Agevolazione[] arrAgevolazioni, Tariffe[] arrTariffe)
		{
			CalcoloResult Result = new CalcoloResult ();
			try
			{
				Categorie categoriaToUse = null;
				TipologieOccupazioni tipologiaToUse = null;
				Tariffe tariffaToUse = null;
				Agevolazione[] agevolazioneToUse = null;
				ArrayList MyArray = new ArrayList();
				Agevolazione CurrentItem = null;

				// Recupero la categoria da utilizzare
				if (arrCategorie != null)
				{
					foreach (Categorie c in arrCategorie)
					{
						if (Immobile.Categoria.IdCategoria == c.IdCategoria)
						{
							categoriaToUse = c;
							break;
						}
					}
				}

				if (categoriaToUse == null)
				{
					Result.Result = E_CALCOLORESULT.NOCATEGORIA;
					Log.Debug("CalcolaImportoOSAP::categoria non trovata::"+ Immobile.Categoria.IdCategoria.ToString() +"::IdDichiarazione::"+Immobile.IdDichiarazione.ToString());
					return Result;
				}

				// Recupero la tipologia occupazione da utilizzare
				if (arrTipologieOccupazioni != null)
				{
					foreach (TipologieOccupazioni to in arrTipologieOccupazioni)
					{
						if (Immobile.TipologiaOccupazione.IdTipologiaOccupazione == to.IdTipologiaOccupazione)
						{
							tipologiaToUse = to;
							break;
						}
					}
				}

				if (tipologiaToUse == null)
				{
					Result.Result = E_CALCOLORESULT.NOTIPOLOGIAOCCUPAZIONE;
					Log.Debug("CalcolaImportoOSAP::tipologia non trovata::"+ Immobile.TipologiaOccupazione.IdTipologiaOccupazione.ToString() +"::IdDichiarazione::"+Immobile.IdDichiarazione.ToString());
					return Result;
				}

				// Recupero l'agevolazione eventuale da utilizzare
				if (arrAgevolazioni != null && Immobile.ListAgevolazioni != null)
				{
					foreach (Agevolazione ag in arrAgevolazioni)
					{
						for (int i = 0; i <= Immobile.ListAgevolazioni.GetUpperBound(0); i++) 
						{
							if (Immobile.ListAgevolazioni[i].IdAgevolazione == ag.IdAgevolazione)
							{
								CurrentItem = new Agevolazione();
								CurrentItem = ag;

								MyArray.Add(CurrentItem);
							}
						}
					}
					agevolazioneToUse=(Agevolazione[])MyArray.ToArray(typeof(Agevolazione));
				}
				else
				{
					// Se non ho agevolazioni ne creo una fittizia al 0% in modo da non gestire
					// casi particolari come agev != null in futuro
					CurrentItem = new Agevolazione();
					CurrentItem.AgevolazionePerc = 0;

					MyArray.Add(CurrentItem);
					agevolazioneToUse=(Agevolazione[])MyArray.ToArray(typeof(Agevolazione));
				}

				// Recupero la tariffa da utilizzare
				if (arrTariffe != null)
				{
					foreach (Tariffe t in arrTariffe)
					{
						// 2 casi possibili
						// - La tariffa è legata a tipo occupazione e categoria, il valore della tariffa
						//   è già quello da applicare per il calcolo (la tab tariffe contiene tutte le
						//   possibili combinazioni di tipo.occ./categoria)
						//*** 20130412 - la tariffa è legata a tipo occupazione+categoria+durata ***
						// - La tabella Categorie contiene un coeff. moltiplicativo da applicare alla tariffa
						//   In questo caso la tabella Tariffe contiene una sola tariffa per ogni tipo occ.
						//   e la categoria è valorizzata con NULL (o -1). In questo caso una volta trovata
						//   la tariffa corretta popolo le info mancanti e calcolo la tariffa vera applicando
						//   il coefficiente in modo da avere una sola gestione in futuro per il calcolo
						if (Immobile.TipologiaOccupazione.IdTipologiaOccupazione == t.IdTipologiaOccupazione
							&&
							(t.IdCategoria == -1 || t.IdCategoria == Immobile.Categoria.IdCategoria)
							&&
							t.IdDurata== Immobile.TipoDurata.IdDurata)
						{
							tariffaToUse = t;
							if (tariffaToUse.IdCategoria == -1)
							{
								tariffaToUse.IdCategoria = categoriaToUse.IdCategoria;
								tariffaToUse.Categoria = categoriaToUse.Descrizione;
								tariffaToUse.Valore *= categoriaToUse.Coefficiente;
							}
							break;
						}
					}
				}

				if (tariffaToUse == null)
				{
					Result.Result = E_CALCOLORESULT.NOTARIFFA;
					Log.Debug("CalcolaImportoOSAP::tariffa non trovata per durata::"+ Immobile.TipoDurata.IdDurata.ToString() +"::IdDichiarazione::"+Immobile.IdDichiarazione.ToString());
					return Result;
				}
				//*** 20130610 - ruolo supplettivo ***
				//la maggiorazione deve essere calcolata a parte perchè non deve incidere sulle riduzioni
				// Se ho una maggiorazione % sulla tariffa, la applico
				//if (Immobile.MaggiorazionePerc != 0.0)
				//	tariffaToUse.Valore += (tariffaToUse.Valore * (Immobile.MaggiorazionePerc / 100));
				//*** ***

				// Controllo la consistenza da utilizzare
				// - Nel caso di superfici >= 1000 MQ, calcolo usando il 10% della superficie
				// - Nel caso di superfici >= 1000 MQ di attrazioni o spettacoli viaggianti,
				//   calcolo usando il 50% fino a 100 MQ, il 25% dai 101 ai 1000 MQ e il 10% oltre i 1000 MQ
				if (Immobile.Consistenza >= 1000 &&
					Immobile.TipoConsistenzaTOCO.IdTipoConsistenza == (int)TipoConsistenza.E_CONSISTENZA.MQ)
				{
					if (Immobile.Attrazione)
					{
						Immobile.Consistenza =
							50 + // 50% dei primi 100 mq
							225 + // 25% dai 101 ai 1000 mq
							(Immobile.Consistenza - 1000) * 0.1; // 10% oltre i 1000 mq
					}
					else
						Immobile.Consistenza *= 0.1; // 10%
				}

				// Qui ho tutti i dati che mi servono, posso procedere al calcolo della TOSAP/COSAP
				double Importo = 0.0;
				double ImpMaggiorazione=0.0;

				Result.TariffaApplicata = tariffaToUse.Valore;

				Importo = tariffaToUse.Valore * Immobile.Consistenza;
				Importo *= (double)Immobile.DurataOccupazione;
				Importo *= tipologiaToUse.CoefficienteMoltiplicativo;

				Result.ImportoLordo = Importo;
				//calcolo l'importo di maggiorazione
				ImpMaggiorazione=Importo * (Immobile.MaggiorazionePerc / 100);
				ImpMaggiorazione += Immobile.MaggiorazioneImporto;
				//detraggo dal calcolato le riduzioni
				foreach (Agevolazione myAg in agevolazioneToUse)
				{
					Importo*=(1-(myAg.AgevolazionePerc/100));
				}
				Importo -= Immobile.DetrazioneImporto;
				//calcolo il netto
				Importo+=ImpMaggiorazione;

				if (Importo < tariffaToUse.MinimoApplicabile)
					Importo = tariffaToUse.MinimoApplicabile;

				Result.Result = E_CALCOLORESULT.OK;
				Result.ImportoCalcolato = Importo;
			}
			catch (Exception ex)
			{
				Result.Result = E_CALCOLORESULT.ERRORECALCOLO;
				Log.Debug("CalcolaImportoOSAP::si è verificato il seguente errore::"+ ex.Message);
			}

			return Result;
		}
	}
}
