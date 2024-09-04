using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAP_NetCoreApp.Models.Queries
{
    public class Users : BaseQuery
    {
        public Users() : base() { }

        /// <summary
        /// Mostrar todos los usuarios en la tabla
        /// </summary
        public List<User> GetAll()
        {
            var users = new List<User>();
            using (var db = GetConnection())
            {
                users = db.Query<User>(@"SELECT * FROM [User]").ToList();
            }
            return users;
        }
    }
}
