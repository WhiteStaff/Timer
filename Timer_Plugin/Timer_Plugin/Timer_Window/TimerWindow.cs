using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;
using System.Timers;

namespace Timer_Plugin.Timer_Window
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class TimerWindow
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("a6fb0a45-8ce0-4cbc-b264-fc852dd1bc5f");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        private void OnBeforeQueryStatus(object sender, EventArgs e)
        {
            var myCommand = sender as OleMenuCommand;
            if (null != myCommand)
            {
                myCommand.Text = "New Text";
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerWindow"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private TimerWindow(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            EventHandler eventHandler = this.ShowMessageBox;
            var menuItem = new MenuCommand(ShowMessageBox, menuCommandID);
            menuItem.BeforeQueryStatus +=
            new EventHandler(OnBeforeQueryStatus);
            commandService.AddCommand(menuItem);

        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static TimerWindow Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
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
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in TimerWindow's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;
            Instance = new TimerWindow(package, commandService);


        }

        public void ShowMessageBox(object sender, EventArgs e)
        {

            string title = "TimerWindow";

            VsShellUtilities.ShowMessageBox(
              this.package,
              aa,
              title,
              OLEMSGICON.OLEMSGICON_INFO,
              OLEMSGBUTTON.OLEMSGBUTTON_OK,
              OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        /// 

        string aa = DateTime.Now.ToString("HH:mm:ss");
        private void Execute(object sender, EventArgs e)
        {
             System.Timers.Timer aTimer;
            ThreadHelper.ThrowIfNotOnUIThread();
            string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            string title = "TimerWindow";


            VsShellUtilities.ShowMessageBox(
            this.package,
            aa,
            title,
            OLEMSGICON.OLEMSGICON_INFO,
            OLEMSGBUTTON.OLEMSGBUTTON_OK,
            OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);


           /* aTimer = new System.Timers.Timer(200);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;*/

            

            
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
