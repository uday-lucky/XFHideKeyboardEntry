using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using HideKeyBoard.Control;
using HideKeyBoard.Droid;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HideKeyboardEntry), typeof(SoftkeyboardDisabledEntryRenderer))]
namespace HideKeyBoard.Droid
{
    public class SoftkeyboardDisabledEntryRenderer : EntryRenderer
    {
        public SoftkeyboardDisabledEntryRenderer(Context context) :base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);

                if (e.NewElement != null)
                {
                    ((Entry)e.NewElement).PropertyChanging += OnPropertyChanging;
                }

                if (e.OldElement != null)
                {
                    ((Entry)e.OldElement).PropertyChanging -= OnPropertyChanging;
                }

                // Disable the Keyboard on Focus
                this.Control.ShowSoftInputOnFocus = false;
            }

        private void OnPropertyChanging(object sender, PropertyChangingEventArgs propertyChangingEventArgs)
            {
                // Check if the view is about to get Focus
                if (propertyChangingEventArgs.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
                {
                    // incase if the focus was moved from another Entry
                    // Forcefully dismiss the Keyboard 
                    InputMethodManager imm = (InputMethodManager)this.Context.GetSystemService(Context.InputMethodService);
                    imm.HideSoftInputFromWindow(this.Control.WindowToken, 0);
                }
            }
    }    
}