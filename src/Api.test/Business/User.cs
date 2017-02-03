// -----------------------------------------------------------------------
// <copyright file="User.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------
namespace Api.test.Business
{
    using System.Collections.Generic;

    public class User : IEntity
    {
        public string Id { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}