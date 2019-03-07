//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module.Win\Controllers\WinSchedulerViewController.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Scheduler.Win;
using DevExpress.Persistent.Base.General;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;
using System;
using System.Drawing;
using System.Linq;

namespace LPO.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.

    //-----------------------------------------------------------------------
    // 3/7/2019 - DLandry:  This particular solution was taken from the following DevExpress Support Question: https://www.devexpress.com/Support/Center/Question/Details/Q478349/how-do-i-customize-the-default-labels-and-their-colors-in-the-scheduler-control-listview
    //-----------------------------------------------------------------------
    public partial class WinSchedulerViewController : ObjectViewController<ObjectView, IEvent>
    {
        public WinSchedulerViewController()
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
            if (View is ListView)
            {
                SchedulerListEditor listEditor = ((ListView)View).Editor as SchedulerListEditor;
                if (listEditor != null)
                {
                    SchedulerControl scheduler = listEditor.SchedulerControl;
                    if (scheduler != null)
                    {
                        SetupLabels(scheduler.Storage);
                    }
                }
            }
            else
                if (View is DetailView)
            {
                foreach (SchedulerLabelPropertyEditor pe in ((DetailView)View).GetItems<SchedulerLabelPropertyEditor>())
                {
                    if (pe.Control != null)
                    {
                        SetupLabels(((AppointmentLabelEdit)pe.Control).Storage);
                    }
                    else
                    {
                        pe.ControlCreated += new EventHandler<EventArgs>(pe_ControlCreated);
                    }
                }
            }
        }

        void pe_ControlCreated(object sender, EventArgs e)
        {
            SetupLabels(((AppointmentLabelEdit)((SchedulerLabelPropertyEditor)sender).Control).Storage);
        }

        private static void SetupLabels(ISchedulerStorage storage)
        {

            storage.Appointments.Labels.Clear();
            //int testNum = 12;
            //for (int i = 0; i < testNum; i++)
            //{
            //    AppointmentLabel label = (AppointmentLabel)storage.Appointments.Labels.CreateNewLabel(
            //        string.Format("Alarm Level {0:d2}", i));
            //    label.Color = Color.FromArgb(127 * i / (testNum - 1) + 128, 0, 0);
            //    storage.Appointments.Labels.Add(label);
            //}
            AppointmentLabel labelCivil = (AppointmentLabel)storage.Appointments.Labels.CreateNewLabel("Civil/Structural");
            labelCivil.Color = Color.Coral;
            storage.Appointments.Labels.Add(labelCivil);

            AppointmentLabel labelPiping = (AppointmentLabel)storage.Appointments.Labels.CreateNewLabel("Piping");
            labelPiping.Color = Color.SlateGray;
            storage.Appointments.Labels.Add(labelPiping);

            AppointmentLabel labelMechanical = (AppointmentLabel)storage.Appointments.Labels.CreateNewLabel("Mechanical");
            labelMechanical.Color = Color.FromArgb(148, 82, 247);
            storage.Appointments.Labels.Add(labelMechanical);

            AppointmentLabel labelElectricalInstrument = (AppointmentLabel)storage.Appointments.Labels.CreateNewLabel("Electrical/Instrumentation");
            labelElectricalInstrument.Color = Color.SteelBlue;
            storage.Appointments.Labels.Add(labelElectricalInstrument);

            AppointmentLabel labelGeneral = (AppointmentLabel)storage.Appointments.Labels.CreateNewLabel("General");
            labelGeneral.Color = Color.YellowGreen;
            storage.Appointments.Labels.Add(labelGeneral);

        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
