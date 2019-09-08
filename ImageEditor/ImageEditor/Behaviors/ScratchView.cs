using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ImageEditor.Behaviors
{
    public class ScratchView :  Behavior<SignaturePadView>
    {
        protected override void OnAttachedTo(SignaturePadView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.SignatureLine.IsVisible = false;
            bindable.CaptionLabel.IsVisible = false;
            bindable.SignaturePrompt.IsVisible = false;
            bindable.ClearLabel.IsEnabled = false;
            bindable.ClearLabel.VerticalOptions = LayoutOptions.Center;
        }
        protected override void OnDetachingFrom(SignaturePadView bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}
