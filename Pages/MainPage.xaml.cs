using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.PageModels;

namespace MauiAppMinhasCompras.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}