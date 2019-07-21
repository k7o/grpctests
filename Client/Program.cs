using Grpc.Core;
using Grpc.Net.Client;
using Messages;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        // The port number(50051) must match the port of the gRPC server.
        const int Port = 50051;

        static async Task Main(string[] args)
        {
            AppContext.SetSwitch(
              "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport",
              true);

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = ((a, b, c, d) => true);
            /*
            handler.ClientCertificates.Add(
                new System.Security.Cryptography.X509Certificates.X509Certificate2("D:/Projects/grpctests/Development/Certificates/grpctests.pfx", "welkom01")
                );
                */
            var httpClient = new HttpClient(handler);

            httpClient.BaseAddress = new Uri($"https://localhost:{Port}");
            var client = GrpcClient.Create<Fucker.FuckerClient>(httpClient);

            //var client = GrpcClient.Create<Fucker.FuckerClient>(httpClient);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" } );

            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
