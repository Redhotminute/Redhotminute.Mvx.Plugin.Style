using System;
using MvvmCross.Converters;
using System.Globalization;
using MvvmCross.Localization;
using MvvmCross.Binding;
using MvvmCross.Exceptions;
using Mvx.Plugin.Style.iOS.Plugin;
using Mvx.Plugin.Style.Plugin;
using MvvmCross.IoC;

namespace Mvx.Plugin.Style.iOS.Converters
{
	public class FontLangValueConverter : MvxValueConverter {
		/// <summary>
		/// Convert the specified value, targetType, parameter and culture.
		/// </summary>
		/// <param name="value">AssetPlugin</param>
		/// <param name="targetType">Target type.</param>
		/// <param name="parameter">Font name</param>
		/// <param name="culture">Culture.</param>
		public override object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ConvertValue(value, parameter);
		}

		private object ConvertValue(object value,object parameter) {
			IMvxLanguageBinder textProvider = value as IMvxLanguageBinder;
			TouchAssetPlugin assetPlugin = MvxIoCProvider.Instance.Resolve<IAssetPlugin>() as TouchAssetPlugin;

			if (value!= null && parameter!= null){
				try{
					//split the text and font definition
					var values = parameter.ToString().Split(';');

					return assetPlugin.ParseToAttributedText(textProvider.GetText(values[0]), assetPlugin.GetFontByName(values[1]));
				}catch(Exception e){
                    MvxBindingLog.Error("Problem parsing binding {0}", e.ToLongString());
				}
			}

			return null;
		}


	}
}

