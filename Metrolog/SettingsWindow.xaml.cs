/*
 * Created by SharpDevelop.
 * User: yudin.sv
 * Date: 10/11/2021
 * Time: 13:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace Metrolog
{
	/// <summary>
	/// Interaction logic for SettingsWindow.xaml
	/// </summary>
	public partial class SettingsWindow : Window
	{
		public SettingsWindow()
		{
			InitializeComponent();
		}

		private void LoadSettings()
		{
			IsValidateCheckBox.IsChecked = App.ApplicationSettings.IsValidate;
			IsValidateToSchemaCheckBox.IsChecked = App.ApplicationSettings.IsValidateToSchema;
			XmlSchemaTextBox.Text = App.ApplicationSettings.SchemaFile;
			ColorThemeComboBox.SelectedIndex = App.ApplicationSettings.ColorTheme;
			XmlViewerComboBox.SelectedIndex = (int)App.ApplicationSettings.XmlViewer;
			IsAnimateCheckBox.IsChecked = App.ApplicationSettings.IsAnimate;
		}

		private void ChangeSettings()
		{
			bool? result = IsValidateCheckBox.IsChecked;
			App.ApplicationSettings.IsValidate = result.HasValue ? result.Value : false;
			result = IsValidateToSchemaCheckBox.IsChecked;
			App.ApplicationSettings.IsValidateToSchema = result.HasValue ? result.Value : false;
			App.ApplicationSettings.SchemaFile = XmlSchemaTextBox.Text;
			App.ApplicationSettings.ColorTheme = ColorThemeComboBox.SelectedIndex;
			App.ApplicationSettings.XmlViewer = (XmlViewer)XmlViewerComboBox.SelectedIndex;
			result = IsAnimateCheckBox.IsChecked;
			App.ApplicationSettings.IsAnimate = result.HasValue ? result.Value : false;
		}
		
		private void SettingsWindow_OnLoaded(object sender, RoutedEventArgs e)
		{
			LoadSettings();
		}
	
		private void OKButton_OnClick(object sender, RoutedEventArgs e)
		{
			ChangeSettings();
			DialogResult = true;
			Close();
		}

		private void CancelButton_OnClick(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
            Close();
		}

		private void XmlSchemaButton_OnClick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.DefaultExt = ".xsd"; // Default file extension
			dlg.Filter = "Файлы Xml схемы (.xsd)|*.xsd|Все файлы (*.*)|*.*"; 
			dlg.InitialDirectory = Environment.CurrentDirectory;

			if (dlg.ShowDialog(this) == true)
			{
				XmlSchemaTextBox.Text = dlg.FileName;
			}
		}
	}
}