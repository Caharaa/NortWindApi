using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Data;
using NorthwindAPI.Models;
using Microsoft.AspNetCore.Authorization;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase{

    private readonly ApplicationDbContext _context;
        public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet("Orderlist")]
    public async Task<ActionResult<List<Orders>>> GetOrderList()
    {
        var result = await _context.Orders.ToListAsync();
        return Ok(result);
    }
}