namespace sdev2301_a1_ZorawarSinghRandhawa.Entities;

public class Course
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public int Credits { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
}