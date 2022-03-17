using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watch_List.Models;

namespace Watch_List.Classes
{
    public static class AdditionalExtensions
    {
        /// <summary>
        /// Removes the last char element
        /// </summary>
        /// <param name="data">your string</param>
        public static void RemoveLastElement(this string data)
        {
            if(data.Length > 0)
            {
                //data = data.Substring(0, data.Length - 1);
                data = data.Remove(data.Length - 1, 1);
            }            
        }
        /// <summary>
        /// If user in db return UserErrorType object, else return null
        /// </summary>
        /// <returns>UserErrorType or null</returns>
        public static Error? TryCheckUniqueness(this List<User> users, User user)
        {
            foreach (var userDb in users)
            {
                if (userDb.Login == user.Login) { return new Error() { Message = UserErrorType.LoginError }; }
                if (userDb.Email == user.Email) { return new Error() { Message = UserErrorType.EmailError }; }
            }

            return null;
        }      
    }
}
