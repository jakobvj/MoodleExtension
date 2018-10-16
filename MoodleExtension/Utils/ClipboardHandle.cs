using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodleExtension
{
    public static class ClipboardHandle
    {
        public static void GetTextToClipboard(string text)
        {
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(text);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                msg += Environment.NewLine;
                msg += Environment.NewLine;
                msg += "The problem:";
                msg += Environment.NewLine;
                MessageBox.Show(msg);
            }
        }
    }
}
