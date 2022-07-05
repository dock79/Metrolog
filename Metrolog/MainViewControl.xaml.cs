/*
 * Created by SharpDevelop.
 * User: yudin.sv
 * Date: 29.07.2021
 * Time: 8:52
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

namespace Metrolog
{
	/// <summary>
	/// Interaction logic for MainViewControl.xaml
	/// </summary>
	public partial class MainViewControl : UserControl
	{
		public event RoutedEventHandler NewXmlFileClick;
		public event RoutedEventHandler LoadXmlFileClick;
		public event RoutedEventHandler ShowXmlFileClick;
		
		
		public MainViewControl()
		{
			InitializeComponent();
		}
		void button1_Click(object sender, RoutedEventArgs e)
		{
			//Передать это событие наверх родителю
			if (this.NewXmlFileClick != null)
				this.NewXmlFileClick(this, e);
		}
		void button2_Click(object sender, RoutedEventArgs e)
		{
			//Передать это событие наверх родителю
			if (this.LoadXmlFileClick != null)
				this.LoadXmlFileClick(this, e);
		}
		
		void button3_Click(object sender, RoutedEventArgs e)
		{
			//Передать это событие наверх родителю
			if (this.ShowXmlFileClick != null)
				this.ShowXmlFileClick(this, e);
		}

		private void Button4_OnClick(object sender, RoutedEventArgs e)
		{
			SettingsWindow sw = new SettingsWindow();
			sw.Owner = App.Current.MainWindow;
			sw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			sw.ShowDialog();
		}
	}
}