using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using UGIM.Server.Models;
using UGIM.Server.Services.Abstract;

namespace UGIM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher")]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;
        private UserManager<AppUser> _userManager;
        public StudentsController(IStudentService studentService, UserManager<AppUser> userManager)
        {
            _studentService = studentService;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _studentService.GetAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var result =await _studentService.GetListAsync(userId);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> Update(StudentDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           
            var result = await _studentService.UpdateAsync(model);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]StudentDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = _userManager.GetUserId(HttpContext.User);
            var result = await _studentService.AddAsync(model, userId);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

    }
}
