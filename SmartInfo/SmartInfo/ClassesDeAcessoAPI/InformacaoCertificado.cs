using Newtonsoft.Json;
using SmartInfo.Info;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartInfo.ClassesDeAcessoAPI
{
  public  class InformacaoCertificado
    {
        //Metodo Para Buscar Uma Lista De Cursos Na Web API
        public async Task<List<tb_instrucao_de_levantar_certificado_Info>> ListaInformacoesCertificadoJson()
        {
            List<tb_instrucao_de_levantar_certificado_Info> tb_Instrucao_De_Levantar_Certificado_Infos = null;
            try
            {
                var client = new HttpClient();
                string url = string.Format("{0}/InstrucaoDeLevantarCertificado", ConfigSystem.URLAPI);
                var uri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(uri);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<tb_instrucao_de_levantar_certificado_Info>>(responseString);
                return json;

            }
            catch (JsonException ex)
            {
                string ERRO = ex.Message;
                return tb_Instrucao_De_Levantar_Certificado_Infos;
            }
            catch (HttpRequestException)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return tb_Instrucao_De_Levantar_Certificado_Infos;
            }
            catch (Exception)
            {
                //await DisplayAlert("Resultado", ex.Message, "OK");
                return tb_Instrucao_De_Levantar_Certificado_Infos;
            }
            finally
            {

            }
        }
    }
}
