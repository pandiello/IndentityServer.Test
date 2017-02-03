
namespace Api.test.Controllers
{
    using System;
    using AutoMapper;
    using Business;
    using Business.DataAccess;
    using DTO;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMapper dtoMapper;
        private readonly IRepository<Product> productsRepository;
        private readonly IRepository<User> usersRepository;

        public ProductsController(IMapper mapper, IRepository<Product> productsRepository, IRepository<User> usersRepository)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            if (productsRepository == null)
            {
                throw new ArgumentNullException(nameof(productsRepository));
            }

            if (usersRepository == null)
            {
                throw new ArgumentNullException(nameof(usersRepository));
            }


            this.dtoMapper = mapper;
            this.productsRepository = productsRepository;
            this.usersRepository = usersRepository;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return new JsonResult(this.dtoMapper.Map<ProductDto>(this.productsRepository.GetById(id)));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ProductDto productDto)
        {
            if (productDto == null)
            {
                return new BadRequestObjectResult("User argument is not present.");
            }

            Product product = this.dtoMapper.Map<Product>(productDto);
            User user = this.usersRepository.GetById(product.UserId);
            if(user == null)
            {
                return new BadRequestObjectResult($"There isn't any user with id '{product.UserId}'");
            }

            if (!this.productsRepository.TryAdd(product))
            {
                return new BadRequestObjectResult("The user id must be unique.");
            }

            user.Products.Add(product);
            return new JsonResult(this.dtoMapper.Map<ProductDto>(product));
        }
    }
}
