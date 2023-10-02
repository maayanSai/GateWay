using GateWay.Models;
using Microsoft.AspNetCore.Mvc;

namespace GateWay.Controllers
{
    [ApiController]
    [Route("api/address")]

    public class AddressController : Controller
    {
        [HttpGet(Name = "CheckAdd")]
        public async Task<string> CheckCityAndStreet(string CityName, string StreetName)
        {
            try
            {
                var address = new AddressModel();
                bool exist = await address.Check(CityName, StreetName);
                if (exist)
                {
                    return "City and Street exist";
                }
                else
                {
                    return "City and Street not exist";
                }
            }
            catch (Exception)
            {
                return "ERROR";
            }
        }
    }
}
