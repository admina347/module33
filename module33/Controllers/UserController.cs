using Microsoft.AspNetCore.Mvc;

namespace module33.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
            var logger = new Logger();

            logger.WriteEvent("Сообщение о событии в программе");
            logger.WriteError("Сообщение об ошибке в программе");
        }

        [HttpGet]
        public User GetUser()
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Login = "ivan",
                Password = "123456",
                FirstName = "Иван",
                LastName = "Петров",
                Email = "ivan-p@gamil.com"
            };
        }
    }
}