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
using LPO.Module.BusinessObjects.Supplier;

namespace LPO.Module.BusinessObjects.Instruments
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("inst_component")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class InstrumentComponent : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public InstrumentComponent(Session session)
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
        Instrument instrument;
        [Association("Instrument-InstrumentComponents")]
        public Instrument Instrument
        {
            get => instrument;
            set => SetPropertyValue(nameof(Instrument), ref instrument, value);
        }

        Components.Component component;
        [Association("Component-InstrumentComponents")]
        public Components.Component Component
        {
            get => component;
            set => SetPropertyValue(nameof(Component), ref component, value);
        }

        Supplier.Supplier supplier;
        public Supplier.Supplier Supplier
        {
            get => supplier;
            set => SetPropertyValue(nameof(Supplier), ref supplier, value);
        }

        decimal price;
        public decimal Price
        {
            get => price;
            set => SetPropertyValue(nameof(Price), ref price, value);
        }
        DateTime dateOfPrice;
        public DateTime DateOfPrice
        {
            get => dateOfPrice;
            set => SetPropertyValue(nameof(DateOfPrice), ref dateOfPrice, value);
        }

        Quote quote;
        public Quote Quote
        {
            get => quote;
            set => SetPropertyValue(nameof(Quote), ref quote, value);
        }

        string comments;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Comments
        {
            get => comments;
            set => SetPropertyValue(nameof(Comments), ref comments, value);
        }
    }
}