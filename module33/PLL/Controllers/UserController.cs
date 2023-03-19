using System.Security.Authentication;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace module33.Controllers
{
    [ExceptionHandler]
    [ApiController]
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

            //loger.WriteEvent("Сообщение о событии в программе");
            //loger.WriteError("Сообщение об ошибке в программе");

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

        [Authorize(Roles = "Администратор")]
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

        [HttpGet]
        [Route("authenticate")]
        public async Task<UserViewModel> Authenticate(string login, string password)
        {

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Запрос не корректен");
            User user = _userRepository.GetByLogin(login);
            if (user is null)
                throw new AuthenticationException("Пользователь на найден");
            if (user.Password != password)
                throw new AuthenticationException("Введенный пароль не корректен");
            
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, 
                "AppCookie", 
                ClaimsIdentity.DefaultNameClaimType, 
                ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return _mapper.Map <UserViewModel> (user);
        }
    }
}