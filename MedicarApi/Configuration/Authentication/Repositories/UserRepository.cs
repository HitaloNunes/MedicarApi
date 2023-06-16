using MedicarApi.Configuration.Authentication.Models;

namespace MedicarApi.Configuration.Authentication.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = Guid.NewGuid(), Username = "Hashirama Senju", Password = "doakcqtvcabyz", Role = "Hokage" });
            users.Add(new User { Id = Guid.NewGuid(), Username = "Tsunade", Password = "llcnyaccztpgqkv", Role = "Boss" });
            users.Add(new User { Id = Guid.NewGuid(), Username = "Sakura Haruno", Password = "qledtzxsspiamoll", Role = "Nurse" });
            User usuario = users.Where(z => z.Username == username && z.Password == password).FirstOrDefault() ?? new User() { Username = "Usuário Inválido" };

            return usuario;
        }
    }
}
