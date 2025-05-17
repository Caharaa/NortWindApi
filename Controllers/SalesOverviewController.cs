using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NorthwindAPI.Data;
using NorthwindAPI.Services;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class SalesOverviewController : ControllerBase
{

    private readonly ApplicationDbContext _context;
    private readonly ISaleOverviewService _saleOverviewService;
    public SalesOverviewController(ApplicationDbContext context,ISaleOverviewService saleOverviewService)
    {
        _context = context;
        _saleOverviewService = saleOverviewService;
    }
    [HttpGet("Total Sales")]
    public async Task<ActionResult> GetTotalSale(string dateGroup)
    {
        var result = await _saleOverviewService.GetTotalSaleService(dateGroup);
        return Ok(result);
    }
    [HttpGet("Avg Order")]
    public async Task<ActionResult> GetAvgOrderValuePerProduct()
    {
        var result = await _saleOverviewService.GetAvgOrderValuePerProductService();
        return Ok(result);
    }
    [HttpGet("revenue-by-category")]
    public async Task<ActionResult> GetRevenueByCategory()
    {
       var result = await _saleOverviewService.GetRevenueByCategoryService();
        return Ok(result);
    }



    [HttpGet("GetReport")]
    public async Task<ActionResult> GetReport(DateTime startDate, DateTime endDate)
    {
        var result =  await _saleOverviewService.GetReportsService(startDate,endDate);
        return Ok(result);

    }



}