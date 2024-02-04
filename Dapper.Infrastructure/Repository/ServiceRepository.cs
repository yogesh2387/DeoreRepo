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
    internal class ServiceRepository:IServiceRepository
    {
        private readonly IConfiguration configuration;
        public ServiceRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Services entity)
        {
          var sql = "Insert into dbo.[Services] (ServiceName,EstimatedDuration,TeamMembersInvolved,ServiceType,UserID) VALUES (@ServiceName,@EstimatedDuration,@TeamMembersInvolved,@ServiceType,@UserID)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM dbo.[Services] WHERE ServiceId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                
                return result;
            }
        }

        public async Task<IReadOnlyList<Services>> GetAllAsync()
        {
            var sql = "SELECT * FROM [dbo].[Services]";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Services>(sql);
                return result.ToList();
            }
        }

        public async Task<Services> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM [dbo].[Services] WHERE ServiceId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Services>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Services entity)
        {
            var sql = "UPDATE dbo.[Services] SET ServiceName = @ServiceName, EstimatedDuration = @EstimatedDuration, TeamMembersInvolved = @TeamMembersInvolved, ServiceType = @ServiceType, UserID = @UserID WHERE ServiceId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
