using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartInfo.ClassesDeAcessoAPI;
using SmartInfo.Info;
using Plugin.Connectivity;
using Newtonsoft.Json;
using System.Net.Http;

namespace SmartInfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InformacoesJustificarFaltaView : ContentPage
	{
        List<tb_instrucao_de_justificar_falta_Info> tb_Instrucao_De_Justificar_Falta_Infos = null;
        InformacaoFalta InformacaoFalta = new InformacaoFalta();
		public InformacoesJustificarFaltaView ()
		{
			InitializeComponent ();
            IndicadorDeActividade.IsRunning = true;
            ListaInformacao();
                
		}

        private async void ListaInformacao()
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
                    tb_Instrucao_De_Justificar_Falta_Infos = await InformacaoFalta.ListaInformacoesJustificarFaltaJson();
                    ListaInformacoesFalta.ItemsSource = tb_Instrucao_De_Justificar_Falta_Infos;
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