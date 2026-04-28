using escola.Models;

namespace escola.Interfaces.Repositories;

public interface IMatriculaRepository
{
    void Matricular(Matricula matricula);
    List<Matricula> ListarMatriculas();
    Matricula BuscarPeloId(Guid id);
    Matricula BuscarPorAlunoId(Guid idAluno);
    void AdicionarDisciplina(Guid matriculaId, Disciplina disciplina);
    List<Matricula> BuscarPorNomeAluno(string nome);
    List<Matricula> BuscarPorDisciplina(string nomeDisciplina);
    Matricula BuscarPorNumeroMatricula(string numeroMatricula);
}
