//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module\BusinessObjects\GoBy Documents\GoByDocument.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
//using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using FileSystemData.BusinessObjects;

namespace LPO.Module.BusinessObjects.GoBy_Documents
{
    [DefaultClassOptions]
    [FileAttachment("File"), CreatableItem(false)]
    public class GoByDocument : BaseObject
    {
        public GoByDocument(Session session) : base(session) { }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never), ImmediatePostData]
        public FileSystemStoreObject File
        {
            get => GetPropertyValue<FileSystemStoreObject>("File");
            set => SetPropertyValue<FileSystemStoreObject>("File", value);
        }


        string description;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }
    }
}