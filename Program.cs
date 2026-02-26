using sdev2301_a1_ZorawarSinghRandhawa.Services;

var studentService = new StudentService();
var courseService = new CourseService();

while (true)
{
    Console.WriteLine("\n=== Student Enrollment System ===");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. List Students");
    Console.WriteLine("3. Add Course");
    Console.WriteLine("4. List Courses");
    Console.WriteLine("5. Enroll Student in Course");
    Console.WriteLine("6. Drop Student from Course");
    Console.WriteLine("0. Exit");

    Console.Write("Select option: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter student name: ");
            var name = Console.ReadLine();

            await studentService.AddAsync(name!, DateTime.Now);
            Console.WriteLine("Student added!");
            break;

        case "2":
            var students = await studentService.GetAllAsync();
            foreach (var s in students)
                Console.WriteLine($"{s.Id} - {s.FullName}");
            break;

        case "3":
            Console.Write("Course code: ");
            var code = Console.ReadLine();

            Console.Write("Course name: ");
            var cname = Console.ReadLine();

            Console.Write("Credits: ");
            var credits = int.Parse(Console.ReadLine()!);

            await courseService.AddAsync(code!, cname!, credits);
            Console.WriteLine("Course added!");
            break;

        case "4":
            var courses = await courseService.GetAllAsync();
            foreach (var c in courses)
                Console.WriteLine($"{c.Id} - {c.Code} - {c.Name}");
            break;
        case "5":
            Console.Write("Student ID: ");
            var sid = int.Parse(Console.ReadLine()!);

            Console.Write("Course ID: ");
            var cid = int.Parse(Console.ReadLine()!);

            await courseService.EnrollStudentAsync(sid, cid);
            Console.WriteLine("Enrollment successful!");
            break;

        case "6":
            Console.Write("Student ID: ");
            var dsid = int.Parse(Console.ReadLine()!);

            Console.Write("Course ID: ");
            var dcid = int.Parse(Console.ReadLine()!);

            await courseService.DropStudentAsync(dsid, dcid);
            Console.WriteLine("Dropped successfully!");
            break;

        case "0":
            return;
    }
}