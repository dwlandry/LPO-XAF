﻿//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module.Win\Controllers\SchedulerViewController.Designer.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
namespace LPO.Module.Win.Controllers
{
    partial class SchedulerViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.simpleActionShowSchedulerTrifoldStandardReport = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.simpleActionShowSchedulerDailyReport = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // simpleActionShowSchedulerTrifoldStandardReport
            // 
            this.simpleActionShowSchedulerTrifoldStandardReport.Caption = "Scheduler Trifold Report";
            this.simpleActionShowSchedulerTrifoldStandardReport.Category = "Print";
            this.simpleActionShowSchedulerTrifoldStandardReport.ConfirmationMessage = null;
            this.simpleActionShowSchedulerTrifoldStandardReport.Id = "d697ff87-4e25-45e3-a333-ef3b57b2a479";
            this.simpleActionShowSchedulerTrifoldStandardReport.ImageName = "Preview";
            this.simpleActionShowSchedulerTrifoldStandardReport.ToolTip = null;
            this.simpleActionShowSchedulerTrifoldStandardReport.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.simpleActionShowSchedulerTrifoldStandardReport_Execute);
            // 
            // simpleActionShowSchedulerDailyReport
            // 
            this.simpleActionShowSchedulerDailyReport.Caption = "Daily Schedule Report";
            this.simpleActionShowSchedulerDailyReport.Category = "Print";
            this.simpleActionShowSchedulerDailyReport.ConfirmationMessage = null;
            this.simpleActionShowSchedulerDailyReport.Id = "2d6ecb5e-9c3b-4cf4-880e-4775d2667bae";
            this.simpleActionShowSchedulerDailyReport.ToolTip = null;
            this.simpleActionShowSchedulerDailyReport.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.simpleActionShowSchedulerDailyReport_Execute);
            // 
            // SchedulerViewController
            // 
            this.Actions.Add(this.simpleActionShowSchedulerTrifoldStandardReport);
            this.Actions.Add(this.simpleActionShowSchedulerDailyReport);
            this.TargetObjectType = typeof(LPO.Module.BusinessObjects.Project_Schedule.ProjectEvent);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction simpleActionShowSchedulerTrifoldStandardReport;
        private DevExpress.ExpressApp.Actions.SimpleAction simpleActionShowSchedulerDailyReport;
    }
}
