using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Data;
using System;
using NorthwindAPI.Models;

[Route("api/[controller]")]
[ApiController]

public class SalesOverviewController : ControllerBase
{

    private readonly ApplicationDbContext _context;
    public SalesOverviewController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet("Total Sales")]
    public async Task<ActionResult> GetTotalSale()
    {
        var result = await (
            from order in _context.Orders
            join detail in _context.OrdersDetails on order.OrderID equals detail.OrderID
            group new { order, detail } by order.OrderDate.Value.Year into g
            orderby g.Key
            select new
            {
                salerDate = g.Key,
                saleOverview = Math.Round(g.Sum(x => x.detail.UnitPrice * x.detail.Quantity * (1 - (double)x.detail.Discount)))
            }

        ).ToListAsync();

        return Ok(result);
    }
    [HttpGet("Avg Order")]
    public async Task<ActionResult> GetAvgOrderValuePerProduct()
    {
        var result = await (
            from detail in _context.OrdersDetails
            join order in _context.Orders on detail.OrderID equals order.OrderID
            group new { detail, order } by order.OrderDate.Value.Year into g
            select new
            {
                Orderyear = g.Key,
                AvgOrderValue = Math.Round(g.Sum(x => x.detail.UnitPrice * x.detail.Quantity * (1 - (double)x.detail.Discount))
                                 / g.Select(x => x.order.OrderID).Distinct().Count())
            }
        ).ToListAsync();

        return Ok(result);
    }
    [HttpGet("revenue-by-category")]
    public async Task<ActionResult> GetRevenueByCategory()
    {
        var result = await (
            from od in _context.OrdersDetails
            join p in _context.Products on od.ProductID equals p.ProductID
            join c in _context.Categories on p.CategoryID equals c.CategoryID
            group od by c.CategoryName into g
            select new
            {
                CategoryName = g.Key,
                Revenue = Math.Round(g.Sum(x => x.UnitPrice * x.Quantity * (1 - (double)x.Discount)))
            }
        ).OrderByDescending(r => r.Revenue).ToListAsync();

        return Ok(result);
    }



    [HttpGet("GetReport")]
    public async Task<ActionResult> GetReport(DateTime startDate, DateTime endDate)
    {
        var result = await (
            from order in _context.Orders
            join detail in _context.OrdersDetails on order.OrderID equals detail.OrderID
            join product in _context.Products on detail.ProductID equals product.ProductID
            where order.OrderDate >= startDate && order.OrderDate <= endDate
            group new { detail, product } by product.ProductName into g
            select new
            {
                ProductName = g.Key,
                TotalRevenue = Math.Round(g.Sum(x => x.detail.UnitPrice * x.detail.Quantity * (1 - (double)x.detail.Discount)))
            }
        ).ToListAsync();

        return Ok(result);

    }



}