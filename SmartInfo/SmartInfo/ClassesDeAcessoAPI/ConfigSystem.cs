using System;
using System.Collections.Generic;
using System.Text;

namespace SmartInfo.ClassesDeAcessoAPI
{
    //Classe aonde Possui Todas as Propriedades, aonde Ficam Armazenado os Arquivos De Configuracao Do Sistema
    public static class ConfigSystem
    {
        //"http://webapi.digitransporte.com"
        private static string urlapi = "http://192.168.1.234:8083/api"; //http://doriasoft.ddns.net:8181/api/Cliente


        public static string URLAPI
        {
            get { return urlapi; }
        }
        
    }
}
