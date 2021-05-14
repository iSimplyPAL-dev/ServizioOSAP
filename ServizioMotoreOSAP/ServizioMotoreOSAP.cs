using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.IO;
using log4net;
using log4net.Config;

namespace ServizioMotoreOSAP
{
    /// <summary>
/// Classe di iniziazione del servizio.
/// 
/// Il servizio si occupa di calcolare il dovuto IMU/TASI.
/// </summary>
	public class ServizioMotoreOSAP: System.ServiceProcess.ServiceBase
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private TcpChannel chan; 
		private HttpChannel httpChan;

		// true --> quando si deve buildare il servizio
		// false --> quando si vuole lanciare in console per il debug
		private static bool _runService = false;

		public ServizioMotoreOSAP()
		{
			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
		}

		// The main entry point for the process
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// More than one user Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			if(_runService)
			{
				ServicesToRun = new System.ServiceProcess.ServiceBase[] { new ServizioMotoreOSAP() };
				System.ServiceProcess.ServiceBase.Run(ServicesToRun);
			}
			else
			{
				ServizioMotoreOSAP oServizio= new ServizioMotoreOSAP ();
				oServizio.OnStart(null);
				Console.WriteLine ("3...2...1...partito!");
				Console.ReadLine(); 
			}
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.ServiceName = "ServizioMotoreOSAP";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Set things in motion so your service can do its work.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			// TODO: Add code here to start your service.
			string pathfileinfo = ConfigurationSettings.AppSettings["pathfileconflog4net"].ToString();
			FileInfo fileconfiglog4net = new FileInfo(pathfileinfo);
			XmlConfigurator.ConfigureAndWatch(fileconfiglog4net);
			RegisterService();
		}
 
		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			// TODO: Add code here to perform any tear-down necessary to stop your service.
			ChannelServices.UnregisterChannel(chan);
			ChannelServices.UnregisterChannel(httpChan);
		}

		private void RegisterService()
		{
        
			// Use the configuration file.
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile );

			// Check to see if we have full errors.
			if( RemotingConfiguration.CustomErrorsEnabled ( false ) == true )
			{
				//string s = "Errore eccezioni";
			}

			BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
			BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
			serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
             
			IDictionary props = new Hashtable();
			props["port"] = ConfigurationSettings.AppSettings["TCP_PORT"].ToString(); 
            
			chan = new TcpChannel(props,clientProvider,serverProvider);
            
			props["port"] = ConfigurationSettings.AppSettings["HTTP_PORT"].ToString(); 

			SoapClientFormatterSinkProvider clientProviderSoap = new SoapClientFormatterSinkProvider ();
			SoapServerFormatterSinkProvider serverProviderSoap = new SoapServerFormatterSinkProvider();
			serverProviderSoap.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

			try
			{
				httpChan = new HttpChannel(props, null, serverProviderSoap);
				//            
				ChannelServices.RegisterChannel(chan);
				ChannelServices.RegisterChannel(httpChan);
			
				RemotingConfiguration.RegisterWellKnownServiceType(typeof(OSAPService),
					"OSAPService.rem", WellKnownObjectMode.SingleCall);
			}
			catch(Exception Err)
			{
				Console.WriteLine ("ERRORE::" + Err.Message);
				Console.ReadLine(); 
			}
		}

	}
}
