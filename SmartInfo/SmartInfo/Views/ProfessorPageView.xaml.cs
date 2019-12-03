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
	public partial class ProfessorPageView : ContentPage
	{

        Professor Professor = new Professor();


		public ProfessorPageView ()
		{
			InitializeComponent ();
            IndicadorDeActividade.IsRunning = true;
            ListaDeProfessores();
		}

        private async void ListaDeProfessores()
        {
            try
            {
                var connection = CrossConnectivity.Current.IsConnected;
                if (connection == false)
                {
                    DependencyService.Get<IMessageError>().LongAlert("Verifica a sua conexão de internet.");
                }
                else
                {
                    List<tb_professor_Info> tb_Professor_Infos = await Professor.ListaDeProfessoresJson();
                    ListaProfessores.ItemsSource = tb_Professor_Infos;
                }

            }
            catch (JsonException ex)
            {
                DependencyService.Get<IMessageError>().LongAlert(ex.Message);
            }
            catch (HttpRequestException ex)
            {
                DependencyService.Get<IMessageError>().LongAlert(ex.Message);
            }
            catch (Exception ex)
            {
                DependencyService.Get<IMessageError>().LongAlert(ex.Message);
            }
            finally
            {

            }

            IndicadorDeActividade.IsRunning = false;
        }
    }
}