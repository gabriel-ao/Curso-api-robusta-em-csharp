using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public ServiceJogador()
        {

        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            Jogador jogador = new Jogador(nome, email, request.Senha);

            if (this.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.AdicionarJogador(jogador);

            return (AdicionarJogadorResponse)jogador;
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if(request == null)
            {
                AddNotification("AutenticarJogadorRequest", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRequest"));
            }
            Console.WriteLine("Verificando request " + request);
            //var response = _repositoryJogador.AutenticarJogador(jogador.Email.Endereco, jogador.Senha);

            var email = new Email(request.Email) ;
            var jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador, email);

            if (jogador.IsInvalid())
            {
                return null;
            }

            //jogador = _repositoryJogador.AutenticarJogador(jogador.Email.Endereco, jogador.Senha);


            return (AutenticarJogadorResponse)jogador;
        }


        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {

            if (request == null)
            {
                AddNotification("AlterarJogadorRequest", Message.X0_E_OBRIGATORIO.ToFormat("AlterarJogadorRequest"));
            }

            Jogador jogador = _repositoryJogador.ObterJogadorPorId(request.Id);

            if(jogador == null) {
                AddNotification("Id", Message.X0_INVALIDA);
                return null;
            }
            

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            jogador.AlterarJogador(nome, email, jogador.Status);

            AddNotifications(jogador);


            if (IsInvalid())
            {
                return null;
            }

            _repositoryJogador.AlterarJogador(jogador);

            return (AlterarJogadorResponse)jogador;
        }

        public IEnumerable<JogadorResponse> ListarJogador()
        {

            return _repositoryJogador.ListaJogador().ToList().Select(jogador => (JogadorResponse)jogador).ToList();
        }
    }
}
