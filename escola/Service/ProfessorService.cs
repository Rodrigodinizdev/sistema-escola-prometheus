using escola.DTOs;
using escola.Interfaces.Repositories;
using escola.Interfaces.Services;
using escola.Models;

namespace escola.Service;

    public class ProfessorService(IProfessorRepository professorRepository) : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository = professorRepository;

    public string CriarProfessor(ProfessorDto dto)
    {
        var professorExiste = _professorRepository.BuscarPeloCpf(dto.Cpf);

        if(professorExiste != null)
            return $"CPF já cadastrado";

        var professor = new Professor(dto.NomeCompleto, dto.DataNascimento, dto.Cpf, dto.Especializacao);
        _professorRepository.CadastrarProfessor(professor);
        return $"{professor} cadastrado com sucesso! ";
    }

    public List<Professor> ListarProfessores()
    {
        return _professorRepository.ListarProfessors();
    }
}
