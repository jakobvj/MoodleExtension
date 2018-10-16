using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using MoodleExtension.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoodleExtension.UI
{
    /// <summary>
    /// Interaction logic for GenericoTagUI.xaml
    /// </summary>
    public partial class GenericoTagUI : BaseDialogWindow
    {
        public GenericoTagUI()
        {
            InitializeComponent();
        }
        
        private void GetToClipboard(Generico.Highlighter codeLang)
        {
            try
            {
                DTE2 dte = Package.GetGlobalService(typeof(DTE)) as DTE2;

                if (dte.ActiveDocument != null)
                {
                    var selection = (EnvDTE.TextSelection)dte.ActiveDocument.Selection;
                    //selection.Unindent(100);

                    string code = selection.Text;
                    
                    string result = Generico.WrapCode(codeLang, code);

                    ClipboardHandle.GetTextToClipboard(result);

                    System.Windows.Forms.MessageBox.Show("Kopieret");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Noget gik galt: " + ex.Message);
            }
        }

        

        private void Csharp(object sender, MouseButtonEventArgs e)
        {
            GetToClipboard(Generico.Highlighter.cs);
        }

        private void Html(object sender, MouseButtonEventArgs e)
        {
            GetToClipboard(Generico.Highlighter.html);
        }

        private void Css(object sender, MouseButtonEventArgs e)
        {
            GetToClipboard(Generico.Highlighter.css);
        }

        private void Json(object sender, MouseButtonEventArgs e)
        {
            GetToClipboard(Generico.Highlighter.json);
        }

        private void Javascript(object sender, MouseButtonEventArgs e)
        {
            GetToClipboard(Generico.Highlighter.javascript);
        }

        private void Python(object sender, MouseButtonEventArgs e)
        {
            GetToClipboard(Generico.Highlighter.python);
        }

        private void Sql(object sender, MouseButtonEventArgs e)
        {
            GetToClipboard(Generico.Highlighter.sql);
        }

        private void Xml(object sender, MouseButtonEventArgs e)
        {
            GetToClipboard(Generico.Highlighter.xml);
        }
    }
}
