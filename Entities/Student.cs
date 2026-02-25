namespace sdev2301_a1_ZorawarSinghRandhawa.Entities;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public DateTime EnrollmentDate { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}