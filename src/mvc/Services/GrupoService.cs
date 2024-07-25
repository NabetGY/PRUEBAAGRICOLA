using mvc.Models;

namespace mvc.Services;

public class GrupoService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GrupoService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<Grupo>?> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.GetFromJsonAsync<IEnumerable<Grupo>>("/api/grupos");

        return  result?.ToList();
    }

    public async Task<Grupo?> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.GetFromJsonAsync<Grupo>($"/api/grupos/searchById?id={id}");

        return result;
    }

    public async Task<string> Add(Grupo grupo)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.PostAsJsonAsync("/api/grupos", grupo);

        return await result.Content.ReadAsStringAsync();
    }

    public async Task<string> UpdateAsync(Grupo grupo)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.PutAsJsonAsync($"/api/grupos/{grupo.Id}", grupo);

        return await result.Content.ReadAsStringAsync();
    }

    public async Task<string> DeleteAsync(Grupo grupo)
    {
        var client = _httpClientFactory.CreateClient("Api");

        var result = await client.DeleteAsync($"/api/grupos/{grupo.Id}");

        return await result.Content.ReadAsStringAsync();
    }

}
