//digite CRTL + R + G -- para retirar as referencias do arquivo

using prmToolkit.NotificationPattern;
using System.Runtime.Serialization;
using XGame.Domain.Enum;
using XGame.Domain.Interfaces.Arguments;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {

        public Jogador()
        {

        }

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNullOrEmptyOrInvalidLength(x => x.Senha, 6, 32, "A senha deve ter eentre 6 a 32 caracteres");




        }

        //prop - declara variaveis rapidamente
        //prop - declara variaveis privadas rapidamente
        public Guid Id { get; set; }

        public Nome Nome { get; set; }

        public Email Email { get; set; }

        public string Senha { get; set; }

        public EnumSituacaoJogador Status { get; set; }
    }
}
