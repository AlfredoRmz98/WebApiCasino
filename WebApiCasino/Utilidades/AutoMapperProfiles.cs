using AutoMapper;
using WebApiCasino.DTOs;
using WebApiCasino.Entidades;

namespace WebApiCasino.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Establecemos el mappeo de EmpleadoDTO hacia la entidad Empleado
            CreateMap<ParticipanteDTO, Participante>();
            //Establecemos el mappeo de la entidad Empleado hacia la el DTO GetEmpleadoDTO
            CreateMap<Participante, GetParticipanteDTO>();
            //Establecemos el mappeo desde la entidad Empleado hacia el DTO EmpleadoDTOConPuestos
          //  CreateMap<Participante, ParticipanteDTOconRifa>()
          //      .ForMember(participanteDTO => participanteDTO.Rifas, opciones => opciones.MapFrom(MapParticipanteDTORifas));
            //Establecemos el mappeo de PuestoCreacionDTO hacia nuestra Entidad Puesto
            CreateMap<RifaCreacionDTO, Rifa>()
                .ForMember(rifa => rifa.ParticipanteRifa, opciones => opciones.MapFrom(MapParticipanteRifa));
            //Establecemos el mappeo de la Entidad Puesto hacia el DTO PuestoDTO
            //Establecemos el mappeo de la Entidad Puesto hacie el DTO PuestoDTOconEmpleados
         //   CreateMap<Rifa, RifaDTOconParticipantes>()
        //        .ForMember(rifaDTO => rifaDTO.Participantes, opciones => opciones.MapFrom(MapRifaDTOParticipantes));
            //Establecemos el mappeo des PuestoPatchDTO hacia la entidad Puesto
            CreateMap<RifaPatchDTO, Rifa>().ReverseMap();
            //Establecemos el mappeo desde DepartamentoCreacionDTO hacia la Entidad Departamentos
            //CreateMap<DepartamentoCreacionDTO, Departamentos>();
            ////Establecemos el mappeo desde la Entidad Departamentos hacia el DTO DepartamentoDTO
            //CreateMap<Departamentos, DepartamentoDTO>();

        }
        //Se crea una lista PuestoDTO con los parametros empleado y getEmpleadoDTO
        private List<RifaDTO> MapParticipanteDTORifas(Participante participante, GetParticipanteDTO getParticipanteDTO)
        {
            var result = new List<RifaDTO>();
            //Verificamos que no sea nulla
            if (participante.ParticipanteRifa == null) { return result; }
            //iteraciones
            foreach (var participanteRifa in participante.ParticipanteRifa)
            {
                result.Add(new RifaDTO()
                {
                    Id = participanteRifa.RifaId,
                    Nombre = participanteRifa.Rifa.Nombre
                });
            }

            return result;
        }

        //Se crean una lista de GetEmpleadoDTO
        private List<GetParticipanteDTO> MapRifaDTOParticipantes(Rifa rifa, RifaDTO rifaDTO)
        {

            var result = new List<GetParticipanteDTO>();
            //Buscamos si es null
            if (rifa.ParticipanteRifa == null)
            {
                return result;
            }
            //iteraciones
            foreach (var participanterifa in rifa.ParticipanteRifa)
            {
                result.Add(new GetParticipanteDTO()
                {
                    Id = participanterifa.ParticipanteId,
                    Nombre = participanterifa.Participante.Nombre
                });
            }

            return result;
        }

        //Se crea una lista de ParticipanteRifa
        private List<ParticipanteRifa> MapParticipanteRifa(RifaCreacionDTO rifaCreacionDTO, Rifa rifa)
        {

            var resultado = new List<ParticipanteRifa>();
            //se verifica si es null o no
            if (rifaCreacionDTO.ParticipantesIds == null)
            {
                return resultado;
            }

            //iteraciones
            foreach (var empleadoId in rifaCreacionDTO.ParticipantesIds)
            {
                resultado.Add(new ParticipanteRifa() { ParticipanteId = empleadoId });
            }
            return resultado;
        }
    }
}