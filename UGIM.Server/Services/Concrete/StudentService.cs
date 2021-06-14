using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UGIM.Server.Data;
using UGIM.Server.Models;
using UGIM.Server.Services.Abstract;

namespace UGIM.Server.Services.Concrete
{
    public class StudentService:IStudentService
    {
        private ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> AddAsync(StudentDto model, string teacherId)
        {
            if (model == null)
                return new ResponseModel() {IsSuccess = false,Message = "Null variable"};
            
            var student = new Student()
            {
                LastName = model.LastName,
                AppUserId = teacherId,
                BirthYear = model.BirthYear,
                Class = model.Class,
                FatherName = model.FatherName,
                GroupNumber = model.GroupNumber,
                Name = model.Name,
                School = model.School,
                UgimYear = model.UgimYear
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return new ResponseModel() {IsSuccess = true, Message = "Added"};
        }

        public async Task<ResponseModel> UpdateAsync(StudentDto model)
        {
            var updatedStudent = await _context.Students.FindAsync(model.Id);
            if (updatedStudent == null)
                return new ResponseModel() {IsSuccess = false, Message = "Null studentId"};
         
            updatedStudent.UgimYear = model.UgimYear;
            updatedStudent.Name = model.Name;
            updatedStudent.BirthYear = model.BirthYear;
            updatedStudent.LastName = model.LastName;
            updatedStudent.Class = model.Class;
            updatedStudent.GroupNumber = model.GroupNumber;
            updatedStudent.FatherName = model.FatherName;
            updatedStudent.School = model.School;
            _context.Students.Update(updatedStudent);
            await _context.SaveChangesAsync();
            return new ResponseModel() {Message = "Updated", IsSuccess = true};

        }

        public async Task<ResponseModel> DeleteAsync(int id)
        {
            var deletedStudent = await _context.Students.FindAsync(id);
            if (deletedStudent == null) 
                return new ResponseModel() { IsSuccess = false, Message = "Null studentId" };
            _context.Students.Remove(deletedStudent);
            await  _context.SaveChangesAsync();
            return new ResponseModel() {IsSuccess = true, Message = "Deleted"};
        }

        public async Task<ResponseDataModel<StudentDto>> GetAsync(int id)
        {
            var student =await _context.Students.FindAsync(id);
            if (student == null)
                return new ResponseDataModel<StudentDto>() {IsSuccess = false, Message = "Null", Data = null};
            
            var studentDto = new StudentDto()
            {
                UgimYear = student.UgimYear,
                BirthYear = student.BirthYear,
                Class = student.Class,
                FatherName = student.FatherName,
                GroupNumber = student.GroupNumber,
                Id = student.Id,
                LastName = student.LastName,
                Name = student.Name,
                School = student.School
            };

            return new ResponseDataModel<StudentDto>() {Message = null, IsSuccess = true, Data = studentDto};
        }

        public async Task<ResponseDataModel<IEnumerable<StudentDto>>> GetListAsync(string teacherId)
        {
            var students = await _context.Students.Where(s => s.AppUserId == teacherId).ToListAsync();
            List<StudentDto> studontList = new List<StudentDto>();
            foreach (var student in students)
            {
                var studentDto = new StudentDto()
                {
                    UgimYear = student.UgimYear,
                    BirthYear = student.BirthYear,
                    Class = student.Class,
                    FatherName = student.FatherName,
                    GroupNumber = student.GroupNumber,
                    Id = student.Id,
                    LastName = student.LastName,
                    Name = student.Name,
                    School = student.School
                };
                studontList.Add(studentDto);
            }
            
            return new ResponseDataModel<IEnumerable<StudentDto>>(){IsSuccess = true,Message = null,Data = studontList};
        }
    }
}
