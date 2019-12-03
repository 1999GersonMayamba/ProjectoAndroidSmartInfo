using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartInfo.ClassesDeAcessoAPI;
using SmartInfo.Info;

namespace SmartInfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuadroDeHonraPageView : ContentPage
	{
        Quadro_De_Honra Quadro_De_Honra = new Quadro_De_Honra();
		public QuadroDeHonraPageView ()
		{
			InitializeComponent ();
            IndicadorDeActividade.IsRunning = true;
                
            Alunos();
		}

        private async void Alunos()
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
                        List<tb_quadro_de_honra_Info> tb_Quadro_De_Honras = await Quadro_De_Honra.ListaAlunosJson();
                        ListaAlunosDeHonra.ItemsSource = tb_Quadro_De_Honras;
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