using ApplicationLogic;
using UsuariosEXMN.DataAccess;

namespace ApplicationLogic
{
    public class EmployeesManager
    {
        private readonly EmployeesRepository repo;

        public EmployeesManager(string connectionString)
        {
            repo = new EmployeesRepository(connectionString);
        }

        public void Insert(Employee emp) => repo.Insert(emp);
        public Employee? Find(int id) => repo.Find(id);
        public void Update(Employee emp) => repo.Update(emp);
        public void Delete(int id) => repo.Delete(id);
    }
}
