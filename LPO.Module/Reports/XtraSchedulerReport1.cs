//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module\Reports\XtraSchedulerReport1.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
using DevExpress.XtraScheduler;
using System;

namespace LPO.Module.Reports
{
    public partial class XtraSchedulerReport1 : DevExpress.XtraScheduler.Reporting.XtraSchedulerReport
    {
        public XtraSchedulerReport1()
        {
            InitializeComponent();
        }

        private void dayViewTimeCells1_InitAppointmentDisplayText(object sender, DevExpress.XtraScheduler.AppointmentDisplayTextEventArgs e)
        {
            //SchedulerListEditor listEditor = ((ListView)View).Editor as SchedulerListEditor;
            Appointment appointment = e.Appointment;
            //ProjectEvent obj = (ProjectEvent)listEditor.SourceObjectHelper.GetSourceObject(appointment);
            //if (obj != null)
            //    e.Text = string.Format("{0}: {1}", obj.Project.ProjectNumber, e.Text);
            e.Text = e.Text;
        }
    }
}
