using Microsoft.AspNetCore.Mvc;
using crudpractice.Data;
using crudpractice.Model;
using Microsoft.EntityFrameworkCore;

namespace crudpractice.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Salary()
        {
            return View();
        }
        [HttpGet]
        public async Task <IActionResult> GetBySalary(int low, int high)
        {
            var data = await _context.emp
                        .Where(e => e.Salary >= low && e.Salary <= high)
                        .ToListAsync();

            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Employee Data)
        {
            if (Data == null || string.IsNullOrEmpty(Data.Name) || Data.Age <=18 || Data.Salary < 5000)
                
            return BadRequest(new { message = "your data is not saved succesfully" });
            var exists = await _context.emp
                  .AnyAsync(x => x.Name == Data.Name);
            if (exists)
            {
                return BadRequest(new{message = "Name already exists!"});
            }

            await _context.emp.AddAsync(Data);
            await _context.SaveChangesAsync();
            return Ok(new { message = "error occured" });
        }

        [HttpGet]
        public async Task<IActionResult> GetALL() {
            var info = await _context.emp.ToListAsync();
            return Json(info);
        }

        
        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.emp.FindAsync(id);

            if (data == null)
                return NotFound(new { message = "Data not found" });

            _context.emp.Remove(data);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Data deleted successfully" });
        }
        [HttpGet]

        public async Task<IActionResult> GetById(int id)
        {
            var data = await _context.emp.FindAsync(id);
            return Json(data);
        }

        [HttpPut]

        public async Task<IActionResult> Update(Employee Data)
        {
            var existing = await _context.emp.FindAsync(Data.id);

            if (existing == null)
                return NotFound(new { message = "Data not found" });

            existing.Name = Data.Name;
            existing.ClassName = Data.ClassName;
            existing.RollNo = Data.RollNo;
            existing.Age = Data.Age;
            existing.Salary = Data.Salary;
           
            await _context.SaveChangesAsync();

            return Ok(new { message = "Data updated successfully" });
        }

    }
}


    
