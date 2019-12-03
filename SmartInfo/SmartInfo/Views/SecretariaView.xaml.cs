using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartInfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SecretariaView : ContentPage
	{
		public SecretariaView ()
		{
			InitializeComponent ();
		}

        private async void Btn_Pagamento_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            await Navigation.PushAsync(new InformacoesDePagementoView());
            IndicadorDeActividade.IsRunning = false;
        }

        private async void Btn_Certificado_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            await Navigation.PushAsync(new InformacaoDeLevantarCertificadoView());
            IndicadorDeActividade.IsRunning = false;
        }

        private async void Btn_Faltas_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            await Navigation.PushAsync(new InformacoesJustificarFaltaView());
            IndicadorDeActividade.IsRunning = false;
        }

        private async void Btn_Notas_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            await Navigation.PushAsync(new PautasView());
            IndicadorDeActividade.IsRunning = false;
        }
    }
}