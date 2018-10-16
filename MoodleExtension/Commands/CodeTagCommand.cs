using System;
using System.ComponentModel.Design;
using System.Globalization;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using MoodleExtension;
using MoodleExtension.UI;

namespace MoodleExtension.Commands
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class CodeTagCommand : Package, IVsShellPropertyEvents
    {
        DTE dte;
        uint cookie;
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 256;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("567f76ec-3322-4496-b909-0919d1d79131");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeTagCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private CodeTagCommand(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static CodeTagCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new CodeTagCommand(package);
            
        }
        protected override void Initialize()
        {

            base.Initialize();

            // set an eventlistener for shell property changes
            IVsShell shellService = GetService(typeof(SVsShell)) as IVsShell;

            if (shellService != null)
                ErrorHandler.ThrowOnFailure(shellService.AdviseShellPropertyChanges(this, out cookie));
   }
        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            //DTE2 dte = Package.GetGlobalService(typeof(DTE)) as DTE2;

            //if (dte.ActiveDocument != null)
            //{
            //    var selection = (TextSelection)dte.ActiveDocument.Selection;
            //    selection.Unindent(100);

            //    string text = selection.Text;
                
            //    //text = text.Replace("\r\n", " ");
            //    // Modify the text, for example:
            //    text = "<code>" + text + "</code>";
            //    ClipboardHandle.GetTextToClipboard(text);
            //    // Replace the selection with the modified text.
            //    //selection.Text = text;
            //}
            var codetagControl = new CodeTagUI();
            codetagControl.ShowModal();
            //string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            //string title = "CodeTagCommand";

            //// Show a message box to prove we were here
            //VsShellUtilities.ShowMessageBox(
            //    this.ServiceProvider,
            //    message,
            //    title,
            //    OLEMSGICON.OLEMSGICON_INFO,
            //    OLEMSGBUTTON.OLEMSGBUTTON_OK,
            //    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }

        public int OnShellPropertyChange(int propid, object var)
        {
            // when zombie state changes to false, finish package initialization

            if ((int)__VSSPROPID.VSSPROPID_Zombie == propid)
            {
                if ((bool)var == false)
                {

                    // zombie state dependent code

                    this.dte = GetService(typeof(SDTE)) as DTE;

                    // eventlistener no longer needed

                    IVsShell shellService = GetService(typeof(SVsShell)) as IVsShell;

                    if (shellService != null)
                        ErrorHandler.ThrowOnFailure(shellService.UnadviseShellPropertyChanges(this.cookie));
                    this.cookie = 0;

                }

            }

            return VSConstants.S_OK;

        }
    }
}
