﻿using System;
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
        Provider,
        Applications
    }
    internal class AppData
    {
        public static PCshopEntities1 db = new PCshopEntities1();
    }
}
