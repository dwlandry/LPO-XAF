//using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using FileSystemData.BusinessObjects;

namespace LPO.Module.BusinessObjects.GoBy_Documents
{
    [DefaultClassOptions]
    [FileAttachment("File")]
    public class GoByDocument : BaseObject
    {
        public GoByDocument(Session session) : base(session) { }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never), ImmediatePostData]
        public FileSystemStoreObject File
        {
            get => GetPropertyValue<FileSystemStoreObject>("File");
            set => SetPropertyValue<FileSystemStoreObject>("File", value);
        }


        //string description;
        //[Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //public string Description
        //{
        //    get => description;
        //    set => SetPropertyValue(nameof(Description), ref description, value);
        //}
    }
}