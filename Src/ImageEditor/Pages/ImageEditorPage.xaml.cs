using ImageEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageEditor.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageEditorPage : ContentPage
	{
        List<IEnumerable<Point>> redostrokeslist;

        public ImageEditorPage (string SelectedImage)
		{
			InitializeComponent ();
            //BindingContext = new ImageEditorViewModel(SelectedImage);
		}

        private void Editorcomment_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrEmpty(editorcomment.Text))
            {
                labelcomment.Text = editorcomment.Text;
                pancontainer.IsVisible = true;
                resetlabel.IsVisible = true;
            }
            else
            {
                labelcomment.Text = "";
                pancontainer.IsVisible = false;
            }
            scratchcolorslider.IsVisible = false;
            signaturepad.IsEnabled = false;
            editorcomment.IsVisible = false;
            commentcolorslider.IsVisible = false;
            imgcolors.IsVisible = false;
        }
        private void ShowCommentEditor_Tapped(object sender, EventArgs e)
        {
            pancontainer.IsVisible = false;
            pancontainer.IsEnabled = true;
            scratchcolorslider.IsVisible = false;
            signaturepad.IsEnabled = false;
            signaturepad.ClearLabel.IsVisible = false;
            editorcomment.IsVisible = true;
            commentcolorslider.IsVisible = true;
            imgcolors.IsVisible = true;
            editorcomment.Focus();
        }

        private void PanContainer_Tapped(object sender, EventArgs e)
        {
            pancontainer.IsVisible = false;
            scratchcolorslider.IsVisible = false;
            signaturepad.IsEnabled = false;
            signaturepad.ClearLabel.IsVisible = false;
            editorcomment.IsVisible = true;
            commentcolorslider.IsVisible = true;
            imgcolors.IsVisible = true;
            editorcomment.Focus();
        }
        private void ShowScratchView_Tapped(object sender,EventArgs e)
        {
            imgcolors.IsVisible = !imgcolors.IsVisible;
            scratchcolorslider.IsVisible = !scratchcolorslider.IsVisible;
            signaturepad.IsVisible = true;
            signaturepad.IsEnabled = !signaturepad.IsEnabled;
            signaturepad.ClearLabel.IsVisible = signaturepad.Strokes.Any() ? true : false;
            resetlabel.IsVisible = signaturepad.Strokes.Any() ? true : false;
            pancontainer.IsEnabled = false;
            redostrokeslist = new List<IEnumerable<Point>>(signaturepad.Strokes);
        }

        private void RotateImage_Tapped(object sender, EventArgs e)
        {
            if(imagebackground.Rotation == 270)
            { 
                imagebackground.Rotation = 0;
                return; 
            }

               imagebackground.Rotation += 90;
               resetlabel.IsVisible = true;
        }

        private void UndoStroke_Tapped(object sender, EventArgs e)
        {
            var strokes = signaturepad.Strokes.ToList();
            redostrokeslist.Add(strokes.LastOrDefault());
            strokes.RemoveAt(strokes.Count() - 1);
            signaturepad.Strokes = strokes;
            redoimg.IsVisible = true;
        }

        private void ResetAllActions_Tapped(object sender, EventArgs e)
        {
            editorcomment.Text = "";
            labelcomment.Text = "";
            pancontainer.IsVisible = false;
            editorcomment.IsVisible = false;
            pancontainer.TranslationX = editorcomment.TranslationX;
            pancontainer.TranslationY = editorcomment.TranslationY;
            
            var strokes = signaturepad.Strokes.ToList();
            strokes.Clear();
            redoimg.IsVisible = false;
            redostrokeslist = new List<IEnumerable<Point>>();
            signaturepad.Strokes = strokes;

            imagebackground.Rotation = 0;

            resetlabel.IsVisible = false;
        }

        private void RedoStroke_Tapped(object sender, EventArgs e)
        {
            if (redostrokeslist.Any())
            {
                var strokes = signaturepad.Strokes.ToList();
                strokes.Add(redostrokeslist.LastOrDefault());
                redostrokeslist.Remove(redostrokeslist.LastOrDefault());
                signaturepad.Strokes = strokes;
            }
        }

        private void ClearScratch_Tapped(object sender, EventArgs e)
        {
            var strokes = signaturepad.Strokes.ToList();
            strokes.Clear();
            var points = signaturepad.Points.ToList();
            points.Clear();
            signaturepad.Points = points;
            signaturepad.Strokes = strokes;
            redoimg.IsVisible = false;
        }
    }
}