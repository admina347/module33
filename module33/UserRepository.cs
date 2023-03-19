namespace module33
{
    public class UserRepository : IUserRepository
    {
        List<User> Users { get; set; } = new List<User>();

        public UserRepository()
        {
            Users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "ivan",
                Password = "123456",
                FirstName = "Иван",
                LastName = "Петров",
                Email = "ivan-p@gmail.com"
            });
            Users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "peti",
                Password = "qwwretg",
                FirstName = "Пётр",
                LastName = "Иванов",
                Email = "peti@mail.ru"
            });
            Users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "oleg",
                Password = "213egfdn",
                FirstName = "Олег",
                LastName = "Иванов",
                Email = "oleg87@mail.ru"
            });
        }

        //Get all users
        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = Users;
            return users;
        }

        //Get usre by login
        public User GetByLogin(string login)
        {
            User user = Users.FirstOrDefault(u => u.Login == login);
            return user;
        }
    }
}