using Newtonsoft.Json;
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
using System.Collections.ObjectModel;
using Plugin.Connectivity;

namespace SmartInfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InformacoesDePagementoView : ContentPage
	{

        PagamentoPropina PagamentoPropina = new PagamentoPropina();
        private List<tb_classe_Info> tb_Classe_Infos;
        private List<tb_curso_Info> tb_Curso_Infos;
        private List<tb_instrucao_de_pagamento_Info> tb_Instrucao_De_Pagamento_Infos;
        string Id_Curso = null, Id_Classe = null;

      //  ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();

        public InformacoesDePagementoView ()
		{
			InitializeComponent ();
            IndicadorDeActividade.IsRunning = true;
            Classes();
            Cursos();
            ListaPagamento();

        }

        private async void ListaPagamento()
        {
            try
            {
                tb_Instrucao_De_Pagamento_Infos = await PagamentoPropina.ListaInformacoesPagamnetoJson();
                ListaInformacoes.ItemsSource = tb_Instrucao_De_Pagamento_Infos;
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

        private async void Cursos()
        {
            try
            {
                tb_Curso_Infos = await PagamentoPropina.ListaDeCursos();
                Pk_Curso.ItemsSource = tb_Curso_Infos;
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

        private async void Classes()
        {
            try
            {
                tb_Classe_Infos = await PagamentoPropina.ListaDeClasses();
                Pk_Classe.ItemsSource = tb_Classe_Infos;
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

        private void Pk_Classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            var classe = Pk_Classe.SelectedItem as tb_classe_Info;
            Id_Classe = classe.Id_Classe;
        }

        private async void Btn_Pesquisar_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;

            if (string.IsNullOrEmpty(Id_Curso) == true)
            {
                DependencyService.Get<IMessageError>().LongAlert("Seleciona o curso");
            }
            else if (string.IsNullOrEmpty(Id_Classe) == true)
            {
                DependencyService.Get<IMessageError>().LongAlert("Seleciona a classe");
            }
            else
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
                        tb_Instrucao_De_Pagamento_Infos = await PagamentoPropina.ListaInformacoesPagamnetoPorParametroJson(Id_Classe, Id_Curso);
                        ListaInformacoes.ItemsSource = tb_Instrucao_De_Pagamento_Infos;
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
            }
            IndicadorDeActividade.IsRunning = false;
        }

        private void Pk_Curso_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curso = Pk_Curso.SelectedItem as tb_curso_Info;
            Id_Curso = curso.Id_Curso;
        }


      
    }
}