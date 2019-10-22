using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ImageEditor.Behaviors
{
	internal class PanContainer : ContentView
	{
		double x, y;

		public PanContainer ()
		{
			// Set PanGestureRecognizer.TouchPoints to control the 
			// number of touch points needed to pan
			var panGesture = new PanGestureRecognizer ();
			panGesture.PanUpdated += OnPanUpdated;
			GestureRecognizers.Add (panGesture);
		}

		void OnPanUpdated (object sender, PanUpdatedEventArgs e)
		{
            var pan = sender as PanContainer;
			switch (e.StatusType) {
               
			case GestureStatus.Running:

                    //var TranslationX = Math.Max(Math.Min(0, x + e.TotalX), -Math.Abs(Content.Width - App.Current.MainPage.Width));
                    //var TranslationY = Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(Content.Height - App.Current.MainPage.Height));

                    Content.TranslationX = e.TotalX;
                    Content.TranslationY = e.TotalY;

                   

                    break;
			
			case GestureStatus.Completed:
                    // Store the translation applied during the pan

                    pan.TranslationX = Content.TranslationX ;
                    pan.TranslationY = Content.TranslationY ;

                    x = Content.TranslationX = 0;
                    y = Content.TranslationY = 0;

                    break;
			}
		}
	}
}
