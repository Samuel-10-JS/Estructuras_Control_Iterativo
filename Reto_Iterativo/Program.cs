class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("=== REGISTRO DE CALIFICACIONES ===");
        int[] calificaciones = { 79, 83, 99, 61, 48, 71, 91, 54, 83, 69 };

        for (int i = 0; i < calificaciones.Length; i++)
        {
            Console.WriteLine($"Estudiante {i + 1}: {calificaciones[i]}");
        }

        Console.WriteLine("\n=== ORDEN DESCENDENTE ===");
        for (int i = calificaciones.Length - 1; i >= 0; i--)
        {
            Console.WriteLine($"Estudiante {i + 1}: {calificaciones[i]}");
        }

        Console.WriteLine("\n=== PROMEDIO DEL GRUPO ===");

        int sumaTotal = 0;
        foreach (int cal in calificaciones)
        {
            sumaTotal += cal;
        }
        double promedio = (double)sumaTotal / calificaciones.Length;
        Console.WriteLine($"Suma total: {sumaTotal}");
        Console.WriteLine($"Promedio: {promedio:F1}");

        Console.WriteLine("\n=== POSICIONES PARES ===");

        for (int i = 0; i < calificaciones.Length; i += 2)
        {
            Console.WriteLine($"Posición par: {calificaciones[i]}");
        }

        Console.WriteLine("\n=== CONTROL DE ACCESO ===");
        int intentos = 0;
        string claveCorrecta = "sena2025";
        bool accesoConcedido = false;

        while (intentos < 3 && !accesoConcedido)
        {
            Console.Write("Ingresa la clave: ");
            string? entrada = Console.ReadLine();

            if (entrada == claveCorrecta)
            {
                Console.WriteLine("Acceso concedido.");
                accesoConcedido = true;
            }
            else
            {
                intentos++;
                int restantes = 3 - intentos;
                if (restantes > 0)
                {
                    Console.WriteLine($"Clave incorrecta. Intentos restantes: {restantes}");
                }
                else
                {
                    Console.WriteLine("Acceso bloqueado.");
                }
            }
        }

        if (accesoConcedido)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Ver promedio del grupo");
                Console.WriteLine("2. Ver calificación más alta");
                Console.WriteLine("3. Salir");
                Console.Write("Elige una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine($"Promedio del grupo: {promedio:F1}");
                            break;
                        case 2:
                            int calMasAlta = calificaciones[0];
                            foreach (int c in calificaciones)
                            {
                                if (c > calMasAlta)
                                {
                                    calMasAlta = c;
                                }
                            }
                            Console.WriteLine($"Calificación más alta: {calMasAlta}");
                            break;
                        case 3:
                            Console.WriteLine("Hasta luego.");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intenta de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    opcion = 0; 
                }
            } while (opcion != 3);
        }

        Console.WriteLine("\n=== PRIMERA CALIFICACIÓN REPROBATORIA ===");
        for (int i = 0; i < calificaciones.Length; i++)
        {
            if (calificaciones[i] < 60)
            {
                Console.WriteLine($"Encontrada en posición {i + 1}: {calificaciones[i]}");
                break;
            }
        }

        Console.WriteLine("\n=== ESTUDIANTES APROBADOS ===");
        int totalAprobados = 0;
        foreach (int cal in calificaciones)
        {
            if (cal < 60)
            {
                continue;
            }
            Console.WriteLine($"Aprobado: {cal}");
            totalAprobados++;
        }
        Console.WriteLine($"Total aprobados: {totalAprobados}");

        Console.WriteLine("\n=== FILTRO COMBINADO ===");

        for (int i = 0; i < calificaciones.Length; i++)
        {
            if (calificaciones[i] < 70)
            {
                continue;
            }
            if (calificaciones[i] >= 95)
            {
                Console.WriteLine($"Búsqueda detenida al encontrar: {calificaciones[i]}");
                break;
            }
            Console.WriteLine($"Calificación procesada: {calificaciones[i]}");
        }
    }
}