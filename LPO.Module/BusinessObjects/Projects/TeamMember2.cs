//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module\BusinessObjects\Projects\TeamMember2.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace LPO.Module.BusinessObjects.Projects
{
    [DefaultClassOptions]
    [ImageName("BO_Person")]
    [CreatableItem(false)]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class TeamMember2 : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public TeamMember2(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            fromDate = DateTime.Today;
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        //[Association("Person-TeamMember2s")]
        public Person Person
        {
            get => person;
            set => SetPropertyValue(nameof(Person), ref person, value);
        }
        Person person;

        string company;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Company
        {
            get => company;
            set => SetPropertyValue(nameof(Company), ref company, value);
        }
        string projectRole;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ProjectRole
        {
            get => projectRole;
            set => SetPropertyValue(nameof(ProjectRole), ref projectRole, value);
        }
        DateTime fromDate;
        public DateTime FromDate
        {
            get => fromDate;
            set => SetPropertyValue(nameof(FromDate), ref fromDate, value);
        }
        DateTime thruDate;
        public DateTime ThruDate
        {
            get => thruDate;
            set => SetPropertyValue(nameof(ThruDate), ref thruDate, value);
        }

        //[Association("TeamMember2-PhoneNumbers")]
        //public XPCollection<PhoneNumber> PhoneNumbers
        //{
        //    get
        //    {
        //        return GetCollection<PhoneNumber>(nameof(PhoneNumbers));
        //    }
        //}
        [DisplayName("Phone Numbers")]
        public string AllPhoneNumbers => Person == null ? string.Empty : string.Join("; ", Person.PhoneNumbers.Select(x => $"({x.PhoneType}) {x.Number}"));

        [Association("Project-TeamMembers2")]
        public XPCollection<Project> Projects => GetCollection<Project>(nameof(Projects));
    }
}