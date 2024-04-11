using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingAPI.Models;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly DbparkingContext _dataBase;

        public VehicleController(DbparkingContext dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpGet]
        [Route("ListarVehicles")]
        public async Task<IActionResult> Lista()
        {
            try
            {
                var listaVehicle = await _dataBase.Vehicles.ToListAsync();
                return Ok(listaVehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("AgregarVehicle")]
        public async Task<IActionResult> Agregar([FromBody] Vehicle request)
        {
            try
            {

                await _dataBase.Vehicles.AddAsync(request);
                await _dataBase.SaveChangesAsync();
                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno al agregar: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var tareaEliminar = await _dataBase.Vehicles.FindAsync(id);
            if (tareaEliminar == null)
            {
                return BadRequest("No existe la tarea");

            }
            _dataBase.Vehicles.Remove(tareaEliminar);
            await _dataBase.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar(int id, [FromBody] Vehicle request)
        {
            try
            {
                var vehicle = await _dataBase.Vehicles.FindAsync(id);
                if (vehicle == null)
                {
                    return BadRequest("No se encontró el vehicles");
                }

                // Actualizar los campos de la compañía con los valores proporcionados en la solicitud
                vehicle.Brand = request.Brand;
                vehicle.Model = request.Model;
                vehicle.Color = request.Color;
                vehicle.Plate = request.Plate;
                vehicle.Type = request.Type;
                
                // Actualiza otros campos según sea necesario

                _dataBase.Vehicles.Update(vehicle);
                await _dataBase.SaveChangesAsync();

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno al editar: " + ex.Message);
            }
        }




    }
}
