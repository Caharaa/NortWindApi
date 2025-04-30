using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Data;
using NorthwindAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase{

    private readonly ApplicationDbContext _context;
        public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet("Orderlist")]
    public async Task<ActionResult<IEnumerable<Orders>>> GetOrderList(){
        return await _context.Orders.ToListAsync();
}
}