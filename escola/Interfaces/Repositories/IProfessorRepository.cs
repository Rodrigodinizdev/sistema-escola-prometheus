using escola.Models;
namespace escola.Interfaces.Repositories;

public interface IProfessorRepository
{
    void CadastrarProfessor(Professor professor);
    List<Professor> ListarProfessors();
    Professor BuscarPeloId(Guid id);
    Professor BuscarPeloCpf(string cpf);
}
