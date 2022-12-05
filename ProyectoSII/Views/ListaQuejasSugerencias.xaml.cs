﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSII.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaQuejasSugerencias : ContentPage
    {
        public ListaQuejasSugerencias()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            InitializeComponent();
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevaQueja());
        }
    }
}