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
            
            var cacert = File.ReadAllText($@"Certificates\ca.crt");
            var cert = File.ReadAllText($@"Certificates\client.crt");
            var key = File.ReadAllText($@"Certificates\client.key");

            var keypair = new KeyCertificatePair(cert, key);
            var sslCredentials = new SslCredentials(cacert, keypair);

            
            var c = new Channel($"localhost", Port, sslCredentials);
            
            var httpClient = new HttpClient();
            
            httpClient.BaseAddress = new Uri($"http://localhost:{Port}");
            var client = new Fucker.FuckerClient(c);
            
            //var client = GrpcClient.Create<Fucker.FuckerClient>(httpClient);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
