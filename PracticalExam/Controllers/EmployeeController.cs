using Microsoft.AspNetCore.Mvc;
using PracticalExam.Database_Models;
using PracticalExam.Interfaces;

namespace PracticalExam.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IAll<Employee> _all;

        public EmployeeController(IAll<Employee> all)
        {
            this._all = all;
        }


        public async Task<IActionResult> Index()
        {
            var result = await _all.GetAll();
            if (result.Count > 0)
            {
                return View(result);
            }

            return NotFound();
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _all.Insert(employee);
                    await _all.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }

             return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _all.GetById(id);
                if (result != null)
                {
                    return View(result);
                }

                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IActionResult> Update(Employee employee)
        {
            try
            {
                bool result = await _all.Update(employee);
                if (result)
                {
                    if (ModelState.IsValid)
                    {
                        await _all.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                }

                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }

        }




        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var dataexists = await _all.GetById(id);
            if (dataexists != null) 
            {
                return View(dataexists);
            }
            return BadRequest();
        }


        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _all.Delete(id);
            if (result)
            {
                await _all.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
