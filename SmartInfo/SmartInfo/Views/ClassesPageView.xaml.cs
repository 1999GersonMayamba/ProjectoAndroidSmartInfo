using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartInfo.Info;
using SmartInfo.ClassesDeAcessoAPI;
using Plugin.Connectivity;
using Newtonsoft.Json;
using System.Net.Http;

namespace SmartInfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClassesPageView : ContentPage
	{
        ClasseAPI ClasseAPI = new ClasseAPI();

		public ClassesPageView ()
		{
			InitializeComponent ();
            IndicadorDeActividade.IsRunning = true;
            Classes();
		}

        private async void Classes()
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
                    List<tb_classe_Info> tb_Classe_Infos = await ClasseAPI.ListaClassesJson();
                    ListaClasses.ItemsSource = tb_Classe_Infos;
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
    }
}