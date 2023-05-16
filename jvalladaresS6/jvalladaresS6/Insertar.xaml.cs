using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jvalladaresS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar : ContentPage
    {
        public Insertar()
        {
            InitializeComponent();


        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);//4
                parametros.Add("nombre", txtNombre.Text);//Javier
                parametros.Add("apellido", txtApellido.Text);//Valladares
                parametros.Add("edad", txtEdad.Text);//34

                cliente.UploadValues("http://192.168.27.104/moviles/post.php", "POST", parametros);
                DisplayAlert("ALERTA", "DATO INGRESADO", "Salir");

            }
            catch (Exception ex)
            {

                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}