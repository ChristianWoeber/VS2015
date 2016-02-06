using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrator
{
    public class DbMigrator
    {
        private ILogger _logger;

        public DbMigrator(ILogger logger)
        {
            _logger = logger;
        }

        public void Migrate()
        {
            _logger.LogInfo("Migration startet at " + DateTime.Now);
            _logger.LogInfo("Migration ended at " + DateTime.Now.AddSeconds(300));
        }
    }
}
