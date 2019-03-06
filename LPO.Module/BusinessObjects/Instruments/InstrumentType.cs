//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module\BusinessObjects\Instruments\InstrumentType.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using LPO.Module.BusinessObjects.Instrument_Spec;
using System;
using System.Linq;

namespace LPO.Module.BusinessObjects.Instruments
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [Persistent("inst_instrument-type"), CreatableItem(false)]
    public class InstrumentType : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public InstrumentType(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string name;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [XafDisplayName("Type")]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        //[Association("InstrumentTypeSpecItem-InstrumentType")]
        //public XPCollection<InstrumentTypeSpecItem> InstrumentTypeSpecItems => GetCollection<InstrumentTypeSpecItem>(nameof(InstrumentTypeSpecItems));

        [Association("InstrumentType-SpecItems")]
        public XPCollection<SpecItem> SpecItems => GetCollection<SpecItem>(nameof(SpecItems));
    }
}