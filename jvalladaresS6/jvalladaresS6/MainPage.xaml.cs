using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace jvalladaresS6
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }

        private void btnConsultar_Clicked(object sender, EventArgs e)
        {
            var mensaje = "BIENVENIDO";
            DependencyService.Get<Mensaje>().longAlert(mensaje);
            Navigation.PushAsync(new Consultar());
        }
    }
}
