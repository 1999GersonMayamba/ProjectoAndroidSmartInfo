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
	public partial class InformacaoDeLevantarCertificadoView : ContentPage
	{
        InformacaoCertificado InformacaoCertificado = new InformacaoCertificado();
        List<tb_instrucao_de_levantar_certificado_Info> Certificado_Info =  null;


		public InformacaoDeLevantarCertificadoView ()
		{
			InitializeComponent ();
            IndicadorDeActividade.IsRunning = true;
            ListaDeInformacoes();
		}

        private async void ListaDeInformacoes()
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
                    Certificado_Info = await InformacaoCertificado.ListaInformacoesCertificadoJson();
                    ListaInformacoesCertificado.ItemsSource = Certificado_Info;
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