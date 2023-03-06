namespace ExampleWebApplication.DTOs
{
    /// <summary>
    /// Error response DTO
    /// </summary>
    public class ErrorResponse
    {
        public List<Error> Errors { get; set; }
    }
    /// <summary>
    /// Error DTO
    /// </summary>
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string ProgramName { get; set; }
    }
}
