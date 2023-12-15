using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string Password = "3";
            string Login = "user";
            bool assert = UserTest.ValidatedUser(Login, Password);
            Assert.IsFalse(assert);
        }
        [TestMethod]
        public void TestMethod2() 
        {
            string Password = "1";
            string Login = "1";
            bool assert = UserTest.ValidatedUser(Login, Password);
            Assert.IsTrue(assert);
        }
        [TestMethod]
        public void TestMethod3() 
        {
            string Password = "1";
            string Login = "2";
            bool assert = UserTest.ValidatedUser(Login, Password);
            Assert.IsFalse(assert);
        }
        [TestMethod]
        public void TestMethod4()
        {
           
            string TovarName = "3070";
            string Categories = "category";
            string Price = "34000";
            bool assert = UserTest.TovarTest(TovarName, Categories, Price);
            Assert.IsFalse(assert);
            
        }
        [TestMethod]
        public void TestMethod5()
        {
            string TovarName = "3080ti";
            string Categories = "Видеокарта";
            string Price = "30000";
            bool assert = UserTest.TovarTest(TovarName, Categories, Price);
            Assert.IsTrue(assert);
        }


    }
}
