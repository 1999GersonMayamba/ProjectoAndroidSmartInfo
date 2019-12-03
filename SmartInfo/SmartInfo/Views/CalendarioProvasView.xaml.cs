using SmartInfo.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartInfo.ClassesDeAcessoAPI;
using Newtonsoft.Json;
using System.Net.Http;

namespace SmartInfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarioProvasView : ContentPage
    {
        private List<tb_classe_Info> Classes;
        private List<tb_curso_Info> Cursos;
        private List<tb_trimestre_Info> Trimestre;
        private List<tb_calendario_prova_Info> tb_Calendario_Prova_Infos = null;

        CalendarioProva CalendarioProva = new CalendarioProva();

        string _trimestre,  _curso, _classe;

        public CalendarioProvasView()
        {
            InitializeComponent();
            IndicadorDeActividade.IsRunning = true;
            ListaDeClasses();
            ListaDeCursos();
            ListaDeTrimestre();
        }

        private void Pk_Classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            var classe = Pk_Classe.SelectedItem as tb_classe_Info;
            _classe = classe.Id_Classe;
        }

        private void Pk_Curso_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curso = Pk_Curso.SelectedItem as tb_curso_Info;
            _curso = curso.Id_Curso;
        }


        private async void Btn_Pesquisar_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;

            try
            {

                 if (string.IsNullOrEmpty(_trimestre) == true)
                {
                    DependencyService.Get<IMessageError>().LongAlert("Seleciona o Trimestre");
                }
                else if (string.IsNullOrEmpty(_curso) == true)
                {
                    DependencyService.Get<IMessageError>().LongAlert("Seleciona o curso");
                }
                else if (string.IsNullOrEmpty(_classe.ToString()) == true)
                {
                    DependencyService.Get<IMessageError>().LongAlert("Seleciona a classe");
                }
                else
                {

                    tb_Calendario_Prova_Infos = await CalendarioProva.ListaDeProvas(_trimestre, _curso, _classe);
                    ListaCalendarioDeProvas.ItemsSource = tb_Calendario_Prova_Infos;
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

        private async void ListaDeCursos()
        {
            try
            {
                Cursos = await CalendarioProva.ListaDeCursos();
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
            IndicadorDeActividade.IsRunning = false;
        }

        private async void ListaDeClasses()
        {
            try
            {
                Classes = await CalendarioProva.ListaDeClasses();
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
            IndicadorDeActividade.IsRunning = false;
        }

        private async void ListaDeTrimestre()
        {
            try
            {
                Trimestre = await CalendarioProva.ListaDeTrimestre();
                Pk_Trimestre.ItemsSource = Trimestre;
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
            IndicadorDeActividade.IsRunning = false;
        }

        private void Pk_Trimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            var trimestre = Pk_Trimestre.SelectedItem as tb_trimestre_Info;
            _trimestre = trimestre.Id_Trimestre;
        }
    }
}