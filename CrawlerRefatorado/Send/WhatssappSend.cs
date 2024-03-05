using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace CrawlerRefatorado.Send;
 public class WhatssappSend
{
    public static async Task Main(string args, string nomeProdutoMagalu, string nomeProdutoMercado, double precoProdutoMercadoLivre, double precoProdutoMagazineLuiza, string melhorCompra, string urlProduto)
    {
        var options = new RestClientOptions("https://app.whatsgw.com.br")
        {
            MaxTimeout = -1,
        };
        var client = new RestClient(options);
        var request = new RestRequest("/api/WhatsGw/Send", Method.Post);
        request.AddHeader("Content-Type", "application/json");
        var body = @"{
" + "\n" +
        @"""apikey"" : ""b3d8ba24-d4ca-492b-afb4-387fd9799c41"",
" + "\n" +
        @"""phone_number"" : ""5579981125546"",
" + "\n" +
        @$"""contact_phone_number"" : ""{args}"",
" + "\n" +
        @"""message_custom_id"" : ""yoursoftwareid"",
" + "\n" +
        @"""message_type"" : ""text"",
" + "\n" +
        @$"""message_body"" : ""Resultado da comparação de preços:\n\n
*Mercado Livre:*\n
Produto: {nomeProdutoMercado}\n
Preço: R${precoProdutoMercadoLivre}\n\n
*Magazine Luiza:*\n
Produto: {nomeProdutoMagalu}\n
Preço: R${precoProdutoMagazineLuiza}\n\n
*Melhor compra:*\n
{melhorCompra} - {urlProduto}\n\n\n
Robô: D777\n
Usuário: diegoalves"",
" + "\n" +
        @"""check_status"" : ""1""
" + "\n" +
        @"}";
        request.AddStringBody(body, DataFormat.Json);
        RestResponse response = await client.ExecuteAsync(request);
        Console.WriteLine(response.Content);
    }
}

