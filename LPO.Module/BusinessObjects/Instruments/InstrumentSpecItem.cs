//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module\BusinessObjects\Instruments\InstrumentSpecItem.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
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
    [Persistent("inst_instrument-spec-item"), CreatableItem(false)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    //[RuleCombinationOfPropertiesIsUnique(DefaultContexts.Save, "Instrument, SpecItem")]
    public class InstrumentSpecItem : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public InstrumentSpecItem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        Instrument instrument;
        [Association("Instrument-InstrumentSpecItems")]
        public Instrument Instrument
        {
            get => instrument;
            set => SetPropertyValue(nameof(Instrument), ref instrument, value);
        }

        SpecItem specItem;
        public SpecItem SpecItem
        {
            get => specItem;
            set => SetPropertyValue(nameof(SpecItem), ref specItem, value);
        }

        string data;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Data
        {
            get => data;
            set => SetPropertyValue(nameof(Data), ref data, value);
        }

        bool isActive;
        public bool IsActive
        {
            get => isActive;
            set => SetPropertyValue(nameof(IsActive), ref isActive, value);
        }
        InstrumentType refInstrumentType;
        public InstrumentType RefInstrumentType
        {
            get => refInstrumentType;
            set => SetPropertyValue(nameof(RefInstrumentType), ref refInstrumentType, value);
        }


    }
}