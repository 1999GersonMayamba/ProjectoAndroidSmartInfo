using Newtonsoft.Json;
using SmartInfo.Info;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartInfo.ClassesDeAcessoAPI
{
  public  class InformacaoFalta
    {
        //Metodo Para Buscar Uma Lista De Cursos Na Web API
        public async Task<List<tb_instrucao_de_justificar_falta_Info>> ListaInformacoesJustificarFaltaJson()
        {
            List<tb_instrucao_de_justificar_falta_Info> tb_Instrucao_De_Justificar_Falta_Infos = null;
            try
            {
                var client = new HttpClient();
                string url = string.Format("{0}/InstrucaoDeJustificarFalta", ConfigSystem.URLAPI);
                var uri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_instrucao_de_justificar_falta_Info>>(responseString);
                return json;

            }
            catch (JsonException ex)
            {
                string ERRO = ex.Message;
                return tb_Instrucao_De_Justificar_Falta_Infos;
            }
            catch (HttpRequestException)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return tb_Instrucao_De_Justificar_Falta_Infos;
            }
            catch (Exception)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return tb_Instrucao_De_Justificar_Falta_Infos;
            }
            finally
            {

            }
        }
    }
}
