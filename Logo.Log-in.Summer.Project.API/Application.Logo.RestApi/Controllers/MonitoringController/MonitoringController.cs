namespace Application.Logo.RestApi.Controllers.MonitoringController
{
    using Application.Logo.Business.Interface;
    using Application.Logo.Business.RequestFolder;
    using Application.Logo.Business.ResponseFolder;
    using Application.Logo.RestApi.Controllers.Base;
    using Application.Logo.RestApi.Request;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;
    

    public class MonitoringController : BaseController
    {
        private readonly IMonitoringService _monitoringService;
        private readonly IMapper _mapper;
        Logger logger = new Logger();


        public MonitoringController(IMonitoringService monitoringService, IMapper mapper)
        {
            _monitoringService = monitoringService;
            _mapper = mapper;
           
        }
        

        [HttpPost("post")]
        public async Task<ActionResult<SumBusinessResponse>> Sum(SumRestRequest request)
        {
            
            var businessRequest = _mapper.Map<SumBusinessRequest>(request);
            var response = await _monitoringService.SumAsync(businessRequest);
            logger.Log($"API: Received Sum request with x={request.X} and y={request.Y} response = {response.Result}");
            return Ok(response);
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            logger.Log("API: Logged");
            return Ok();

        }
    }
}
