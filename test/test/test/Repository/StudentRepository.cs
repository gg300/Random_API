using Microsoft.AspNetCore.Http.HttpResults;
using test.Entities;
namespace test.Repository;

public class StudentRepository : IStudentRepository
{
    readonly ApplicationDbContext _context;
    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public Student? GetById(int id)
    {
        var student = _context.Students.FirstOrDefault(x => x.Id == id);
        return student;
    }

    public List<Student> GetAll()
    {
        return _context.Students.ToList();
    }
    public void Add(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public void Update(Student student)
    {
        var exists = _context.Students.FirstOrDefault(x => x.Id == student.Id);
        if (exists != null)
        {
            exists.Name = student.Name;
            exists.Email = student.Email;
            exists.Phone = student.Phone;
            exists.Address = student.Address;
            exists.Grade = student.Grade;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var student = _context.Students.FirstOrDefault(x => x.Id == id);
        if (student != null)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}