using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartInfo.Info;

namespace SmartInfo.ClassesDeAcessoAPI
{
   public class Curso
    {
        //Metodo Para Buscar Uma Lista De Cursos Na Web API
        public async Task<List<tb_curso_Info>> ListaCursosJson()
        {
            List<tb_curso_Info> listaDecursos = null;
            try
            {
                var client = new HttpClient();
                string url = string.Format("{0}/Curso", ConfigSystem.URLAPI);
                var uri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_curso_Info>>(responseString);
                return json;

            }
            catch (JsonException ex)
            {
                string ERRO = ex.Message;
                return listaDecursos;
            }
            catch (HttpRequestException)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return listaDecursos;
            }
            catch (Exception)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return listaDecursos;
            }
            finally
            {

            }
        }

    }
}
