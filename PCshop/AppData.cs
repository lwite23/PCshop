using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCshop
{
    public enum TableName
    {
        Users,
        Roles,
        Tovar, 
        Categories,
        Provider
    }
    internal class AppData
    {
        public static PCshopEntities db = new PCshopEntities();
    }
}
