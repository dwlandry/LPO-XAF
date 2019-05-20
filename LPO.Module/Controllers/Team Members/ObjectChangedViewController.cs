//-----------------------------------------------------------------------
// <copyright file="F:\my files\Programming\landrys-lpo\LPO-XAF\LPO.Module\Controllers\Team Members\ObjectChangedViewController.cs" company="David W. Landry III">
//     Author: _**David Landry**_
//     *Copyright (c) David W. Landry III. All rights reserved.*
// </copyright>
//-----------------------------------------------------------------------
using DevExpress.ExpressApp;
using LPO.Module.BusinessObjects.Projects;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LPO.Module.Controllers.Team_Members
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ObjectChangedViewController : ViewController
    {
        public ObjectChangedViewController()
        {
            InitializeComponent();
            TargetObjectType = typeof(TeamMember2);
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
            //TargetObjectType = typeof(TeamMember2);
            View.ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
            // Access and customize the target View control.
        }

        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if (e.PropertyName == "Person")
            {
                // Get the Company and Role from the most recent jobs this person has been assigned to
                //XPCollection<TeamMember2> teamMembers = new XPCollection<TeamMember2>( TeamMember2.Fields.Person == e.NewValue);
                //MessageBox.Show("Person");
            }
            //throw new NotImplementedException();
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
