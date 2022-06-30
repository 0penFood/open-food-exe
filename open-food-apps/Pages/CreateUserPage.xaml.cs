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
    /// Logique d'interaction pour CreateUserPage.xaml
    /// </summary>
    public partial class CreateUserPage : Page
    {
        GlobalData globalDt;

        public CreateUserPage(GlobalData globalData)
        {
            InitializeComponent();
            globalDt = globalData;
        }

        private void btn_createuser_create_Click(object sender, RoutedEventArgs e)
        {
            var dataDic = new Dictionary<string, string>();
            dataDic.Add("firstName",    txtbox_firstname.Text);
            dataDic.Add("lastName",     txtbox_lastname.Text);
            dataDic.Add("email",        txtbox_email.Text);
            dataDic.Add("phone",        txtbox_phone.Text);
            dataDic.Add("password",     txtbox_password.Password);

            IContact contact = new Contact(globalDt);


            contact.PostUser(dataDic, cbxbox_acType.Text).Wait();
        }
    }
}
