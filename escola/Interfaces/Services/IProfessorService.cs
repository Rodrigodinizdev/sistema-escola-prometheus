using escola.DTOs;
using escola.Models;
namespace escola.Interfaces.Services;

public interface IProfessorService
{
    string CriarProfessor(ProfessorDto dto);
    List<Professor> ListarProfessores();
}
