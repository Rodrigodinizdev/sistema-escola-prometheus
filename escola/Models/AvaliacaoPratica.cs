namespace escola.Models;

public class AvaliacaoPratica : Avaliacao
{
    public AvaliacaoPratica(string titulo, DateTime dataRealizacao, double nota, Disciplina disciplina)
        : base(titulo, dataRealizacao, nota, disciplina) { }

    public override double Peso => 0.4;

    public override string ToString() => $"Id: {Id} | [Prática] {Titulo} | Nota: {Nota} | Data: {DataRealizacao:dd/MM/yyyy}";
}