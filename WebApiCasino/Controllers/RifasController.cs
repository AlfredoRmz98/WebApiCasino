using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasino.DTOs;
using WebApiCasino.Entidades;

namespace WebApiCasino.Controllers
{
    [ApiController]
    [Route("rifas")]
    public class RifasController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public RifasController(ApplicationDbContext context, IMapper mapper)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rifa>>> GetAll()
        {
            //Se obtiene la lista del objeto Rifas
            return await dbContext.Rifas.ToListAsync();
        }

        [HttpPost]
        [ActionName(nameof(RifaCreacionDTO))]
        public async Task<ActionResult> Post(RifaCreacionDTO rifaCreacionDTO)
        {
            //Se verifica que el objeto de EmpleadosIds no sea nullo
            if (rifaCreacionDTO.ParticipantesIds == null)
            {
                return BadRequest("No se puede crear una clase sin empleados.");
            }
            //Se obtiene una lista de los empleadosIds del objeto Empleados
            var participantesIds = await dbContext.Participantes
                .Where(participanteBD => rifaCreacionDTO.ParticipantesIds.Contains(participanteBD.Id)).Select(x => x.Id).ToListAsync();
            //Se obtiene del objeto empleadosIds el nombre que exista
            if (rifaCreacionDTO.ParticipantesIds.Count != participantesIds.Count)
            {
                return BadRequest("No existe uno de los participantes enviados");
            }
            //Se realiza el mappeo de puestoCreacionDTO a Puesto
            var rifa = mapper.Map<Rifa>(rifaCreacionDTO);

            //OrdenarPorEmpleados(puesto);
            //Se añade a la DB
            dbContext.Add(rifa);
            //Se guardan los cambios de nuestra DB de manera asincrona
            await dbContext.SaveChangesAsync();

            //Se realiza el mappeo de puesto a PuestoDTO
            var rifaDTO = mapper.Map<RifaDTO>(rifa);

            return CreatedAtRoute("obtenerRifa", new { id = rifa.Id }, rifaDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, RifaCreacionDTO rifaCreacionDTO)
        {
            //Se obtiene el id del objeto Puestos
            var rifaDB = await dbContext.Rifas
                //Se incluye la relacion de EmpleadoPuesto
                .Include(x => x.ParticipanteRifa)
                .FirstOrDefaultAsync(x => x.Id == id);

            //Verifica que no sea null
            if (rifaDB == null)
            {
                return NotFound();
            }

            //Se realiza el mappeo de puesto DB a PuestoCracionDTO
            rifaDB = mapper.Map(rifaCreacionDTO, rifaDB);

            //OrdenarPorAlumnos(puestoDB);
            //Se guardan los cambios de nuestra DB de manera asincrona
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            //Se obtiene del id del objeto Puestos
            var exist = await dbContext.Rifas.AnyAsync(x => x.Id == id);
            //Verifica si no existe 
            if (!exist)
            {
                return NotFound("La Rifa no fue encontrado.");
            }
            //Se realiza la eliminacion en nuestra DB
            dbContext.Remove(new Rifa { Id = id });
            //Se guardan los cambios de nuestra DB de manera asíncrona
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
