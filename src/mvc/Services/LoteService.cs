using mvc.Models;

namespace mvc.Services;

public class LoteService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LoteService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<Lote>?> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.GetFromJsonAsync<IEnumerable<Lote>>("/api/lotes");

        return  result?.ToList();
    }

    public async Task<Lote?> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.GetFromJsonAsync<Lote>($"/api/lotes/searchById?id={id}");

        return result;
    }

    public async Task<string> Add(Lote lote)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.PostAsJsonAsync("/api/lotes", lote);

        return await result.Content.ReadAsStringAsync();
    }

    public async Task<string> UpdateAsync(Lote lote)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.PutAsJsonAsync($"/api/lotes/{lote.Id}", lote);

        return await result.Content.ReadAsStringAsync();
    }

    public async Task<string> DeleteAsync(Lote lote)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.DeleteAsync($"/api/lotes/{lote.Id}");

        return await result.Content.ReadAsStringAsync();
    }

}
