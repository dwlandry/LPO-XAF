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
using LPO.Module.BusinessObjects.Project_Schedule;
using FileSystemData.BusinessObjects;
using LPO.Module.BusinessObjects.Instruments;
using LPO.Module.BusinessObjects.Documents;

namespace LPO.Module.BusinessObjects.Projects
{
    [DefaultClassOptions]
    [ImageName("BO_Handshake")]
    [DefaultProperty("DisplayName")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    //[FileAttachment("ProjectFolder")]
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
        public XPCollection<CommunicationItem> CommunicationItems => GetCollection<CommunicationItem>(nameof(CommunicationItems));

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
        //[RuleRegularExpression("HyperLinkDemoObject.Url.RuleRegularExpression", DefaultContexts.Save, @"(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})")]
        [EditorAlias("HyperLinkStringPropertyEditor")]
        public string ProjectFolder
        {
            get => projectFolder;
            set => SetPropertyValue(nameof(ProjectFolder), ref projectFolder, value);
        }

        [Association("Project-TeamMembers")]
        public XPCollection<TeamMember> TeamMembers => GetCollection<TeamMember>(nameof(TeamMembers));

        [Association("Project-GoBys")]
        public XPCollection<ProjectGoByDocument> GoBys => GetCollection<ProjectGoByDocument>(nameof(GoBys));

        [Association("Project-Documents")]
        public XPCollection<ProjectDocument> Documents => GetCollection<ProjectDocument>(nameof(Documents));

        public string DisplayName => client != null ? string.Format("({0}) {1} - {2}", client.Name, projectNumber, projectDescription) : string.Format("{0} - {1}", projectNumber, projectDescription);

        [Association("Project-Instruments")]
        public XPCollection<Instrument> Instruments => GetCollection<Instrument>(nameof(Instruments));

        [Association("Project-PIDs")]
        public XPCollection<PID> PIDs => GetCollection<PID>(nameof(PIDs));


    }
}