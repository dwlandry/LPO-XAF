using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using LPO.Module.BusinessObjects.Instruments;

namespace LPO.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class InstrumentViewController : ViewController
    {
        //ArrayList modifiedInstrumentTypes;
        //public InstrumentViewController()
        //{
        //    InitializeComponent();
        //    // Target required Views (via the TargetXXX properties) and create their Actions.
        //}
        //protected override void OnActivated()
        //{
        //    base.OnActivated();
        //    modifiedInstrumentTypes = new ArrayList();
        //    ObjectSpace.ObjectChanged += new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
        //    ObjectSpace.Committed += new EventHandler(ObjectSpace_Committed);
        //    // Perform various tasks depending on the target View.
        //}
        //protected override void OnViewControlsCreated()
        //{
        //    base.OnViewControlsCreated();
        //    // Access and customize the target View control.
        //}
        //protected override void OnDeactivated()
        //{
        //    // Unsubscribe from previously subscribed events and release other references and resources.
        //    base.OnDeactivated();
        //}
        //void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        //{
        //    if (e.Object is Instrument && e.PropertyName == "InstrumentType" && !modifiedInstrumentTypes.Contains(e.Object))
        //    {
        //        modifiedInstrumentTypes.Add(e.Object);
        //    }
        //}
        //void ObjectSpace_Committed(object sender, EventArgs e)
        //{
        //    //LinkToListViewController controller = Frame.GetController<LinkToListViewController>();

        //    foreach (Instrument instrument in modifiedInstrumentTypes)
        //    {
        //        AddInstrumentSpecItemsFromTypeSpecItems(instrument, instrument.InstrumentType);
        //        
        //    }

        //}
        //void AddInstrumentSpecItemsFromTypeSpecItems(Instrument instrument, InstrumentType instrumentType)
        //{
        //    // For each 
        //    // Create InstrumentSpecItem
        //    InstrumentSpecItem instrumentSpecItem = new InstrumentSpecItem(instrument.Session) {
        //        Instrument = instrument,
        //    };
        //    instrument.Save();
        //}
    }
}
