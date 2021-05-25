using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] int id)
        {
            var result = _employeeManager.GetItem(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _employeeManager.GetItems();
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeRequest employeeRequest)
        {    
            var id = await _employeeManager.Create(employeeRequest);

            return Ok(id);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EmployeeRequest employeeRequest)
        { 
            await _employeeManager.Update(id, employeeRequest);

            return Ok();
        }
                
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {            
            await _employeeManager.Delete(id);

            return Ok();
        }
    }
}