using escola.DTOs;
using escola.Interfaces.Repositories;
using escola.Interfaces.Services;
using escola.Models;
namespace escola.Service;

public class DisciplinaService(IDisciplinaRepository disciplinaRepository, IProfessorRepository professorRepository) : IDisciplinaService
{
    private readonly IDisciplinaRepository _disciplinaRepository = disciplinaRepository;
    private readonly IProfessorRepository _professorRepository = professorRepository;

    public string CriarDisciplina(DisciplinaDto dto)
    {
        var professor = _professorRepository.BuscarPeloId(dto.IdProfessor);
        if (professor == null)
            return "Professor não encontrado";

        var disciplina = new Disciplina(dto.nome, dto.cargaHoraria, professor);
        _disciplinaRepository.CadastrarDisciplina(disciplina);
        return $"Disciplina {disciplina} criada com sucesso";
    }

    public List<Disciplina> ListarDisciplinas()
    {
        return _disciplinaRepository.ListarDisciplinas();
    }

}
