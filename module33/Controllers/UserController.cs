using Microsoft.AspNetCore.Mvc;

namespace module33.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private ILoger _loger;
        public UserController(ILoger loger)
        {
            _loger =loger;
            
            //Create log new folder
            loger.CreateLogDir();

            loger.WriteEvent("Сообщение о событии в программе");
            loger.WriteError("Сообщение об ошибке в программе");
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