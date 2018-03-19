using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using LPO.Module.BusinessObjects.Communication;
using lpmt_xaf.Module.BusinessObjects.Project_Schedule;

namespace LPO.Module.BusinessObjects.Projects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Project : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Project(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        string projectNumber;
        [Size(30)]
        public string ProjectNumber
        {
            get => projectNumber;
            set => SetPropertyValue(nameof(ProjectNumber), ref projectNumber, value);
        }
        string projectDescription;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ProjectDescription
        {
            get => projectDescription;
            set => SetPropertyValue(nameof(ProjectDescription), ref projectDescription, value);
        }

        [Association("Project-CommunicationItems")]
        public XPCollection<CommunicationItem> CommunicationItems
        {
            get
            {
                return GetCollection<CommunicationItem>(nameof(CommunicationItems));
            }
        }

        Client.Client client;
        [Association("Client-Projects")]
        public Client.Client Client
        {
            get => client;
            set => SetPropertyValue(nameof(Client), ref client, value);
        }

        [Association("Project-ProjectEvents")]
        public XPCollection<ProjectEvent> ProjectEvents => GetCollection<ProjectEvent>(nameof(ProjectEvents));

        string projectFolder;
        [Size(255)]
        [EditorAlias("HyperLinkStringPropertyEditor")]
        public string ProjectFolder
        {
            get => projectFolder;
            set => SetPropertyValue(nameof(ProjectFolder), ref projectFolder, value);
        }
    }
}