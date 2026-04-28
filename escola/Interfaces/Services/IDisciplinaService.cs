using escola.DTOs;
using escola.Models;

namespace escola.Interfaces.Services;

public interface IDisciplinaService
{
    string CriarDisciplina(DisciplinaDto dto);
    List<Disciplina> ListarDisciplinas();
}
