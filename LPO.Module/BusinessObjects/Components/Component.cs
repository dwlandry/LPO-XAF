//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module\BusinessObjects\Components\Component.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using LPO.Module.BusinessObjects.Instruments;
using System;
using System.ComponentModel;
using System.Linq;

namespace LPO.Module.BusinessObjects.Components
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("DisplayName"), CreatableItem(false)]
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
        public string DisplayName => componentType is null ? string.Format("[COMPONENT TYPE]: {0}", modelNumber) : string.Format("{0}: {1}", componentType.Name, modelNumber);
    }
}