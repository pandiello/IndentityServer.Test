// -----------------------------------------------------------------------
// <copyright file="Product.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------
namespace Api.test.Business
{
    using System.Collections.Generic;

    public class Product : IEntity
    {
        public string Name { get; set; }

        public double ExpectedValue { get; set; }

        public int TotalTicketsNumber { get; set; }

        public string UserId { get; set; }

        public string Id { get; set; }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}