using Newtonsoft.Json;
using SmartInfo.Info;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartInfo.ClassesDeAcessoAPI
{
      public  class Professor
        {
        //Metodo Para Buscar Uma Lista De professores Na Web API
        public async Task<List<tb_professor_Info>> ListaDeProfessoresJson()
        {
            List<tb_professor_Info> tb_Professor_Infos = null;
            try
            {
                var client = new HttpClient();
                string url = string.Format("{0}/Professor", ConfigSystem.URLAPI);
                var uri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_professor_Info>>(responseString);
                return json;

            }
            catch (JsonException ex)
            {
                string ERRO = ex.Message;
                return tb_Professor_Infos;
            }
            catch (HttpRequestException)
            {
                return tb_Professor_Infos;
            }
            catch (Exception)
            {
                return tb_Professor_Infos;
            }
            finally
            {

            }
        }
    }
}
