using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Infrastructure.Repository
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly IConfiguration configuration;
        public MeetingRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Meeting entity)
        {
   
            var sql = "Insert into dbo.[Meeting] (UserID,meetingStartDate,meetingEndDate,Status) VALUES (@UserID,@meetingStartDate,@meetingEndDate,@Status)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

   

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM dbo.[Meeting] WHERE MeetingId=@id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });

                return result;
            }
        }

        public async Task<IReadOnlyList<Meeting>> GetAllAsync()
        {
            var sql = "SELECT * FROM [dbo].[Meeting]";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Meeting>(sql);
                return result.ToList();
            }
        }

        public async Task<Meeting> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM [dbo].[Meeting] WHERE MeetingID = @id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Meeting>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Meeting entity)
        {
             var sql = "UPDATE dbo.[Meeting] SET Status = @Status  WHERE MeetingId = @MeetingId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
