using ImageEditor.Helpers;
using ImageEditor.Pages;
using Plugin.Screenshot;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ImageEditor.ViewModels
{
    public class Current : INotifyPropertyChanged
    {   
        public delegate void CallbackEventHandler(string ImagePath);
        public event CallbackEventHandler Callback;
        public string SelectedImage { get; set; }
        public string CommentColor { get; set; }
        public string StrokeColor { get; set; }
        public double ColorSliderValue { get; set; }
        public double ScratchSliderValue { get; set; }
        public ICommand SaveImageCommand { get; set; }
        public ICommand ClosePageCommand { get; set; }
        public Current(string _SelectedImage)
        {
            SelectedImage = _SelectedImage;
            CommentColor = StrokeColor = "Black";
            SaveImageCommand = new Command(SaveImageCommandExecute);
            ClosePageCommand = new Command(ClosePageCommandExecute);
        }

        private async void ClosePageCommandExecute(object obj)
        {
           var selectedOption = await App.Current.MainPage.DisplayAlert("Discard Photo",
                "if you discard now,you'll lose your photos and edits.","Discard","Keep");
            if (selectedOption) await App.Current.MainPage.Navigation.PopModalAsync();
        }

        private void OnScratchSliderValueChanged()
        {
            var colorvalue = Convert.ToInt32(ScratchSliderValue);
            var selectedcolor = SliderColorsList.SliderColors.FirstOrDefault(x => x.ID == colorvalue);
            StrokeColor = selectedcolor.ColorOnHEX;
        }
        private void OnColorSliderValueChanged()
        {
            var colorvalue = Convert.ToInt32(ColorSliderValue);
            var selectedcolor = SliderColorsList.SliderColors.FirstOrDefault(x => x.ID == colorvalue);
            CommentColor = selectedcolor.ColorOnHEX;
        }
        private async void SaveImageCommandExecute(object obj)
        {
            var editorPage = obj as ImageEditorPage;

            var signaturepad = editorPage.Content.FindByName("signaturepad") as SignaturePadView;
            signaturepad.ClearLabel.IsVisible = false;

            var gritoolbar = editorPage.Content.FindByName("gridtoolbar") as Grid;
            gritoolbar.IsVisible = false;

            var savebutton = editorPage.Content.FindByName("savebutton") as Button;
            savebutton.IsVisible = false;

            var imgcolors = editorPage.Content.FindByName("imgcolors") as Image;
            imgcolors.IsVisible = false;

            var commentslider = editorPage.Content.FindByName("commentcolorslider") as Slider;
            commentslider.IsVisible = false;

            var scratchslider = editorPage.Content.FindByName("scratchcolorslider") as Slider;
            scratchslider.IsVisible = false;
       
            string path = await CrossScreenshot.Current.CaptureAndSaveAsync();
           
            await App.Current.MainPage.Navigation.PopModalAsync();

            Callback?.Invoke(path);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ImagePath">Send ImagePath that need to Edit</param>
        /// <param name="callbackEventHandler">return imagepath after click save button</param>
        /// <returns>return ImagePath on callback(imagepath)</returns>
        public static async Task EditImage(string ImagePath, CallbackEventHandler callbackEventHandler)
        {
            var imgviewmodel = new Current(ImagePath);
            imgviewmodel.Callback += callbackEventHandler;
            var imgpage = new ImageEditorPage(ImagePath);
            imgpage.BindingContext = imgviewmodel;
            await App.Current.MainPage.Navigation.PushModalAsync(imgpage, true);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
