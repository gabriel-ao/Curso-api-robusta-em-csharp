using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Arguments.Plataforma;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServicePlataoforma
    {
        AdicionarPlataformaResponse Adicionar(AutenticarJogadorRequest request);

    }

}
