using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace UnitTests
{
/// <summary>
    /// Unit test that reloads the database schema based on Hibernate mapping files.
    /// </summary>
    [TestFixture]
    public class SchemaLoader
    {
        // Enable this test to reload the schema
        [Test]
        public void ReloadSchema()
        {
            var cfg = new Configuration();
            IDictionary<string, string> props = new Dictionary<string, string>();
            props.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            props.Add("dialect", "NHibernate.Dialect.MySQLDialect");
            props.Add("connection.driver_class", "NHibernate.Driver.MySqlDataDriver");
            props.Add("connection.connection_string", "User ID=ttreat;Password=jakeismdev;Data Source=my01.winhost.com;Database=mysql_18514_jakeism");

            // Does not contain correct connection string because we do not want to reload the schema on
            // the production database.

            cfg.AddProperties(props);
            cfg.AddAssembly(typeof(User).Assembly);

            var schemaExport = new SchemaExport(cfg);
            schemaExport.SetOutputFile("c:/db_monitor.sql");
            schemaExport.Create(true, true);
        }
    }
}
