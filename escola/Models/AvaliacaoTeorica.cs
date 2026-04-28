namespace escola.Models;

public class AvaliacaoTeorica : Avaliacao
{
    public AvaliacaoTeorica(string titulo, DateTime dataRealizacao, double nota, Disciplina disciplina)
        : base(titulo, dataRealizacao, nota, disciplina) { }

    public override double Peso => 0.6;

    public override string ToString() => $"Id: {Id} | [Teórica] {Titulo} | Nota: {Nota} | Data: {DataRealizacao:dd/MM/yyyy}";
}