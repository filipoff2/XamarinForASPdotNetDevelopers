using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MediaSample
{
	/// <summary>
	/// sample taken from: https://github.com/jamesmontemagno/MediaPlugin
	/// why not used as plugin becouse it didn't work with newest forms sample
	/// </summary>
	public partial class MediaPage : ContentPage
	{
		Stream stream;
		public MediaPage()
		{
			InitializeComponent();


			takePhoto.Clicked += async (sender, args) =>
			{

				if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
				{
					DisplayAlert("No Camera", ":( No camera available.", "OK");
					return;
				}

				var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
				{
					Directory = "Test",
					SaveToAlbum = true,
					CompressionQuality = 75,
					CustomPhotoSize = 50,
					PhotoSize = PhotoSize.MaxWidthHeight,
					MaxWidthHeight = 2000,
					DefaultCamera = CameraDevice.Front
				});

				if (file == null)
					return;

				DisplayAlert("File Location", file.Path, "OK");

				image.Source = ImageSource.FromStream(() =>
		  {
				  stream = file.GetStream();

				  file.Dispose();
				  return stream;
			  });
			};

			pickPhoto.Clicked += async (sender, args) =>
			{
				if (!CrossMedia.Current.IsPickPhotoSupported)
				{
					DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
					return;
				}
				var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
				{
					PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

				});


				if (file == null)
					return;

				image.Source = ImageSource.FromStream(() =>
		  {
				  stream = file.GetStream();
				  file.Dispose();
				  return stream;
			  });
			};

			takeVideo.Clicked += async (sender, args) =>
			{
				if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
				{
					DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
					return;
				}

				var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
				{
					Name = "video.mp4",
					Directory = "DefaultVideos",
				});

				if (file == null)
					return;

				DisplayAlert("Video Recorded", "Location: " + file.Path, "OK");

				file.Dispose();
			};

			pickVideo.Clicked += async (sender, args) =>
			{
				if (!CrossMedia.Current.IsPickVideoSupported)
				{
					DisplayAlert("Videos Not Supported", ":( Permission not granted to videos.", "OK");
					return;
				}
				var file = await CrossMedia.Current.PickVideoAsync();

				if (file == null)
					return;

				DisplayAlert("Video Selected", "Location: " + file.Path, "OK");
				file.Dispose();
			};

			sendfile.Clicked += async (sender, args) =>
			{
				//todo put other your IIS s
				try
				{
					if (stream == null)
						return; // user canceled file picking

					using (HttpClient _httpClient = new HttpClient())
					{
						var url = "https://localhost:44360/api/FileApi/save";
						var boundary = System.Guid.NewGuid().ToString();
						var content = new System.Net.Http.MultipartFormDataContent(boundary);
						content.Headers.Remove("Content-Type");
						content.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);
						content.Add(new System.Net.Http.StreamContent(stream));
						await _httpClient.PostAsync(url, content);
					}
				}
				catch (Exception ex)
				{
					var exception = ex;
					DisplayAlert("Video Selected", "Location: " + ex.Message, "OK");
				}
			};
		}
	}
}