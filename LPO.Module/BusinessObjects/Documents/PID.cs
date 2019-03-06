//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module\BusinessObjects\Documents\PID.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using FileSystemData.BusinessObjects;
using LPO.Module.BusinessObjects.Instruments;
using LPO.Module.BusinessObjects.Motors;
using LPO.Module.BusinessObjects.Projects;
using System;
using System.ComponentModel;
using System.Linq;

namespace LPO.Module.BusinessObjects.Documents
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("DisplayName"), CreatableItem(false)]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [FileAttachment("File")]
    [Persistent("docs_pid")]
    public class PID : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public PID(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [DevExpress.Xpo.Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never), ImmediatePostData]
        [Persistent(@"file")]
        public FileSystemStoreObject File
        {
            get => GetPropertyValue<FileSystemStoreObject>("File");
            set => SetPropertyValue<FileSystemStoreObject>("File", value);
        }

        string description;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Persistent(@"description")]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        Project project;
        [Association("Project-PIDs")]
        public Project Project
        {
            get => project;
            set => SetPropertyValue(nameof(Project), ref project, value);
        }

        string drawingNumber;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Persistent(@"drawing_number")]
        public string DrawingNumber
        {
            get => drawingNumber;
            set => SetPropertyValue(nameof(DrawingNumber), ref drawingNumber, value);
        }
        string rev;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [Persistent(@"rev")]
        public string Rev
        {
            get => rev;
            set => SetPropertyValue(nameof(Rev), ref rev, value);
        }

        bool originalFromClient;
        [Persistent(@"is_original_from_client")]
        public bool OriginalFromClient
        {
            get => originalFromClient;
            set => SetPropertyValue(nameof(OriginalFromClient), ref originalFromClient, value);
        }

        [Association("PID-Instruments")]
        public XPCollection<Instrument> Instruments => GetCollection<Instrument>(nameof(Instruments));

        public string DisplayName => !string.IsNullOrEmpty(Rev) ? string.Format("{0}_R{1}", DrawingNumber, Rev) : DrawingNumber;

        [Association("PID-Motors")]
        public XPCollection<Motor> Motors => GetCollection<Motor>(nameof(Motors));

        ProjectParty responsibleParty;
        [DataSourceProperty("Project.Parties")]
        public ProjectParty ResponsibleParty
        {
            get => responsibleParty;
            set => SetPropertyValue(nameof(ResponsibleParty), ref responsibleParty, value);
        }
    }
}