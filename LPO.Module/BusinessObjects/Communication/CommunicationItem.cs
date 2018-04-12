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
using LPO.Module.BusinessObjects.Projects;

namespace LPO.Module.BusinessObjects.Communication
{
    [DefaultClassOptions]
    [ImageName("BO_Communication")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [Persistent(@"comm_communication-item")]
    public class CommunicationItem : GenerateUserFriendlyId.Module.BusinessObjects.UserFriendlyIdPersistentObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CommunicationItem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                    && Session.IsNewObject(this)
                        && (Session.ObjectLayer is SimpleObjectLayer)
                        //OR
                        //&& !(Session.ObjectLayer is DevExpress.ExpressApp.Security.ClientServer.SecuredSessionObjectLayer)
                        && TrackingNumber == string.Empty)
            {
                int nextSequence = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "MyServerPrefix");
                //TrackingNumber = this.Project.ProjectNumber nextSequence;
                base.OnSaving();
            }

            DateOpened = DateTime.Today;

            IncludeInReport = true;

            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        
        [PersistentAlias("concat('C', ToStr(SequentialNumber))")]
        public string CommunicationItemId
        {
            get => Convert.ToString(EvaluateAlias("CommunicationItemId"));
            //get => communicationItemId;
            //set => SetPropertyValue(nameof(CommunicationItemId), ref communicationItemId, value);
        }

        bool includeInReport;
        [Persistent(@"include_in_report")]
        public bool IncludeInReport
        {
            get => includeInReport;
            set => SetPropertyValue(nameof(IncludeInReport), ref includeInReport, value);
        }

        DateTime dateClosed;
        [Persistent(@"date_closed")]
        public DateTime DateClosed
        {
            get => dateClosed;
            set => SetPropertyValue(nameof(DateClosed), ref dateClosed, value);
        }

        DateTime dateOpened;
        [Persistent(@"date_opened")]
        public DateTime DateOpened
        {
            get => dateOpened;
            set => SetPropertyValue(nameof(DateOpened), ref dateOpened, value);
        }

        DateTime dateRequired;
        [Persistent(@"date_required")]
        public DateTime DateRequired
        {
            get => dateRequired;
            set => SetPropertyValue(nameof(DateRequired), ref dateRequired, value);
        }

        CommunicationCategory communicationCategory;
        [Persistent(@"communication_category")]
        [Association("Category-CommunicationItems")]
        public CommunicationCategory CommunicationCategory
        {
            get => communicationCategory;
            set => SetPropertyValue(nameof(CommunicationCategory), ref communicationCategory, value);
        }

        bool costImpact;
        [Persistent(@"has_cost_impact")]
        public bool CostImpact
        {
            get => costImpact;
            set => SetPropertyValue(nameof(CostImpact), ref costImpact, value);
        }

        string description;
        [Size(SizeAttribute.Unlimited)]
        [Persistent(@"description")]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }
        Project project;
        [Association("Project-CommunicationItems")]
        public Project Project
        {
            get => project;
            set => SetPropertyValue(nameof(Project), ref project, value);
        }

        Origination origination;
        [Association("Origination-CommunicationItems")]
        public Origination Origination
        {
            get => origination;
            set => SetPropertyValue(nameof(Origination), ref origination, value);
        }

        string originator;
        [Size(255)]
        [Persistent(@"originator")]
        public string Originator
        {
            get => originator;
            set => SetPropertyValue(nameof(Originator), ref originator, value);
        }

        string ownership;
        [Size(255)]
        [Persistent(@"ownership")]
        public string Ownership
        {
            get => ownership;
            set => SetPropertyValue(nameof(Ownership), ref ownership, value);
        }

        string resolution;
        [Size(SizeAttribute.Unlimited)]
        [Persistent(@"resolution")]
        public string Resolution
        {
            get => resolution;
            set => SetPropertyValue(nameof(Resolution), ref resolution, value);
        }

        bool scheduleImpact;
        [Persistent(@"has_schedule_impact")]
        public bool ScheduleImpact
        {
            get => scheduleImpact;
            set => SetPropertyValue(nameof(ScheduleImpact), ref scheduleImpact, value);
        }

        string trackingNumber;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Persistent(@"tracking_number")]
        [RuleUniqueValue, Indexed(Unique = true)]
        public string TrackingNumber
        {
            get => trackingNumber;
            set => SetPropertyValue(nameof(TrackingNumber), ref trackingNumber, value);
        }

        [Association("CommunicationItem-ItemCommentsCollection")]
        public XPCollection<ItemComment> ItemCommentsCollection => GetCollection<ItemComment>(nameof(ItemCommentsCollection));
    }
}