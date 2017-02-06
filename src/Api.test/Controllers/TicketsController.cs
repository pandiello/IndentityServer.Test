namespace Api.test.Controllers
{
    using System;
    using System.Globalization;
    using AutoMapper;
    using Business;
    using Business.DataAccess;
    using DTO;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        private readonly IMapper ticketMapper;
        private readonly IRepository<Product> productsRepository;
        private readonly IRepository<User> usersRepository;
        private readonly IRepository<Ticket> ticketRepository;

        public TicketsController(IMapper ticketMapper, IRepository<Product> productsRepository, IRepository<User> usersRepository, IRepository<Ticket> ticketRepository)
        {
            if (ticketMapper == null)
            {
                throw new ArgumentNullException(nameof(ticketMapper));
            }

            if (productsRepository == null)
            {
                throw new ArgumentNullException(nameof(productsRepository));
            }

            if (usersRepository == null)
            {
                throw new ArgumentNullException(nameof(usersRepository));
            }

            if (ticketRepository == null)
            {
                throw new ArgumentNullException(nameof(ticketRepository));
            }

            this.ticketMapper = ticketMapper;
            this.productsRepository = productsRepository;
            this.usersRepository = usersRepository;
            this.ticketRepository = ticketRepository;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return new JsonResult(this.ticketMapper.Map<TicketDto>(this.ticketRepository.GetById(id))); ;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]TicketDto ticketDto)
        {
            if (ticketDto == null)
            {
                return new BadRequestObjectResult("Ticket argument is not present.");
            }

            Ticket ticket = this.ticketMapper.Map<Ticket>(ticketDto);
            User user = this.usersRepository.GetById(ticket.UserOwnerId);
            if (user == null)
            {
                return new BadRequestObjectResult($"There isn't any user with id '{ticket.UserOwnerId}'");
            }

            Product product = this.productsRepository.GetById(ticket.ProductId);
            if (product == null)
            {
                return new BadRequestObjectResult($"There isn't any product with id '{ticket.ProductId}'");
            }

            if (product.Tickets.Count >= product.TotalTicketsNumber)
            {
                return new JsonResult($"All the tickets for product '{product.Id}' have been created.");
            }


            if (!this.ticketRepository.TryAdd(ticket))
            {
                return new BadRequestObjectResult("The ticket id must be unique.");
            }
            
            product.Tickets.Add(ticket);
            return new JsonResult(this.ticketMapper.Map<TicketDto>(ticket));

        }
    }
}
