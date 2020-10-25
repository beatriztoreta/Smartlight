using AppTCC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParametersPage : ContentPage
    {
        ParamViewModel _viewModel;
                 

        public ParametersPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new ParamViewModel();

            




        }

        private async void Section_Tapped(object sender, System.EventArgs e)
        {
            var label = (sender as Label);

            await Navigation.PushAsync(new ParametersFixPage(Convert.ToInt32(label.Text)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            RefreshView refreshView = new RefreshView();

            CollectionView collectionView = new CollectionView();
            collectionView.SetBinding(ItemsView.ItemsSourceProperty, "Sec");

            collectionView.ItemTemplate = new DataTemplate(() =>
            {

                Label sector_tag_Label = new Label { HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start, BackgroundColor = Color.Yellow };
                sector_tag_Label.SetBinding(Label.TextProperty, "sector_tag");

                Label sector_Label = new Label { HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start, BackgroundColor = Color.Yellow };
                sector_Label.SetBinding(Label.TextProperty, "sector");

                StackLayout stack = new StackLayout {Padding = 10, Margin = new Thickness(30,10,30,0), 
                    Children = {
                       sector_tag_Label,
                       sector_Label
                    }
                };
                
                

                return stack;
            });

            refreshView.Content = collectionView;
        }
    }
}