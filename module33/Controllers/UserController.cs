using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace module33.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private ILoger _loger;
        private IUserRepository _userRepository;
        public UserController(ILoger loger, IMapper mapper, IUserRepository userRepository)
        {
            _loger = loger;
            _mapper = mapper;
            _userRepository = userRepository;

            //Create log new folder
            //loger.CreateLogDir();

            loger.WriteEvent("Сообщение о событии в программе");
            loger.WriteError("Сообщение об ошибке в программе");

            //
            //userRepository.GetAll();
            //userRepository.GetByLogin("oleg");
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

        
        [HttpGet]
        [Route("viewmodel")]
        public UserViewModel GetUserViewModel()
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Иван",
                LastName = "Иванов",
                Email = "ivan@gmail.com",
                Password = "11111122222qq",
                Login = "ivanov"
            };

            var userViewModel = _mapper.Map<UserViewModel>(user);
            // UserViewModel userViewModel = new UserViewModel(user);

            return userViewModel;
        }
    }
}