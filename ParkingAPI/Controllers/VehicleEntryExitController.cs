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
    public class VehicleEntryExitController : ControllerBase
    {
        private readonly DbparkingContext _dataBase;

        public VehicleEntryExitController(DbparkingContext dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpGet]
        [Route("ListarRegistros")]
        public async Task<IActionResult> Lista()
        {
            try
            {
                var lista = await _dataBase.VehicleEntryExits.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("ListarRegistrosPorCompania/{companyId:int}")]
        public async Task<IActionResult> ListaPorCompania(int companyId)
        {
            try
            {
                var registrosPorCompania = await _dataBase.VehicleEntryExits
                    .Where(e => e.CompanyId == companyId)
                    .ToListAsync();

                return Ok(registrosPorCompania);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarRegistrosPorVehiculo/{vehiculeID:int}")]
        public async Task<IActionResult> ListaPorVehicule(int vehiculeID)
        {
            try
            {
                var registrosPorCompania = await _dataBase.VehicleEntryExits
                    .Where(e => e.VehicleId == vehiculeID)
                    .ToListAsync();

                return Ok(registrosPorCompania);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("ResumenPorRangoDeHoras")]
        public async Task<IActionResult> ResumenPorRangoHorario(DateTime horaInicio, DateTime horaFin)
        {
            try
            {
                // Filtrar las entradas y salidas de vehículos dentro del rango de tiempo especificado
                var registrosPorRangoHorario = await _dataBase.VehicleEntryExits
                    .Where(e => e.EntryTime >= horaInicio && e.EntryTime <= horaFin)
                    .ToListAsync();

                // Contar la cantidad de entradas y salidas dentro del rango de tiempo especificado
                var entradasPorRangoHorario = registrosPorRangoHorario.Count(e => e.EntryTime >= horaInicio && e.EntryTime <= horaFin);
                var salidasPorRangoHorario = registrosPorRangoHorario.Count(e => e.ExitTime >= horaInicio && e.ExitTime <= horaFin);

                // Devolver el resumen como un objeto JSON
                var resumenPorRangoHorario = new
                {
                    Entradas = entradasPorRangoHorario,
                    Salidas = salidasPorRangoHorario
                };

                return Ok(resumenPorRangoHorario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }


















    }
}
