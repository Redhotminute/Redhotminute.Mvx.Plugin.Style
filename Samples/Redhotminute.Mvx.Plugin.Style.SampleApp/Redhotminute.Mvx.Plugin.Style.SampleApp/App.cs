using MvvmCross.Platform.IoC;
using MvvmCross.Platform.UI;

namespace Redhotminute.Mvx.Plugin.Style.SampleApp
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.FirstViewModel>();
        }

		public override void LoadPlugins(MvvmCross.Platform.Plugins.IMvxPluginManager pluginManager) {
			base.LoadPlugins(pluginManager);
			var plugin = MvvmCross.Platform.Mvx.Resolve<IAssetPlugin>();

			plugin.AddColor(new MvxColor(0, 200, 190), "Background")
			      .AddColor(new MvxColor(101, 18, 111), "Primary")
				  .AddColor(new MvxColor(230, 229, 6), "Secondairy");

			plugin.AddFont(new Font() {Name="H1",FontFilename = "JosefinSlab-Bold.ttf", FontPlatformName = "JosefinSlab-Bold", Size = 40, Color = plugin.GetColor("Secondairy") })
			      .AddFont(new Font() {Name="ItalicFont",FontFilename = "Nunito-Italic.ttf", FontPlatformName = "Nunito-Italic", Size = 15, Color = plugin.GetColor("Secondairy"), Alignment = TextAlignment.Center },"i")
			      .AddFont(new BaseFont() { Name = "BoldFont", FontFilename = "Nunito-Bold.ttf", FontPlatformName = "Nunito-Bold", Size = 15, Color = plugin.GetColor("Secondairy") }, "b")
				  .AddFont(new Font() {Name="RegularFont",FontFilename = "Nunito-Regular.ttf", FontPlatformName = "Nunito-Regular", Size = 13, LineHeight = 28, Color = plugin.GetColor("Primary"), BoldFont = plugin.GetFontByName("BoldFont") });
			//add your fonts here. of course wouldn't actually add them here, but after the plugins are loaded you could.
		}
    }
}
