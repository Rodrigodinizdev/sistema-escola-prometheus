using escola.Interfaces.Repositories;
using escola.Models;

namespace escola.Repository;

public class ProfessorRepository() : IProfessorRepository
{
    private readonly List<Professor> _professores = [];

    public Professor BuscarPeloCpf(string cpf) => _professores.FirstOrDefault(p => p.CPF == cpf);

    public Professor BuscarPeloId(Guid id) => _professores.FirstOrDefault(p => p.Id == id);

    public void CadastrarProfessor(Professor professor) => _professores.Add(professor);

    public List<Professor> ListarProfessors() => _professores.ToList();

}

