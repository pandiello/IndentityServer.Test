namespace Api.test.Controllers
{
    using System;
    using AutoMapper;
    using Business;
    using Business.DataAccess;
    using DTO;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IRepository<User> usersRepository;
        private readonly IMapper userMapper;

        public UserController(IRepository<User> usersRepository, IMapper userMapper)
        {
            if (usersRepository == null)
            {
                throw new ArgumentNullException(nameof(usersRepository));
            }

            if (userMapper == null)
            {
                throw new ArgumentNullException(nameof(userMapper));
            }

            this.usersRepository = usersRepository;
            this.userMapper = userMapper;
        }

        // GET api/accounts/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return new JsonResult(this.usersRepository.GetById(id));
        }

        // POST api/accounts
        [HttpPost]
        public IActionResult Post([FromBody]UserDto userDto)
        {
            if (userDto == null)
            {
                return new BadRequestObjectResult("User argument is not present.");
            }

            User user = this.userMapper.Map<User>(userDto);
            if (!this.usersRepository.TryAdd(user))
            {
                return new BadRequestObjectResult("The user id must be unique.");
            }

            return new JsonResult(user);
        }
    }
}
