using open_food_apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace open_food_apps.Pages
{
    /// <summary>
    /// Logique d'interaction pour ListUserPage.xaml
    /// </summary>
    public partial class ListUserPage : Page
    {
        GlobalData globalDt;
        string UserList { get; set; }

        public ListUserPage(GlobalData globalData)
        {
            globalDt = globalData;
            InitializeComponent();
            GetInfoAllUser();
        }

        private void GetInfoAllUser()
        {
            IContact contact = new Contact(globalDt);

            
            //lbl_listUser_test.Content = contact.RecoverDataAllUser();
        }

        private void btn_userpg_adduser_Click(object sender, RoutedEventArgs e)
        {
            CreateUserPage page = new CreateUserPage(globalDt);
            NavigationService.Navigate(page);
        }
    }
}
