﻿using XGame.Domain.Enum;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Arguments.Jogador
{
    public class JogadorResponse
    {
        public Guid Id { get; private set; }

        public string NomeCompleto { get; private set; }

        public string PrimeiroNome { get; private set; }

        public string UltimoNome { get; private set; }

        public string Email { get; private set; }

        public string Status { get; private set; }

        public static explicit operator JogadorResponse(Entities.Jogador entidade)
        {
            return new JogadorResponse()
            {
                Id = entidade.Id,
                Email = entidade.Email.Endereco,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                NomeCompleto = entidade.ToString(),
                //Status = entidade.Status.ToString(),
            };
        }
    }
}
