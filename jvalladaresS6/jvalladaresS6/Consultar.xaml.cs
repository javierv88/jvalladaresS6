using jvalladaresS6.WS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jvalladaresS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consultar : ContentPage
    {
        private const string Url = "http://192.168.27.104/moviles/post.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<mjvalladaresS6.WS.Datos> post;
        public Consultar()
        {
            InitializeComponent();
            Obtener();
        }

        public async void Obtener()
        {
            var content = await cliente.GetStringAsync(Url);
            List<mpSemana6.WS.Datos> posts = JsonConvert.DeserializeObject<List<mpSemana6.WS.Datos>>(content);
            post = new ObservableCollection<WS.Datos>(posts);
            lista.ItemsSource = post;
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage()); 
        }

        private void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string codigo = (e.SelectedItem as Datos).codigo.ToString();
            string nombre = (e.SelectedItem as Datos).nombre;
            string apellido = (e.SelectedItem as Datos).apellido;
            string edad = (e.SelectedItem as Datos).edad.ToString();
            Navigation.PushAsync(new Editar(codigo, nombre, apellido, edad));
        }
    }
}