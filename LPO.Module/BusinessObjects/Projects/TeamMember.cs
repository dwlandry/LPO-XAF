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

namespace LPO.Module.BusinessObjects.Projects
{
    [DefaultClassOptions]
    [ImageName("BO_Person")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class TeamMember : Person
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public TeamMember(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            fromDate = DateTime.Today;
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        string company;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Company
        {
            get => company;
            set => SetPropertyValue(nameof(Company), ref company, value);
        }
        string projectRole;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ProjectRole
        {
            get => projectRole;
            set => SetPropertyValue(nameof(ProjectRole), ref projectRole, value);
        }
        DateTime fromDate;
        public DateTime FromDate
        {
            get => fromDate;
            set => SetPropertyValue(nameof(FromDate), ref fromDate, value);
        }
        DateTime thruDate;
        public DateTime ThruDate
        {
            get => thruDate;
            set => SetPropertyValue(nameof(ThruDate), ref thruDate, value);
        }

        //Project project;
        //[Association("Project-TeamMembers")]
        //public Project Project
        //{
        //    get => project;
        //    set => SetPropertyValue(nameof(Project), ref project, value);
        //}

        [Association("Project-TeamMembers")]
        public XPCollection<Project> Projects => GetCollection<Project>(nameof(Projects));
    }
}