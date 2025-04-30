using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;
using NorthwindAPI.Data;
using NorthwindAPI.Dto;
using System.Runtime.CompilerServices;
using NorthwindAPI.Services;

namespace NorthwindAPI.Services
{
    public class SaleOverviewService : ISaleOverviewService
    {
        private readonly ApplicationDbContext _context;
        public SaleOverviewService(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<List<TotalSaleDto>> GetTotalSaleService()
        {
            var result = await (
                from order in _context.Orders
                join detail in _context.OrdersDetails on order.OrderID equals detail.OrderID
                group new { order, detail } by order.OrderDate.Value.Year   into g
                orderby g.Key
                select new TotalSaleDto
                {
                    SaleDate = g.Key,
                    SaleOverview = Math.Round(g.Sum(x => x.detail.UnitPrice * x.detail.Quantity * (1 - (double)x.detail.Discount)))
                }

            ).ToListAsync();

            return result;
        }
        public async Task<List<AvgOrderperProductDto>> GetAvgOrderValuePerProductService()
        {
            var result = await (
                from detail in _context.OrdersDetails
                join order in _context.Orders on detail.OrderID equals order.OrderID
                group new { detail, order } by order.OrderDate.Value.Year into g
                select new AvgOrderperProductDto
                {
                    Orderyear = g.Key,
                    AvgOrderValue = Math.Round(g.Sum(x => x.detail.UnitPrice * x.detail.Quantity * (1 - (double)x.detail.Discount))
                                     / g.Select(x => x.order.OrderID).Distinct().Count())
                }
            ).ToListAsync();

            return result;
        }
        public async Task<List<RevenueByCategoryDto>> GetRevenueByCategoryService()
        {
            var result = await (
                from od in _context.OrdersDetails
                join p in _context.Products on od.ProductID equals p.ProductID
                join c in _context.Categories on p.CategoryID equals c.CategoryID
                group od by c.CategoryName into g
                select new RevenueByCategoryDto
                {
                    CategoryName = g.Key,
                    Revenue = Math.Round(g.Sum(x => x.UnitPrice * x.Quantity * (1 - (double)x.Discount)))
                }
            ).OrderByDescending(r => r.Revenue).ToListAsync();

            return result;
        }
        public async Task<List<ReportDto>> GetReportsService(DateTime startDate,DateTime endDate)
        {
            var result = await (
                from order in _context.Orders
                join detail in _context.OrdersDetails on order.OrderID equals detail.OrderID
                join product in _context.Products on detail.ProductID equals product.ProductID
                where order.OrderDate >= startDate && order.OrderDate <= endDate
                group new { detail, product } by product.ProductName into g

                select new ReportDto
                {
                    ProductName = g.Key,
                    TotalRevenue = Math.Round(g.Sum(x => x.detail.UnitPrice * x.detail.Quantity * (1 - (double)x.detail.Discount)))
                }
        ).ToListAsync();
            return result;
        }
    }
}