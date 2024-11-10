using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Models;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public User[] Index()
        {
            return [new User()];
        }
    }
}
