using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using HideKeyBoard.Control;
using HideKeyBoard.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(HideKeyboardEntry), typeof(SoftkeyboardDisabledEntryRenderer))]
namespace HideKeyBoard.iOS
{
    public class SoftkeyboardDisabledEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            // Disabling the keyboard
            this.Control.InputView = new UIView();
        }
    }
}