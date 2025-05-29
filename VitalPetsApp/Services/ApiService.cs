using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using VitalPetsApp.Models;

namespace VitalPetsApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://10.0.2.2:7009/api"; //Cambiar el puerto en cada maquina fisica, ya que el puerto es diferente para cada integrante del grupo

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        //Obtener las mascotas
        public async Task<List<Mascota>> GetMascotasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/mascota");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Mascota>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener mascotas: {ex.Message}");
            }

            return new List<Mascota>();
        }

        //Obtener mascota por ID
        public async Task<Mascota> GetMascotaByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/mascota/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Mascota>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener mascota: {ex.Message}");
            }

            return null;
        }

        //Crear una mascota
        public async Task<bool> CrearMascotaAsync(Mascota mascota)
        {
            try
            {
                var json = JsonSerializer.Serialize(mascota);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{BaseUrl}/mascota", content);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al crear mascota: {error}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al crear mascota: {ex.Message}");
                return false;
            }
        }


        //Actualizar una mascota
        public async Task<bool> ActualizarMascotaAsync(Mascota mascota)
        {
            try
            {
                var json = JsonSerializer.Serialize(mascota);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{BaseUrl}/mascota/{mascota.Id}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar mascota: {ex.Message}");
                return false;
            }
        }

        //Eliminar una mascota
        public async Task<bool> EliminarMascotaAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/mascota/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar mascota: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/usuario");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Usuario>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
            }

            return new List<Usuario>();
        }
    }
}
