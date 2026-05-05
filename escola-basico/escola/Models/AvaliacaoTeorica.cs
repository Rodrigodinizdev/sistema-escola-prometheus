using escola.Enum;

namespace escola.Models;

public class AvaliacaoTeorica : Avaliacao
{
    public AvaliacaoTeorica(string titulo, Aluno aluno, DateTime dataRealizacao, double nota, Disciplina disciplina)
        : base(titulo, aluno, dataRealizacao, nota, disciplina, TipoAvaliacaoEnum.Teorica)
    {
    }

    public override double Peso => 0.6;
}