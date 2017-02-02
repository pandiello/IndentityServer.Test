// -----------------------------------------------------------------------
// <copyright file="User.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------
namespace Api.test.Business
{
    public class User : IEntity
    {
        public string Id { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}