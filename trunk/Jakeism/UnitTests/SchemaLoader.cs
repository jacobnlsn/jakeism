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
            var cfg = new Configuration().Configure();
            var schemaExport = new SchemaExport(cfg);
            schemaExport.SetOutputFile(@"C:\New folder\jakeism.sql");
            schemaExport.Create(true, true);
        }
    }
}
