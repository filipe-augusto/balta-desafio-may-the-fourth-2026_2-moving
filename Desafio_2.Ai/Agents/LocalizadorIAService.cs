using Desafio_2.Core.Repositories.Abstractioncs;
using Desafio_2.Core.Services.Abstractioncs;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using System.Text.Json;

namespace Desafio_2.Ai.Agents;

public class LocalizadorIAService(IChatClient clienteChat, ICaixaRepository repositorioCaixa) : ILocalizadorIAService
{
    private readonly IChatClient _clienteChat = clienteChat;
    private readonly ICaixaRepository _repositorioCaixa = repositorioCaixa;

 public async Task<string> LocalizarItemAsync(string itemProcurado)
    {
        var caixas = await _repositorioCaixa.ListarAsync();

        var agente = new ChatClientAgent(
            _clienteChat,
            name: "AgenteLocalizadorCaixas",
            instructions:
            """
        Você é um assistente que localiza objetos em caixas numeradas.
        """
        );

        var prompt =
        $"""
    Item procurado:
    {itemProcurado}

    Caixas cadastradas:
    {JsonSerializer.Serialize(caixas)}

    Em qual caixa está o item?
    """;

        var resposta = await agente.RunAsync(prompt);

        return resposta.ToString();
    }

}