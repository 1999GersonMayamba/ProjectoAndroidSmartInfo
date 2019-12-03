/*Gerado no Gerador de Codigo Do Engº Gerson Z. Maiamba
Data: 09/11/2019 15:41:17
Direitos autorais de Engº Gerson Z. Maiamba*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SmartInfo.Info
{
	public class tb_instrucao_de_pagamento_Info
		{
			public string Id_Instrucao{ get; set; }
			public string Id_Classe{ get; set; }
			public string Id_Curso{ get; set; }
            public string Classe { get; set; }
            public string Curso { get; set; }
            public string Valor{ get; set; }
			public string IBAN{ get; set; }
			public string Numero_Da_Conta{ get; set; }
			public string Descricao{ get; set; }
			public string Banco{ get; set; }
			public string Opcao{ get; set; }
		}
}
