using System;
using AxiaFutures.Forms;
using AxiaFutures.Services.MessageProcessor;
using AxiaFutures.Services.Speech;
using AxiaFutures.Services.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace AxiaFutures
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            Application.Run(ServiceProvider.GetRequiredService<Login>());
         
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Login>();
            services.AddTransient<Feed>();

            services.AddSingleton<ITextToSpeechService, TextToSpeechService>();
            services.AddSingleton<IWSocketService, WSocketService>();
            services.AddSingleton<IMessageProcessorService, MessageProcessorService>();
        }
    }
}