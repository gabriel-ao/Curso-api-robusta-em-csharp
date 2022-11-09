using XGame.Domain.Entities;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        Jogador AutenticarJogador(string Email, string Senha);

        Jogador AdicionarJogador(Jogador jogador);

        IEnumerable<Jogador> ListaJogador();
    }
}
