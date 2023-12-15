using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCshop
{
    public class UserTest
    {
        public static bool ValidatedUser(string Login, string Password)
        {
            if (Login == null || Password == null)
                return false;
            else if (Password == "1" && Login == "1") return true;
            else return false;
        }
        public static bool ValidateBack(bool click)
        {
            if (click == true)
            {
                return true;
            }
            return false;
        }
        public static bool ValidateValue(string value)
        {
            if (!int.TryParse(value, out var result))
                return false;
            else return true;
        }
        public static bool TovarTest(string TovarName, string Category,string Price)
        {
            if (TovarName == null || Category == null || Price == null)
                return false;
            else if (TovarName == "ASUS 3080ti" && Category == "Видеокарта" && Price == "30000") return true;
            else return false;
        }
    }
}
