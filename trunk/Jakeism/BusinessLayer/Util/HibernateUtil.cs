using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace BusinessLayer.Util
{
    public class HibernateUtil
    {
        private static ISessionFactory SessionFactory = BuildSessionFactory();
        private static ISessionFactory BuildSessionFactory()
        {
            try
            {
                return new Configuration().Configure().BuildSessionFactory();
            }
            catch (TypeInitializationException)
            {
                // TODO: throw a meaningful exception here
                throw new Exception("Unable to create SessionFactory.");
            }
        }

        public static ISessionFactory GetSessionFactory()
        {
            return SessionFactory;
        }
    }
}
