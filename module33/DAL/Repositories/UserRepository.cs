namespace module33
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public UserRepository()
        {
            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "ivan",
                Password = "123456",
                FirstName = "Иван",
                LastName = "Петров",
                Email = "ivan-p@gmail.com",
                Role = new Role()
                {
                    Id = 1,
                    Name = "Пользователь"
                }
            });
            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "peti",
                Password = "qwwretg",
                FirstName = "Пётр",
                LastName = "Иванов",
                Email = "peti@mail.ru",
                Role = new Role()
                {
                    Id = 1,
                    Name = "Пользователь"
                }
            });
            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "oleg",
                Password = "21",
                FirstName = "Олег",
                LastName = "Иванов",
                Email = "oleg87@mail.ru",
                Role = new Role()
                {
                    Id = 2,
                    Name = "Администратор"
                }
            });
        }

        //Get all users
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        //Get usre by login
        public User GetByLogin(string login)
        {
            return _users.FirstOrDefault(u => u.Login == login);
        }
    }
}