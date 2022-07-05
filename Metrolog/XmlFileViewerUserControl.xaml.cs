using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.XPath;
using Microsoft.Win32;


namespace Metrolog
{
    /// <summary>
    /// Interaction logic for NewXmlFileControl.xaml
    /// </summary>
    public partial class XmlFileViewerUserControl : UserControl
    {
        private XmlDocument _document;
        private WebBrowser _webBrowser;
        private TreeView _treeView;
        private XmlViewer _xmlViewerType;
        
        public XmlDocument Document => _document;

        public XmlViewer XmlViewerType
        {
            get => _xmlViewerType;
            set
            {
                _xmlViewerType = value;
                UpdateView();
            }
        }
        
        public XmlFileViewerUserControl()
        {
            InitializeComponent();
            _document = new XmlDocument();
            _webBrowser = new WebBrowser();
            _treeView = new TreeView();
            _treeView.PreviewMouseLeftButtonDown += TreeView_OnPreviewMouseLeftButtonDown;
            XmlViewerType = XmlViewer.Browser;
        }

        /*public void LoadXmlToView1(XmlDocument document)
        {
            try
            {
                _document = document;

                if (XmlViewerType == XmlViewer.Browser)
                {
                    LoadWebBrowser();
                }
                else
                {
                    LoadTreeView();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Невозможно просмотреть файл." + "\n" + e.Message, "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }*/

        public void LoadXmlToView(XmlDocument document)
        {
            try
            {
                _document = document;
                LoadWebBrowser();
                LoadTreeView();
                UpdateView();
            }
            catch (Exception e)
            {
                MessageBox.Show("Невозможно просмотреть файл." + "\n" + e.Message, "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void UpdateView()
        {
            
            if (XmlViewerType == XmlViewer.Browser)
            {
               ViewerUserControl.Content = _webBrowser;
            }
            else
            {
                ViewerUserControl.Content = _treeView;
            }
        }

        private void LoadWebBrowser()
        {
            var str = _document.InnerXml;
            _webBrowser.NavigateToString(str);
            //ViewerUserControl.Content = _webBrowser;
        }

        private void LoadTreeView()
        {
            _treeView.Items.Clear();
            //Creates the elements and adds them to a treeView control
            CreateElements(_document);
            //ViewerUserControl.Content = _treeView;
        }


        private void CreateElements(XmlDocument doc)
        {
            TreeViewItem item = null;
            foreach (XmlNode node in doc.ChildNodes)
                CreateChildElements(node, item);
            //CreateChildElements(node, item);
            //MyFindChild(node, item);
        }

        private void CreateChildElements(XmlNode innerNode, TreeViewItem parent)
        {
            var item = new TreeViewItem() {IsExpanded = true};

            var header = new TextBlock();
            header.FontSize = 14;

            switch (innerNode.NodeType)
            {
                case XmlNodeType.Element:
                    //item.Header = "<" + innerNode.Name;
                    header.Inlines.Add(new Run() {Foreground = Brushes.Brown, Text = "<" + innerNode.Name});
                    break;
                case XmlNodeType.XmlDeclaration:
                    //item.Header = "<?" + innerNode.InnerText;
                    header.Inlines.Add(new Run() {Foreground = Brushes.Blue, Text = "<?" + innerNode.Value});
                    break;
                case XmlNodeType.Comment:
                    //item.Header = "<!--" + innerNode.InnerText;
                    header.Inlines.Add(new Run() {Text = "<!--" + innerNode.Value});
                    break;
                default:
                    //item.Header = innerNode.Value.Trim();
                    header.Inlines.Add(new Run() {Text = innerNode.Value.Trim()});
                    break;
            }

            if (innerNode.Attributes != null)
                foreach (XmlAttribute attribute in innerNode.Attributes)
                    //item.Header += string.Format(" {0}=\"{1}\"", attribute.Name, attribute.Value);
                    header.Inlines.Add(
                        new Run()
                        {
                            Foreground = Brushes.Red,
                            Text = string.Format(" {0}=\"{1}\"", attribute.Name, attribute.Value)
                        });

            switch (innerNode.NodeType)
            {
                case XmlNodeType.Element:
                    if (innerNode.HasChildNodes)
                        //item.Header += ">";
                        header.Inlines.Add(new Run() {Foreground = Brushes.Brown, Text = ">"});
                    else
                        //item.Header += "/>";
                        header.Inlines.Add(new Run() {Foreground = Brushes.Brown, Text = "/>"});
                    break;
                case XmlNodeType.XmlDeclaration:
                    //item.Header += "?>";
                    header.Inlines.Add(new Run() {Foreground = Brushes.Blue, Text = "?>"});
                    break;
                case XmlNodeType.Comment:
                    //item.Header += "-->";
                    header.Inlines.Add(new Run() {Text = "-->"});
                    break;
                default:
                    break;
            }

            if (innerNode.ChildNodes != null)
            {
                foreach (XmlNode node in innerNode.ChildNodes)
                    CreateChildElements(node, item);
            }
            //}
            //else // innerNode.ChildNodes.Count == 1
            //{
            //header.Inlines.Add(
            //new Run() {Foreground = Brushes.Red, Text = innerNode.InnerText});
            //}

            //////////////////////
            //header.Inlines.Add(new LineBreak());
            //header.Inlines.Add(new Run() {Foreground = Brushes.Red, Text = innerNode.Name});
            //////////////////////////////

            //Добавляем либо в родительский TreeViewItem либо в сам TreeView, тут подумать может это как-то рефакторить
            item.Header = header;

            if (parent == null)
                //treeView.Items.Clear();
                _treeView.Items.Add(item);
            else
                parent.Items.Add(item);
        }
      
        private void TreeView_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var depObj = e.OriginalSource as Run;
                var tb = depObj.Parent as TextBlock;
                var tvi = tb.Parent as TreeViewItem;
                if (tvi == null) return;
                if (tvi.Items?.Count == 0) return;
                tvi.IsExpanded = !tvi.IsExpanded;
            }
            catch (Exception ex)
            {
            }
        }
    }
}