using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartInfo.Info;

namespace SmartInfo.ClassesDeAcessoAPI
{
  public  class ClasseAPI
    {
        //Metodo Para Buscar Uma Lista De Cursos Na Web API
        public async Task<List<tb_classe_Info>> ListaClassesJson()
        {
            List<tb_classe_Info> tb_Classe_Infos = null;
            try
            {
                var client = new HttpClient();
                string url = string.Format("{0}/Classe", ConfigSystem.URLAPI);
                var uri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_classe_Info>>(responseString);
                return json;

            }
            catch (JsonException ex)
            {
                string ERRO = ex.Message;
                return tb_Classe_Infos;
            }
            catch (HttpRequestException)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return tb_Classe_Infos;
            }
            catch (Exception)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return tb_Classe_Infos;
            }
            finally
            {

            }
        }
    }
}
