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

namespace LPO.Module.BusinessObjects.Instrument_Spec
{
    [DefaultClassOptions]
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