
using NorthwindAPI.Dto;
namespace NorthwindAPI.Services
{
    public interface ISaleOverviewService
    {
        Task<List<TotalSaleDto>> GetTotalSaleService();
        Task<List<AvgOrderperProductDto>> GetAvgOrderValuePerProductService();
        Task<List<RevenueByCategoryDto>> GetRevenueByCategoryService();

        Task<List<ReportDto>> GetReportsService(DateTime startDate,DateTime endDate);
    }
}