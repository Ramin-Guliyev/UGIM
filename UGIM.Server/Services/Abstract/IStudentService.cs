using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UGIM.Server.Models;

namespace UGIM.Server.Services.Abstract
{
   public interface IStudentService
    {
        Task<ResponseModel> AddAsync(StudentDto model,string teacherId);
        Task<ResponseModel> UpdateAsync(StudentDto model);
        Task<ResponseModel> DeleteAsync(int id);
        Task<ResponseDataModel<StudentDto>> GetAsync(int id);
        Task<ResponseDataModel<IEnumerable<StudentDto>>>GetListAsync(string teacherId);
    }
}
