using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SmartInfo.Menu;
using SmartInfo.Views;
using Xamarin.Forms.Xaml;

namespace SmartInfo
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            menuList = new List<MasterPageItem>();
            // incluindo items de menu e definindo : title ,page and icon
                        menuList.Add(new MasterPageItem()
                        {
                            Title = "Informações Academicas",
                            Icon = "InformacoesAcademicas.png",
                            TargetType =
                   typeof(InformacoesAcademicasView)
                        });
                        menuList.Add(new MasterPageItem()
                        {
                            Title = "Secretária",
                            Icon = "Secretaria.png",
                            TargetType =
                         typeof(SecretariaView)
                        });
                       //menuList.Add(new MasterPageItem()
                       // {
                       //     Title = "Confirmação",
                       //     Icon = "iconConfrimacao.png",
                       //     TargetType =
                       //     typeof(ConfirmacaoView)
                       // });
                        menuList.Add(new MasterPageItem()
                        {
                            Title = "Actividades",
                            Icon = "Actividade.png",
                            TargetType =
                            typeof(ActividadeView)
                        });
                        menuList.Add(new MasterPageItem()
                        {
                            Title = "Novidades",
                            Icon = "Novidade.png",
                            TargetType =
                        typeof(NovidadeView)
                        }); menuList.Add(new MasterPageItem()
                        {
                            Title = "Localização Da Instituição",
                            Icon = "iconLozalizacao.png",
                            TargetType =
                            typeof(LocalizacaoSmartbits)
                        });
                     menuList.Add(new MasterPageItem()
                        {
                            Title = "Sobre",
                            Icon = "icons8About.png",
                            TargetType =
                   typeof(ConfiguracaoPage)
                        });


            // Configurando o ItemSource fpara o ListView na MainPage.xaml
            paginaMestreList.ItemsSource = menuList;
                        // navegação inicial
                        Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(InformacoesAcademicasView)));
        }


        // Evento para a seleção de item no menu
        // trata a seleção do usuário no ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
