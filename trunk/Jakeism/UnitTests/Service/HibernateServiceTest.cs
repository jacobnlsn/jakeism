using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Cfg;
using NUnit.Framework;
using BusinessLayer.Domain;
using BusinessLayer.Service;

namespace UnitTests.Service
{
    [TestFixture]
    public class HibernateServiceTest
    {

        [Test]
        public void TestSave()
        {
            using (var service = new HibernateService())
            {
                User user = new User();
                user.UserName = "hello world";
                user.Password = "password";
                user.IsAdmin = false;
                service.Save(user);
            }
        }
    }
}
