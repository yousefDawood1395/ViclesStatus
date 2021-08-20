using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViclesStatus.Mapping;
using ViclesStatus.Models;
using ViclesStatus.Models.Dtos;
using ViclesStatus.Timer_Manager;
using ViclesStatus.unitOfWork;

namespace ViclesStatus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOFWork _unitOfWork;
        private readonly IHubContext<statusHub> _hub;

        List<VehicleDto> VehicleDtos = new List<VehicleDto>();

        public VehiclesController(IUnitOFWork unitOfWork , IHubContext<statusHub> hub)
        {
            _unitOfWork = unitOfWork;
            _hub = hub;
        }

        //// GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehicles()
        {
            var Vehicles = await _unitOfWork.Vehicles.GetAll();
            VehicleDtos =  Vehicles.toVehicleDto();

            return Ok(VehicleDtos);
        }

        [Route("getVehicleStatus")]
        [HttpGet]
        public async Task<ActionResult<VehicleDto>> getVehiclesStatus()
        {
            var Vehicles = await _unitOfWork.Vehicles.GetAll();

            var vehiclesStatus = await  _unitOfWork.Vehicles.getData(Vehicles.toVehicleDto());
          var dataTransfered = new TimerManager(() => _hub.Clients.All.SendAsync("transferVehicleStatus",  _unitOfWork.Vehicles.getData(Vehicles.toVehicleDto())));
            return Ok(vehiclesStatus);
        }

        //// GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDto>> GetVehicle(int id)
        {
            var vehicle = await _unitOfWork.Vehicles.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle.toVehicleDto());
        }

        //// PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, VehicleDto vehicleDto)
        {
            var vehicle = vehicleDto.toVehicleModel();
            if (id != vehicle.Vehicle_ID)
            {
                return BadRequest();
            }

            await _unitOfWork.Vehicles.Update(vehicle);
            return Ok();


        }

        //// POST: api/Vehicles
        [HttpPost]
        public async Task<ActionResult<VehicleDto>> PostVehicle(VehicleDto vehicleDto)
        {
            var vehicle = vehicleDto.toVehicleModel();

            await _unitOfWork.Vehicles.ADD(vehicle);

            return Created("Created", vehicleDto);
        }

        //// DELETE: api/Vehicles/5
        [HttpDelete("{vehicleId}")]
        public async Task<IActionResult> DeleteVehicle(int vehicleId)
        {
            await _unitOfWork.Vehicles.Delete(vehicleId);
            return Ok();
        }
    }
}
