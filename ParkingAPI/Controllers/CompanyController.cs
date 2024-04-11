using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingAPI.Models;
using System.Threading;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DbparkingContext _dataBase;

        public CompanyController(DbparkingContext baseDatos)
        {
            _dataBase = baseDatos;
        }

        [HttpGet]
        [Route("ListarCompanies")]
        public async Task<IActionResult> Lista()
        {
            try
            {
            var listaCompanies = await _dataBase.Companies.ToListAsync();
            return Ok(listaCompanies);
            }catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("AgregarCompanies")]
        public async Task<IActionResult> Agregar([FromBody] Company request)
        {
            try
            {

            await _dataBase.Companies.AddAsync(request);
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
            var tareaEliminar = await _dataBase.Companies.FindAsync(id);
            if (tareaEliminar == null)
            {
                return BadRequest("No existe la tarea");

            }
            _dataBase.Companies.Remove(tareaEliminar);
            await _dataBase.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar(int id, [FromBody] Company request)
        {
            try
            {
                var company = await _dataBase.Companies.FindAsync(id);
                if (company == null)
                {
                    return BadRequest("No se encontró la compañía");
                }

                // Actualizar los campos de la compañía con los valores proporcionados en la solicitud
                company.Name = request.Name;
                company.Address = request.Address;
                company.Telephone = request.Telephone;
                // Actualiza otros campos según sea necesario

                _dataBase.Companies.Update(company);
                await _dataBase.SaveChangesAsync();

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno al editar: " + ex.Message);
            }
        }


    }
}
