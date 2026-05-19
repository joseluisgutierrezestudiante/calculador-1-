using System;

namespace CalculadoraPresupuesto
{
    class Program
    {
    {
        static void Main(string[] args)
        {
            // configuracion de la consola para mejor experiencia de usuario
            Console.Title = "Sistema de Gestión de Presupuesto";
            Console.WriteLine("=============================================");
            Console.WriteLine("bienvenido a la calculadora de la finanzas personal");
            Console.WriteLine("=============================================\n");

            // 1. datos basicos del usuario (manejo de texto con string)
            Console.Write("Por favor, ingresa tu nombre: ");
            string nombreUsuario = Console.ReadLine();

            // 2. ingreso de valores (Manejo de dinero con Decimal)
            Console.Write("Ingresa tus ingresos totales de este mes: ");
            string ingresoInput = Console.ReadLine();

            // Convertimos el texto a decimal para no perder precisión con centavos
            decimal ingresos = decimal.Parse(ingresoInput);

            Console.Write("Ingresa el gasto total de tus facturas o arriendo: ");
            string gastosInput = Console.ReadLine();
            decimal gastosFijos = decimal.Parse(gastosInput);

            Console.Write("Ingresa un estimado de gastos extra (comida, salidas, transporte): ");
            string extrasInput = Console.ReadLine();
            decimal gastosExtras = decimal.Parse(extrasInput);

            // 3. operacion aritmetica para calcular el saldo neto (manejo de numeros con decimal)
            decimal totalGastos = gastosFijos + gastosExtras;
            decimal saldoNeto = ingresos - totalGastos;

            // 4. presentacion de resultados con interpolacion de cadena y formato de moneda
            Console.WriteLine("\n=============================================");
            Console.WriteLine($"         RESUMEN FINANCIERO DE {nombreUsuario.ToUpper()} ");
            Console.WriteLine("=============================================");

            // El formato :C o :F2 ayuda a representar el dinero de forma limpia en pantalla
            Console.WriteLine($"Total Ingresos:       ${ingresos:F2}");
            Console.WriteLine($"Total Gastos:         ${totalGastos:F2}");
            Console.WriteLine("---------------------------------------------");

            // Evaluamos la situación financiera para dar un mensaje adecuado
            if (saldoNeto > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"¡Buenas noticias! Te quedan: ${saldoNeto:F2} libres para ahorro o inversión.");
            }
            else if (saldoNeto == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Cuidado: Tus ingresos cubren exactamente tus gastos. No tienes margen de ahorro.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Alerta: Estás en déficit. Tu saldo es negativo por: ${Math.Abs(saldoNeto):F2}");
            }

            // Restauramos el color original de la consola y evitamos que se cierre rápido
            Console.ResetColor();
            Console.WriteLine("=============================================");
            Console.WriteLine("\nPresiona cualquier tecla para salir del programa...");
            Console.ReadKey();
        }
    }
}