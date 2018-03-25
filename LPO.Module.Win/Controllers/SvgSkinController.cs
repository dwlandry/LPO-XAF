using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Model;

namespace LPO.Module.Win.Controllers
{
    public class SvgSkinController : WindowController, IModelExtender
    {
        private SimpleAction showPaletteAction;
        private ChooseSkinController chooseSkinController;
        public SvgSkinController()
        {
            TargetWindowType = WindowType.Main;
            this.showPaletteAction = new SimpleAction(this, "ShowPalette", "Panels");
            this.showPaletteAction.Execute += ShowPaletteAction_Execute;
            this.showPaletteAction.ImageName = "Action_ChooseSkin";
        }
        protected override void OnFrameAssigned()
        {
            base.OnFrameAssigned();
            chooseSkinController = Frame.GetController<ChooseSkinController>();
            if (chooseSkinController != null)
            {
                chooseSkinController.ChooseSkinAction.ExecuteCompleted += ChooseSkinAction_ExecuteCompleted;
            }
        }
        private void ChooseSkinAction_ExecuteCompleted(object sender, ActionBaseEventArgs e)
        {
            RestorePalette(Application);
            UpdateActionActivity(showPaletteAction);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && chooseSkinController != null)
            {
                chooseSkinController.ChooseSkinAction.ExecuteCompleted -= ChooseSkinAction_ExecuteCompleted;
            }
        }
        public static void RestorePalette(XafApplication application)
        {
            var model = (IModelApplicationOptionsSkinSvg)application.Model.Options;
            if (model.Palette == null) return;
            var skin = CommonSkins.GetSkin(UserLookAndFeel.Default);
            DevExpress.Utils.Svg.SvgPalette palette = skin.CustomSvgPalettes[model.Palette];
            if (palette != null)
            {
                skin.SvgPalettes[Skin.DefaultSkinPaletteName].SetCustomPalette(palette);
                LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            }
        }
        public static void SavePalette(XafApplication application)
        {
            var model = (IModelApplicationOptionsSkinSvg)application.Model.Options;
            model.Palette = UserLookAndFeel.Default.ActiveSvgPaletteName;
        }
        private void ShowPaletteAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var form = ((WinWindow)Window).Form;
            using (var dialog = new DevExpress.Customization.SvgSkinPaletteSelector(form))
            {
                dialog.ShowDialog();
                SavePalette(Application);
            }
        }
        protected override void UpdateActionActivity(ActionBase action)
        {
            base.UpdateActionActivity(action);
            var isSvgSkin = UserLookAndFeel.Default.ActiveStyle == ActiveLookAndFeelStyle.Skin
                && UserLookAndFeel.Default.ActiveSkinName == SkinStyle.Bezier;
            action.Active["Svg"] = isSvgSkin;
        }
        public void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
        {
            extenders.Add<IModelApplicationOptionsSkin, IModelApplicationOptionsSkinSvg>();
        }
    }

    public interface IModelApplicationOptionsSkinSvg
    {
        [Category("Appearance")]
        string Palette { get; set; }
    }
}
