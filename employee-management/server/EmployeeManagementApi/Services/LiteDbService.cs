using LiteDB;
using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Services
{
    public class LiteDbService
    {
        private readonly string _dbPath = "EmployeeData.db";

        public void SaveLogin(LoginModel login)
        {
            using var db = new LiteDatabase(_dbPath);
            var col = db.GetCollection<LoginModel>("logins");
            col.Insert(login);
        }
    }
}