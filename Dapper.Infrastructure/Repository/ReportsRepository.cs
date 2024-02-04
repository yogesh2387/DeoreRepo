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
    internal class ReportsRepository:IReportsRepository
    {
        private readonly IConfiguration configuration;
        public ReportsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Reports entity)
        {
            entity.reportGenerationDate = DateTime.Now;
            var sql = "Insert into dbo.[Reports] (ServiceId,MeetingId,UserId,reportGenerationDate) VALUES (@ServiceId,@MeetingId,@UserId,@reportGenerationDate)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM dbo.[Reports] WHERE Id = @ReportId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                
                return result;
            }
        }

        public async Task<IReadOnlyList<Reports>> GetAllAsync()
        {
            var sql = "SELECT * FROM [dbo].[Reports]";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Reports>(sql);
                return result.ToList();
            }
        }

        public async Task<Reports> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM [dbo].[Reports] WHERE ReportId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Reports>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Reports entity)
        {
            entity.reportGenerationDate = DateTime.Now;
            var sql = "UPDATE dbo.[Reports] SET UserId = @UserId, ServiceId = @ServiceId, MeetingId = @MeetingId, reportGenerationDate = @reportGenerationDate  WHERE ReportId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
