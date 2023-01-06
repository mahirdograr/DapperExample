using Dapper;
using Microsoft.Data.SqlClient;
using productwebsitetest.Models;
using System.Data;

namespace productwebsitetest.Repository
{
    public class PersonelRepository
    {
        private string connectionString;

        public PersonelRepository()
        {
            connectionString = @"Data Source=MAHIRSUPPORT;Initial Catalog=PersonelHoliday;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        }


        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(Personel pers)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Personels(FirstName, LastName, AllowedPermitCount,Password,ActiveStatus,Email,TotalPermitCount)
                  VALUES (@name, @surname, @allowedpermit, @password,@activestatus,@mail,@totalpermit)";
                dbConnection.Open();
                dbConnection.Execute(sQuery,pers);
            }
        }

        public List<Personel> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from personels";
                dbConnection.Open();
                return dbConnection.Query<Personel>(sQuery).ToList();
            }
        }

        public Personel GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select * from Personels where Id=@id";
                dbConnection.Open();
                return dbConnection.Query<Personel>(sQuery, new {id = id}).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"delete from Personels where Id=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery,new {id=id });            }
        }

        public void Update(Personel pers)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Update Personels Set FirstName=@name, LastName=@surname, AllowedPermitCount=@allowedpermit,Password=@password,ActiveStatus=@activestatus,Email=@mail,TotalPermitCount=@totalpermit";
                dbConnection.Open();
                dbConnection.Query(sQuery,pers);
            }
        }
    }
}
