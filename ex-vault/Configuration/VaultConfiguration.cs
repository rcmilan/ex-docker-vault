using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;

namespace ex_vault.Configuration
{
    public static class VaultConfiguration
    {
        public static IServiceCollection AddIVaultClient(this IServiceCollection services)
        {
            services.AddTransient<IVaultClient>(opt =>
            {
                IAuthMethodInfo authMethod = new TokenAuthMethodInfo(vaultToken: "vault-plaintext-root-token");
                VaultClientSettings vaultClientSettings = new("http://127.0.0.1:8200", authMethod);

                return new VaultClient(vaultClientSettings);
            });

            return services;
        }
    }
}