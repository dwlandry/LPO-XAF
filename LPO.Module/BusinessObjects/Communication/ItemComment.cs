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

namespace lpmt_xaf.Module.BusinessObjects.Communication
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [Persistent(@"comm_communication-item_comments")]
    public class ItemComment : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public ItemComment(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            DateAdded = DateTime.Today;
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string addedBy;
        [Size(255)]
        [Persistent(@"added_by")]
        public string AddedBy
        {
            get => addedBy;
            set => SetPropertyValue(nameof(AddedBy), ref addedBy, value);
        }

        string comment;
        [Size(SizeAttribute.Unlimited)]
        [Persistent(@"comment")]
        public string Comment
        {
            get => comment;
            set => SetPropertyValue(nameof(Comment), ref comment, value);
        }

        DateTime dateAdded;
        [Persistent(@"date_added")]
        public DateTime DateAdded
        {
            get => dateAdded;
            set => SetPropertyValue(nameof(DateAdded), ref dateAdded, value);
        }

        CommunicationItem communicationItem;
        [Association("CommunicationItem-ItemCommentsCollection")]
        [Persistent(@"communication_item_id")]
        public CommunicationItem CommunicationItem
        {
            get => communicationItem;
            set => SetPropertyValue(nameof(CommunicationItem), ref communicationItem, value);
        }
    }
}