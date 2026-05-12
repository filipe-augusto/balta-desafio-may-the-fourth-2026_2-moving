namespace Desafio_2.Core.Models;

public class Caixa
{
    public int Numero { get; set; }

    public string DescricaoConteudo { get; set; } = string.Empty;

    public DateTime DataCadastro { get; set; } = DateTime.Now;
}