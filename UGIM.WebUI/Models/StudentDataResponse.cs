using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UGIM.WebUI.Models
{
    public class StudentDataResponse<T>:StudentResponse
    {
        public T Data { get; set; }
    }
}
