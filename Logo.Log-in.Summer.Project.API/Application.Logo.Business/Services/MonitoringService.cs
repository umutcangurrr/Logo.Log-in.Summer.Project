using Application.Logo.Business.Interface;
using Application.Logo.Business.RequestFolder;
using Application.Logo.Business.ResponseFolder;
using Application.Logo.Cammon.Extension;


namespace Application.Logo.Business.Services
{
    public class MonitoringService : IMonitoringService
    {
        public async Task<SumBusinessResponse> SumAsync(SumBusinessRequest request)
        {
            int result = await OperationExtension.SumAsync(request.X, request.Y);
            return new SumBusinessResponse { Result = result };
        }
    }
}
