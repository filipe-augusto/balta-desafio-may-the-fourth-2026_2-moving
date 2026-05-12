using Desafio_2.Core.Models;
using Desafio_2.Core.Repositories.Abstractioncs;
namespace Desafio_2.Infra.Repositories;

public class CaixaRepository : ICaixaRepository
{
    private static readonly List<Caixa> Caixas = [];

    public Task<List<Caixa>> ListarAsync()
    {
        return Task.FromResult(Caixas);
    }

    public Task<Caixa> AdicionarAsync(Caixa caixa)
    {
        Caixas.Add(caixa);

        return Task.FromResult(caixa);
    }
}