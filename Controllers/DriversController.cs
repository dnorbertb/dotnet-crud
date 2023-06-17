using AppApi.Data;
using AppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly ApiDbContext _context;

    public DriversController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetDrivers()
    {
        List<Driver> drivers = _context.Drivers.ToList();
        return Ok(drivers);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        var driver = _context.Drivers.FirstOrDefault(x => x.Id == id);
        // _context.Drivers.FirstOrDefaultAsync();

        return Ok(driver);
    }

    [HttpPost]
    public IActionResult AddDriver(Driver driver)
    {
        _context.Drivers.Add(driver);
        _context.SaveChanges();
        return Ok(driver.Id);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDriver(int id)
    {
        var driverToDelete = _context.Drivers.FirstOrDefault(d => d.Id == id);
        if (driverToDelete == null) return NotFound();

        _context.Drivers.Remove(driverToDelete);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch]
    public IActionResult UpdateDriver(Driver driver)
    {
        var existingDriver = _context.Drivers.FirstOrDefault(d => d.Id == driver.Id);
        if (existingDriver == null) return NotFound();
        existingDriver.Name = driver.Name;
        existingDriver.DriverNumber = driver.DriverNumber;
        existingDriver.Team = driver.Team;
        _context.SaveChanges();
        return Ok(existingDriver);
    }
}