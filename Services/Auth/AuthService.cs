using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using Polly;
using Polly.Retry;

namespace AxiaFutures.Services.Auth
{
    internal class AuthService : IAuthService
    {
        private HttpClient _httpClient;
        private const string ENDPOINT = "https://beta.axiafutures.com/api/mock-login";

        public AuthService()
        {
            this._httpClient = new HttpClient();
        }

        public async Task<bool> Auth(Model.Auth auth)
        {
            try
            {
                if (!IsValid(auth))
                {
                    throw new ValidationException("Dados invalidos");
                }

                var authResponse = await AuthAssync(auth);

                if (authResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("✅ Requisição POST enviada com sucesso!");
                }
                else
                {
                    Console.WriteLine($"❌ Erro ao enviar requisição: {authResponse.StatusCode}");
                    var mensagemErro = await authResponse.Content.ReadAsStringAsync();
                    Console.WriteLine($"Detalhes: {mensagemErro}");
                    throw new AccessViolationException(mensagemErro);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool IsValid(Model.Auth auth)
        {
            return !auth.Password.Equals(string.Empty) && !auth.UserName.Equals(string.Empty);
        }

        private async Task<HttpResponseMessage> AuthAssync(Model.Auth auth)
        {
           var pipeline = new ResiliencePipelineBuilder<HttpResponseMessage>()
               .AddRetry(new RetryStrategyOptions<HttpResponseMessage>
               {
                   ShouldHandle = new PredicateBuilder<HttpResponseMessage>()
                       .Handle<HttpRequestException>()
                       .HandleResult(r => !r.IsSuccessStatusCode),

                   BackoffType = DelayBackoffType.Exponential,
                   UseJitter = true,
                   MaxRetryAttempts = 3,
                   Delay = TimeSpan.FromMicroseconds(100),

                   OnRetry = args =>
                   {
                       Console.WriteLine($"Tentativa {args.AttemptNumber} falhou. Aguardando {args.RetryDelay.TotalSeconds} segundos...");
                       return default;
                   }
               })
               .Build();

            var result = await pipeline.ExecuteAsync(async token =>
            {
                var content = JsonContent.Create(auth);
                return await _httpClient.PostAsync(new Uri(ENDPOINT), content, cancellationToken: token);
            });

            return result;
        }

    }
}
