using Microsoft.EntityFrameworkCore;
using sdev2301_a1_ZorawarSinghRandhawa.Data;
using sdev2301_a1_ZorawarSinghRandhawa.Entities;

namespace sdev2301_a1_ZorawarSinghRandhawa.Services;

public class CourseService
{
    private readonly AppDbContext _db = new();

    public async Task<Course> AddAsync(string code, string name, int credits)
    {
        if (credits <= 0)
            throw new Exception("Credits must be greater than 0.");

        if (await _db.Courses.AnyAsync(c => c.Code == code))
            throw new Exception("Course code must be unique.");

        var course = new Course
        {
            Code = code,
            Name = name,
            Credits = credits
        };

        _db.Courses.Add(course);
        await _db.SaveChangesAsync();

        return course;
    }
    public async Task<List<Course>> GetAllAsync()
    {
        return await _db.Courses
            .OrderBy(c => c.Code)
            .ToListAsync();
    }
    public async Task EnrollStudentAsync(int studentId, int courseId)
    {
        var student = await _db.Students
            .Include(s => s.Courses)
            .FirstOrDefaultAsync(s => s.Id == studentId);

        var course = await _db.Courses.FindAsync(courseId);

        if (student == null || course == null)
            throw new Exception("Invalid student or course.");

        if (student.Courses.Any(c => c.Id == courseId))
            throw new Exception("Student already enrolled.");

        student.Courses.Add(course);
        await _db.SaveChangesAsync();
    }
    public async Task DropStudentAsync(int studentId, int courseId)
    {
        var student = await _db.Students
            .Include(s => s.Courses)
            .FirstOrDefaultAsync(s => s.Id == studentId);

        if (student == null)
            return;

        var course = student.Courses.FirstOrDefault(c => c.Id == courseId);

        if (course == null)
            return;

        student.Courses.Remove(course);
        await _db.SaveChangesAsync();
    }
}