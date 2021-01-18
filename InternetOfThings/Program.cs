using System;
using System.Threading.Tasks;
using System.Linq;
using CommandLine;
using System.Collections.Generic;

namespace InternetOfThings
{

    [Verb("start-object")]
    public class MockObjectOptions
    {
        [Option('i', "identiface", Required = true)]
        public IEnumerable<string> SensorNames { get; set; }

        [Option("ip-address", Required = true)]
        public string IpAddress { get; set; }

        [Option("port", Required = true)]
        public int Port { get; set; }
    }

    [Verb("start-server")]
    public class ServerOptions
    {
        [Option("ip-address", Required = true)]
        public string IpAddress { get; set; }

        [Option("port", Required = true)]
        public int Port { get; set; }
    }

    class Program
    {
        async static Task<int> Main(string[] args)
        {
            return await CommandLine.Parser.Default
                .ParseArguments<MockObjectOptions, ServerOptions>(args)
                    .MapResult(
                        (MockObjectOptions opts) => MockObject.Run(opts),
                        (ServerOptions opts) => MqttServer.Run(opts),
                        errs => Task.FromResult(1));
        }
    }
}
