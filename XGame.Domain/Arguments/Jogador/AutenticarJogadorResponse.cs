using XGame.Domain.Entities;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse
    {
        public string PrimeiroNome { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public static explicit operator AutenticarJogadorResponse(Entities.Jogador entidade)
        {
            return new AutenticarJogadorResponse()
            {
                Email = entidade.Email.Endereco,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                Status = (int)entidade.Status
                //AutenticarJogadorResponse response = new AutenticarJogadorResponse();
                //response.Email = jogador.Email.Endereco;
                //response.PrimeiroNome = jogador.Nome.PrimeiroNome;
                //response.Status = (int)jogador.Status;
                //return response;
            };
        }
    }
}
