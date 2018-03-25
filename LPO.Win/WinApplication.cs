using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using System.Collections.Generic;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.Persistent.BaseImpl;

namespace LPO.Win {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWinWinApplicationMembersTopicAll.aspx
    public partial class LPOWindowsFormsApplication : WinApplication {
        #region Default XAF configuration options (https://www.devexpress.com/kb=T501418)
        static LPOWindowsFormsApplication() {
            DevExpress.Persistent.Base.PasswordCryptographer.EnableRfc2898 = true;
            DevExpress.Persistent.Base.PasswordCryptographer.SupportLegacySha512 = false;
        }
        private void InitializeDefaults() {
            LinkNewObjectToParentImmediately = false;
            OptimizedControllersCreation = true;
            UseLightStyle = true;
        }
        #endregion
        public LPOWindowsFormsApplication() {
            InitializeComponent();
			InitializeDefaults();

            /// To open the linked file without creating a temporary one (and keep any changes to it after closing the program), handle the FileAttachmentsWindowsFormsModule.CustomOpenFileWithDefaultProgram event and call the e.FileData.SaveToStream method and pass null (nothing in VB.NET) as a parameter.
            fileAttachmentsWindowsFormsModule1.CustomOpenFileWithDefaultProgram += new EventHandler<DevExpress.ExpressApp.FileAttachments.Win.CustomFileOperationEventArgs>(fileAttachmentsWindowsFormsModule1_CustomOpenFileWithDefaultProgram);
        }
        private void fileAttachmentsWindowsFormsModule1_CustomOpenFileWithDefaultProgram(object sender, DevExpress.ExpressApp.FileAttachments.Win.CustomFileOperationEventArgs e)
        {
            if ((e.FileData is FileSystemData.BusinessObjects.FileSystemLinkObject)
                || (e.FileData is FileSystemData.BusinessObjects.FileSystemStoreObject))
            {
                e.FileData.SaveToStream(null);
                e.Handled = true;
            }
        }

        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProviders.Add(new SecuredObjectSpaceProvider((SecurityStrategyComplex)Security, XPObjectSpaceProvider.GetDataStoreProvider(args.ConnectionString, args.Connection, true), false));
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
            GenerateUserFriendlyId.Module.SequenceGenerator.Initialize(this, args.ConnectionString); //!!!
        }
        private void LPOWindowsFormsApplication_CustomizeLanguagesList(object sender, CustomizeLanguagesListEventArgs e) {
            string userLanguageName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            if(userLanguageName != "en-US" && e.Languages.IndexOf(userLanguageName) == -1) {
                e.Languages.Add(userLanguageName);
            }
        }
        private void LPOWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
            e.Updater.Update();
            e.Handled = true;
#else
            if(System.Diagnostics.Debugger.IsAttached) {
                e.Updater.Update();
                e.Handled = true;
            }
            else {
				string message = "The application cannot connect to the specified database, " +
					"because the database doesn't exist, its version is older " +
					"than that of the application or its schema does not match " +
					"the ORM data model structure. To avoid this error, use one " +
					"of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

				if(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
					message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
				}
				throw new InvalidOperationException(message);
            }
#endif
        }
    }
}
