using System;
using System.Collections.Generic;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace Metrolog
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static ApplicationSettings _applicationSettings;

		public App()
		{
			_applicationSettings = new ApplicationSettings();
		}

		public static ApplicationSettings ApplicationSettings
		{
			get => _applicationSettings;
			set => _applicationSettings = value;
		}
		
		private void App_OnStartup(object sender, StartupEventArgs e)
		{
			_applicationSettings = ApplicationSettings.LoadSettings("Metrolog.config");
		}

		
		
		private void App_OnExit(object sender, ExitEventArgs e)
		{
			ApplicationSettings.SaveSettings(_applicationSettings, "Metrolog.config");
		}

	}
}