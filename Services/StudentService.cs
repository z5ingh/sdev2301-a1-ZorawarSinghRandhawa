using Microsoft.EntityFrameworkCore;
using sdev2301_a1_ZorawarSinghRandhawa.Data;
using sdev2301_a1_ZorawarSinghRandhawa.Entities;

namespace sdev2301_a1_ZorawarSinghRandhawa.Services;

public class StudentService
{
    private readonly AppDbContext _db = new();

    public async Task<Student> AddAsync(string fullName, DateTime enrollmentDate)
    {
        var student = new Student
        {
            FullName = fullName,
            EnrollmentDate = enrollmentDate
        };

        _db.Students.Add(student);
        await _db.SaveChangesAsync();

        return student;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _db.Students
            .OrderBy(s => s.FullName)
            .ToListAsync();
    }
}