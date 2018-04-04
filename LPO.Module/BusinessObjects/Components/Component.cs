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
using LPO.Module.BusinessObjects.Instruments;

namespace LPO.Module.BusinessObjects.Components
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("DisplayName")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("cmpnt_component")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Component : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Component(Session session)
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
        ComponentType componentType;
        [Association("ComponentType-Components")]
        public ComponentType ComponentType
        {
            get => componentType;
            set => SetPropertyValue(nameof(ComponentType), ref componentType, value);
        }

        Manufacturer manufacturer;
        [Association("Manufacturer-Components")]
        public Manufacturer Manufacturer
        {
            get => manufacturer;
            set => SetPropertyValue(nameof(Manufacturer), ref manufacturer, value);
        }

        string modelNumber;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ModelNumber
        {
            get => modelNumber;
            set => SetPropertyValue(nameof(ModelNumber), ref modelNumber, value);
        }

        [Association("Component-InstrumentComponents")]
        public XPCollection<InstrumentComponent> InstrumentComponents => GetCollection<InstrumentComponent>(nameof(InstrumentComponents));

        [XafDisplayName("Component")]
        public string DisplayName => string.Format("{0}: {1}", manufacturer.Name, modelNumber);
    }
}