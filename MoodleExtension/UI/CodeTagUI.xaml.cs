using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using MoodleExtension.Commands;
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
    /// Interaction logic for CodeTagUI.xaml
    /// </summary>
    public partial class CodeTagUI : BaseDialogWindow
    {
        public CodeTagUI()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                DTE2 dte = Package.GetGlobalService(typeof(DTE)) as DTE2;

                if (dte.ActiveDocument != null)
                {
                    var selection = (EnvDTE.TextSelection)dte.ActiveDocument.Selection;
                    selection.Unindent(100);

                    string text = selection.Text;

                    //text = text.Replace("\r\n", " ");
                    // Modify the text, for example:
                    text = "<code>" + text + "</code>";
                    ClipboardHandle.GetTextToClipboard(text);
                    // Replace the selection with the modified text.
                    //selection.Text = text;
                    System.Windows.Forms.MessageBox.Show("Kopieret");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Noget gik galt: " + ex.Message);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DTE2 dte = Package.GetGlobalService(typeof(DTE)) as DTE2;

                if (dte.ActiveDocument != null)
                {
                    var selection = (EnvDTE.TextSelection)dte.ActiveDocument.Selection;
                    //selection.Unindent(100);

                    string text = selection.Text;

                    //text = text.Replace("\r\n", " ");
                    // Modify the text, for example:
                    text = "<kbd>" + text + "</kbd>";
                    ClipboardHandle.GetTextToClipboard(text);
                    // Replace the selection with the modified text.
                    //selection.Text = text;
                    System.Windows.Forms.MessageBox.Show("Kopieret");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Noget gik galt: " + ex.Message);
            }
            
        }
    }
}
