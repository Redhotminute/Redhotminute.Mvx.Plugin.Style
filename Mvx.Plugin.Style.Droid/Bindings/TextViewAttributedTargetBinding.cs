using System;
using Android.Text;
using Android.Text.Method;
using Android.Text.Util;
using Android.Widget;
using MvvmCross.Binding;
using Mvx.Plugin.Style.Droid.Helpers;

namespace Mvx.Plugin.Style.Droid.Bindings {
	public class TextViewAttributedTargetBinding
		: TextViewFontTargetBinding {

		public TextViewAttributedTargetBinding(TextView target)
			: base(target) {
		}

		protected override void SetValueImpl(object target, object toSet) {
			var label = (TextView)target;
			SpannableString spannable;

			AttributedStringBaseFontWrapper wrapper = toSet as AttributedStringBaseFontWrapper;
			if (wrapper != null) {
				//set the base font
				base.SetValueImpl(target, wrapper.Font);
                spannable = wrapper.SpannableString;
                if (wrapper.ContainsClickable)
                {
                    label.MovementMethod = new LinkMovementMethod();

                    if(wrapper.ClickableFont!= null){
                        label.SetLinkTextColor(new Android.Graphics.Color(wrapper.ClickableFont.Color.R,wrapper.ClickableFont.Color.G,wrapper.ClickableFont.Color.B));
                    }
                }

                label.TextFormatted = spannable;
			}
			else {
				spannable = toSet as SpannableString;
				if (spannable != null)
				{
					label.TextFormatted = toSet as SpannableString;
				}
				else if (toSet != null)
				{
					label.Text = toSet.ToString();
				}
			}
		}

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		public override Type TargetType => typeof(SpannableString);
	}
}

