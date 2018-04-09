using System;
using System.Configuration;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace LPO.Win {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            
#if EASYTEST
            DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register();
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            if(Tracing.GetFileLocationFromSettings() == DevExpress.Persistent.Base.FileLocation.CurrentUserApplicationDataFolder) {
                Tracing.LocalUserAppDataPath = Application.LocalUserAppDataPath;
            }
            Tracing.Initialize();
            LPOWindowsFormsApplication winApplication = new LPOWindowsFormsApplication();
            // Refer to the https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112680.aspx help article for more details on how to provide a custom splash form.
            //winApplication.SplashScreen = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen("YourSplashImage.png");
            SecurityAdapterHelper.Enable();
            if(ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                // The following line was added by David Landry per the recommendation of XPO Best Practices article, https://www.devexpress.com/Support/Center/Question/Details/A2944/xpo-best-practices
                InitializeDAL(winApplication.ConnectionString);
            }
#if EASYTEST
            if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
            }
#endif
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached && winApplication.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
                winApplication.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            }
#endif
            try {
                winApplication.Setup();
                winApplication.Start();
            }
            catch(Exception e) {
                winApplication.HandleException(e);
            }
        }

        /// <summary>
        /// To improve web application performance, create a single data access layer 
        /// (DAL for short) to connect to a data store and share it across multiple units of work (sessions).
        /// 
        /// References:
        /// https://documentation.devexpress.com/CoreLibraries/2260/DevExpress-ORM-Tool/Getting-Started/Tutorial-4-A-Windows-Forms-Application-for-Data-Editing
        /// https://www.devexpress.com/Support/Center/Question/Details/A2944/xpo-best-practices
        /// 
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        static void InitializeDAL(string connectionString)
        {
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(AccessConnectionProvider.GetConnectionString(@connectionString), AutoCreateOption.DatabaseAndSchema);
        }
    }
}
