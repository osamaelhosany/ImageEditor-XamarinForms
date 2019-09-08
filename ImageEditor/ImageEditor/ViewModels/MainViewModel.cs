using ImageEditor.Pages;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ImageEditor.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public string SelectedImage { get; set; }
        public bool IsBusy { get; set; }
        public ICommand ChoosePhotoCommand { get; set; }
        public MainViewModel()
        {
            ChoosePhotoCommand = new Command(ChoosePhotoCommandExecute);
        }

        private async void ChoosePhotoCommandExecute(object obj)
        {
            string selectedOption = await App.Current.MainPage.DisplayActionSheet("Select Option", "Cancel", "",
                new string[] { "Take New Photo", "From Gallery" });
            switch (selectedOption)
            {
                case "Take New Photo":
                    TakePictureFromCamera();
                    break;
                case "From Gallery":
                    TakePictureFromLibrary();
                    break;
                default:
                    break;
            }
        }
        private async void TakePictureFromLibrary()
        {
            IsBusy = true;
            var file = await CrossMedia.Current.PickPhotoAsync
                (new PickMediaOptions()
                {
                    SaveMetaData = true,
                    PhotoSize = PhotoSize.MaxWidthHeight
                });
            if (file != null)
            {
                SelectedImage = file.Path;
                App.Current.MainPage.Navigation.PushModalAsync(new ImageEditorPage(SelectedImage));

            }
            else
            {
            }
            IsBusy = false;
        }
        private async void TakePictureFromCamera()
        {
            IsBusy = true;
            var file = await CrossMedia.Current.TakePhotoAsync
                (new StoreCameraMediaOptions()
                {
                    SaveMetaData = true,
                    PhotoSize = PhotoSize.MaxWidthHeight
                });

            if (file != null)
            {
                SelectedImage = file.Path;
                App.Current.MainPage.Navigation.PushModalAsync(new ImageEditorPage(SelectedImage));
            }
            else
            {

            }
            IsBusy = false;
        }
    }
}
