using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartInfo.Info;
using SmartInfo.ClassesDeAcessoAPI;
using Newtonsoft.Json;
using System.Net.Http;

namespace SmartInfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatriculaView : ContentPage
    {

        private List<tb_classe_Info> Classes;
        private List<tb_curso_Info> Cursos;
        Matricula Matricula = new Matricula();
        tb_matricula_Info tb_Matricula_Info = new tb_matricula_Info();

        public MatriculaView()
        {
            InitializeComponent();
            ListaDeClasses();
            ListaDeCursos();
        }

        private async void ListaDeCursos()
        {
            try
            {
                Cursos = await Matricula.ListaDeCursos();
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
                DependencyService.Get<IMessageError>().LongAlert("Verifica a sua conexão de internet");
            }
            finally
            {

            }
        }

        private async void ListaDeClasses()
        {
            try
            {
                Classes = await Matricula.ListaDeClasses();
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
                //DependencyService.Get<IMessageError>().LongAlert(ex.Message);
            }
            finally
            {

            }
        }

        private void Data_De_Nascimento_DateSelected(object sender, DateChangedEventArgs e)
        {
            try
            {
                string DataMMDDAAA = DateTime.Parse(Data_De_Nascimento.Date.ToString()).ToString("yyyy/MM/dd");
                tb_Matricula_Info.Data_De_Nascimento = DataMMDDAAA;

            }
            catch (Exception)
            {

            }
        }

        private void Pk_Classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            var classe = Pk_Classe.SelectedItem as tb_classe_Info;
            tb_Matricula_Info.Id_Classe = classe.Id_Classe;
        }

        private void Pk_Curso_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curso = Pk_Curso.SelectedItem as tb_curso_Info;
            tb_Matricula_Info.Id_Curso = curso.Id_Curso;
        }

        private async void Btn_Matricular_se_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            tb_Matricula_Info.Nome_Completo = Et_Nome_Completo.Text;
            tb_Matricula_Info.Nome_Da_Mae = Et_Nome_Da_Mae.Text;
            tb_Matricula_Info.Nome_Do_Pai = Et_Nome_Do_Pai.Text;
            //tb_Matricula_Info.Altura = Et_Altura.Text;
            tb_Matricula_Info.Endereco = Et_Endereco.Text;
            tb_Matricula_Info.Numero_Do_Bilhete = Et_Numero_BI.Text;
            string Result = await Matricula.Matricular_se(tb_Matricula_Info);
            await DisplayAlert("CONFRIMAÇÃO", Result, "OK");
            IndicadorDeActividade.IsRunning = false;
        }
    }
}