int totalOperaciones = 0;
double recaudacionTotal = 0;
double operacionMasCara = 0;
string clienteMasCaro = "";
bool salirMenuPrincipal = false;

while (!salirMenuPrincipal)
{
    Console.Clear();
    Console.WriteLine("-------------------------");
    Console.WriteLine("     TALLER MECÁNICO     ");
    Console.WriteLine("-------------------------");
    Console.WriteLine("1. Registrar una nueva orden de reparación");
    Console.WriteLine("2. Consultar cada y resumen de actividad");
    Console.WriteLine("3. Salir del programa");
    Console.WriteLine();
    Console.WriteLine("Seleccione una opción: ");

    string opcionMenu = Console.ReadLine();

    if (opcionMenu == "1")
    {
        Console.Write("Ingresar nombre del cliente: ");
        string nombreCliente = Console.ReadLine();

        Console.WriteLine("---  Servicios Mecánicos  ---");
        Console.WriteLine("1. Diagnóstico computarizado - 25.00 €");
        Console.WriteLine("2. Liempieza de inyectores - 45.00 €");
        Console.WriteLine("3. Instalación de frenos - 60.00 €");
        Console.WriteLine("Selecione el servicio (1-3): ");
        string opcionServicio = Console.ReadLine();

        double precioServicio = 0;
        string servicioPrincipal = "";

        if (opcionServicio == "1")
        {
            servicioPrincipal = "Diagnóstico computarizado";
            precioServicio = 25.0;
        }
        else if (opcionServicio == "2")
        {
            servicioPrincipal = "Limpieza de inyectores";
            precioServicio = 45.0;
        }
        else if (opcionServicio == "3")
        {
            servicioPrincipal = "Instalación de frenos";
            precioServicio = 60.0;
        }
        else
        {
            servicioPrincipal = "ERROR";
            precioServicio = 0.0;
        }

        double importeExtras = 0;
        int contadorExtra = 0;
        bool masExtra = true;

        while (masExtra)
        {
            Console.WriteLine("---  Servicios Adicionales  ---");
            Console.WriteLine("1. Copia de seguridad de - 15.00 €");
            Console.WriteLine("2. Actualización de Software");
            Console.WriteLine("3. Revisión de niveles - 10.00 €");
            Console.WriteLine("4. Terminar selección de extras");
            Console.WriteLine("Selecione una opción: ");
            string opExtra = Console.ReadLine();

            if (opExtra == "1")
            {
                importeExtras = importeExtras + 15.0;
                contadorExtra++;
            }
            else if (opExtra == "2")
            {
                importeExtras = importeExtras + 20.0;
                contadorExtra++;
            }
            else if (opExtra == "3")
            {
                importeExtras = importeExtras + 10.0;
                contadorExtra++;
            }
            else if (opExtra == "4")
            {
                masExtra = false;
            }
            else
            {
                Console.WriteLine("Opción no válida");
            }
        }

        Console.WriteLine("---  modalidad de Taller  ---");
        Console.WriteLine("1. Turno Normal (sin costo)");
        Console.WriteLine("2. Reparación Urgente (15.00 €)");
        Console.WriteLine("Seleccione la modalidad (1-2): ");
        string opModalidad = Console.ReadLine();
        
        double suplemento = 0;
        string modalidad = "Normal";

        if (opModalidad == "2")
        {
            suplemento = 15.0;
            modalidad = "Urgente";
        }

        double subtotal = precioServicio + importeExtras;
        double descuento = 0;

        if (subtotal > 50.0)
        {
            descuento = subtotal * 0.10;
        }

        double totalFinal = subtotal - descuento + suplemento;

        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Total a Pagar. " + totalFinal + " €");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Ingrese el dinero: ");
        double dinero = Convert.ToDouble(Console.ReadLine());

        while (dinero < totalFinal)
        {
            double faltante = totalFinal - dinero;
            Console.WriteLine ("Efectivo insuficiente. Faltan " + faltante + " €.");
            Console.Write("Ingrese nuevamente el dinero: ");
            dinero = Convert.ToDouble(Console.ReadLine());
        }

        double cambio = dinero - totalFinal;

        totalOperaciones++;
        recaudacionTotal = recaudacionTotal + totalFinal;

        if (totalFinal > operacionMasCara)
        {
            operacionMasCara = totalFinal;
            clienteMasCaro = nombreCliente;
        }
        Console.Clear();
        Console.WriteLine("------------------------------------");
        Console.WriteLine("     Justificante de Reparación     ");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Cliente: " + nombreCliente);
        Console.WriteLine("Servicio: " + servicioPrincipal);
        Console.WriteLine("Modalidad: " + modalidad);
        Console.WriteLine("Cantidad de extras: " + contadorExtra);
        Console.WriteLine("Subtotal: " + subtotal + " €");
        Console.WriteLine("Descuento: " + descuento + " €");
        Console.WriteLine("Suplemento: " + suplemento + " €");
        Console.WriteLine("Total cobrado: " + totalFinal + " €");
        Console.WriteLine("Dinero entregado: " + dinero + " €");
        Console.WriteLine("Cambio entregado: " + cambio + " €");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Presione una tecla para volver al menú...");
        Console.ReadKey();

    }
    else if (opcionMenu == "2")
    {
        Console.Clear();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("     Balance de Caja Diaria     ");
        Console.WriteLine("--------------------------------");
        if (totalOperaciones == 0)
        {
            Console.WriteLine("No se registran órdenes en este turno.");
        }
        else
        {
            double valorMedio = recaudacionTotal / totalOperaciones;
            Console.WriteLine("Órdenes realizadas: " + totalOperaciones);
            Console.WriteLine("Recaudación total: " + recaudacionTotal + " €");
            Console.WriteLine("Valor medio por orden: " + valorMedio + " €");
            Console.WriteLine("Orden más cara: " + operacionMasCara + " € (Cliente: " + clienteMasCaro + ")");
        }
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Presione una tecla para regresar...");
        Console.ReadKey();
    }
    else if (opcionMenu == "3")
    {
        salirMenuPrincipal = true;
        Console.Clear();
        Console.WriteLine("Saliendo del programa.");
    }
    else
    {
        Console.WriteLine("Opción no válida. Presione una tecla para intentar de nuevo...");
        Console.ReadKey();
    }



}