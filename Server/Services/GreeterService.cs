using System;
using System.Threading.Tasks;
using Grpc.Core;
using Messages;

namespace Server
{
    public class GreeterService : Fucker.FuckerBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name + ", age " + request.Age
            });
        }
    }
}
