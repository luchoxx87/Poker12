List<byte> bytes = new List<byte>() { 8,8,8 };
var ordenar = bytes.OrderBy(x => x).ToList();

bool tieneTrio = false;

for (int i = 0; i < ordenar.Count - 2; i++)
{
    // Verificar si los tres elementos son iguales
    if (ordenar[i] == ordenar[i + 1] && ordenar[i + 1] == ordenar[i + 2])
    {
        Console.WriteLine($"Se encontró un trio con los valores: {ordenar[i]}, {ordenar[i + 1]}, {ordenar[i + 2]}");
        tieneTrio = true;
    }
}

if (tieneTrio)
{
    Console.WriteLine("Hay un trio en la lista.");
}
else
{
    Console.WriteLine("No hay un trio en la lista.");
}