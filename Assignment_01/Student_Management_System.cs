using System;

// 1. Domain Model: Holds only student data properties
public class Student
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string StudentId { get; set; }
}

// 2. Persistence Responsibility: Handles database interactions
public class StudentRepository
{
    public void SaveToDatabase(Student student)
    {
        // Simulated DB connection and insertion query
        Console.WriteLine($"[DB Log]: Inserting Student '{student.Name}' (ID: {student.StudentId}) into SQL Server...");
    }
}

// 3. Communication Responsibility: Handles notifications separately
public class StudentEmailService
{
    public void SendWelcomeEmail(Student student)
    {
        // Simulated SMTP client call
        Console.WriteLine($"[Email Service]: Dispatched welcome email to {student.Email}.");
    }
}

// Execution Driver
class Program
{
    static void Main()
    {
        Student student = new Student { 
            Name = "Alex Mercer", 
            Email = "alex.mercer@university.edu", 
            StudentId = "CS4182" 
        };
        
        StudentRepository repository = new StudentRepository();
        repository.SaveToDatabase(student);

        StudentEmailService emailService = new StudentEmailService();
        emailService.SendWelcomeEmail(student);
    }
}