using escola.Models;

namespace escola.Interfaces.Repositories;

public interface IAlunoRepository
{
    void CadastrarAluno(Aluno aluno);
    List<Aluno> ListarAlunos();
    Aluno BuscarPeloId(Guid id);
    List<Aluno> BuscarPeloNome(string nome);
    Aluno BuscarPeloCpf(string cpf);
}
