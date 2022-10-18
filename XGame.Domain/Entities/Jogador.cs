//digite CRTL + R + G -- para retirar as referencias do arquivo

using System.Runtime.Serialization;
using XGame.Domain.Enum;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador
    {
        //prop - declara variaveis rapidamente
        //prop - declara variaveis privadas rapidamente
        public Guid Id { get; set; }

        public Nome Nome { get; set; }

        public Email Email { get; set; }

        public string Senha { get; set; }

        public EnumSituacaoJogador Status { get; set; }
    }
}
