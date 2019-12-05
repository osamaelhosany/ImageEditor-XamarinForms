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
            ChoosePhotoCommand = new Command(async(obj)=>await ChoosePhotoCommandExecute(obj));
        }

        private async Task ChoosePhotoCommandExecute(object obj)
        {
            string selectedOption = await App.Current.MainPage.DisplayActionSheet("Select Option", "Cancel", "",
                new string[] { "Take New Photo", "From Gallery" });
            
            switch (selectedOption)
            {
                case "Take New Photo":
                   SelectedImage = await TakePictureFromCamera();
                    break;
                case "From Gallery":
                   SelectedImage = await TakePictureFromLibrary();
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(SelectedImage))
            {
                await Current.EditImage(SelectedImage, testphoto);
            }
        }
        
    

        private async Task<string> TakePictureFromLibrary()
        {
            IsBusy = true;
            var file = await CrossMedia.Current.PickPhotoAsync
                (new PickMediaOptions()
                {
                    SaveMetaData = true,
                    PhotoSize = PhotoSize.MaxWidthHeight
                });
            IsBusy = false;
            if (file == null)
                return null;
            
            return file.Path;
           
        }
        private async Task<string> TakePictureFromCamera()
        {
            IsBusy = true;
            var file = await CrossMedia.Current.TakePhotoAsync
                (new StoreCameraMediaOptions()
                {
                    SaveMetaData = true,
                    PhotoSize = PhotoSize.MaxWidthHeight
                });

            IsBusy = false;
            if (file == null)
                return null;

            return file.Path;
        }
        
        private void testphoto(string selectedimage)
        {
            
        }

    }
}
