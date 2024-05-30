using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Poker12.Core;
using Poker12.Core.Jugadas;

namespace MyBenchmarks
{
    public class Md5VsSha256
    {
        private const int N = 10000;
        private readonly byte[] data;

        private readonly SHA256 sha256 = SHA256.Create();
        private readonly MD5 md5 = MD5.Create();

        public Md5VsSha256()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);

        public IEnumerable<IJugada> CrearJugadas(List<Carta> cartas)
        {
            var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.Diez),
            new(EPalo.Corazon, EValor.As),
            new(EPalo.Corazon, EValor.Cinco),
            new(EPalo.Corazon, EValor.Tres),
            new(EPalo.Corazon, EValor.Dos),
        };

        }
        public Resultado ObtenerResultado()
        {
            var jugadas = CrearJugadas();
            // Crear una lsita de cartas (5), cuyo unica jugada aplicable es carta alta
            {
                
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Md5VsSha256>();
        }
    }
}
