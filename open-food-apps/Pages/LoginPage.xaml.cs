using open_food_apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Logique d'interaction pour LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        GlobalData globalDt;
        public LoginPage(GlobalData globalData)
        {
            globalDt = globalData;
            InitializeComponent();
        }

        private void btn_lg_validate_Click(object sender, RoutedEventArgs e)
        {
            IContact contact = new Contact(globalDt);

            
            //bool stateRequest = contact.Connect(txtBox_lg_email.Text, contact.EncryptMdp(txtBox_lg_password.Password));
            bool stateRequest = contact.Connect(txtBox_lg_email.Text, txtBox_lg_password.Password);

            if(stateRequest)
            {
                btn_lg_validate.Background = Brushes.Green;

                Menu page = new Menu(globalDt);
                NavigationService.Navigate(page);
            }
            else
            {
                btn_lg_validate.Background = Brushes.Red;
                
            }
        }
    }
}
