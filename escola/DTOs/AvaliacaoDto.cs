namespace escola.DTOs;

    public record AvaliacaoDto(string Titulo, DateTime DataRealizacao, double Nota, Guid MatriculaId, string DisciplinaId, string Tipo);
  
