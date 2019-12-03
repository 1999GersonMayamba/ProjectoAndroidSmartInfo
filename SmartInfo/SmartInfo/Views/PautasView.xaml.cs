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
using System.Reflection;

namespace SmartInfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PautasView : ContentPage
	{
        private List<tb_classe_Info> Classes;
        private List<tb_curso_Info> Cursos;
        private List<tb_trimestre_Info> Trimestre;
        private List<tb_ano_Info> Ano;
        //private tb_curso_de_electronica10_Info tb_Curso_De_Electronica10_Infos;
        //private tb_curso_de_electronica11_Info tb_Curso_De_Electronica11_Infos;
        //private tb_curso_de_electronica12_Info tb_Curso_De_Electronica12_Infos;
        //private tb_curso_de_electronica13_Info tb_Curso_De_Electronica13_Infos;

       // private tb_curso_de_informatica10_Info tb_Curso_De_Informatica10_Infos;
        //private tb_curso_de_informatica11_Info tb_Curso_De_Informatica11_Infos;
        //private tb_curso_de_informatica12_Info tb_Curso_De_Informatica12_Infos;
        //private tb_curso_de_informatica13_Info tb_Curso_De_Informatica13_Infos;


        string _trimestre, _ano, _curso; 
        int _classe;
        Pauta _Pauta = new Pauta();

        public PautasView ()
		{
			InitializeComponent ();
            ListaDeClasses();
            ListaDeCursos();
            ListaDeTrimestre();
            ListaDeAnoLestivo();
        }

        private async void ListaDeAnoLestivo()
        {
            try
            {
                Ano = await _Pauta.ListaDeAnoLectivo();
                Pk_Ano_Lectivo.ItemsSource = Ano;
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

        private async void ListaDeTrimestre()
        {
            try
            {
                Trimestre = await _Pauta.ListaDeTrimestre();
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
        }

        private void Pk_Classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            var classe = Pk_Classe.SelectedItem as tb_classe_Info;
            _classe = classe.Classe;
        }

        private void Pk_Ano_Lectivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ano = Pk_Ano_Lectivo.SelectedItem as tb_ano_Info;
            _ano = ano.Id_Ano;
        }

        private void Pk_Curso_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curso = Pk_Curso.SelectedItem as tb_curso_Info;
            _curso = curso.Curso;
        }

        private void Pk_Trimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            var trinestre = Pk_Trimestre.SelectedItem as tb_trimestre_Info;
            _trimestre = trinestre.Id_Trimestre;
        }

        private async void Btn_Visualizar_Boletim_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;

            try
            {
             if(string.IsNullOrEmpty(Et_Numero_BI.Text) == true)
                {
                    DependencyService.Get<IMessageError>().LongAlert("Preencha o numero do bilhete");
                }
                else  if(string.IsNullOrEmpty(_trimestre) == true)
                {
                    DependencyService.Get<IMessageError>().LongAlert("Seleciona o Trimestre");
                }
                else if (string.IsNullOrEmpty(_ano) == true)
                {
                    DependencyService.Get<IMessageError>().LongAlert("Seleciona o ano lectivo");
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
                    if (_classe == 10 && _curso == "Electrónica e Telecomunicações")
                    {
                        tb_curso_de_electronica10_Info tb_Curso_De_Electronica10_Info = new tb_curso_de_electronica10_Info();
                        tb_Curso_De_Electronica10_Info = await _Pauta.ListaDePauta10Electronica(Et_Numero_BI.Text, _trimestre, _ano, _classe, _curso);


                        if (tb_Curso_De_Electronica10_Info.Id == null)
                        {
                            await DisplayAlert("BOLETIM", "Para as informsações selecionadas a pauta ainda se encontra indisponivél", "OK");
                        }
                        else
                        {
                            string Result = "Lingoa Portuguesa " + tb_Curso_De_Electronica10_Info.Lingua_Portuguesa + "\n" +
                                   "Matemática " + tb_Curso_De_Electronica10_Info.Matematica + "\n" +
                                   "E.Eletcrónica " + tb_Curso_De_Electronica10_Info.Electronica + "\n" +
                                   "Informática " + tb_Curso_De_Electronica10_Info.Informatica + "\n" +
                                   "Empeendorismo " + tb_Curso_De_Electronica10_Info.Empreendedorismo + "\n" +
                                   "FAI " + tb_Curso_De_Electronica10_Info.FAI + "\n" +
                                   "Fisíca " + tb_Curso_De_Electronica10_Info.Fisica + "\n" +
                                   "Ingles " + tb_Curso_De_Electronica10_Info.Ingles + "\n" +
                                   "Telecomunicações " + tb_Curso_De_Electronica10_Info.Telecomunicacoes + "\n" +
                                   "P.O " + tb_Curso_De_Electronica10_Info.P_O + "\n" +
                                   "Educação Fisica " + tb_Curso_De_Electronica10_Info.Ed_Fisica + "\n" +
                                   "Desenho Tecnico " + tb_Curso_De_Electronica10_Info.Desenho_Tecnico + "\n";

                            await DisplayAlert("BOLETIM", Result, "OK");
                        }
                    }
                    else if (_classe == 11 && _curso == "Electrónica e Telecomunicações")
                    {
                        tb_curso_de_electronica11_Info tb_Curso_De_Electronica11_Info = new tb_curso_de_electronica11_Info();
                        tb_Curso_De_Electronica11_Info = await _Pauta.ListaDePauta11Electronica(Et_Numero_BI.Text, _trimestre, _ano, _classe, _curso);


                        if (tb_Curso_De_Electronica11_Info.Id == null)
                        {
                            await DisplayAlert("BOLETIM", "Para as informsações selecionadas a pauta ainda se encontra indisponivél", "OK");
                        }
                        else
                        {
                            string Result = "Lingoa Portuguesa " + tb_Curso_De_Electronica11_Info.Lingua_Portuguesa + "\n" +
                                   "Matemática " + tb_Curso_De_Electronica11_Info.Matematica + "\n" +
                                   "E.Eletcrónica " + tb_Curso_De_Electronica11_Info.Electronica + "\n" +
                                   "Informática " + tb_Curso_De_Electronica11_Info.Informatica + "\n" +
                                   "Empeendorismo " + tb_Curso_De_Electronica11_Info.Empreendedorismo + "\n" +
                                   "FAI " + tb_Curso_De_Electronica11_Info.FAI + "\n" +
                                   "Fisíca " + tb_Curso_De_Electronica11_Info.Fisica + "\n" +
                                   "Ingles " + tb_Curso_De_Electronica11_Info.Ingles + "\n" +
                                   "Telecomunicações " + tb_Curso_De_Electronica11_Info.Telecomunicacoes + "\n" +
                                   "P.O " + tb_Curso_De_Electronica11_Info.P_O + "\n" +
                                   "Educação Fisica " + tb_Curso_De_Electronica11_Info.Ed_Fisica + "\n" +
                                   "Desenho Tecnico " + tb_Curso_De_Electronica11_Info.Desenho_Tecnico + "\n";

                            await DisplayAlert("BOLETIM", Result, "OK");
                        }
                    }
                    else if (_classe == 12 && _curso == "Electrónica e Telecomunicações")
                    {
                        tb_curso_de_electronica12_Info tb_Curso_De_Electronica12_ = new tb_curso_de_electronica12_Info();
                        tb_Curso_De_Electronica12_ = await _Pauta.ListaDePauta12Electronica(Et_Numero_BI.Text, _trimestre, _ano, _classe, _curso);

                        if (tb_Curso_De_Electronica12_.Id == null)
                        {
                            await DisplayAlert("BOLETIM", "Para as informsações selecionadas a pauta ainda se encontra indisponivél", "OK");
                        }
                        else
                        {
                            string Result = "Eletrónica " + tb_Curso_De_Electronica12_.Electronica + "\n" +
                                   "Matemática " + tb_Curso_De_Electronica12_.Matematica + "\n" +
                                   "Empeendorismo " + tb_Curso_De_Electronica12_.Empreendedorismo + "\n" +
                                   "Fisíca " + tb_Curso_De_Electronica12_.Fisica + "\n" +
                                   "Ingles " + tb_Curso_De_Electronica12_.Ingles + "\n" +
                                   "OGI " + tb_Curso_De_Electronica12_.OGI + "\n" +
                                   "Projecto Tecnologico " + tb_Curso_De_Electronica12_.Projecto_Tecnologico + "\n" +
                                   "P.O " + tb_Curso_De_Electronica12_.P_O + "\n" +
                                   "Telecomunicações " + tb_Curso_De_Electronica12_.Telecomunicacoes + "\n" +
                                   "Sistemas Digitais " + tb_Curso_De_Electronica12_.Sistemas_Digitais + "\n";

                            await DisplayAlert("BOLETIM", Result, "OK");
                        }
                    }
                    else if (_classe == 13 && _curso == "Electrónica e Telecomunicações")
                    {
                        tb_curso_de_electronica13_Info tb_Curso_De_Electronica13_ = new tb_curso_de_electronica13_Info();
                        tb_Curso_De_Electronica13_ = await _Pauta.ListaDePauta13Electronica(Et_Numero_BI.Text, _trimestre, _ano, _classe, _curso);

                        if (tb_Curso_De_Electronica13_.Id == null)
                        {
                            await DisplayAlert("BOLETIM", "Para as informsações selecionadas a pauta ainda se encontra indisponivél", "OK");
                        }
                        else
                        {
                            string Result =
                                   "Projecto Tecnologico " + tb_Curso_De_Electronica13_.Projecto_Tecnologico;

                            await DisplayAlert("BOLETIM", Result, "OK");
                        }
                    }
                    else if (_classe == 10 && _curso == "Informática")
                    {

                        tb_curso_de_informatica10_Info tb_Curso_De_Informatica10 = new tb_curso_de_informatica10_Info();
                        tb_Curso_De_Informatica10 = await _Pauta.ListaDePauta10Informatica(Et_Numero_BI.Text, _trimestre, _ano, _classe, _curso);


                        if (tb_Curso_De_Informatica10.Id == null)
                        {
                            await DisplayAlert("BOLETIM", "Para as informsações selecionadas a pauta ainda se encontra indisponivél", "OK");
                        }
                        else
                        {
                            string Result = "Lingoa Portuguesa " + tb_Curso_De_Informatica10.Lingua_Portuguesa + "\n" +
                                   "Matemática " + tb_Curso_De_Informatica10.Matematica + "\n" +
                                   "Electrótecnia " + tb_Curso_De_Informatica10.Electrotecnia + "\n" +
                                   "Educação Fisica " + tb_Curso_De_Informatica10.Educacao_Fisica + "\n" +
                                   "Empeendorismo " + tb_Curso_De_Informatica10.Empreendedorismo + "\n" +
                                   "FAI " + tb_Curso_De_Informatica10.FAI + "\n" +
                                   "Fisíca " + tb_Curso_De_Informatica10.Fisica + "\n" +
                                   "Ingles " + tb_Curso_De_Informatica10.Ingles + "\n" +
                                   "Química " + tb_Curso_De_Informatica10.Quimica + "\n" +
                                   "SEAC " + tb_Curso_De_Informatica10.SEAC + "\n" +
                                   "TIC " + tb_Curso_De_Informatica10.TIC + "\n" +
                                   "TLP " + tb_Curso_De_Informatica10.TLP + "\n";

                            await DisplayAlert("BOLETIM", Result, "OK");
                        }
                    }
                    else if (_classe == 11 && _curso == "Informática")
                    {
                        tb_curso_de_informatica11_Info tb_Curso_De_Informatica11 = new tb_curso_de_informatica11_Info();
                        tb_Curso_De_Informatica11 = await _Pauta.ListaDePauta11Informatica(Et_Numero_BI.Text, _trimestre, _ano, _classe, _curso);


                        if (tb_Curso_De_Informatica11.Id == null)
                        {
                            await DisplayAlert("BOLETIM", "Para as informsações selecionadas a pauta ainda se encontra indisponivél", "OK");
                        }
                        else
                        {
                            string Result = "Lingoa Portuguesa " + tb_Curso_De_Informatica11.Lingua_Portuguesa + "\n" +
                                   "Matemática " + tb_Curso_De_Informatica11.Matematica + "\n" +
                                   "Electrótecnia " + tb_Curso_De_Informatica11.Electrotecnia + "\n" +
                                   "Educação Fisica " + tb_Curso_De_Informatica11.Educacao_Fisica + "\n" +
                                   "Empeendorismo " + tb_Curso_De_Informatica11.Empreendedorismo + "\n" +
                                   "FAI " + tb_Curso_De_Informatica11.FAI + "\n" +
                                   "Fisíca " + tb_Curso_De_Informatica11.Fisica + "\n" +
                                   "Ingles " + tb_Curso_De_Informatica11.Ingles + "\n" +
                                   "Química " + tb_Curso_De_Informatica11.Quimica + "\n" +
                                   "SEAC " + tb_Curso_De_Informatica11.SEAC + "\n" +
                                   "TIC " + tb_Curso_De_Informatica11.TIC + "\n" +
                                   "TLP " + tb_Curso_De_Informatica11.TLP + "\n";

                            await DisplayAlert("BOLETIM", Result, "OK");
                        }

                    }
                    else if (_classe == 12 && _curso == "Informática")
                    {
                        tb_curso_de_informatica12_Info tb_Curso_De_Informatica12 = new tb_curso_de_informatica12_Info();
                        tb_Curso_De_Informatica12 = await _Pauta.ListaDePauta12Informatica(Et_Numero_BI.Text, _trimestre, _ano, _classe, _curso);


                        if (tb_Curso_De_Informatica12.Id == null)
                        {
                            await DisplayAlert("BOLETIM", "Para as informsações selecionadas a pauta ainda se encontra indisponivél", "OK");
                        }
                        else
                        {
                            string Result = 
                                   "Matemática " + tb_Curso_De_Informatica12.Matematica + "\n" +
                                   "Empeendorismo " + tb_Curso_De_Informatica12.Empreendedorismo + "\n" +
                                   "OGI " + tb_Curso_De_Informatica12.OGI + "\n" +
                                   "Fisíca " + tb_Curso_De_Informatica12.Fisica + "\n" +
                                   "Ingles " + tb_Curso_De_Informatica12.Ingles + "\n" +
                                   "SEAC " + tb_Curso_De_Informatica12.SEAC + "\n" +
                                   "Projecto Tecnologico " + tb_Curso_De_Informatica12.Projecto_Tecnologico + "\n" +
                                   "TLP " + tb_Curso_De_Informatica12.TLP + "\n";

                            await DisplayAlert("BOLETIM", Result, "OK");
                        }
                    }
                    else
                    {
                        tb_curso_de_informatica13_Info tb_Curso_De_Informatica13 = new tb_curso_de_informatica13_Info();
                        tb_Curso_De_Informatica13 = await _Pauta.ListaDePauta13Informatica(Et_Numero_BI.Text, _trimestre, _ano, _classe, _curso);


                        if (tb_Curso_De_Informatica13.Id == null)
                        {
                            await DisplayAlert("BOLETIM", "Para as informsações selecionadas a pauta ainda se encontra indisponivél", "OK");
                        }
                        else
                        {
                            string Result =
                                   "Projecto Tecnologico " + tb_Curso_De_Informatica13.Projecto_Tecnologico;

                            await DisplayAlert("BOLETIM", Result, "OK");
                        }
                    }
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

        public static object GetPropertyValue(object source, string propertyName)
        {
            PropertyInfo property = source.GetType().GetProperty(propertyName);
            return property.GetValue(source, null);
        }

        private async void ListaDeCursos()
        {
            try
            {
                Cursos = await _Pauta.ListaDeCursos();
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
                Classes = await _Pauta.ListaDeClasses();
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