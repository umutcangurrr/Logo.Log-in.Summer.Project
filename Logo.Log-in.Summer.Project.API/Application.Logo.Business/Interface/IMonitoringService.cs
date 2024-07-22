
using Application.Logo.Business.RequestFolder;
using Application.Logo.Business.ResponseFolder;

namespace Application.Logo.Business.Interface
{
    public interface IMonitoringService
    {
        Task<SumBusinessResponse> SumAsync(SumBusinessRequest request);
    }
}
