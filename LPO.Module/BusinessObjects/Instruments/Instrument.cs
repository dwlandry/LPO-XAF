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
using LPO.Module.BusinessObjects.Instrument_Spec;
using DevExpress.CodeParser;
using LPO.Module.BusinessObjects.Components;

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
        protected override void OnSaving()
        {
            if (instrumentTypeChanged)
                AddInstrumentSpecItems();
            base.OnSaving();
        }

        protected override void OnSaved()
        {
            //if (instrumentTypeChanged)
            //    RemoveInactiveSpecItems();
            base.OnSaved();
        }

        void RemoveInactiveSpecItems()
        {
            //// If there are existing InstrumentSpecItems, set their IsActive to false.
            //for (int i = 0; i < InstrumentSpecItems.Count; i--)
            //{
            //    InstrumentSpecItem instrumentSpecItem = InstrumentSpecItems[i];
            //    if (!instrumentSpecItem.IsActive)
            //        instrumentSpecItem.Delete();
            //}

            XPQuery<InstrumentSpecItem> instSpecItems = new XPQuery<InstrumentSpecItem>(Session);
            var inactiveSpecItems = from i in instSpecItems where (i.Instrument.Oid == Oid && i.IsActive == false) select i;
            var lst = inactiveSpecItems.ToList();
            foreach (var item in lst)
            {
                item.Delete();
            }
            //do
            //{
            //    lst[0].Delete();
            //} while (lst.Count()>0);
            
        }

        void AddInstrumentSpecItems()
        {
            
            // If there are existing InstrumentSpecItems, set their IsActive to false.
            for (int i = 0; i < InstrumentSpecItems.Count; i++)
            {
                InstrumentSpecItems[i].IsActive = false;
            }

            if (InstrumentType is null) return;

            XPQuery<InstrumentSpecItem> instSpecItems = new XPQuery<InstrumentSpecItem>(Session);
            var instrumentSpecItemsForThisInstrument = from i in instSpecItems where i.Instrument.Oid == Oid select i.SpecItem.Oid;

            foreach (var item in InstrumentType.SpecItems)
            {
                if (instrumentSpecItemsForThisInstrument.Contains(item.Oid))
                {
                    var obj = from i in InstrumentSpecItems
                                where i.SpecItem.Oid == item.Oid
                                select i;

                    obj.ToList()[0].IsActive = true;
                }
                else
                {
                    InstrumentSpecItem instrumentSpecItem = new InstrumentSpecItem(Session)
                    {
                        SpecItem = item,
                        IsActive = true,
                        RefInstrumentType = instrumentType
                    };
                    InstrumentSpecItems.Add(instrumentSpecItem);
                }
            }
        }

        
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

        bool instrumentTypeChanged;
        InstrumentType instrumentType;
        [Persistent(@"instrument_type")]
        public InstrumentType InstrumentType
        {
            get => instrumentType;
            set
            {
                if (instrumentType == value)
                {
                    return;
                }
                
                instrumentTypeChanged = true;
                SetPropertyValue(nameof(InstrumentType), ref instrumentType, value);
                RaisePropertyChangedEvent(nameof(InstrumentType));
            }
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

        [Association("Instrument-InstrumentSpecItems")]
        public XPCollection<InstrumentSpecItem> InstrumentSpecItems => GetCollection<InstrumentSpecItem>(nameof(InstrumentSpecItems));

        [Association("Instrument-InstrumentComponents")]
        public XPCollection<InstrumentComponent> InstrumentComponents => GetCollection<InstrumentComponent>(nameof(InstrumentComponents));

        //Manufacturer manufacturer;
        //public Manufacturer Manufacturer
        //{
        //    get => manufacturer;
        //    set => SetPropertyValue(nameof(Manufacturer), ref manufacturer, value);
        //}

        //Components.Component component;
        //[Association("InstrumentComponent-Instruments")]
        [XafDisplayName("Component")]
        //[EditorAlias("MemoEdit")]
        public string Component
        {
            get
            {
                StringBuilder componentBuilder = new StringBuilder();

                foreach (InstrumentComponent item in InstrumentComponents)
                {
                    if (item.Component != null)
                        componentBuilder.Append(componentBuilder.Length == 0 ? item.Component.DisplayName + ", " : "\n" + item.Component.DisplayName + ", ");

                }

                var result = componentBuilder.ToString();
                return result.Length>2 ? result.Remove(result.Length-2) : "";
            }
            //set => SetPropertyValue(nameof(SingleComponent), ref component, value);
        }
        //decimal price;
        public decimal Price
        {
            get
            {
                decimal price = 0;
                foreach (var component in InstrumentComponents)
                {
                    price += component.Price;
                }
                return price;
            }
            //set => SetPropertyValue(nameof(Price), ref price, value);
        }
        Supplier.Supplier supplier;
        public Supplier.Supplier Supplier
        {
            get => supplier;
            set => SetPropertyValue(nameof(Supplier), ref supplier, value);
        }

        [Association("Instrument-Alarms")]
        public XPCollection<InstrumentAlarm> Alarms => GetCollection<InstrumentAlarm>(nameof(Alarms));

    }
}