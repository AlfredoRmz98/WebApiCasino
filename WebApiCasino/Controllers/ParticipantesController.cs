using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasino.DTOs;
using WebApiCasino.Entidades;

namespace WebApiCasino.Controllers
{
    [ApiController]
    [Route("participantes")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class ParticipantesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public ParticipantesController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetParticipanteDTO>>> Get()
        {
            var participantes = await dbContext.Participantes.ToListAsync();
            return mapper.Map<List<GetParticipanteDTO>>(participantes);
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<GetParticipanteDTO>>> Get([FromRoute] string nombre)
        {
            var participantes = await dbContext.Participantes.Where(participanteDB => participanteDB.Nombre.Contains(nombre)).ToListAsync();
            return mapper.Map<List<GetParticipanteDTO>>(participantes);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsParticipante")]
        public async Task<ActionResult> Post([FromBody] ParticipanteDTO participanteDto)
        {
            var existeParticipanteMismoNombre = await dbContext.Participantes.AnyAsync(x => x.Nombre == participanteDto.Nombre);

            if (existeParticipanteMismoNombre)
            {
                return BadRequest($"Ya existe un participante con el nombre {participanteDto.Nombre}");
            }
            var participante = mapper.Map<Participante>(participanteDto);
            dbContext.Add(participante);
            await dbContext.SaveChangesAsync();

            var participanteDTO = mapper.Map<GetParticipanteDTO>(participante);
            return CreatedAtRoute("obtenerparticipante", new { id = participante.Id }, participanteDTO);
        }

        [HttpPut("{id:int}")]// api/empleados/1
        public async Task<ActionResult> Put(ParticipanteDTO participanteCreacionDTO, int id)
        {
            //Obtenemos del objeto Participante el id
            var exist = await dbContext.Participantes.AnyAsync(x => x.Id == id);
            //verificamos que el objeto no sea null
            if (!exist)
            {
                return NotFound();
            }
            //Se realiza el mappeo a la clase EmpleadoCreacionDTO
            var empleado = mapper.Map<Participante>(participanteCreacionDTO);
            empleado.Id = id;

            //Se realiza la actualizacion de nuestro DB
            dbContext.Update(empleado);
            //Se guardan los cambios de la DB de manera Asincrona
            await dbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //Obtenemos el id del objeto Participantes
            var exist = await dbContext.Participantes.AnyAsync(x => x.Id == id);
            //Verificamos que no sea null
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado");
            }
            //Se elimina el objeto con el id especificado
            dbContext.Remove(new Participante()
            {
                Id = id
            });
            //Se guardan los cambio de manera Asincrona
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }

}
