using RestSharp;
using TestRest.Communications.Responses;
using TestRest.Communications.ViaCep;
using TestRest.Exceptions.ExceptionsBase;

namespace TestRest.Applications.UseCases.ViaCep;

public class GetCityByCep
{
    public async Task<Cep> Execute(string cep)
    {
        try
        {
            var client = new RestClient($"https://viacep.com.br/ws/{cep}/json/");
            var request = new RestRequest("", Method.Get);
            var response = await client.ExecuteAsync<CepModel>(request);

            if (response.IsSuccessful)
            {
                return new Cep
                {
                    State = response.Data.Estado,
                    City = response.Data.Localidade,
                    CepNumber = response.Data.Cep
                };
            }

            throw new ErrorInCep("error no cep passado");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}