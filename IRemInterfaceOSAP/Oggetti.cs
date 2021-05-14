using System;
using AnagInterface;

namespace IRemInterfaceOSAP
{
	public interface IRemotingInterfaceOSAP
	{
		//*** 20130610 - ruolo supplettivo ***
		//CalcoloResult CalcolaImportoOSAP(Articolo Immobile, Categorie[] arrCategorie, TipologieOccupazioni[] arrTipologieOccupazioni, Agevolazione[] arrAgevolazioni, Tariffe[] arrTariffe);
		CalcoloResult CalcolaOSAP (Ruolo.E_TIPO TipoRuolo, Articolo Immobile,Categorie[] arrCategorie, TipologieOccupazioni[] arrTipologieOccupazioni,Agevolazione[] arrAgevolazioni, Tariffe[] arrTariffe, CalcoloResult ArticoloPrecedente);
		//*** ***
	}

	[Serializable]
	public class Uffici
	{
		private int _idUfficio;
		private string _descrizione;

		public int IdUfficio
		{
			get { return _idUfficio; }
			set { _idUfficio = value; }
		}

		public string Descrizione
		{
			get { return _descrizione; }
			set { _descrizione = value; }
		}
	}

	[Serializable]
	public class TitoloRichiedente
	{
		private int _idTitoloRichiedente;
		private string _descrizione;

		public int IdTitoloRichiedente
		{
			get { return _idTitoloRichiedente; }
			set { _idTitoloRichiedente = value; }
		}

		public string Descrizione
		{
			get { return _descrizione; }
			set { _descrizione = value; }
		}
	}

	[Serializable]
	public class TipologieOccupazioni
	{
		private int _idTipologiaOccupazione;
		private string _descrizione;
		private double _coefficienteMoltiplicativo;
        private string _Tributo;
        public string IdTributo
        {
            get { return _Tributo; }
            set { _Tributo = value; }
        }
        public int IdTipologiaOccupazione
		{
			get { return _idTipologiaOccupazione; }
			set { _idTipologiaOccupazione = value; }
		}

		public string Descrizione
		{
			get { return _descrizione; }
			set { _descrizione = value; }
		}

		public double CoefficienteMoltiplicativo
		{
			get { return _coefficienteMoltiplicativo; }
			set { _coefficienteMoltiplicativo = value; }
		}
	}

	[Serializable]
	public class TipoConsistenza
	{
		public enum E_CONSISTENZA
		{
			MQ = 1,
			MT = 2,
			NUTENTI = 3
		}

		private int _idTipoConsistenza;
		private string _descrizione;

		public int IdTipoConsistenza
		{
			get { return _idTipoConsistenza; }
			set { _idTipoConsistenza = value; }
		}

		public string Descrizione
		{
			get { return _descrizione; }
			set { _descrizione = value; }
		}

		public TipoConsistenza()
		{
		}
	}

	[Serializable]
	public class Tariffe
	{
		private int _idTariffa;
		private string _idEnte;
		private string _idTributo;
		private string _descrTributo;
		private int _idCategoria;
		private string _categoria;
		private int _idTipologiaOccupazione;
		private string _tipologiaOccupazione;
		private int _idDurata;
		private string _durata;
		private int _anno;
		private double _valore;
		private double _minimoApplicabile;
        
		public int IdTariffa
		{
			get { return _idTariffa; }
			set { _idTariffa = value; }
		}

		public string IdEnte
		{
			get { return _idEnte; }
			set { _idEnte = value; }
		}

		public string IdTributo
		{
			get { return _idTributo; }
			set { _idTributo = value; }
		}
		public string DescrTributo
		{
			get { return _descrTributo; }
			set { _descrTributo = value; }
		}

		public int IdCategoria
		{
			get { return _idCategoria; }
			set { _idCategoria = value; }
		}

		public string Categoria
		{
			get { return _categoria; }
			set { _categoria = value; }
		}

		public int IdTipologiaOccupazione
		{
			get { return _idTipologiaOccupazione; }
			set { _idTipologiaOccupazione = value; }
		}

		public string TipologiaOccupazione
		{
			get { return _tipologiaOccupazione; }
			set { _tipologiaOccupazione = value; }
		}

		public int IdDurata
		{
			get { return _idDurata; }
			set { _idDurata = value; }
		}

		public string Durata
		{
			get { return _durata; }
			set { _durata = value; }
		}

		public int Anno
		{
			get { return _anno; }
			set { _anno = value; }
		}

		public double Valore
		{
			get { return _valore; }
			set { _valore = value; }
		}

		public double MinimoApplicabile
		{
			get { return _minimoApplicabile; }
			set { _minimoApplicabile = value; }
		}
	}

	[Serializable]
	public class Ruolo
	{
		//*** 20130610 - ruolo supplettivo ***
		public enum E_TIPO
		{
			ORDINARIO=0,
			SUPPLETIVO=1
		}
		//*** ***

		private int _idRuolo;
		private Cartella _cartella;
		private Articolo _articolo;
		private double _importoLordo;
		private double _importo;
		private DateTime _dataVariazione;
		private Tariffe _tariffa; // Info non propria del Ruolo, ma utile per visualizzazioni

		public int IdRuolo
		{
			get { return _idRuolo; }
			set { _idRuolo = value; }
		}

		public Cartella CartellaTOCO
		{
			get { return _cartella; }
			set { _cartella = value; }
		}

		public Articolo ArticoloTOCO
		{
			get { return _articolo; }
			set { _articolo = value; }
		}

		public double ImportoLordo
		{
			get { return _importoLordo; }
			set { _importoLordo = value; }
		}
		
		public double Importo
		{
			get { return _importo; }
			set { _importo = value; }
		}

		public DateTime DataVariazione
		{
			get { return _dataVariazione; }
			set { _dataVariazione = value; }
		}

		public Tariffe Tariffa
		{
			get { return _tariffa; }
			set { _tariffa = value; }
		}

		public Ruolo()
		{
		}
	}

	[Serializable]
	public class Rata
	{
		private int _idRata;
		private int _idCartella;
		private string _numeroRata;
		private string _descrizioneRata;
		private double _importoRata;
		private DateTime _dataScadenza;
		private string _codiceBollettino;
		private string _codeline;
		private string _numeroContoCorrente;
		private string _barcode;
		private DateTime _dataInserimento;

		public int IdRata
		{
			get { return _idRata; }
			set { _idRata = value; }
		}

		public int IdCartella
		{
			get { return _idCartella; }
			set { _idCartella = value; }
		}

		// Numero rata == "U" indica soluzione unica
		public string NumeroRata
		{
			get { return _numeroRata; }
			set { _numeroRata = value; }
		}

		// La descrizione viene presa direttamente dall'enum
		public string DescrizioneRata
		{
			get	{ return _descrizioneRata; }
			set { _descrizioneRata = value; }
		}

		public double ImportoRata
		{
			get { return _importoRata; }
			set { _importoRata = value; }
		}

		public DateTime DataScadenza
		{
			get { return _dataScadenza; }
			set { _dataScadenza = value; }
		}

		public string CodiceBollettino
		{
			get { return _codiceBollettino; }
			set { _codiceBollettino = value; }
		}

		public string Codeline
		{
			get { return _codeline; }
			set { _codeline = value; }
		}

		public string NumeroContoCorrente
		{
			get { return _numeroContoCorrente; }
			set { _numeroContoCorrente = value; }
		}

		public string Barcode
		{
			get { return _barcode; }
			set { _barcode = value; }
		}

		public DateTime DataInserimento
		{
			get { return _dataInserimento; }
			set { _dataInserimento = value; }
		}
		
		public Rata()
		{
		}
	}

	[Serializable]
	public class RataExt : Rata 
	{
        private string _Tributo;
        public string IdTributo
        {
            get { return _Tributo; }
            set { _Tributo = value; }
        }
        private int _IdContribuente;
		public int IdContribuente
		{
			get { return _IdContribuente; }
			set { _IdContribuente = value; }
		}

		private int _Anno;
		public int Anno
		{
			get { return _Anno; }
			set { _Anno = value; }
		}

		private double _ImportoPagato;
		public double ImportoPagato
		{
			get { return _ImportoPagato; }
			set { _ImportoPagato = value; }
		}

		private string _IdEnte;
		public string IdEnte
		{
			get { return _IdEnte; }
			set { _IdEnte = value; }
		}

		private string _CodiceCartella;
		public string CodiceCartella
		{
			get { return _CodiceCartella; }
			set { _CodiceCartella = value; }
		}

		private DateTime _DataEmissione;
		public DateTime DataEmissione
		{
			get { return _DataEmissione; }
			set { _DataEmissione = value; }
		}

		private DateTime _DataAccredito;
		public DateTime DataAccredito
		{
			get { return _DataAccredito; }
			set { _DataAccredito = value; }
		}		

		private DateTime _DataPagamento;
		public DateTime DataPagamento
		{
			get { return _DataPagamento; }
			set { _DataPagamento = value; }
		}		
	}

	[Serializable]
	public class PagamentoExt : Pagamento
	{
        private string _Tributo;
        public string IdTributo
        {
            get { return _Tributo; }
            set { _Tributo = value; }
        }
        private string _NumeroRataString;
		public string NumeroRataString
		{
			get { return _NumeroRataString; }
			set { _NumeroRataString = value; }
		}

		private int _idDataAnagrafica;
		public int IdDataAnagrafica
		{
			get { return _idDataAnagrafica; }
			set { _idDataAnagrafica = value; }
		}

		private string _Anno;
		public string Anno
		{
			get { return _Anno; }
			set { _Anno = value; }
		}

		private string _Nominativo;
		public string Nominativo
		{
			get { return _Nominativo; }
			set { _Nominativo = value; }
		}
        private string _CFPIVA;
        public string CFPIVA
        {
            get { return _CFPIVA; }
            set { _CFPIVA = value; }
        }

		private string _CodiceCartella;
		public string CodiceCartella
		{
			get { return _CodiceCartella; }
			set { _CodiceCartella = value; }
		}
    }

	[Serializable]
	public class Pagamento
	{
		private int _idPagamento;
		private int _codContribuente;
		private string _idEnte;
		private Cartella _cartella;
		private int _numeroRata;
		private double _importoPagato;
		private DateTime _dataAccredito;
		private DateTime _dataPagamento;
		private string _provenienza;
		private string _codiceBollettino;

		public int IdPagamento
		{
			get { return _idPagamento; }
			set { _idPagamento = value; }
		}

		public int CodContribuente
		{
			get { return _codContribuente; }
			set { _codContribuente = value; }
		}

		public string IdEnte
		{
			get { return _idEnte; }
			set { _idEnte = value; }
		}

		public Cartella CartellaTOCO
		{
			get { return _cartella; }
			set { _cartella = value; }
		}

		public int NumeroRata
		{
			get { return _numeroRata; }
			set { _numeroRata = value; }
		}

		public double ImportoPagato
		{
			get { return _importoPagato; }
			set { _importoPagato = value; }
		}

		public DateTime DataAccredito
		{
			get { return _dataAccredito; }
			set { _dataAccredito = value; }
		}

		public DateTime DataPagamento
		{
			get { return _dataPagamento; }
			set { _dataPagamento = value; }
		}

		public string Provenienza
		{
			get { return _provenienza; }
			set { _provenienza = value; }
		}

		public string CodiceBollettino
		{
			get { return _codiceBollettino; }
			set { _codiceBollettino = value; }
		}

		public Pagamento()
		{
		}
	}

	[Serializable]
	public class Minuta
	{
		private DettaglioAnagrafica _anagraficaContribuente;
		private int _codContribuente;
		private int _idDichiarazione;
		private string _NDichiarazione;
		private string _sVia = string.Empty;
		private int _codVia = -1;
		private string _civico = string.Empty;
		private string _esponente = string.Empty;
		private string _interno = string.Empty;
		private string _consistenza;
		private string _dataInizioOccupazione;
		private string _durata;
		private string _dataFineOccupazione;
		private double _maggiorazioneImporto;
		private double _maggiorazionePerc;
		private double _detrazioneImporto;
		private string _attrazione;
		private string _tipologiaOccupazione;
		private string _categoria;
		//*** 20130416 - deve essere l'elenco di tutte le % di agevolazione applicate
		//private double _agevolazionePerc;
		private string _agevolazionePerc;
		//*** ***
		private double _tariffaApplicata;
		private double _importoLordo;
		private double _importo;
        private string _Tributo;
        public string IdTributo
        {
            get { return _Tributo; }
            set { _Tributo = value; }
        }
        public DettaglioAnagrafica AnagraficaContribuente
		{
			get { return _anagraficaContribuente; }
			set { _anagraficaContribuente = value; }
		}

		public int CodContribuente
		{
			get { return _codContribuente; }
			set { _codContribuente = value; }
		}
		public int IdDichiarazione
		{
			get { return _idDichiarazione; }
			set { _idDichiarazione = value; }
		}
		public string NDichiarazione
		{
			get { return _NDichiarazione; }
			set { _NDichiarazione = value; }
		}

		public string SVia
		{
			get { return _sVia; }
			set { _sVia = value; }
		}

		public int CodVia
		{
			get { return _codVia; }
			set { _codVia = value; }
		}

		public string Civico
		{
			get { return _civico; }
			set { _civico = value; }
		}

		public string Esponente
		{
			get { return _esponente; }
			set { _esponente = value; }
		}

		public string Interno
		{
			get { return _interno; }
			set { _interno = value; }
		}

		public string Consistenza
		{
			get { return _consistenza; }
			set { _consistenza = value; }
		}

		public string DataInizioOccupazione
		{
			get { return _dataInizioOccupazione; }
			set { _dataInizioOccupazione = value; }
		}

		public string Durata
		{
			get { return _durata; }
			set { _durata = value; }
		}

		public string DataFineOccupazione
		{
			get { return _dataFineOccupazione; }
			set { _dataFineOccupazione = value; }
		}

		public double MaggiorazioneImporto
		{
			get { return _maggiorazioneImporto; }
			set { _maggiorazioneImporto = value; }
		}

		public double MaggiorazionePerc
		{
			get { return _maggiorazionePerc; }
			set { _maggiorazionePerc = value; }
		}

		public double DetrazioneImporto
		{
			get { return _detrazioneImporto; }
			set { _detrazioneImporto = value; }
		}

		public string Attrazione
		{
			get { return _attrazione; }
			set { _attrazione = value; }
		}

		public string TipologiaOccupazione
		{
			get { return _tipologiaOccupazione; }
			set { _tipologiaOccupazione = value; }
		}

		public string Categoria
		{
			get { return _categoria; }
			set { _categoria = value; }
		}

		//*** 20130416 - deve essere l'elenco di tutte le % di agevolazione applicate
//		public double AgevolazionePerc
//		{
//			get { return _agevolazionePerc; }
//			set { _agevolazionePerc = value; }
//		}
		public string AgevolazionePerc
		{
			get { return _agevolazionePerc; }
			set { _agevolazionePerc = value; }
		}
		//*** ***
		public double TariffaApplicata
		{
			get { return _tariffaApplicata; }
			set { _tariffaApplicata = value; }
		}

		public double ImportoLordo
		{
			get { return _importoLordo; }
			set { _importoLordo = value; }
		}

		public double Importo
		{
			get { return _importo; }
			set { _importo = value; }
		}

		public Minuta()
		{
		}
	}

	[Serializable]
	public class Lotto
	{
		private string _idEnte;
		private int _nLotto;
		private int _anno;
		private int _primaCartella;
		private int _ultimaCartella;
		private string _codiceConcessione;
		private DateTime _dataEmissione;

		public string IdEnte
		{
			get { return _idEnte; }
			set { _idEnte = value; }
		}

		public int NLotto
		{
			get { return _nLotto; }
			set { _nLotto = value; }
		}

		public int Anno
		{
			get { return _anno; }
			set { _anno = value; }
		}

		public int PrimaCartella
		{
			get { return _primaCartella; }
			set { _primaCartella = value; }
		}

		public int UltimaCartella
		{
			get { return _ultimaCartella; }
			set { _ultimaCartella = value; }
		}

		public string CodiceConcessione
		{
			get { return _codiceConcessione; }
			set { _codiceConcessione = value; }
		}

		public DateTime DataEmissione
		{
			get { return _dataEmissione; }
			set { _dataEmissione = value; }
		}

		public Lotto()
		{
		}
	}

	[Serializable]
	public enum E_CALCOLORESULT
	{
		OK,
		NOTARIFFA,
		NOCATEGORIA,
		NOTIPOLOGIAOCCUPAZIONE,
		ERRORECALCOLO
	}

	[Serializable]
	public class CalcoloResult
	{
		public double TariffaApplicata;
		public double ImportoLordo;
		public double ImportoCalcolato;
		public E_CALCOLORESULT Result;
	}

	[Serializable]
	public class ElaborazioneEffettuata
	{
		private string _idEnte;
		private int _idflusso;
		private int _anno;
		private DateTime _dataOraInizioElaborazione;
		private DateTime _dataOraFineElaborazione;
		private DateTime _dataOraMinutaStampata;
		private DateTime _dataOraMinutaApprovata;
		private DateTime _dataOraCalcoloRate;
		private DateTime _dataOraDocumentiStampati;
		private DateTime _dataOraDocumentiApprovati;
		private int _nUtenti;
		private int _nDichiarazioni;
		private int _nArticoli;
		private double _importoTotale;
		private double _sogliaMinimaRate;
		private string _note;
		//*** 20130610 - ruolo supplettivo ***
		private int _TipoRuolo;
		//*** ***
        private string _Tributo;
        //*** 201806 ***
        private string _ListOccupazioni;
        public string IdTributo
        {
            get { return _Tributo; }
            set { _Tributo = value; }
        }
        public string IdEnte
		{
			get { return _idEnte; }
			set { _idEnte = value; }
		}
		public int IdFlusso
		{
			get { return _idflusso; }
			set { _idflusso = value; }
		}
		public int Anno
		{
			get { return _anno; }
			set { _anno = value; }
		}

		public DateTime DataOraInizioElaborazione
		{
			get { return _dataOraInizioElaborazione; }
			set { _dataOraInizioElaborazione = value; }
		}

		public DateTime DataOraFineElaborazione
		{
			get { return _dataOraFineElaborazione; }
			set { _dataOraFineElaborazione = value; }
		}

		public DateTime DataOraMinutaStampata
		{
			get { return _dataOraMinutaStampata; }
			set { _dataOraMinutaStampata = value; }
		}

		public DateTime DataOraMinutaApprovata
		{
			get { return _dataOraMinutaApprovata; }
			set { _dataOraMinutaApprovata = value; }
		}

		public DateTime DataOraCalcoloRate
		{
			get { return _dataOraCalcoloRate; }
			set { _dataOraCalcoloRate = value; }
		}

		public DateTime DataOraDocumentiStampati
		{
			get { return _dataOraDocumentiStampati; }
			set { _dataOraDocumentiStampati = value; }
		}

		public DateTime DataOraDocumentiApprovati
		{
			get { return _dataOraDocumentiApprovati; }
			set { _dataOraDocumentiApprovati = value; }
		}

		public int NUtenti
		{
			get { return _nUtenti; }
			set { _nUtenti = value; }
		}

		public int NDichiarazioni
		{
			get { return _nDichiarazioni; }
			set { _nDichiarazioni = value; }
		}

		public int NArticoli
		{
			get { return _nArticoli; }
			set { _nArticoli = value; }
		}

		public double ImportoTotale
		{
			get { return _importoTotale; }
			set { _importoTotale = value; }
		}

		public double SogliaMinimaRate
		{
			get { return _sogliaMinimaRate; }
			set { _sogliaMinimaRate = value; }
		}

		public string Note
		{
			get { return _note; }
			set { _note = value; }
		}
		//*** 20130610 - ruolo supplettivo ***
		public int TipoRuolo
		{
			get { return _TipoRuolo; }
			set { _TipoRuolo = value; }
		}
        //*** ***
        //*** 201806 ***
        public string ListOccupazioni
        {
            get { return _ListOccupazioni; }
            set { _ListOccupazioni = value; }
        }
        public ElaborazioneEffettuata()
		{
		}
	}

	[Serializable]
	public class Durata
	{
		private int _idDurata;
		private string _descrizione;

		public int IdDurata
		{
			get { return _idDurata; }
			set { _idDurata = value; }
		}

		public string Descrizione
		{
			get { return _descrizione; }
			set { _descrizione = value; }
		}
		
		public Durata()
		{
		}
	}

	[Serializable]
	public class DichiarazioneTosapCosapTestata
	{
		private string _nDichiarazione;
		private string _noteDichiarazione;
		private string _Operatore;
		private int _idTipoAtto;
        private DateTime _dataDichiarazione;
		private DateTime _dataInserimento;
		private DateTime _dataVariazione;
		private DateTime _dataCessazione;
		private Uffici _ufficio;
		private TitoloRichiedente _titoloRichiedente;

		public string NDichiarazione
		{
			get { return _nDichiarazione; }
			set { _nDichiarazione = value; }
		}

		public DateTime DataDichiarazione
		{
			get { return _dataDichiarazione; }
			set { _dataDichiarazione = value; }
		}

		public int IdTipoAtto
		{
			get { return _idTipoAtto; }
			set { _idTipoAtto = value; }
		}
        public TitoloRichiedente TitoloRichiedente
		{
			get { return _titoloRichiedente; }
			set { _titoloRichiedente = value; }
		}

		public Uffici Ufficio
		{
			get { return _ufficio; }
			set { _ufficio = value; }
		}

		public string NoteDichiarazione
		{
			get { return _noteDichiarazione; }
			set { _noteDichiarazione = value; }
		}
		public string Operatore
		{
			get { return _Operatore; }
			set { _Operatore = value; }
		}
		public DateTime DataInserimento
		{
			get { return _dataInserimento; }
			set { _dataInserimento = value; }
		}
		public DateTime DataVariazione
		{
			get { return _dataVariazione; }
			set { _dataVariazione = value; }
		}
		public DateTime DataCessazione
		{
			get { return _dataCessazione; }
			set { _dataCessazione = value; }
		}
	}

	[Serializable]
	public class DichiarazioneTosapCosap
	{
		private DichiarazioneTosapCosapTestata _testataDichiarazione;
		private DettaglioAnagrafica _anagraficaContribuente;
		private Articolo[] _articoliDichiarazione;
		private string _idEnte;
		private string _codTributo;
		private int _idDichiarazione;
        public DichiarazioneTosapCosapTestata TestataDichiarazione
		{
			get { return _testataDichiarazione; }
			set { _testataDichiarazione = value; }
		}

		public DettaglioAnagrafica AnagraficaContribuente
		{
			get { return _anagraficaContribuente; }
			set { _anagraficaContribuente = value; }
		}

		public Articolo[] ArticoliDichiarazione
		{
			get { return _articoliDichiarazione; }
			set { _articoliDichiarazione = value; }
		}

		public string IdEnte
		{
			get { return _idEnte; }
			set { _idEnte = value; }
		}

		public string CodTributo
		{
			get { return _codTributo; }
			set { _codTributo = value; }
		}

		public int IdDichiarazione
		{
			get { return _idDichiarazione; }
			set { _idDichiarazione = value; }
		}
	}


	[Serializable]
	public class Rate
	{
		private string _idEnte;
		private int _anno;
		private string _nRata; // 'U' = soluzione unica, numero = n. rata
		private string _descrizione;
		private DateTime _dataScadenza;
		//*** 20130610 - ruolo supplettivo ***
		private int _IdFlusso;
		//*** ***

		public string IdEnte
		{
			get { return _idEnte; }
			set { _idEnte = value; }
		}

		public int Anno
		{
			get { return _anno; }
			set { _anno = value; }
		}

		public string NRata
		{
			get { return _nRata; }
			set { _nRata = value; }
		}

		public string Descrizione
		{
			get { return _descrizione; }
			set { _descrizione = value; }
		}

		public DateTime DataScadenza
		{
			get { return _dataScadenza; }
			set { _dataScadenza = value; }
		}
		//*** 20130610 - ruolo supplettivo ***
		public int IdFlusso
		{
			get { return _IdFlusso; }
			set { _IdFlusso = value; }
		}
		//*** ***

		public Rate()
		{
		}
	}
	
	[Serializable]
	public class Categorie
	{
		private int _idCategoria;
		private string _descrizione;
		private double _coefficiente;
        private string _Tributo;
        public string IdTributo
        {
            get { return _Tributo; }
            set { _Tributo = value; }
        }

		public int IdCategoria
		{
			get { return _idCategoria; }
			set { _idCategoria = value; }
		}

		public string Descrizione
		{
			get { return _descrizione; }
			set { _descrizione = value; }
		}

		public double Coefficiente
		{
			get { return _coefficiente; }
			set { _coefficiente = value; }
		}
	}

	[Serializable]
	public class Coefficienti
	{
		private string _tipoTabella;
		private int _idTabella;
		private string _descrizione;
		private int _anno;
		private decimal _coefficiente;

		public string TipoTabella
		{
			get { return _tipoTabella; }
			set { _tipoTabella=value; }
		}

		public int IdTabella
		{
			get { return _idTabella; }
			set { _idTabella = value; }
		}

		public string Descrizione
		{
			get { return _descrizione; }
			set { _descrizione = value; }
		}

		public int Anno
		{
			get { return _anno; }
			set { _anno = value; }
		}

		public decimal Coefficiente
		{
			get { return _coefficiente; }
			set { _coefficiente = value; }
		}
	}

	[Serializable]
	public class Cartella
	{
		private int _idCartella;
		private string _codiceCartella;
		private int _anno;
		private DateTime _dataEmissione;
		private int _codContribuente;
		private string _idEnte;
		private DichiarazioneTosapCosap _dichiarazione;
		private double _importoTotale;
		private double _importoArrotondamento;
		private double _importoCarico;
		private int _idFlussoRuolo;
		private DateTime _dataVariazione;
		private Ruolo[] _ruoli;
		private bool _selezionato;
        private int _TipoDoc = 0;
		private DettaglioAnagrafica _dettaglioContribuente;
        private string _Tributo;
        private bool _IsSgravio=false;
        private decimal _ImpPreSgravio=0;
        private decimal _ImpPagato = 0;
        public string IdTributo
        {
            get { return _Tributo; }
            set { _Tributo = value; }
        }
        public int IdCartella
		{
			get { return _idCartella; }
			set { _idCartella = value; }
		}

		public string CodiceCartella
		{
			get { return _codiceCartella; }
			set { _codiceCartella = value; }
		}

		public int Anno
		{
			get { return _anno; }
			set { _anno = value; }
		}

		public DateTime DataEmissione
		{
			get { return _dataEmissione; }
			set { _dataEmissione = value; }
		}

		public int CodContribuente
		{
			get { return _codContribuente; }
			set { _codContribuente = value; }
		}

		public string IdEnte
		{
			get { return _idEnte; }
			set { _idEnte = value; }
		}

		public DichiarazioneTosapCosap Dichiarazione
		{
			get { return _dichiarazione; }
			set { _dichiarazione = value; }
		}

		public double ImportoTotale
		{
			get { return _importoTotale; }
			set { _importoTotale = value; }
		}

		public double ImportoArrotondamento
		{
			get { return _importoArrotondamento; }
			set { _importoArrotondamento = value; }
		}

		public double ImportoCarico
		{
			get { return _importoCarico; }
			set { _importoCarico = value; }
		}

		public int IdFlussoRuolo
		{
			get { return _idFlussoRuolo; }
			set { _idFlussoRuolo = value; }
		}

		public DateTime DataVariazione
		{
			get { return _dataVariazione; }
			set { _dataVariazione = value; }
		}

		public DettaglioAnagrafica DettaglioContribuente
		{
			get { return _dettaglioContribuente; }
			set { _dettaglioContribuente = value; }
		}

		public Ruolo[] Ruoli
		{
			get { return _ruoli; }
			set { _ruoli = value; }
		}

		public bool Selezionato
		{
			get { return _selezionato; }
			set { _selezionato = value; }
		}
        public int IdTipoDoc
        {
            get { return _TipoDoc; }
            set { _TipoDoc = value; }
        }
        public bool IsSgravio
        {
            get { return _IsSgravio; }
            set { _IsSgravio = value; }
        }
        public decimal ImpPreSgravio
        {
            get { return _ImpPreSgravio; }
            set { _ImpPreSgravio = value; }
        }
        public decimal ImpPagato
        {
            get { return _ImpPagato; }
            set { _ImpPagato = value; }
        }

        public Cartella()
		{
		}
	}
	[Serializable]
	public class Articolo
	{
		private DichiarazioneTosapCosap _dichiarazione;
		private int _idArticolo = -1;
		private int _idDichiarazione=-1;
		private string _idTributo="";
		private string _sVia = String.Empty;
		private int _codVia = -1;
		private int _civico = -1;
		private string _esponente = String.Empty;
		private string _interno = String.Empty;
		private string _scala = String.Empty;
		private Categorie _categoria;
		private TipologieOccupazioni _tipologiaOccupazione;
		private double _consistenza = 0;
		private TipoConsistenza _tipoConsistenza;
		private DateTime _dataInizioOccupazione;
		private DateTime _dataFineOccupazione;
		private Durata _tipoDurata;
		private int _durataOccupazione;
		private double _maggiorazioneImporto;
		private double _maggiorazionePerc;
		private string _note = String.Empty;
		private Agevolazione[] _agevolazione;
		private double _detrazioneImporto;
		private bool _attrazione;
		private string _Operatore;
		private DateTime _dataInserimento;
		private DateTime _dataVariazione;
		private DateTime _dataCessazione;
		//*** 20130610 - ruolo supplettivo ***
		private int _IdArticoloPadre;
		private string _ElencoPercAgevolazioni;
		//*** ***

		public int IdArticolo
		{
			get { return _idArticolo; }
			set { _idArticolo = value; }
		}

		public int IdDichiarazione
		{
			get { return _idDichiarazione; }
			set { _idDichiarazione = value; }
		}
		public string IdTributo
		{
			get { return _idTributo; }
			set { _idTributo = value; }
		}
		public string SVia
		{
			get { return _sVia; }
			set { _sVia = value; }
		}

		public int CodVia
		{
			get { return _codVia; }
			set { _codVia = value; }
		}

		public int Civico
		{
			get { return _civico; }
			set { _civico = value; }
		}

		public string Esponente
		{
			get { return _esponente; }
			set { _esponente = value; }
		}

		public string Interno
		{
			get { return _interno; }
			set { _interno = value; }
		}

		public string Scala
		{
			get { return _scala; }
			set { _scala = value; }
		}

		public DateTime DataInizioOccupazione
		{
			get { return _dataInizioOccupazione; }
			set { _dataInizioOccupazione = value; }
		}

		public DateTime DataFineOccupazione
		{
			get { return _dataFineOccupazione; }
			set { _dataFineOccupazione = value; }
		}

		public Durata TipoDurata
		{
			get { return _tipoDurata; }
			set { _tipoDurata = value; }
		}

		public int DurataOccupazione
		{
			get { return _durataOccupazione; }
			set { _durataOccupazione = value; }
		}

		public double Consistenza
		{
			get { return _consistenza; }
			set { _consistenza = value; }
		}

		public TipoConsistenza TipoConsistenzaTOCO
		{
			get { return _tipoConsistenza; }
			set { _tipoConsistenza = value; }
		}

		public string Note
		{
			get { return _note; }
			set { _note = value; }
		}

		public double MaggiorazioneImporto
		{
			get { return _maggiorazioneImporto; }
			set { _maggiorazioneImporto = value; }
		}

		public double MaggiorazionePerc
		{
			get { return _maggiorazionePerc; }
			set { _maggiorazionePerc = value; }
		}

		public TipologieOccupazioni TipologiaOccupazione
		{
			get { return _tipologiaOccupazione; }
			set { _tipologiaOccupazione = value; }
		}

		public Categorie Categoria
		{
			get { return _categoria; }
			set { _categoria = value; }
		}

		public Agevolazione[] ListAgevolazioni
		{
			get { return _agevolazione; }
			set { _agevolazione = value; }
		}

		public double DetrazioneImporto
		{
			get { return _detrazioneImporto; }
			set { _detrazioneImporto = value; }
		}

		public bool Attrazione
		{
			get { return _attrazione; }
			set { _attrazione = value; }
		}
		public string Operatore
		{
			get { return _Operatore; }
			set { _Operatore = value; }
		}
		public DateTime DataInserimento
		{
			get { return _dataInserimento; }
			set { _dataInserimento = value; }
		}
		public DateTime DataVariazione
		{
			get { return _dataVariazione; }
			set { _dataVariazione = value; }
		}
		public DateTime DataCessazione
		{
			get { return _dataCessazione; }
			set { _dataCessazione = value; }
		}

		public DichiarazioneTosapCosap Dichiarazione
		{
			get { return _dichiarazione; }
			set { _dichiarazione = value; }
		}
		//*** 20130610 - ruolo supplettivo ***
		public string ElencoPercAgevolazioni
		{
			get { return _ElencoPercAgevolazioni; }
			set { _ElencoPercAgevolazioni = value; }
		}
		public int IdArticoloPadre
		{
			get { return _IdArticoloPadre; }
			set { _IdArticoloPadre = value; }
		}
		//*** ***
		public Articolo ()
		{}

	}

	[Serializable]
	public class Agevolazione
	{
		private int _idAgevolazione;
		private string _descrizione;
		private double _agevolazionePerc;
		private bool _selezionato;
        private string _Tributo;
        public string IdTributo
        {
            get { return _Tributo; }
            set { _Tributo = value; }
        }
        public int IdAgevolazione
		{
			get { return _idAgevolazione; }
			set { _idAgevolazione = value; }
		}
		public string Descrizione
		{
			get { return _descrizione; }
			set { _descrizione = value; }
		}
		public double AgevolazionePerc
		{
			get { return _agevolazionePerc; }
			set { _agevolazionePerc = value; }
		}
		public bool Selezionato
		{
			get { return _selezionato; }
			set { _selezionato = value; }
		}

		public Agevolazione()
		{
		}
	}
}