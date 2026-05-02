namespace escola.Models;

public class Disciplina
{
    public Disciplina(string nome, int cargaHoraria, Professor professor)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        CargaHoraria = cargaHoraria;
        Professor = professor;
    }
    public Guid Id { get; }
    public string Nome { get; }
    public int CargaHoraria { get; }
    public Professor Professor { get; }

    public override string ToString() => $"Id: {Id} | Disciplina: {Nome} | Carga Horária: {CargaHoraria} horas | ProfessorResponsável: {Professor}";
    
}
