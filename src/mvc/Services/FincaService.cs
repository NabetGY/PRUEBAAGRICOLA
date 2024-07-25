using mvc.Models;

namespace mvc.Services;

public class FincaService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FincaService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<Finca>?> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.GetFromJsonAsync<IEnumerable<Finca>>("/api/fincas");

        return  result?.ToList();
    }

    public async Task<Finca?> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.GetFromJsonAsync<Finca>($"/api/fincas/searchById?id={id}");

        return result;
    }

    public async Task<string> Add(Finca finca)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.PostAsJsonAsync("/api/fincas", finca);

        return await result.Content.ReadAsStringAsync();
    }

    public async Task<string> UpdateAsync(Finca finca)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.PutAsJsonAsync($"/api/fincas/{finca.Id}", finca);

        return await result.Content.ReadAsStringAsync();
    }

    public async Task<string> DeleteAsync(Finca finca)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.DeleteAsync($"/api/fincas/{finca.Id}");

        return await result.Content.ReadAsStringAsync();
    }

}
