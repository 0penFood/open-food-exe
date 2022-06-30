using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace open_food_apps.Models
{
    internal interface IContact
    {
        bool Connect(string email, string password);
        string EncryptMdp(string password);

        Task<string> RecoverDataAllUser();
        Task<string> PostUser(Dictionary<string, string> keyValues, string type);
    }
}
