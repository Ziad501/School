using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Genereic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentRepository(AppDbContext _context) : GenericRepository<Student>(_context), IStudentRepository
    {
        public async Task<List<Student>> GetAllStudents(CancellationToken cancellation)
        {
            return await _dbSet.Include(p => p.Department).ToListAsync(cancellation);
        }

    }
}
