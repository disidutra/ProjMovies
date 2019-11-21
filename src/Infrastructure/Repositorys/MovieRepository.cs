using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Services;
using Dapper;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IConfiguration _config;
        public MovieRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<MovieGenre>> GetAll()
        {
            using (SqlConnection conexao = new SqlConnection(
                        _config.GetConnectionString("DBConnection")))
            {
                var result = await conexao.QueryAsync<MovieGenre>(
                    @"SELECT M.Id, M.Name, M.DateCreated, M.Active, M.GenreId, G.Name as GenreName
                            FROM Movies as M
                            INNER JOIN Genres as G ON G.Id = M.GenreId 
                            ORDER BY M.Name"
                    );

                return result;
            }            
        }
    }
}