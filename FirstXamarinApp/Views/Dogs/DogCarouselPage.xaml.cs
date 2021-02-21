﻿using FirstXamarinApp.ViewModels.Dogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinApp.Views.Dogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DogCarouselPage : ContentPage
    {
        public DogCarouselPage()
        {
            InitializeComponent();
            BindingContext = new DogCarouselViewModel();
        }
    }
}