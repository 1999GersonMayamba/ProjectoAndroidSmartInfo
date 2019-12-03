using Newtonsoft.Json;
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
	public partial class ConfirmacaoView : ContentPage
	{

        private List<tb_classe_Info> Classes;
        private List<tb_curso_Info> Cursos;
        Confirmacao Confirmacao = new Confirmacao();
        tb_confirmacao_Info tb_Confirmacao_Info = new tb_confirmacao_Info();

        public ConfirmacaoView ()
		{
			InitializeComponent ();
            ListaDeClasses();
            ListaDeCursos();
        }

        private void Pk_Classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            var classe = Pk_Classe.SelectedItem as tb_classe_Info;
            tb_Confirmacao_Info.Id_Classe = classe.Id_Classe;
        }

        private void Pk_Curso_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curso = Pk_Curso.SelectedItem as tb_curso_Info;
            tb_Confirmacao_Info.Id_Curso = curso.Id_Curso;
        }

        private async void Btn_Confrimacao_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            tb_Confirmacao_Info.Numero_Do_Bilhete = Et_Numero_BI.Text;
            string Result = await Confirmacao.FazerConfirmacao(tb_Confirmacao_Info);
            await DisplayAlert("CONFRIMAÇÃO", Result, "OK");
            IndicadorDeActividade.IsRunning = false;

        }

        private async void ListaDeCursos()
        {
            try
            {
                Cursos = await Confirmacao.ListaDeCursos();
                Pk_Curso.ItemsSource = Cursos;
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
        }

        private async void ListaDeClasses()
        {
            try
            {
                Classes = await Confirmacao.ListaDeClasses();
                Pk_Classe.ItemsSource = Classes;
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
        }
    }
}