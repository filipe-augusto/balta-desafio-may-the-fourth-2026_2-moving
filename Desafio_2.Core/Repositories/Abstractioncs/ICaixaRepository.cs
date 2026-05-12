using Desafio_2.Core.Models;

namespace Desafio_2.Core.Repositories.Abstractioncs;

public interface ICaixaRepository
{
    Task<List<Caixa>> ListarAsync();

    Task<Caixa> AdicionarAsync(Caixa caixa);
}
