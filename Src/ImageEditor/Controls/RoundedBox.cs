using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ImageEditor.Controls
{
   internal class RoundedBox : BoxView
    {
        private double _size;

        public double Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged();
                AdjustSize();
            }
        }

        private void AdjustSize()
        {
            this.HeightRequest = Size;
            this.WidthRequest = Size;
            this.CornerRadius = Size / 2;
        }

        public RoundedBox()
        {
            HorizontalOptions = LayoutOptions.Center;
        }
    }
}
