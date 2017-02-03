// -----------------------------------------------------------------------
// <copyright file="Product.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------
namespace Api.test.Business
{
    public class Product : IEntity
    {
        public string Name { get; set; }

        public double ExpectedValue { get; set; }

        public int Tickets { get; set; }

        public string UserId { get; set; }
        public string Id { get; set; }
    }
}