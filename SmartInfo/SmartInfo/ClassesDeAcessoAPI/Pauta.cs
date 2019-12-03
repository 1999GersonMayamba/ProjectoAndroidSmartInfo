using Newtonsoft.Json;
using SmartInfo.Info;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartInfo.ClassesDeAcessoAPI
{
   public class Pauta
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

        //Metodo para poder trazer a lista de Ano Lectivo
        public async Task<List<tb_ano_Info>> ListaDeAnoLectivo()
        {

            List<tb_ano_Info> tb_Ano_Infos = null;

            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Ano");
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_ano_Info>>(responseString);
                return json;
            }
            catch (JsonException ex)
            {
                return tb_Ano_Infos;
            }
            catch (HttpRequestException ex)
            {
                return tb_Ano_Infos;
            }
            catch (Exception ex)
            {
                return tb_Ano_Infos;
            }
            finally
            {

            }

        }


        //Metodo para poder trazer a pauta
        public async Task<tb_curso_de_informatica10_Info> ListaDePauta10Informatica(string BI, string ID_Trimestre, string Id_Ano_Lectivo, int Classe, string Curso)
        {
            tb_curso_de_informatica10_Info tb_Curso_De_Informatica = null;
            try



            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Boletim/BI=", BI, "/TR=", ID_Trimestre, "/AN=", Id_Ano_Lectivo, "/CL=", Classe, "/CR=", Curso);
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<tb_curso_de_informatica10_Info>(responseString);
                return json;

            }
            catch (JsonException ex)
            {
                return tb_Curso_De_Informatica;
            }
            catch (HttpRequestException ex)
            {
                return tb_Curso_De_Informatica;
            }
            catch (Exception ex)
            {
                return tb_Curso_De_Informatica;
            }
            finally
            {

            }

        }


        //Metodo para poder trazer a pauta
        public async Task<tb_curso_de_informatica11_Info> ListaDePauta11Informatica(string BI, string ID_Trimestre, string Id_Ano_Lectivo, int Classe, string Curso)
        {
            tb_curso_de_informatica11_Info tb_Curso_De_Informatica = null;
            try



            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Boletim/BI=", BI, "/TR=", ID_Trimestre, "/AN=", Id_Ano_Lectivo, "/CL=", Classe, "/CR=", Curso);
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<tb_curso_de_informatica11_Info>(responseString);
                return json;

            }
            catch (JsonException ex)
            {
                return tb_Curso_De_Informatica;
            }
            catch (HttpRequestException ex)
            {
                return tb_Curso_De_Informatica;
            }
            catch (Exception ex)
            {
                return tb_Curso_De_Informatica;
            }
            finally
            {

            }

        }



        //Metodo para poder trazer a pauta
        public async Task<tb_curso_de_informatica12_Info> ListaDePauta12Informatica(string BI, string ID_Trimestre, string Id_Ano_Lectivo, int Classe, string Curso)
        {
            tb_curso_de_informatica12_Info tb_Curso_De_Informatica = null;
            try



            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Boletim/BI=", BI, "/TR=", ID_Trimestre, "/AN=", Id_Ano_Lectivo, "/CL=", Classe, "/CR=", Curso);
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<tb_curso_de_informatica12_Info>(responseString);
                return json;

            }
            catch (JsonException ex)
            {
                return tb_Curso_De_Informatica;
            }
            catch (HttpRequestException ex)
            {
                return tb_Curso_De_Informatica;
            }
            catch (Exception ex)
            {
                return tb_Curso_De_Informatica;
            }
            finally
            {

            }

        }


        //Metodo para poder trazer a pauta
        public async Task<tb_curso_de_informatica13_Info> ListaDePauta13Informatica(string BI, string ID_Trimestre, string Id_Ano_Lectivo, int Classe, string Curso)
        {
            tb_curso_de_informatica13_Info tb_Curso_De_Informatica = null;
            try



            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Boletim/BI=", BI, "/TR=", ID_Trimestre, "/AN=", Id_Ano_Lectivo, "/CL=", Classe, "/CR=", Curso);
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<tb_curso_de_informatica13_Info>(responseString);
                return json;

            }
            catch (JsonException ex)
            {
                return tb_Curso_De_Informatica;
            }
            catch (HttpRequestException ex)
            {
                return tb_Curso_De_Informatica;
            }
            catch (Exception ex)
            {
                return tb_Curso_De_Informatica;
            }
            finally
            {

            }

        }



        //Metodo para poder trazer a pauta
        public async Task<tb_curso_de_electronica10_Info> ListaDePauta10Electronica(string BI, string ID_Trimestre, string Id_Ano_Lectivo, int Classe, string Curso)
        {
            tb_curso_de_electronica10_Info tb_Curso_De_Electronica10_Infos = null;
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Boletim/BI=", BI, "/TR=", ID_Trimestre, "/AN=", Id_Ano_Lectivo, "/CL=", Classe, "/CR=", Curso);
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<tb_curso_de_electronica10_Info>(responseString);
                return json;
            }
            catch (JsonException ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            catch (HttpRequestException ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            catch (Exception ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            finally
            {

            }

        }


        //Metodo para poder trazer a pauta
        public async Task<tb_curso_de_electronica11_Info> ListaDePauta11Electronica(string BI, string ID_Trimestre, string Id_Ano_Lectivo, int Classe, string Curso)
        {
            tb_curso_de_electronica11_Info tb_Curso_De_Electronica10_Infos = null;
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Boletim/BI=", BI, "/TR=", ID_Trimestre, "/AN=", Id_Ano_Lectivo, "/CL=", Classe, "/CR=", Curso);
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<tb_curso_de_electronica11_Info>(responseString);
                return json;
            }
            catch (JsonException ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            catch (HttpRequestException ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            catch (Exception ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            finally
            {

            }

        }


        //Metodo para poder trazer a pauta
        public async Task<tb_curso_de_electronica12_Info> ListaDePauta12Electronica(string BI, string ID_Trimestre, string Id_Ano_Lectivo, int Classe, string Curso)
        {
           tb_curso_de_electronica12_Info tb_Curso_De_Electronica10_Infos = null;
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Boletim/BI=", BI, "/TR=", ID_Trimestre, "/AN=", Id_Ano_Lectivo, "/CL=", Classe, "/CR=", Curso);
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<tb_curso_de_electronica12_Info>(responseString);
                return json;
            }
            catch (JsonException ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            catch (HttpRequestException ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            catch (Exception ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            finally
            {

            }

        }


        //Metodo para poder trazer a pauta
        public async Task<tb_curso_de_electronica13_Info> ListaDePauta13Electronica(string BI, string ID_Trimestre, string Id_Ano_Lectivo, int Classe, string Curso)
        {
            tb_curso_de_electronica13_Info tb_Curso_De_Electronica10_Infos = null;
            try
            {
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
                string URL = string.Concat(ConfigSystem.URLAPI, "/Boletim/BI=", BI, "/TR=", ID_Trimestre, "/AN=", Id_Ano_Lectivo, "/CL=", Classe, "/CR=", Curso);
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<tb_curso_de_electronica13_Info>(responseString);
                return json;
            }
            catch (JsonException ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            catch (HttpRequestException ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            catch (Exception ex)
            {
                return tb_Curso_De_Electronica10_Infos;
            }
            finally
            {

            }

        }

    }
}
