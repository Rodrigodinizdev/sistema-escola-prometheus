using escola.DTOs;
using escola.Models;
namespace escola.Interfaces.Services;

public interface IAlunoService
{
    string CriarAluno(AlunoDto dto);
    List<Aluno> ListarAlunos();
}
