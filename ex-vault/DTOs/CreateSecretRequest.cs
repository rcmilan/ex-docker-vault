namespace ex_vault.DTOs
{
    public class CreateSecretRequest
    {
        public string Path { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }
}
