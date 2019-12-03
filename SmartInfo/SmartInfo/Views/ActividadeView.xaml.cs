using Newtonsoft.Json;
using Plugin.Connectivity;
using SmartInfo.ClassesDeAcessoAPI;
using SmartInfo.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartInfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActividadeView : ContentPage
	{
        Actividade Actividade = new Actividade();
        string _id_categoria = null;

		public ActividadeView ()
		{
			InitializeComponent ();
            IndicadorDeActividade.IsRunning = true;
            ListaCategotia();
            ListaLoding();

        }

        private async void ListaLoding()
        {
            try
            {
                var connection = CrossConnectivity.Current.IsConnected;
                if (connection == false)
                {
                    //this.IndicadorDeActividade.IsRunning = false;
                    //await DisplayAlert("ERRO", "Verifica a sua conexão de internet.", "OK");
                    DependencyService.Get<IMessageError>().LongAlert("Verifica a sua conexão de internet.");
                }
                else
                {
                    List<tb_actividade_Info> tb_Actividade_Infos = await Actividade.ListaDeActividade();
                    ListaDeActividade.ItemsSource = tb_Actividade_Infos;
                }

            }
            catch (JsonException ex)
            {
                DependencyService.Get<IMessageError>().LongAlert(ex.Message);
                //await DisplayAlert("Resultado", ex.Message, "OK");
            }
            catch (HttpRequestException ex)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                DependencyService.Get<IMessageError>().LongAlert(ex.Message);
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                DependencyService.Get<IMessageError>().LongAlert(ex.Message);
            }
            finally
            {

            }

            IndicadorDeActividade.IsRunning = false;
        }

        private async void ListaCategotia()
        {
            try
            {
                var connection = CrossConnectivity.Current.IsConnected;
                if (connection == false)
                {
                    //this.IndicadorDeActividade.IsRunning = false;
                    //await DisplayAlert("ERRO", "Verifica a sua conexão de internet.", "OK");
                    DependencyService.Get<IMessageError>().LongAlert("Verifica a sua conexão de internet.");
                }
                else
                {
                    List<tb_duracao_da_actividade_Info> tb_Duracao_Da_Actividade_Infos = await Actividade.ListaDeCategoriaActividade();
                    Pk_CategoriaActividade.ItemsSource = tb_Duracao_Da_Actividade_Infos;
                }

            }
            catch (JsonException ex)
            {
                DependencyService.Get<IMessageError>().LongAlert(ex.Message);
                //await DisplayAlert("Resultado", ex.Message, "OK");
            }
            catch (HttpRequestException ex)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                DependencyService.Get<IMessageError>().LongAlert(ex.Message);
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                DependencyService.Get<IMessageError>().LongAlert(ex.Message);
            }
            finally
            {

            }

            IndicadorDeActividade.IsRunning = false;
        }

        private async void Pk_CategoriaActividade_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            var id = Pk_CategoriaActividade.SelectedItem as tb_duracao_da_actividade_Info;
            _id_categoria = id.Id_Duracao;
            List<tb_actividade_Info> tb_Actividade_Infos = await Actividade.ListaDeActividadePorCategoria(_id_categoria);
            ListaDeActividade.ItemsSource = tb_Actividade_Infos;
            IndicadorDeActividade.IsRunning = false;
        }
    }
}