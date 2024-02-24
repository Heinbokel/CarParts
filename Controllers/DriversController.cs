using Microsoft.AspNetCore.Mvc;

namespace CarParts.Controllers {

    [ApiController]
    public class DriversController: ControllerBase {

        private readonly CarTripsContext _context;

        public DriversController(CarTripsContext context) {
            this._context = context;
        }

        [HttpGet("drivers", Name = "GetDrivers")]
        public List<Driver> GetDrivers() {
            return this._context.Drivers.ToList();
        }


    }

}