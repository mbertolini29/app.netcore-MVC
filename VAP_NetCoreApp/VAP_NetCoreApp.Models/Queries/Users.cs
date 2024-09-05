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

        /// <summary
        /// Crea un nuevo usuario en la tabla user
        /// </summary
        /// <param name ="user">Objeto usuario con las propiedades a guardar</param>
        /// <returns>BaseResult indicando si se agrego el registro o si hubo un error, muestra el mensaje en Message</returns>        
        public BaseResult Create(User user)
        {
            var rowsAffected = 0;
            using (var db = GetConnection())
            {
                rowsAffected = db.Execute(@"INSERT INTO [User] (Email, Balance, Age, RoleID) 
                                                 VALUES (@Email, @Balance, @Age, @RoleID)", user); 
            }
            
            return new BaseResult
            {
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? string.Empty : "Por favor contactanos para revisar el problema con este usuario."
            };
        }
    }
}
