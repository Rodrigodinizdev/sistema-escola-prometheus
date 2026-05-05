using escola.Enum;

namespace escola.Models;

public abstract class Avaliacao
{
    public Avaliacao(string titulo, Aluno aluno, DateTime dataRealizacao, double nota, Disciplina disciplina, TipoAvaliacaoEnum tipo)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        DataRealizacao = dataRealizacao;
        Nota = nota;
        Disciplina = disciplina;
        Tipo = tipo;
        Aluno = aluno;
    }

    public Guid Id { get; }
    public Aluno Aluno { get; }
    public string Titulo { get; }
    public DateTime DataRealizacao { get; }
    public double Nota { get; }
    public Disciplina Disciplina { get; }
    public TipoAvaliacaoEnum Tipo { get; private set; }
    public abstract double Peso { get; }
    public double NotaPonderada => Nota * Peso;

    public static double MediaAluno(List<Avaliacao> avaliacoes)
    {
        var teorica = avaliacoes.FirstOrDefault(a => a.Tipo == TipoAvaliacaoEnum.Teorica);
        var pratica = avaliacoes.FirstOrDefault(a => a.Tipo == TipoAvaliacaoEnum.Pratica);

        if (teorica == null && pratica == null)
            return 0;

        if (teorica == null)
            return pratica.NotaPonderada;

        if (pratica == null)
            return teorica.NotaPonderada;

        return teorica.NotaPonderada + pratica.NotaPonderada;

    }

    public static SituacaoAluno CalcularSituacao(double media) => media switch
    {
        >= 7.0 => SituacaoAluno.Aprovado,
        >= 5.0 => SituacaoAluno.Recuperacao,
        _ => SituacaoAluno.Reprovado
    };

}
