using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartInfo.Info;

namespace SmartInfo.ClassesDeAcessoAPI
{
  public  class Quadro_De_Honra
    {
        //Metodo Para Buscar Uma Lista De Cursos Na Web API
        public async Task<List<tb_quadro_de_honra_Info>> ListaAlunosJson()
        {
            List<tb_quadro_de_honra_Info> tb_Quadro_De_Honra_Infos = null;
            try
            {
                var client = new HttpClient();
                string url = string.Format("{0}/QuadroDeHonra", ConfigSystem.URLAPI);
                var uri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_quadro_de_honra_Info>>(responseString);
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
    }
}
