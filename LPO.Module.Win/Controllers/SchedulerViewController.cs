//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module.Win\Controllers\SchedulerViewController.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Scheduler.Win;
using DevExpress.XtraReports.UI;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Reporting;
using LPO.Module.Reports;
using System;
using System.Linq;

namespace LPO.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SchedulerViewController : ViewController
    {
        public SchedulerViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void simpleActionShowSchedulerTrifoldStandardReport_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View is ListView)
            {
                SchedulerListEditor listEditor = ((ListView)View).Editor as SchedulerListEditor;
                if (listEditor != null)
                {
                    SchedulerControl scheduler = listEditor.SchedulerControl;
                    if (scheduler != null)
                    {
                        // Bind custom scheduler reports to the Scheduler and invoke the Preview dialog
                        // https://documentation.devexpress.com/WindowsForms/5729/Controls-and-Libraries/Scheduler/Examples/Printing-and-Reporting/How-to-Print-a-Scheduler-Using-a-Report-Preview-Step-by-Step-Guide
                        XtraSchedulerReportTrifoldStandard xr = new XtraSchedulerReportTrifoldStandard();
                        SchedulerControlPrintAdapter scPrintAdapter = new SchedulerControlPrintAdapter(scheduler);
                        xr.SchedulerAdapter = scPrintAdapter;
                        xr.CreateDocument(true);
                        using (ReportPrintTool printTool = new ReportPrintTool(xr))
                        {
                            printTool.ShowRibbonPreviewDialog();
                        }
                    }
                }
            }
        }
    }
}
