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
        /// Crea un nuevo usuario en la tabla user, usando un INSERT directo en C#
        /// </summary
        /// <param name ="user">Objeto usuario con las propiedades a guardar</param>
        /// <returns>BaseResult indicando si se agrego el registro o si hubo un error, muestra el mensaje en Message</returns>        
        public BaseResult CreateUsingSQLCode(User user)
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

        /// <summary
        /// Crea un nuevo usuario en la tabla user, usando un procedimiento almacenado.
        /// </summary
        /// <param name ="user">Objeto usuario con las propiedades a guardar</param>
        /// <returns>BaseResult indicando si se agrego el registro o si hubo un error, muestra el mensaje en Message</returns>        
        public BaseResult CreateUsingStoredProcedure(User user)
        {
            using (var db = GetConnection())
            {
                var result = db.QueryFirstOrDefault<BaseResult>(@"User_AddUser", new {
                    user.Email,
                    user.RoleID,
                    user.Balance,
                    user.Age
                }, commandType: System.Data.CommandType.StoredProcedure);


                return result ?? new BaseResult
                {
                    Success = false,
                    Message = "No se puede crear el usuario, el procedimiento no devolvió un resultado."
                };
            }
        }
    }
}
