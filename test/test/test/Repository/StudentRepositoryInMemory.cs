using test.Entities;
namespace test.Repository;

public class StudentRepositoryInMemory : IStudentRepository
{
    private List<Student> _students = new List<Student>
    {
        new Student
        {
            Id = 1, Name = "John", Email = "helo@lol.com", Phone = "0123456789", Address = "Sri Lanka", Grade = 10
        },
        new Student
        {
            Id = 2, Name = "Jane", Email = "plm@gmail.ru", Phone = "0123456789", Address = "Anatolia", Grade = 3
        },
        new Student
        {
            Id = 3, Name = "Jack", Email = "muie@dobre.cur", Phone = "0123456789", Address = "Miercuri", Grade = 5
        }
    };
    
    public Student? GetById(int id)
    {
        var student = _students.FirstOrDefault(x => x.Id == id);
        
        return student;
    }

    public List<Student> GetAll()
    {
        return _students;
    }
    public void Add(Student student)
    {
        if(GetById(student.Id) != null)
            throw new Exception("Student already exists");
        _students.Add(student);
    }

    public void Update(Student student)
    {
        var studentToUpdate =_students.FirstOrDefault(x => x.Id == student.Id);
        if(studentToUpdate == null)
            throw new Exception("Student does not exist");
        studentToUpdate.Name = student.Name;
        studentToUpdate.Email = student.Email;
        studentToUpdate.Phone = student.Phone;
        studentToUpdate.Address = student.Address;
        studentToUpdate.Grade = student.Grade;
    }

    public void Delete(int id)
    {
        var student = _students.FirstOrDefault(x => x.Id == id);
        if(student != null)
            _students.Remove(student);
    }
}