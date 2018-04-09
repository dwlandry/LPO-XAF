using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp;

namespace LPO.Module.Win.Controllers
{
    public partial class UserControl1 : UserControl, IComplexControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private IObjectSpace objectSpace;
        public void Setup(IObjectSpace objectSpace, XafApplication application)
        {
            gridControl1.DataSource = objectSpace.GetObjects<LPO.Module.BusinessObjects.Projects.Project>();
            this.objectSpace = objectSpace;
        }

        void IComplexControl.Refresh()
        {
            gridControl1.DataSource = objectSpace.GetObjects<BusinessObjects.Projects.Project>();
        }

    }
}
