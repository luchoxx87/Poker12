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
            return new List<IJugada>
            {
                new CartaAlta(),
                new Color(),
                new DoblePar(),
                new EscaleraReal(),
                new EscaleraColor(),
                new Escalera(),
                new FullHouse(),
                new Pareja(),
                new Trio()
            };
        }
        public Resultado ObtenerResultado(List<Carta>cartas)
        {
            var jugadas = CrearJugadas(cartas);
            var resultados = new List<Resultado>();

            foreach (var jugada in jugadas)
            {
                var resultado = jugada.Aplicar(cartas);
                if (resultado.Prioridad > 0)
                {
                    resultados.Add(resultado);
                }
            }

            return resultados.OrderByDescending(r => r.Prioridad).ThenByDescending(r => r.Valor).FirstOrDefault();

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
