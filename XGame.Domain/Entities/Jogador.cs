//digite CRTL + R + G -- para retirar as referencias do arquivo

using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Runtime.Serialization;
using XGame.Domain.Enum;
using XGame.Domain.Extensions;
using XGame.Domain.Interfaces.Arguments;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNullOrEmptyOrInvalidLength(x => x.Senha, 6, 32, "A senha deve ter eentre 6 a 32 caracteres");


        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Id = Guid.NewGuid();
            Status = EnumSituacaoJogador.EmAnalise;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, Message.X0_INVALIDA.ToFormat("Senha"));

            if (IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }


            AddNotifications(nome, email);
        }

        //prop - declara variaveis rapidamente
        //prop - declara variaveis privadas rapidamente
        public Guid Id { get; private set; }

        public Nome Nome { get; private set; }

        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public EnumSituacaoJogador Status { get; private set; }

        public override string ToString()
        {
            return this.Nome.PrimeiroNome + " " + this.Nome.UltimoNome;
        }
    }
}
