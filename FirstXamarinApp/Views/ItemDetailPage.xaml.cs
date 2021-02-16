using FirstXamarinApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FirstXamarinApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
            
        }
    }
}