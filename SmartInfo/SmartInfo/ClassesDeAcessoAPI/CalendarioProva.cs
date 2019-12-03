using Newtonsoft.Json;
using SmartInfo.Info;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartInfo.ClassesDeAcessoAPI
{
      public  class CalendarioProva
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


        //Metodo para poder trazer a lista de Trimestre
        public async Task<List<tb_trimestre_Info>> ListaDeTrimestre()
        {
            List<tb_trimestre_Info> tb_Trimestre_Infos = null;

            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Trimestre");
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_trimestre_Info>>(responseString);
                return json;
            }
            catch (JsonException ex)
            {
                return tb_Trimestre_Infos;
            }
            catch (HttpRequestException ex)
            {
                return tb_Trimestre_Infos;
            }
            catch (Exception ex)
            {
                return tb_Trimestre_Infos;
            }
            finally
            {

            }
        }



        //Metodo para poder trazer a lista de Calendario das provas de uma determinada classe 
        // um determinado trimestre e um curso
        public async Task<List<tb_calendario_prova_Info>> ListaDeProvas(string _id_trimestre, string _id_curso, string _id_classe)
        {
            List<tb_calendario_prova_Info> tb_Calendario_Prova_Infos = null;

            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/CalendarioProvas/TR=", _id_trimestre, "/CL=", _id_classe, "/CR=", _id_curso);  // /CL=/CR=
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_calendario_prova_Info>>(responseString);
                return json;
            }
            catch (JsonException ex)
            {
                return tb_Calendario_Prova_Infos;
            }
            catch (HttpRequestException ex)
            {
                return tb_Calendario_Prova_Infos;
            }
            catch (Exception ex)
            {
                return tb_Calendario_Prova_Infos;
            }
            finally
            {

            }
        }

    }
}
