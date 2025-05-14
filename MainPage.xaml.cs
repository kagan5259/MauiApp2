using MauiApp2.Models;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
			var grid = new Grid
			{
				ColumnDefinitions = new ColumnDefinitionCollection
			{
				new ColumnDefinition(), new ColumnDefinition(), new ColumnDefinition()
			},
				RowSpacing = 0 // araları boşluk bırakmasın
			};

			string[] headers = { "Ad", "Soyad", "Yaş" };

			for (int i = 0; i < headers.Length; i++)
			{
				var label = new Label
				{
					Text = headers[i],
					TextColor = Colors.White,
					FontAttributes = FontAttributes.Bold,
					HorizontalTextAlignment = TextAlignment.Center,
					VerticalTextAlignment = TextAlignment.Center
				};

				var frame = new Frame
				{
					Content = label,
					Padding = 5,
					BorderColor = Colors.Black,
					BackgroundColor = Colors.Red,
					HasShadow = false,
					Margin = 0,
					CornerRadius = 0
				};

				grid.Add(frame, i, 0);
			}

			var kisiler = new List<Person>
		{
			new Person { Ad = "Ahmet", Soyad = "Yılmaz", Yas = 25 },
			new Person { Ad = "Ayşe", Soyad = "Demir", Yas = 30 },
			new Person { Ad = "Mehmet", Soyad = "Kaya", Yas = 22 },
			new Person { Ad = "Mehmet2", Soyad = "Kaya2", Yas = 22 },
			new Person { Ad = "Mehmet3", Soyad = "Kaya3", Yas = 22 }
		};

			for (int row = 0; row < kisiler.Count; row++)
			{
				var kisi = kisiler[row];
				string[] hucreler = { kisi.Ad, kisi.Soyad, kisi.Yas.ToString() };

				for (int col = 0; col < hucreler.Length; col++)
				{
					var label = new Label
					{
						Text = hucreler[col],
						HorizontalTextAlignment = TextAlignment.Center,
						VerticalTextAlignment = TextAlignment.Center
					};

					var frame = new Frame
					{
						Content = label,
						Padding = 5,
						BorderColor = Colors.Black,
						HasShadow = false,
						Margin = 0,
						CornerRadius = 0,
						BackgroundColor = (row % 2 == 0) ? Colors.White : Color.FromArgb("#f0f0f0")
					};

					// 🔥 Tıklama olayı sadece 1. kolona (Ad) ekleniyor
					if (col == 0)
					{
						var tappedKisi = kisi; // closure sabitleme
						var tap = new TapGestureRecognizer();
						tap.Tapped += async (s, e) =>
						{
							await DisplayAlert("Detay", $"Ad: {tappedKisi.Ad}\nSoyad: {tappedKisi.Soyad}\nYaş: {tappedKisi.Yas}", "Tamam");
						};
						frame.GestureRecognizers.Add(tap);
					}

					grid.Add(frame, col, row + 1);
				}
			}

			TabloAlani.Children.Add(grid);

		}

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
