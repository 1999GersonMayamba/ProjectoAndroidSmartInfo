using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using SmartInfo.ClassesDeAcessoAPI;
using SmartInfo.Info;
using System.Threading.Tasks;

namespace SmartInfo.ClassesDeAcessoAPI
{
  public  class PagamentoPropina
    {
        //Metodo Para Buscar Uma Lista De Cursos Na Web API
        public async Task<List<tb_instrucao_de_pagamento_Info>> ListaInformacoesPagamnetoJson()
        {
            List<tb_instrucao_de_pagamento_Info> tb_Quadro_De_Honra_Infos = null;
            try
            {
                var client = new HttpClient();
                string url = string.Format("{0}/InstrucaoDePagamento", ConfigSystem.URLAPI);
                var uri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_instrucao_de_pagamento_Info>>(responseString);
                return json;

            }
            catch (JsonException ex)
            {
                string ERRO = ex.Message;
                return tb_Quadro_De_Honra_Infos;
            }
            catch (HttpRequestException)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return tb_Quadro_De_Honra_Infos;
            }
            catch (Exception)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return tb_Quadro_De_Honra_Infos;
            }
            finally
            {

            }
        }


        //Metodo Para Buscar Uma Lista De Cursos Na Web API
        public async Task<List<tb_instrucao_de_pagamento_Info>> ListaInformacoesPagamnetoPorParametroJson(string _classe, string _curso)
        {
            List<tb_instrucao_de_pagamento_Info> tb_Quadro_De_Honra_Infos = null;
            try
            {
                var client = new HttpClient();
                string url = string.Format("{0}/InstrucaoDePagamento/CL={1}/CR={2}", ConfigSystem.URLAPI, _classe, _curso);
                var uri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_instrucao_de_pagamento_Info>>(responseString);
                return json;

            }
            catch (JsonException ex)
            {
                string ERRO = ex.Message;
                return tb_Quadro_De_Honra_Infos;
            }
            catch (HttpRequestException)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return tb_Quadro_De_Honra_Infos;
            }
            catch (Exception)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return tb_Quadro_De_Honra_Infos;
            }
            finally
            {

            }
        }


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
            catch (JsonException)
            {
                return tb_Classe_Infos;
            }
            catch (HttpRequestException)
            {
                return tb_Classe_Infos;
            }
            catch (Exception)
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
            catch (JsonException)
            {
                return tb_Curso_Infos;
            }
            catch (HttpRequestException)
            {
                return tb_Curso_Infos;
            }
            catch (Exception)
            {
                return tb_Curso_Infos;
            }
            finally
            {

            }

        }
    }
}
