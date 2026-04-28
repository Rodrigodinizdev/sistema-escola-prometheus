using escola.Interfaces.Repositories;
using escola.Models;

namespace escola.Repository;

public class MatriculaRepository : IMatriculaRepository
{
    private readonly List<Matricula> _matriculas = [];

    public Matricula BuscarPeloId(Guid id) => _matriculas.FirstOrDefault(m => m.Id == id);

    public List<Matricula> ListarMatriculas() => _matriculas.ToList();

    public void Matricular(Matricula matricula) => _matriculas.Add(matricula);

    public Matricula BuscarPorAlunoId(Guid idAluno) => _matriculas.FirstOrDefault(m => m.Aluno.Id == idAluno);

    public void AdicionarDisciplina(Guid matriculaId, Disciplina disciplina)
    {
        var matricula = BuscarPeloId(matriculaId);
        if (matricula == null) return;

        matricula.Disciplinas.Add(disciplina);
        disciplina.Matriculas.Add(matricula);
    }

    public List<Matricula> BuscarPorNomeAluno(string nome) => _matriculas.Where(m => m.Aluno.NomeCompleto.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
    
    public List<Matricula> BuscarPorDisciplina(string nomeDisciplina) => _matriculas.Where(m => m.Disciplinas.Any(d => d.Nome.Equals(nomeDisciplina, StringComparison.OrdinalIgnoreCase))).ToList();
        
    public Matricula BuscarPorNumeroMatricula(string numeroMatricula) => _matriculas.FirstOrDefault(m => m.NumeroMatricula == numeroMatricula);
    

}
