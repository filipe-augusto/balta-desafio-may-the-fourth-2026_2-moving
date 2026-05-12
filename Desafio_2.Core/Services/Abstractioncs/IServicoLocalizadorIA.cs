namespace Desafio_2.Core.Services.Abstractioncs;

public interface IServicoLocalizadorIA
{
    Task<string> LocalizarItemAsync(string itemProcurado);
}