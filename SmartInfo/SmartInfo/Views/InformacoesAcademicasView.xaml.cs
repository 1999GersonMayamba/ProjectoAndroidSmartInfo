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
    public partial class InformacoesAcademicasView : ContentPage
    {
        public InformacoesAcademicasView()
        {
            InitializeComponent();
        }

        private async void Btn_Cursos_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            await Navigation.PushAsync(new CursosPageView());
            IndicadorDeActividade.IsRunning = false;
        }

        private async void Btn_Classes_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            await Navigation.PushAsync(new ClassesPageView());
            IndicadorDeActividade.IsRunning = false;
        }

        private async void Btn_Disciplinas_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            await Navigation.PushAsync(new DisciplinaPageView());
            IndicadorDeActividade.IsRunning = false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            await Navigation.PushAsync(new QuadroDeHonraPageView());
            IndicadorDeActividade.IsRunning = false;
        }

        private async void Btn_Professores_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            await Navigation.PushAsync(new ProfessorPageView());
            IndicadorDeActividade.IsRunning = false;
        }

        private async void Btn_Calendario_Provas_Clicked(object sender, EventArgs e)
        {
            IndicadorDeActividade.IsRunning = true;
            await Navigation.PushAsync(new CalendarioProvasView());
            IndicadorDeActividade.IsRunning = false;
        }
    }
}