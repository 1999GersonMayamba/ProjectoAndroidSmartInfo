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
	public partial class NovidadeView : ContentPage
	{
        Novidade Novidade = new Novidade();
        string _Id_Categoria = null;
		public NovidadeView ()
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
                    List<tb_novidade_Info> tb_Novidade_Infos = await Novidade.ListaDeNovidade();
                    ListaDeNovidade.ItemsSource = tb_Novidade_Infos;
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
                    List<tb_categoria_novidade_Info> tb_Categoria_Novidade_Infos = await Novidade.ListaDeCategoriaNovidade();
                    Pk_Categoria_Novidade.ItemsSource = tb_Categoria_Novidade_Infos;
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

        private async void Pk_Categoria_Novidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            var id = Pk_Categoria_Novidade.SelectedItem as tb_categoria_novidade_Info;
            _Id_Categoria = id.Id_Categoria;
            List<tb_novidade_Info> tb_Novidade_Infos = await Novidade.ListaDeNovidadePorCategoria(_Id_Categoria);
            ListaDeNovidade.ItemsSource = tb_Novidade_Infos;
            IndicadorDeActividade.IsRunning = false;
        }
    }
}