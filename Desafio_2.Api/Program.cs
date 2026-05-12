using Desafio_2.Ai.Agents;
using Desafio_2.Api.Dtos;
using Desafio_2.Core.Models;
using Desafio_2.Core.Repositories.Abstractioncs;
using Desafio_2.Core.Services.Abstractioncs;
using Desafio_2.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICaixaRepository, CaixaRepository>();

builder.Services.AddScoped<ILocalizadorIAService, LocalizadorIAService>();

var app = builder.Build();

app.MapPost("/caixas", async (
    CadastroCaixaRequestDTO requisicao,
    ICaixaRepository repositorioCaixa) =>
{
    var caixa = new Caixa
    {
        Numero = requisicao.Numero,
        DescricaoConteudo = requisicao.DescricaoConteudo
    };

    await repositorioCaixa.AdicionarAsync(caixa);

    return Results.Ok(caixa);
});

app.MapPost("/caixas/localizar", async (
    LocalizarItemRequestDTO requisicao,
    ILocalizadorIAService servicoLocalizadorIA) =>
{
    var resultado = await servicoLocalizadorIA.LocalizarItemAsync(
        requisicao.ItemProcurado);

    return Results.Ok(new
    {
        resposta = resultado
    });
});

app.Run();
