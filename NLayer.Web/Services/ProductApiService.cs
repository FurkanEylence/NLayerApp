using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var response =
                await _httpClient.GetFromJsonAsync<CustomeResponseDto<List<ProductWithCategoryDto>>>(
                    "api/Products/GetProductsWithCategory");
            return response.Data;
        }

        public async Task<ProductDto> SaveAsync(ProductDto productDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", productDto);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomeResponseDto<ProductDto>>();
            return responseBody.Data;

        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomeResponseDto<ProductDto>>($"api/products/{id}");
            return response.Data;
        }

        public async Task<bool> UpdateAsync(ProductDto productDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/products", productDto);
            return response.IsSuccessStatusCode;

        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/products/{id}");
            return response.IsSuccessStatusCode;

        }
    }
}
