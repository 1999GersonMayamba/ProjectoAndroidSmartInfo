using Newtonsoft.Json;
using SmartInfo.Info;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartInfo.ClassesDeAcessoAPI
{
  public  class Actividade
    {

        //Metodo para poder trazer a lista de Categoria 
        public async Task<List<tb_duracao_da_actividade_Info>> ListaDeCategoriaActividade()
        {
            List<tb_duracao_da_actividade_Info> tb_Duracao_Da_Actividade_Infos = null;

            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/TempoDeActividade");
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_duracao_da_actividade_Info>>(responseString);
                return json;
            }
            catch (JsonException)
            {
                return tb_Duracao_Da_Actividade_Infos;
            }
            catch (HttpRequestException)
            {
                return tb_Duracao_Da_Actividade_Infos;
            }
            catch (Exception)
            {
                return tb_Duracao_Da_Actividade_Infos;
            }
            finally
            {

            }
        }

        //Metodo para poder trazer a lista de Novidade
        public async Task<List<tb_actividade_Info>> ListaDeActividade()
        {
            List<tb_actividade_Info> tb_Actividade_Infos = null;

            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Actividade");
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_actividade_Info>>(responseString);
                return json;
            }
            catch (JsonException)
            {
                return tb_Actividade_Infos;
            }
            catch (HttpRequestException)
            {
                return tb_Actividade_Infos;
            }
            catch (Exception)
            {
                return tb_Actividade_Infos;
            }
            finally
            {

            }
        }

        //Metodo para poder trazer a lista de Categoria 
        public async Task<List<tb_actividade_Info>> ListaDeActividadePorCategoria(string _id_categoria)
        {
            List<tb_actividade_Info> tb_Actividade_Infos = null;

            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Actividade/Duracao=", _id_categoria);
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_actividade_Info>>(responseString);
                return json;
            }
            catch (JsonException)
            {
                return tb_Actividade_Infos;
            }
            catch (HttpRequestException)
            {
                return tb_Actividade_Infos;
            }
            catch (Exception)
            {
                return tb_Actividade_Infos;
            }
            finally
            {

            }
        }
    }
}
