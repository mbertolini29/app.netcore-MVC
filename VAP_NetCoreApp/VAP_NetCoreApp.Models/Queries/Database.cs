using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAP_NetCoreApp.Models.Queries
{
    /// <summary>
    /// Queries de Users
    /// </summary>
    public class Database
    {
        public Users Users { get; set; }

        public Database()
        {
            Users = new Users();
        }
    }
}
