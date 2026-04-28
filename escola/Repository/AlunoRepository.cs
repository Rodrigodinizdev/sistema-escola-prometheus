using escola.Interfaces.Repositories;
using escola.Models;

namespace escola.Repository;

public class AlunoRepository : IAlunoRepository
{
    private readonly List<Aluno> _alunos = [];

    public Aluno BuscarPeloId(Guid id) => _alunos.FirstOrDefault(a => a.Id == id);

    public List<Aluno> BuscarPeloNome(string nome) => _alunos.Where(a => a.NomeCompleto.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();

    public void CadastrarAluno(Aluno aluno) => _alunos.Add(aluno);

    public List<Aluno> ListarAlunos() => _alunos.ToList();

    public Aluno BuscarPeloCpf(string cpf) => _alunos.FirstOrDefault(a => a.CPF.Equals(cpf, StringComparison.OrdinalIgnoreCase));

}
