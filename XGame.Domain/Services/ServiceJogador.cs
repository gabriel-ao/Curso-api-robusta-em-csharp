using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;

namespace XGame.Domain.Services
{
    public class ServiceJogador : IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if(request == null)
            {
                throw new Exception("AutenticarrJogadorRequesti é obrigatorio");
            }

            if(string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("Informe um e-mail");
            }

            if (IsEmail(request.Email))
            {
                throw new Exception("Informe um e-mail");
            }


            if (string.IsNullOrEmpty(request.Senha))
            {
                throw new Exception("Informe um senha");
            }

            if (request.Senha.Length < 6)
            {
                throw new Exception("Digite uma senha de no mínimo 6 caracteres");
            }

            var response = _repositoryJogador.AutenticarJogador(request);

            return response;
        }

        private bool IsEmail(string email)
        {
            return false;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            Guid id = _repositoryJogador.AdicionarJogador(request);
            return new AdicionarJogadorResponse() { Id = id, Message = "Operação reealizada com sucesso" };
        }
    }
}
