namespace escola.Models;

public class Aluno : Pessoa
{
    public Aluno(string nomeCompleto, DateTime dataNascimento, string cpf) : base(nomeCompleto, dataNascimento, cpf)
    {
        NumeroMatricula = GeradorMatricula();
        DataMatricula = DateTime.Now;
    }

    public string NumeroMatricula { get; }
    public DateTime DataMatricula { get; }
    
    public string GeradorMatricula() => $"{DateTime.Now.Year}{new Random().Next(0000, 9999)}";
    
    public override string ToString() => $"Id: {Id} | Nome: {NomeCompleto} | Data Nascimento: {DataNascimento} | CPF: {CPF} | Matrícula: {NumeroMatricula} | Data Matrícula: {DataMatricula}";
}
