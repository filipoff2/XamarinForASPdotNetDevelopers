using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobileZoomImages.Models;
using MobileZoomImages.Views;
using MobileZoomImages.ViewModels;
using Plugin.FilePicker.Abstractions;
using Plugin.FilePicker;
using System.Net.Http;

namespace MobileZoomImages.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }


        async void PickFile_Clicked(object sender, EventArgs e)
        {
            //todo
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null)
                    return; // user canceled file picking

                using (HttpClient _httpClient = new HttpClient())
                {
                    var url = "https://localhost:44360/api/FileApi/save";
                    var boundary = System.Guid.NewGuid().ToString();
                    var content = new System.Net.Http.MultipartFormDataContent(boundary);
                    content.Headers.Remove("Content-Type");
                    content.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);
                    content.Add(new System.Net.Http.StreamContent(fileData.GetStream()));
                    await _httpClient.PostAsync(url, content);
                }
            }
            catch (Exception ex) 
            {
                var exception = ex;
            }
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}