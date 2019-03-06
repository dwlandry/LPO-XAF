//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module\BusinessObjects\Instrument Spec\SpecItem.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using LPO.Module.BusinessObjects.Instruments;
using System;
using System.Linq;

namespace LPO.Module.BusinessObjects.Instrument_Spec
{
    [DefaultClassOptions]
    [CreatableItem(false)]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    [Persistent("spec_spec-item")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SpecItem : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SpecItem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        string category;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Category
        {
            get => category;
            set => SetPropertyValue(nameof(Category), ref category, value);
        }
        string description;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        AssetType assetType;
        public AssetType AssetType
        {
            get => assetType;
            set => SetPropertyValue(nameof(AssetType), ref assetType, value);
        }

        [Association("SpecItem-PickList")]
        public XPCollection<SpecItemPickListItem> PickList => GetCollection<SpecItemPickListItem>(nameof(PickList));

        [Association("InstrumentType-SpecItems")]
        public XPCollection<InstrumentType> InstrumentTypes => GetCollection<InstrumentType>(nameof(InstrumentTypes));

        public string PickListItems
        {
            get
            {
                string result = null;
                foreach (var item in PickList)
                {
                    result = result + item.Data + "; ";
                }
                if (string.IsNullOrEmpty(result))
                {
                    return result;
                }
                result = result.Remove(result.Length - 2);
                return result;
            }
        }
    }
}