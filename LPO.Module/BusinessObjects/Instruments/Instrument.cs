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
using LPO.Module.BusinessObjects.Documents;

namespace LPO.Module.BusinessObjects.Instruments
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("Tag")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Bottom)]
    [Persistent("inst_instrument")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Instrument : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Instrument(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
        Project project;
        [Association("Project-Instruments")]
        public Project Project
        {
            get => project;
            set => SetPropertyValue(nameof(Project), ref project, value);
        }

        string tagPrefix;
        [Size(10)]
        [XafDisplayName("Prefix")]
        [Persistent(@"tag_prefix")]
        public string TagPrefix
        {
            get => tagPrefix;
            set => SetPropertyValue(nameof(TagPrefix), ref tagPrefix, value);
        }
        string tagLetters;
        [Size(10)]
        [XafDisplayName("Letters")]
        [Persistent(@"tag_letters")]
        public string TagLetters
        {
            get => tagLetters;
            set => SetPropertyValue(nameof(TagLetters), ref tagLetters, value);
        }
        string tagNumbers;
        [Size(10)]
        [XafDisplayName("Numbers")]
        [Persistent(@"tag_numbers")]
        public string TagNumbers
        {
            get => tagNumbers;
            set => SetPropertyValue(nameof(TagNumbers), ref tagNumbers, value);
        }
        string tagSuffix;
        [Size(10)]
        [XafDisplayName("Suffix")]
        [Persistent(@"tag_suffix")]
        public string TagSuffix
        {
            get => tagSuffix;
            set => SetPropertyValue(nameof(TagSuffix), ref tagSuffix, value);
        }

        public string Tag { get => String.Format("{0}{1}-{2}{3}", TagPrefix, TagLetters, TagNumbers, TagSuffix); }

        InstrumentType instrumentType;
        [Persistent(@"instrument_type")]
        public InstrumentType InstrumentType
        {
            get => instrumentType;
            set => SetPropertyValue(nameof(InstrumentType), ref instrumentType, value);
        }

        InstrumentStatus status;
        public InstrumentStatus Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }

        ProjectScope projectScope;
        public ProjectScope ProjectScope
        {
            get => projectScope;
            set => SetPropertyValue(nameof(ProjectScope), ref projectScope, value);
        }

        PID pID;
        [Association("PID-Instruments")]
        public PID PID
        {
            get => pID;
            set => SetPropertyValue(nameof(PID), ref pID, value);
        }

        [EditorAlias("HyperLinkStringPropertyEditor")]
        [XafDisplayName("PID Link")]
        public string PathToPID => PID != null && PID.File != null ? PID.File.RealFileName : string.Empty;

        string processDescription;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Persistent(@"process_description")]
        public string ProcessDescription
        {
            get => processDescription;
            set => SetPropertyValue(nameof(ProcessDescription), ref processDescription, value);
        }
        string comments;
        [Size(255)]
        public string Comments
        {
            get => comments;
            set => SetPropertyValue(nameof(Comments), ref comments, value);
        }
    }
}