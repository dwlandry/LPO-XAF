using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace LPO.Module.Win.Editors
{
    [PropertyEditor(typeof(string), "FolderBrowseEditor", false)]
    public class FolderBrowseEditor : DXPropertyEditor
    {
        public FolderBrowseEditor(Type objectType, IModelMemberViewItem model)
            : base(objectType, model) { }
        private void buttonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select folder...";
                if (dialog.ShowDialog() != DialogResult.Cancel)
                {
                    ((ButtonEdit)sender).Text = dialog.SelectedPath;
                }
            }
        }

        protected override object CreateControlCore() => new ButtonEdit();
        protected override RepositoryItem CreateRepositoryItem() => new RepositoryItemButtonEdit();

        protected override void SetupRepositoryItem(RepositoryItem item)
        {
            base.SetupRepositoryItem(item);
            ((RepositoryItemButtonEdit)item).ButtonClick += buttonEdit_ButtonClick;
            

        }
        protected override void SetRepositoryItemReadOnly(RepositoryItem item, bool readOnly)
        {
            base.SetRepositoryItemReadOnly(item, readOnly);
            ((RepositoryItemButtonEdit)item).Buttons[0].Enabled = !readOnly;
        }
    }
}