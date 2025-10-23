using System.Globalization;
using System.Runtime.CompilerServices;

// Ejercicios Clase 1 y 2
// Tipos, conversiones, operaciones y contrl de flujo

const string LISTADO_MENU = @"
1. Número positivo o negativo.
2. Comparación de tres números.
3. Múltiplos de un número.
4. Descuento en tienda.
5. Conversión de tipo.
6. Clasificación por edad.
7. Número dentro de rango.
8. Operador ternario.
9. Cálculo de impuestos.
10. Día de la semana con switch.
11. Menú con switch: (1. Sumar, 2. Restar, 3. Multiplicar, 4.Dividir)
12. Contador de pares.
13. Suma de números impares.
14. Contador de letras.
15. Tabla de multiplicar.
16. Promedio de notas.
17. Contador hasta que sea cero.
18. Suma acumulada con condición.
19. Contador de dígitos.
20. Contar vocales.

### Extra - Opcional ###
21. Mini cajero automático
";

while (true)
{
    Console.WriteLine("==============================================");
    Console.WriteLine("         EJERCICIOS CLASE 1 Y 2 (C#)          ");
    Console.WriteLine("==============================================");
    Console.WriteLine("\nMenú de Ejercicios:");
    Console.WriteLine(LISTADO_MENU);
    Console.WriteLine("Ingrese el número del ejercicio que desea probar (1-21):");
    Console.WriteLine("Ingrese '0' o 'salir' para terminar el programa.");

    string? opcion = Console.ReadLine();

    if (opcion == "0" || string.Equals(opcion, "salir", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("\nPrograma terminado, adios!");
        break;
    }

    if (int.TryParse(opcion, out int numeroEjercicio))
    {
        switch (numeroEjercicio)
        {
            case 1:
                Ejercicio1PositivoNegativo();
                break;
            case 2:
                Ejercicio2TresNumeros();
                break;
            case 3:
                Ejercicio3MultiplosNumero();
                break;
            case 4:
                Ejercicio4PrecioDescuento();
                break;
            case 5:
                Ejercicio5ConversionExplicita();
                break;
            case 6:
                EjercicioEdadPersona();
                break;
            case 7:
                Ejercicio7NumeroDentroRango();
                break;
            case 8:
                Ejercicio8NumeroParImpar();
                break;
            case 9:
                Ejercicio9IngresoImpuesto();
                break;
            case 10:
                Ejercicio10DiasDeLaSemana();
                break;
            case 11:
                Ejercicio11OperacionesAritmeticas();
                break;
            case 12:
                Ejercicio12CuantosPares();
                break;
            case 13:
                Ejercicio13SumaNumerosPares();
                break;
            case 14:
                Ejercicio14ContadorLetras();
                break;
            case 15:
                Ejercicio15TablaMultiplicar();
                break;
            case 16:
                Ejercicio16PromedioNotas();
                break;
            case 17:
                Ejercicio17ContadorHastaCero();
                break;
            case 18:
                Ejercicio18SumaAcumulada();
                break;
            case 19:
                Ejercicio19ContadorDigitos();
                break;
            case 20:
                Ejercicio20ContarVocales();
                break;
            case 21:
                Ejercicio21MiniCajeroautomatico();
                break;
            default:
                Console.WriteLine($"El numero ingresado {numeroEjercicio} no corresponde a un ejercicio valido.");
                break;

        }
    }
    else
    {
        Console.WriteLine("Opcion no valida, ingresa un numero valido del 1 al 20");
    }
    Console.WriteLine("\nPresione ENTER para regresar al menú anterior...");
    Console.ReadLine();

}


// 1. Número positivo o negativo: Pedir un número y mostrar si es positivo, negativo o cero.

static void Ejercicio1PositivoNegativo()
{
    Console.WriteLine("1. Número positivo o negativo: Pedir un número y mostrar si es positivo, negativo o cero.");
    Console.Write("Ingrese un numero entero: ");
    string? numero = Console.ReadLine();
    if (int.TryParse(numero, out int numeroIngresado))
    {
        string resultado = "";
        if (numeroIngresado == 0) { resultado = "cero"; }
        else if (numeroIngresado < 0) { resultado = "negativo"; }
        else if (numeroIngresado > 0) { resultado = "positivo"; }
        Console.WriteLine($"El numero ingresado es {resultado}.");
    }
    else
    {
        Console.WriteLine("Opcion no valida, ingresa un numero entero valido");
    }
}

// 2. Comparación de tres números: Pedir tres números distintos y mostrar cuál es el
// mayor y cuál el menor.

static void Ejercicio2TresNumeros()
{
    Console.WriteLine("2. Comparación de tres números: Pedir tres números distintos y mostrar cuál es el mayor y cuál el menor.");
    Console.WriteLine("Ingresa tres numeros distintos separados por coma:");
    string? numerosStr = Console.ReadLine();
    if (string.IsNullOrEmpty(numerosStr))
    {
        Console.WriteLine("Entrada vacia");
        return;
    }
    string[] arrayNumeros = numerosStr.Split(',');

    var numeros = new List<int>();
    foreach (var p in arrayNumeros)
    {
        if (int.TryParse(p, out var n)) numeros.Add(n);
        else
        {
            Console.WriteLine("Valor no numerico");
            return;
        }
    }

    int numeroMayor = numeros.Max();
    int numeroMenor = numeros.Min();
    Console.WriteLine($"El numero mayor es: {numeroMayor}");
    Console.WriteLine($"El numero menor es: {numeroMenor}");
}

// 3. Múltiplos de un número: Pedir dos números e indicar si el primero es múltiplo del
// segundo.

static void Ejercicio3MultiplosNumero()
{
    bool ValidarInput(string? inputUsuario, out int numero)
    {
        if (string.IsNullOrEmpty(inputUsuario))
        {
            Console.WriteLine("Entrada vacía.");
            numero = 0;
            return false;
        }

        if (int.TryParse(inputUsuario, out numero))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Entrada invalida, ingrese un numero valido");
            return false;
        }
    }

    Console.WriteLine("3. Múltiplos de un número: Pedir dos números e indicar si el primero es múltiplo del segundo.");
    Console.WriteLine("Ingresa el primer numero:");
    string? inputUsuario = Console.ReadLine();

    if (!ValidarInput(inputUsuario, out int primerNumero)) return;
    Console.WriteLine("Ingresa el segundo numero:");
    inputUsuario = Console.ReadLine();
    if (!ValidarInput(inputUsuario, out int segundoNumero)) return;
    bool esMultiplo = (primerNumero % segundoNumero == 0) ? true : false;
    Console.WriteLine($"El primero numero es multiplo del segundo: {esMultiplo}");

}

// 4. Descuento en tienda: Pedir el precio de un producto y aplicar un descuento del 10%
// si el precio es mayor a $1000.

static void Ejercicio4PrecioDescuento()
{
    Console.WriteLine("4. Descuento en tienda: Para verificar su descuento, ingrese el precio del producto:");
    string? inputUsuario = Console.ReadLine();
    // double precioProducto;
    bool esValido = double.TryParse(inputUsuario, out double precioProducto);
    if (esValido)
    {
        double nuevoPrecio = precioProducto;
        if (precioProducto > 1000)
        {
            nuevoPrecio = precioProducto * 0.9;
        }
        Console.WriteLine($"El precio del producto seria: {nuevoPrecio}");

    }
    else
    {
        Console.WriteLine($"Error: '{inputUsuario}' no es un número decimal válido.");
    }
}

// 5. Conversión de tipo: Pedir un número decimal y convertirlo a entero (usando
// conversión explícita). Mostrar ambos valores y comentar la diferencia.

static void Ejercicio5ConversionExplicita()
{
    Console.WriteLine("5. Conversion de tipo explicita. Ingrese un numero decimal:");

    string? inputUsuario = Console.ReadLine();
    if (string.IsNullOrEmpty(inputUsuario))
    {
        Console.WriteLine("Entrada vacía.");
        return;
    }
    string inputEstandarizado = inputUsuario.Replace(',', '.');
    bool esValido = decimal.TryParse(inputEstandarizado, NumberStyles.Any,
                     CultureInfo.InvariantCulture, out decimal numeroDecimal);

    if (esValido)
    {
        int numeroEntero = (int)numeroDecimal;
        Console.WriteLine($"Numero decimal original: {numeroDecimal}");
        Console.WriteLine($"Numero convertido a entero: {numeroEntero}");
        Console.WriteLine("Cuando se hace esta conversion, los digitos decimales se truncan hacia cero. En otras palabras se pierden esos decimales");
    }
    else
    {
        Console.WriteLine($"El numero ingresado {inputUsuario} no es valido, intente nuevamente");
    }
}
// 6. Clasificación por edad: Pedir la edad y mostrar si la persona es niño, adolescente,
// adulto o adulto mayor (usa if-else if-else).

static void EjercicioEdadPersona()
{
    Console.WriteLine("6. Clasificación por edad. Ingrese edad:");
    string? inputUsuario = Console.ReadLine();
    bool esValido = int.TryParse(inputUsuario, out int edadPersona);

    if (esValido && edadPersona > 0 && edadPersona < 100)
    {
        if (edadPersona < 12)
        {
            Console.WriteLine("La persona es un niño/a");
        }
        else if (edadPersona < 18)
        {
            Console.WriteLine("La persona es un adolescente");

        }
        else if (edadPersona < 65)
        {
            Console.WriteLine("La persona es un adulto");

        }
        else if (edadPersona < 100)
        {
            Console.WriteLine("La persona es un adulto mayor");

        }
    }
    else
    {
        Console.WriteLine("El valor ingresado no es correcto intente nuevamente.");
    }
}
// 7. Número dentro de rango: Pedir un número y verificar si está dentro del rango 1–100
// (inclusive).

static void Ejercicio7NumeroDentroRango()
{
    Console.WriteLine("7. Número dentro de rango 1-100 (inclusive). Ingrese un numero:");
    string? inputUsuario = Console.ReadLine();
    if (int.TryParse(inputUsuario, out int numero))
    {
        if (numero >= 1 && numero <= 100)
        {
            Console.WriteLine("El numero SI se encuentra en el rango 1-100");
        }
        else
        {
            Console.WriteLine("El numero NO se encuentra en el rango 1-100");
        }
    }
    else
    {
        Console.WriteLine("Entrada incorrecta, ingrese un numero valido.");
    }
}
// 8. Operador ternario: Pedir un número y mostrar "Par" o "Impar" usando el operador
// ternario.

static void Ejercicio8NumeroParImpar()
{
    Console.WriteLine("8. Operador ternario. Ingrese un numero para ver si es par o impar:");
    string? inputUsuario = Console.ReadLine();
    if (int.TryParse(inputUsuario, out int numero))
    {
        string mensaje = (numero % 2 == 0) ? "El numero es par" : "El numero es impar";
        Console.WriteLine(mensaje);
    }
    else
    {
        Console.WriteLine("Entrada incorrecta ingrese un numero entero");
    }
}
/*
9. Cálculo de impuestos: Pedir un ingreso anual y calcular el impuesto:
< 10,000: 0%
10,000–50,000: 10%
50,000: 20%
Mostrar el monto de impuesto a pagar.
*/
static void Ejercicio9IngresoImpuesto()
{
    Console.WriteLine("9. Cálculo de impuestos. Ingrese su ingreso anual para calcular su impuesto:");
    string? inputUsuario = Console.ReadLine();
    if (double.TryParse(inputUsuario, out double ingresoAnual))
    {
        if (ingresoAnual < 10000)
        {
            Console.WriteLine("Su impuesto es 0%");
        }
        else if (ingresoAnual > 10000 && ingresoAnual < 50000)
        {
            Console.WriteLine("Su impuesto es 10%");
        }
        else if (ingresoAnual > 50000)
        {
            Console.WriteLine("Su impuesto es 20%");
        }
    }
    else
    {
        Console.WriteLine("Entrada incorrecta, ingrese un valor valido (ej: 123,45)");
    }

}

// 10. Día de la semana con switch: Pedir un número del 1 al 7 y mostrar el día de la
// semana correspondiente.

static void Ejercicio10DiasDeLaSemana()
{
    Console.WriteLine("10. Día de la semana. Ingrese un numero valido (1-7) para saber el dia de la semana:");
    string? inputUsuario = Console.ReadLine();
    string diaSemana = "";
    if (int.TryParse(inputUsuario, out int numeroDia) && numeroDia >= 1 && numeroDia <= 7)
    {

        switch (numeroDia)
        {
            case 1:
                diaSemana = "Lunes";
                break;
            case 2:
                diaSemana = "Martes";
                break;
            case 3:
                diaSemana = "Miercoles";
                break;
            case 4:
                diaSemana = "Jueves";
                break;
            case 5:
                diaSemana = "Viernes";
                break;
            case 6:
                diaSemana = "Sabado";
                break;
            case 7:
                diaSemana = "Domingo";
                break;
            default:
                diaSemana = "Desconocido";
                break;
        }
        Console.WriteLine($"El dia de la semana es: {diaSemana}");
    }
    else
    {
        Console.WriteLine("Entrada invalida, ingrese un numero valido (1-7)");
    }
}
/*
11. Menú con switch: Crear un menú con opciones (1. Sumar, 2. Restar, 3. Multiplicar, 4.Dividir). Pedir dos números y ejecutar la operación elegida.
*/

static void Ejercicio11OperacionesAritmeticas()
{
    Console.WriteLine("11. Menú con switch: opciones (1. Sumar, 2. Restar, 3. Multiplicar, 4.Dividir). Ingrese opcion: ");
    string? inputUsuario = Console.ReadLine();
    if (inputUsuario == null) return;
    double numeroUno, numeroDos;

    bool LeerEntero(string instruccion, out double numero)
    {
        Console.WriteLine(instruccion);
        string? lectura = Console.ReadLine();
        if (lectura != null) lectura = lectura.Replace(',', '.');
        if (!double.TryParse(lectura, out numero))
        {
            Console.WriteLine("Entrada no valida, ingrese un numero entero");
            return false;
        }
        else
        {
            return true;
        }
    }

    switch (inputUsuario)
    {
        case "1":
            Console.WriteLine("Opcion 1 Sumar dos numeros");
            if (!LeerEntero("Ingrese el primer numero:", out numeroUno)) return;
            if (!LeerEntero("Ingrese el segundo numero:", out numeroDos)) return;
            Console.WriteLine($"La respuesta es: {numeroUno + numeroDos}");
            break;

        case "2":
            Console.WriteLine("Opcion 2 Restar dos numeros");
            if (!LeerEntero("Ingrese el primer numero:", out numeroUno)) return;
            if (!LeerEntero("Ingrese el segundo numero:", out numeroDos)) return;
            Console.WriteLine($"La respuesta es: {numeroUno - numeroDos}");
            break;
        case "3":
            Console.WriteLine("Opcion 3 Multiplicar dos numeros");
            if (!LeerEntero("Ingrese el primer numero:", out numeroUno)) return;
            if (!LeerEntero("Ingrese el segundo numero:", out numeroDos)) return;
            Console.WriteLine($"La respuesta es: {numeroUno * numeroDos}");
            break;
        case "4":
            Console.WriteLine("Opcion 4 Dividir dos numeros");
            if (!LeerEntero("Ingrese el primer numero:", out numeroUno)) return;
            if (!LeerEntero("Ingrese el segundo numero:", out numeroDos)) return;
            if (numeroDos == 0) { Console.WriteLine("El Divisor no puede ser cero."); return; }
            Console.WriteLine($"La respuesta es: {numeroUno / numeroDos}");
            break;
        default:
            Console.WriteLine("Opcion no valida");
            break;

    }
}
// 12. Contador de pares: Pedir un número N y mostrar cuántos números pares hay entre 1 y N.

static void Ejercicio12CuantosPares()
{
    Console.WriteLine("12. Contador de pares. Cuántos números pares hay entre 1 y N? Ingrese un numero N: ");
    string? inputUsuario = Console.ReadLine();
    if (int.TryParse(inputUsuario, out int numero))
    {
        int contador = 0;
        for (int i = 1; i <= numero; i++)
        {
            if (i % 2 == 0) contador++;
        }
        Console.WriteLine($"Entre 1 y {numero} existen {contador} numeros pares");
    }
    else
    {
        Console.WriteLine("Entrada invalida, ingrese un numero entero");
    }
}
// 13. Suma de números impares: Calcular la suma de los números impares del 1 al 100.

static void Ejercicio13SumaNumerosPares()
{
    Console.WriteLine("13. Suma de números impares.");
    int suma = 0;
    for (int i = 1; i <= 100; i++)
    {
        if (i % 2 != 0) suma += i;
    }
    Console.WriteLine($"La suma de los números impares del 1 al 100 es {suma}.");
}
// 14. Contador de letras: Pedir una palabra y mostrar cuántas letras tiene.
static void Ejercicio14ContadorLetras()
{
    Console.WriteLine("14. Contador de letras. Ingrese una palabra para saber cuantas letras tiene.");
    string? inputUsuario = Console.ReadLine();
    int contador = 0;
    if (!string.IsNullOrEmpty(inputUsuario))
    {
        foreach (char c in inputUsuario)
        {
            contador++;
        }
        Console.WriteLine($"La palabra tiene {contador} letras.");
    }
    else
    {
        Console.WriteLine("No puede dejar el campo vacio, ingrese una palabra.");
    }
}
// 15. Tabla de multiplicar: Pedir un número y mostrar su tabla de multiplicar del 1 al 10.

static void Ejercicio15TablaMultiplicar()
{
    Console.WriteLine("15. Tabla de multiplicar. Ingrese un número para mostrar su tabla de multiplicar del 1 al 10.");
    string? inputUsuario = Console.ReadLine();
    if (int.TryParse(inputUsuario, out int numero))
    {
        string tablaMultiplicar = $"Tabla de multiplicar del numero {numero}:\n";
        for (int i = 1; i <= 10; i++)
        {
            int resultado = numero * i;
            string linea = $"{numero} X {i} = {resultado}\n";
            tablaMultiplicar += linea;
        }
        Console.WriteLine(tablaMultiplicar);
    }
    else
    {
        Console.WriteLine("Entrada no valida, ingrese un numero entero.");
    }
}
// 16. Promedio de notas: Pedir 5 notas, calcular el promedio y mostrar si el estudiante aprueba (>=6) o no.

static void Ejercicio16PromedioNotas()
{
    Console.WriteLine("16. Promedio de notas.");
    Console.WriteLine("Puede ingresar notas con decimales entre 1 y 10, por ejemplo: 5.6");
    bool IngresoNota(string instruccion, out double nota)
    {
        Console.WriteLine(instruccion);
        string? inputUsuario = Console.ReadLine();
        if (inputUsuario != null) inputUsuario = inputUsuario.Replace(',', '.');
        if (double.TryParse(inputUsuario, out nota) && nota >= 1 && nota <= 10)
        {
            return true;
        }
        Console.WriteLine("Entrada incorrecta, ingrese un valor valido.");
        return false;
    }

    if (!IngresoNota("Ingrese nota 1: ", out double notaUno)) return;
    if (!IngresoNota("Ingrese nota 2: ", out double notaDos)) return;
    if (!IngresoNota("Ingrese nota 3: ", out double notaTres)) return;
    if (!IngresoNota("Ingrese nota 4: ", out double notaCuatro)) return;
    if (!IngresoNota("Ingrese nota 5: ", out double notaCinco)) return;
    double promedio = (notaUno + notaDos + notaTres + notaCuatro + notaCinco) / 5;
    string veredicto;
    if (promedio >= 6) veredicto = $"Promedio: {promedio}. El estudiante SI aprueba.";
    else veredicto = $"Promedio: {promedio}. El estudiante NO aprueba.";
    Console.WriteLine(veredicto);
}
// 17. Contador hasta que sea cero: Pedir números enteros hasta que el usuario ingrese 0. Mostrar la cantidad de números introducidos.
static void Ejercicio17ContadorHastaCero()
{
    Console.WriteLine("17. Contador hasta que sea cero.");
    int contador = 0;
    bool esValido(string instruccion, out int numeroLeido)
    {
        Console.WriteLine(instruccion);
        string? inputUsuario = Console.ReadLine();
        if (int.TryParse(inputUsuario, out numeroLeido))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Entrada invalida, ingrese un numero entero.");
            return false;
        }
    }

    while (true)
    {
        if (esValido("Ingrese un numero: ", out int numeroIngresado))
        {

            if (numeroIngresado == 0)
            {
                break;
            }
            contador++;
        }
    }
    Console.WriteLine($"Se introdujeron {contador} números antes del cero.");
}

// 18. Suma acumulada con condición: Pedir números y sumar hasta que la suma supere 100. Mostrar cuántos números se ingresaron.

static void Ejercicio18SumaAcumulada()
{
    Console.WriteLine("18. Suma acumulada con condición.");
    int contador = 0, suma = 0;
    bool esValido(string instruccion, out int numeroLeido)
    {
        Console.WriteLine(instruccion);
        string? inputUsuario = Console.ReadLine();
        if (int.TryParse(inputUsuario, out numeroLeido))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Entrada invalida, ingrese un numero entero.");
            return false;
        }
    }

    while (true)
    {
        if (esValido("Ingrese un numero: ", out int numeroIngresado))
        {
            contador++;
            suma += numeroIngresado;
            if (suma > 100)
            {
                break;
            }
        }
    }
    Console.WriteLine($"Se introdujeron {contador} números antes de superar la suma de 100, superado con ({suma}).");

}

// 19. Contador de dígitos: Pedir un número entero y decir cuántos dígitos tiene.
static void Ejercicio19ContadorDigitos()
{
    Console.WriteLine("19. Contador de dígitos. Ingrese un numero entero para saber cuantos digitos tiene:");
    string? inputUsuario = Console.ReadLine();
    if (int.TryParse(inputUsuario, out int numeroLeido))
    {
        int contador = 0;
        foreach (char digito in numeroLeido.ToString())
        {
            contador++;
        }
        Console.WriteLine($"El numero {numeroLeido} tiene {contador} digitos.");

    }
    else
    {
        Console.WriteLine("Entrada invalida, ingrese un numero entero.");
    }

}

// 20. Contar vocales: Pedir una palabra y contar cuántas vocales tiene.
static void Ejercicio20ContarVocales()
{

    Console.WriteLine("20. Contador de vocales. Ingrese una palabra para saber cuantas vocales tiene.");
    string? inputUsuario = Console.ReadLine();
    int contador = 0;
    char[] vocales = ['a', 'e', 'i', 'o', 'u'];
    if (!string.IsNullOrEmpty(inputUsuario))
    {
        foreach (char c in inputUsuario)
        {
            foreach (char v in vocales)
            {
                if (c == v)
                {
                    contador++;

                }
            }
        }
        Console.WriteLine($"La palabra tiene {contador} vocales.");
    }
    else
    {
        Console.WriteLine("No puede dejar el campo vacio, ingrese una palabra.");
    }
}

/*
Ejercicio 21 - Extra - Opcional:
21. Mini cajero automático
Simular un cajero con un saldo inicial. Mostrar un menú con opciones:
1) Consultar saldo
2) Depositar
3) Retirar
4) Salir
Validar que no se retire más de lo que hay y que los montos sean positivos.
*/

static void Ejercicio21MiniCajeroautomatico()
{
    bool inicio = true;
    decimal saldoInicial = 123.45m;
    decimal saldo = saldoInicial;
    while (inicio)
    {
        Console.WriteLine("\nCajero automatico - Bienvenido");
        Console.WriteLine("Escoja una opcion:");
        Console.WriteLine("1) Consultar Saldo");
        Console.WriteLine("2) Depositar");
        Console.WriteLine("3) Retirar");
        Console.WriteLine("4) Salir\n");
        string? inputUsuario = Console.ReadLine();


        void ConsultarSaldo()
        {
            Console.WriteLine($"Su saldo actual es: ${saldo}");
        }

        void Depositar(decimal deposito)
        {
            saldo += deposito;
            Console.WriteLine("Deposito realizado con exito!");
            ConsultarSaldo();
        }

        void Retirar(decimal retiro)
        {
            if (retiro > saldo)
            {
                Console.WriteLine($"No se puede retirar una cantidad mayor al saldo actual ${saldo}");
                return;
            }
            saldo -= retiro;
            Console.WriteLine("Retiro realizado con exito!");
            ConsultarSaldo();
        }

        bool PedirCantidad(string mensaje, out decimal cantidad)
        {
            Console.WriteLine(mensaje);
            string? cantidadStr = Console.ReadLine();
            if (cantidadStr != null) cantidadStr = cantidadStr.Replace(',', '.');
            if (decimal.TryParse(cantidadStr, out cantidad) && cantidad > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Cantidad invalida, ingrese un valor correcto");
                return false;
            }
        }
        decimal cantidad;
        switch (inputUsuario)
        {
            case "1":
                ConsultarSaldo();
                break;
            case "2":
                if (!PedirCantidad("Que cantidad desea depositar: ", out cantidad)) continue;
                Depositar(cantidad);
                break;
            case "3":
                if (!PedirCantidad("Que cantidad desea retirar: ", out cantidad)) continue;
                Retirar(cantidad);
                break;
            case "4":
                inicio = false;
                break;
        }
    }


}