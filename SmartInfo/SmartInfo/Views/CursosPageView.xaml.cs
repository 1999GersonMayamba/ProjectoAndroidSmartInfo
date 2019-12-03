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
using SmartInfo.Info;
using SmartInfo.ClassesDeAcessoAPI;

namespace SmartInfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CursosPageView : ContentPage
	{
        Curso Curso = new Curso();

		public CursosPageView ()
		{
			InitializeComponent ();
            IndicadorDeActividade.IsRunning = true;
            Cursos();

        }

        public async void Cursos()
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
                    List<tb_curso_Info> tb_Curso_Infos = await Curso.ListaCursosJson();
                    ListaCursos.ItemsSource = tb_Curso_Infos;
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