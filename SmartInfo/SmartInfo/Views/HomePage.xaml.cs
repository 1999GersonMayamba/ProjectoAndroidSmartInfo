using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartInfo.Info;

namespace SmartInfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<tb_inicio_Info> listItems = new List<tb_inicio_Info>();
            tb_inicio_Info listItem1 = new tb_inicio_Info() {Titulo = "Visita Na Instituição", UrlImage = "Incursao.jpg", Descricao = "Mais uma incursão com objectivo de apresentar oque a SMARTBITS tem feito e algumas palestras de orientação vocacional com o Prof. Gerson Ndongala." };
            tb_inicio_Info listItem2 = new tb_inicio_Info() { Titulo = "Parceria Smartbits #Evolution", UrlImage = "Parceria.jpg", Descricao = "Na manhã de hoje, Os Dirigentes do IMP-Smartbits visitaram a empresa #Evolution que actua no ramo das telecomunicações para estabelecer parcerias..." };
            tb_inicio_Info listItem3 = new tb_inicio_Info() { Titulo = "ITEL CONSAGRA-SE VENCEDOR DA 2ª EDIÇÃO DA MARATONA DE PROGRAMAÇÃO", UrlImage = "FeiraItel1.jpg", Descricao = "Decorreu hoje 20 de Setembro de 2019 no Instituto de Telecomunicação-ITEL a 2ª Edição da Maratona de Programação na qual participaram as instituições ITEL, IPIL (ex-IMIL), IMCL, SMARTBITS e IMPTEL. Ao término da competição estriveram nas três primeiras posições:1º Lugar - Instituto de Telecomunicações - ITEL\n2º Lugar - Instituto Politécnico Industrial de Luanda – IPIL(ex - IMIL)\n 3 º Lugar - Instituto Médio Técnico SMARTBITS" };
            tb_inicio_Info listItem4 = new tb_inicio_Info() { Titulo = "ITEL CONSAGRA-SE VENCEDOR DA 2ª EDIÇÃO DA MARATONA DE PROGRAMAÇÃO", UrlImage = "FeiraItel2.jpg", Descricao = "Decorreu hoje 20 de Setembro de 2019 no Instituto de Telecomunicação-ITEL a 2ª Edição da Maratona de Programação na qual participaram as instituições ITEL, IPIL (ex-IMIL), IMCL, SMARTBITS e IMPTEL. Ao término da competição estriveram nas três primeiras posições:1º Lugar - Instituto de Telecomunicações - ITEL\n2º Lugar - Instituto Politécnico Industrial de Luanda – IPIL(ex - IMIL)\n 3 º Lugar - Instituto Médio Técnico SMARTBITS" };
            tb_inicio_Info listItem5 = new tb_inicio_Info() { Titulo = "Baile Dos Finalistas 2017", UrlImage = "BaileFinalista.jpg", Descricao = "Baile dos Finalistas, foi um sucesso...Animação,música boa e mui surpresas!" };
            tb_inicio_Info listItem6 = new tb_inicio_Info() { Titulo = "Primeira PAP Da Instituição", UrlImage = "Finalistas2017.jpg", Descricao = "Foram 3 anos de mui batalha mas como lutaram com garra, hoje são considerados #Técnicos_Médio.Bem haja ao SMARTBITS e aos primeiros finalistas." };
            tb_inicio_Info listItem7 = new tb_inicio_Info() { Titulo = "Primerios Finalistas Da Instituição", UrlImage = "Finalistas20172.jpg", Descricao = "Foram 3 anos de mui batalha mas como lutaram com garra, hoje são considerados #Técnicos_Médio.Bem haja ao SMARTBITS e aos primeiros finalistas." };
            listItems.Add(listItem1);
            listItems.Add(listItem2);
            listItems.Add(listItem3);
            listItems.Add(listItem4);
            listItems.Add(listItem5);
            listItems.Add(listItem6);
            listItems.Add(listItem7);
            ListaDeNoticias.ItemsSource = listItems;
        }

        private void Btn_Ver_Mais_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var pedidosItem = button?.BindingContext as tb_inicio_Info;            
        }
    }
}