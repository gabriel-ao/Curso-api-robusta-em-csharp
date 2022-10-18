using XGame.Domain.Arguments.Jogador;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServiceJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);

        Guid AdicionarJogador(AdicionarJogadorRequest request);

    }

}
