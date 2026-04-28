namespace escola.Models;

public class Disciplina
{
    public Disciplina(string nome, int cargaHoraria, Professor professor)
    {
        Id = GeradorId();
        Nome = nome;
        CargaHoraria = cargaHoraria;
        Professor = professor;
        Matriculas = new List<Matricula>();
    }
    public string Id { get; }
    public string Nome { get; }
    public int CargaHoraria { get; }
    public Professor Professor { get; }
    public List<Matricula> Matriculas { get; }

    public string GeradorId() => $"{new Random().Next(0000, 9999)}";
  
    public override string ToString() => $"Id: {Id} | Disciplina: {Nome} | Carga Horária: {CargaHoraria} horas | ProfessorResponsável: {Professor}";
    
}
