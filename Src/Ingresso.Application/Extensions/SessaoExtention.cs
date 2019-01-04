namespace Ingresso.Application.Extensions
{
    using global::Application.DTO;
    using Ingresso.Domain;
    using MongoDB.Bson;
    using System.Collections.Generic;

    public static class SessaoExtention
    {
        public static SessaoDTO MapToDto(this Sessao sessao)
        {
            if (sessao == null)
            {
                return null;
            }

            return new SessaoDTO
            {                
                Id = sessao.Id.ToString(),
                Data = sessao.Data,
                QtLugar = sessao.QtLugar,
                Valor = sessao.Valor,
                FilmeId = sessao.FilmeId?.Id.ToString(),
                Legenda = sessao.Legenda,
                Horarios = MapHorariosToDto(sessao.Horarios),
            };
        }

        private static IEnumerable<HorarioDTO> MapHorariosToDto(IEnumerable<Horario> horarios)
        {
            if (horarios == null)
            {
                yield break;
            }

            foreach (var item in horarios)
            {
                yield return new HorarioDTO
                {
                    Horario = item.Horarios, 
                };
            }
        }

        public static Sessao MapToModel(this SessaoDTO sessao, bool setId = false)
        {
            var f = new Sessao
            {
                Data = sessao.Data,
                QtLugar = sessao.QtLugar,
                Valor = sessao.Valor,
                Legenda = sessao.Legenda,
                Horarios = MapHorariosToDto(sessao.Horarios),
            };

            if (setId)
            {
                f.Id = new ObjectId(sessao.Id);
            }

            return f;
        }

        public static Sessao MapToNewValues(this Sessao currentValue, SessaoDTO newValue)
        {
            currentValue.Data = newValue.Data;
            currentValue.QtLugar = newValue.QtLugar;
            currentValue.Valor = newValue.Valor;
            currentValue.Legenda = newValue.Legenda;
            currentValue.Horarios = MapHorariosToDto(newValue.Horarios);
            return currentValue;
        }
    }
}
