using Application.Features;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Genereic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentRepository(AppDbContext _context) : GenericRepository<Student>(_context), IStudentRepository
    {
        public async Task<PagedList<Student>> GetAllStudents(int page, int pageSize, CancellationToken cancellation)
        {
            var query = _dbSet.Include(p => p.Department).AsNoTracking();
            var studnets = await query.ToListAsync(cancellation);
            return  PagedList<Student>.Create(studnets, page, pageSize);
        }

    }
}
