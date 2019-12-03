using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using SmartInfo.Info;
using Xamarin.Forms;

namespace SmartInfo.ClassesDeAcessoAPI
{
  public  class Matricula
    {

        //Metodo para poder trazer a lista de Classes
        public async Task<List<tb_classe_Info>> ListaDeClasses()
        {
            List<tb_classe_Info> tb_Classe_Infos = null;

            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Classe");
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_classe_Info>>(responseString);
                return json;
            }
            catch (JsonException ex)
            {
                return tb_Classe_Infos;
            }
            catch (HttpRequestException ex)
            {
                return tb_Classe_Infos;
            }
            catch (Exception ex)
            {
                return tb_Classe_Infos;
            }
            finally
            {

            }
        }


        //Metodo para poder trazer a lista de Curso
        public async Task<List<tb_curso_Info>> ListaDeCursos()
        {

            List<tb_curso_Info> tb_Curso_Infos = null;

            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Curso");
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_curso_Info>>(responseString);
                return json;
            }
            catch (JsonException ex)
            {
                return tb_Curso_Infos;
            }
            catch (HttpRequestException ex)
            {
                return tb_Curso_Infos;
            }
            catch (Exception ex)
            {
                return tb_Curso_Infos;
            }
            finally
            {

            }

        }

        /// <summary>
        /// Metodo Responsavel Para fazer a matricula de um aluno
        /// </summary>
        public async Task<string> Matricular_se(tb_matricula_Info tb_Matricula)
        {

            try
            {
                var connection = CrossConnectivity.Current.IsConnected;
                if (connection == false)
                {
                    return "Verifica a sua conexao de internet";
                }
                else if (string.IsNullOrEmpty(tb_Matricula.Altura) == true)
                {
                    return "Campo altura vazio prencha";
                }
                else if (string.IsNullOrEmpty(tb_Matricula.Data_De_Nascimento) == true)
                {
                    return "Seleciona data de nascimento";
                }
                //else if (string.IsNullOrEmpty(enderecorigem) == true)
                //{
                //    return "Campo endereco de origem vazio prencha o campo";
                //}
                //else if (string.IsNullOrEmpty(enderecodestino) == true)
                //{
                //    return "Campo endereco de destino vazio prencha o campo";
                //}
                //else if (string.IsNullOrEmpty(Convert.ToString(peso)) == true)
                //{
                //    return "Campo peso vazio prencha o campo";
                //}
                //else if (string.IsNullOrEmpty(idcategoriacarga) == true)
                //{
                //    return "Seleciona a categotria da carga";
                //}
                //else if (string.IsNullOrEmpty(idmunicipiorigem) == true)
                //{
                //    return "Seleciona o municpio de origem";
                //}
                //else if (string.IsNullOrEmpty(idmunicipiodestino) == true)
                //{
                //    return "Seleciona o municpio de destino";
                //}
                else
                {

                    var json = JsonConvert.SerializeObject(tb_Matricula);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var client = new HttpClient())
                    {
                        string URL = string.Concat(ConfigSystem.URLAPI, "/Matricula");
                        var result = await client.PostAsync(URL, content);
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var error = await result.Content.ReadAsStringAsync();
                            return error;
                        }
                        else if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        {
                            var error = await result.Content.ReadAsStringAsync();
                            return error;
                        }
                        else
                        {
                            var error = await result.Content.ReadAsStringAsync();
                            return error;
                        }
                    };
                }
            }
            catch (JsonException ex)
            {
                return ex.Message;
            }
            catch (HttpRequestException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {

            }


        }
    }
}
