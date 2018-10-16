using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleExtension.UI
{
    public class BaseDialogWindow : DialogWindow
    {

        public BaseDialogWindow()
        {
            this.HasMaximizeButton = false;
            this.HasMinimizeButton = false;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
        }
    }
}
