namespace Desafio_2.Core.Services.Abstractioncs;

public interface ILocalizadorIAService
{
    Task<string> LocalizarItemAsync(string itemProcurado);
}