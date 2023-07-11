using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NullBoxService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        [HttpGet("{token}/{deviceCode}")]
        public ApiResult<bool> CheckLicense(string token, string deviceCode, CancellationToken cancellationToken)
        {
            if (token == "spoze")
            {
                return new ApiResult<bool>()
                {
                    Success = false,
                    StatusCode = Controllers.StatusCode.ERROR,
                    Message = "ناموفق",
                    Data = false,
                };

            }
            else
            {
                return new ApiResult<bool>()
                {
                    Success = true,
                    StatusCode = Controllers.StatusCode.OK,
                    Message = "موفق",
                    Data = true,
                };
            }
        }

        [HttpPost]
        public ApiResult<string> RegisterLicense(RegisterLicense registerLicense, CancellationToken cancellationToken)
        {
            return new ApiResult<string>()
            {
                Success = true,
                StatusCode = Controllers.StatusCode.OK,
                Message = "موفق",
                Data = Guid.NewGuid().ToString(),
            };
        }
    }

    public class ApiResult<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }

    }

    public enum StatusCode
    {
        OK,
        ERROR,
        WARNING
    }

    public class RegisterLicense
    {
        public string LicenseKey { get; set; }
        public string IpAddress { get; set; }
        public string DeviceCode { get; set; }
    }
}