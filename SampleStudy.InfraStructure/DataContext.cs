

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SampleStudy.Domain.Dto;
using System.Reflection.Metadata;

namespace SampleStudy.Infrastructure
{
    public interface IDataContextHelper
    {
        Task<List<PersonDto>> GetAllPersons();
        Task<int> AddPersons(PersonDto Person);
        Task<int> EditPersons(PersonDto Person);
        Task<List<ComminicationDto>> GetCommunicationsByPersonId(long PersonId);
        Task<PersonDto> GetPersonById(long Id);
        Task<int> DeletePerson(long Id);
    }
    public class DataContextHelper : IDataContextHelper
    {
        private readonly string _conn;
        public DataContextHelper(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
        }

        public async Task<List<PersonDto>> GetAllPersons()
        {
            using var connection = new SqlConnection(_conn);

            try {
               await connection.OpenAsync();
          
         
            using var cmd = new SqlCommand("sp_PersonGetAll", connection);
            var reader = await cmd.ExecuteReaderAsync();
            var list = new List<PersonDto>();
            while (reader.Read())
            {
                list.Add(new PersonDto()
                {
                    Id = reader.GetInt64(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Surname = reader.GetString(reader.GetOrdinal("SurName")),
                    DepartmentId = reader.GetInt64(reader.GetOrdinal("DepartmentId")),
                    WorkStartDate = reader.GetDateTime(reader.GetOrdinal("WorkStartDate")),
                    WorkFinishDate = reader.GetDateTime(reader.GetOrdinal("WorkFinishDate")),
                    Comminications = new List<ComminicationDto>(),
                    Department = new DepartmentDto(),
                    EmployeeCode = reader.GetString(reader.GetOrdinal("EmployeeCode")),
                    DepartmentCode = reader.GetInt32(reader.GetOrdinal("DepartmentCode")),
                    DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                });
            }
            return list;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<PersonDto> GetPersonById(long Id)
        {
            using var connection = new SqlConnection(_conn);

            try
            {
                await connection.OpenAsync();


                using var cmd = new SqlCommand("sp_PersonGetById", connection);
                var reader = await cmd.ExecuteReaderAsync();
                var list = new List<PersonDto>();
                while (reader.Read())
                {
                    list.Add(new PersonDto()
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Surname = reader.GetString(reader.GetOrdinal("SurName")),
                        DepartmentId = reader.GetInt64(reader.GetOrdinal("DepartmentId")),
                        WorkStartDate = reader.GetDateTime(reader.GetOrdinal("WorkStartDate")),
                        WorkFinishDate = reader.GetDateTime(reader.GetOrdinal("WorkFinishDate")),
                        Comminications = new List<ComminicationDto>(),
                        Department = new DepartmentDto(),
                        EmployeeCode = reader.GetString(reader.GetOrdinal("EmployeeCode")),
                        DepartmentCode = reader.GetInt32(reader.GetOrdinal("DepartmentCode")),
                        DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName")),
                        IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                    });
                }

              
                return list?.FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<int> AddPersons(PersonDto Person)
        {
            using var connection = new SqlConnection(_conn);

            try
            {
                await connection.OpenAsync();


                using var cmd = new SqlCommand("sp_PersonInsert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", Person.Name);
                cmd.Parameters.AddWithValue("@Surname", Person.Surname);
                cmd.Parameters.AddWithValue("@WorkStartDate", Person.WorkStartDate);
                cmd.Parameters.AddWithValue("@WorkFinishDate", Person.WorkFinishDate);
                cmd.Parameters.AddWithValue("@IsActive", Person.IsActive);
                cmd.Parameters.AddWithValue("@Gender", Person.Gender);
                cmd.Parameters.AddWithValue("@EmployeeCode", Person.EmployeeCode);
                cmd.Parameters.AddWithValue("@CreatedUser", "SYS");
                cmd.Parameters.AddWithValue("@DepartmentId", Person.Department.Id);

                int effected=  await cmd.ExecuteNonQueryAsync();
             
                return effected;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<int> EditPersons(PersonDto Person)
        {
            using var connection = new SqlConnection(_conn);

            try
            {
                await connection.OpenAsync();


                using var cmd = new SqlCommand("sp_PersonInsert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Person.Id);
                cmd.Parameters.AddWithValue("@Name", Person.Name);
                cmd.Parameters.AddWithValue("@Surname", Person.Surname);
                cmd.Parameters.AddWithValue("@WorkStartDate", Person.WorkStartDate);
                cmd.Parameters.AddWithValue("@WorkFinishDate", Person.WorkFinishDate);
                cmd.Parameters.AddWithValue("@IsActive", Person.IsActive);
                cmd.Parameters.AddWithValue("@Gender", Person.Gender);
                cmd.Parameters.AddWithValue("@EmployeeCode", Person.EmployeeCode);
                cmd.Parameters.AddWithValue("@UpdatedUser", "SYS");
                cmd.Parameters.AddWithValue("@DepartmentId", Person.Department.Id);
                int effected = await cmd.ExecuteNonQueryAsync();

                return effected;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<int> DeletePerson(long Id)
        {
            using var connection = new SqlConnection(_conn);
            try
            {
                await connection.OpenAsync();
                using var cmd = new SqlCommand("sp_PersonDelete", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@UpdatedUser", "SYS");
                int effected = await cmd.ExecuteNonQueryAsync();

                return effected;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<ComminicationDto>> GetCommunicationsByPersonId(long PersonId)
        {
            using var connection = new SqlConnection(_conn);

            try
            {
                await connection.OpenAsync();
                using var cmd = new SqlCommand("sp_CommunicationGetAll", connection);
                var reader = await cmd.ExecuteReaderAsync();
                var list = new List<ComminicationDto>();
                while (reader.Read())
                {
                    list.Add(new ComminicationDto()
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        Mail = reader.GetString(reader.GetOrdinal("Mail")),
                        MobilPhone = reader.GetString(reader.GetOrdinal("MobilPhone")),
                        LocalPhone = reader.GetString(reader.GetOrdinal("LocalPhone")),
                        IsActive = reader.GetInt32(reader.GetOrdinal("IsActive"))
                    });
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

       
    }
}

