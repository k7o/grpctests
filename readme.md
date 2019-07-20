https://github.com/grpc/grpc/blob/master/src/csharp/BUILD-INTEGRATION.md





Proto
Genereren van code

C:\Users\Eric\.nuget\packages\grpc.tools\1.22.0\tools\windows_x64\protoc.exe --proto_path=D:\Projects\grpctests\Messages greet.proto --csharp_out="." --js_out="."


Server

dotnet new grpc -o Server


Client

$ # Get the gRPC repository
$ export REPO_ROOT=grpc # REPO root can be any directory of your choice
$ git clone -b $(curl -L https://grpc.io/release) https://github.com/grpc/grpc $REPO_ROOT
$ cd $REPO_ROOT

$ cd examples/node
$ npm install
