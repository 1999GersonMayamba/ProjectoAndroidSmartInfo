using Newtonsoft.Json;
using SmartInfo.Info;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartInfo.ClassesDeAcessoAPI
{
  public  class Novidade
    {
        //Metodo para poder trazer a lista de Categoria 
        public async Task<List<tb_categoria_novidade_Info>> ListaDeCategoriaNovidade()
        {
            List<tb_categoria_novidade_Info> tb_Categoria_Novidade_Infos = null;

            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/TempoDeNovidade");
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_categoria_novidade_Info>>(responseString);
                return json;
            }
            catch (JsonException)
            {
                return tb_Categoria_Novidade_Infos;
            }
            catch (HttpRequestException)
            {
                return tb_Categoria_Novidade_Infos;
            }
            catch (Exception)
            {
                return tb_Categoria_Novidade_Infos;
            }
            finally
            {

            }
        }

        //Metodo para poder trazer a lista de Novidade
        public async Task<List<tb_novidade_Info>> ListaDeNovidade()
        {
            List<tb_novidade_Info> tb_Novidade_Infos = null;

            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Novidade");
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_novidade_Info>>(responseString);
                return json;
            }
            catch (JsonException)
            {
                return tb_Novidade_Infos;
            }
            catch (HttpRequestException)
            {
                return tb_Novidade_Infos;
            }
            catch (Exception)
            {
                return tb_Novidade_Infos;
            }
            finally
            {

            }
        }

        //Metodo para poder trazer a lista de Categoria 
        public async Task<List<tb_novidade_Info>> ListaDeNovidadePorCategoria(string _id_categoria)
        {
            List<tb_novidade_Info> tb_Novidade_Infos = null;

            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Novidade/Categoria=", _id_categoria);
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_novidade_Info>>(responseString);
                return json;
            }
            catch (JsonException)
            {
                return tb_Novidade_Infos;
            }
            catch (HttpRequestException)
            {
                return tb_Novidade_Infos;
            }
            catch (Exception)
            {
                return tb_Novidade_Infos;
            }
            finally
            {

            }
        }
    }
}
