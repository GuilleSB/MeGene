namespace MeGeneAPI.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }     // Indica si la operación fue exitosa
        public string Message { get; set; }   // Mensaje de respuesta
        public T Data { get; set; }           // Datos devueltos en la respuesta

        public ApiResponse(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
