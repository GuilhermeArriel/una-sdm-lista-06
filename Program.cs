using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Digite o nome do Pokémon:");
        string nome = Console.ReadLine()?.ToLower();

        string url = $"https://pokeapi.co/api/v2/pokemon/{nome}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(json);

                    Console.WriteLine("\n=== Dados do Pokémon ===");
                    Console.WriteLine($"Id: {pokemon.Id}");
                    Console.WriteLine($"Nome: {pokemon.Name}");
                    Console.WriteLine($"Altura: {pokemon.Height}");
                    Console.WriteLine($"Peso: {pokemon.Weight}");
                }
                else
                {
                    Console.WriteLine("Pokémon não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}