using escola.Enum;

namespace escola.Models;

public class AvaliacaoPratica : Avaliacao
{
    public AvaliacaoPratica(string titulo, Aluno aluno, DateTime dataRealizacao, double nota, Disciplina disciplina)
        : base(titulo, aluno, dataRealizacao, nota, disciplina, TipoAvaliacaoEnum.Pratica)
    {
    }

    public override double Peso => 0.4;
}