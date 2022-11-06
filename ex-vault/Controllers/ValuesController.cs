using ex_vault.DTOs;
using Microsoft.AspNetCore.Mvc;
using VaultSharp;
using VaultSharp.V1.Commons;

namespace ex_vault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IVaultClient vaultClient;

        public ValuesController(IVaultClient vaultClient)
        {
            this.vaultClient = vaultClient;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSecretRequest request)
        {
            var res = await vaultClient.V1.Secrets.KeyValue.V2.WriteSecretAsync(
                path: request.Path,
                data: request.Data,
                mountPoint: "secret"
            );

            return Ok();
        }

        [HttpGet("{path}")]
        public async Task<IActionResult> Get(string path, string key)
        {
            Secret<SecretData> secret = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(
                path: path,
                mountPoint: "secret"
            );

            var password = secret.Data.Data[key];

            return Ok(password);
        }
    }
}

