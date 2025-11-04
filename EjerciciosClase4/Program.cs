
// Ejercicios Clase 4
// Colecciones: Listas, Arreglos, Diccionarios, Colas, Pilas

using System;
using System.Collections.Generic;
using System.Linq;

const string LISTADO_MENU = @"
1. Exámenes de un alumno.
2. Edades de 20 personas guardadas en una lista.
3. Lista de nombres de estudiantes.
4. Lista de supermercado.
5. Matriz de 5 x 5, pares/impares.
6. Matriz de 5x7, mes de mayo.
7. Almacenar en una matriz las tablas del 1 al 9.
8. Crear una matriz de 10 x 10, y “esconder” varias 'X' en lugares aleatorios.
9. Diccionario de calificaciones.
10. Simulador de atención en ventanilla.

### Extra - Opcional ###
11. Inventario con múltiples colecciones:
";

while (true)
{
    Console.WriteLine("==============================================");
    Console.WriteLine("         EJERCICIOS CLASE 4 (C#)          ");
    Console.WriteLine("==============================================");
    Console.WriteLine("\nMenú de Ejercicios:");
    Console.WriteLine(LISTADO_MENU);
    Console.WriteLine("Ingrese el número del ejercicio que desea probar (1-11):");
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
                Ejercicio1PromedioExamenesAlumno();
                break;
            case 2:
                Ejercicio2EdadesPersonas();
                break;
            case 3:
                Ejercicio3ConteoNombresEstudiantes();
                break;
            case 4:
                Ejercicio4ListaSupermercado();
                break;
            case 5:
                Ejercicio5Matriz5x5();
                break;
            case 6:
                Ejercicio6MatrizMesMayo();
                break;
            case 7:
                Ejercicio7MatrizTablaDelNueve();
                break;
            case 8:
                Ejercicio8EquisEscondidas();
                break;
            case 9:
                Ejercicio9DiccionarioCalificaciones();
                break;
            case 10:
                Ejercicio10AtencionVentanilla();
                break;
            case 11:
                Ejercicio11Inventario();
                break;

            default:
                Console.WriteLine($"El numero ingresado {numeroEjercicio} no corresponde a un ejercicio valido.");
                break;

        }
    }
    else
    {
        Console.WriteLine("Opcion no valida, ingresa un numero valido del 1 al 11");
    }
    Console.WriteLine("\nPresione ENTER para regresar al menú anterior...");
    Console.ReadLine();

}

// 1.​ Dado que se tiene almacenado en una lista, los resultados de los últimos 10
// exámenes de un alumno, calcular su promedio y mostrar por pantalla las 10 notas de
// los exámenes y el promedio resultante.
static void Ejercicio1PromedioExamenesAlumno()
{
    List<int> notasExamenes = new List<int> { 9, 7, 8, 6, 10, 7, 8, 6, 10, 9 };
    double promedio = notasExamenes.Average();
    Console.WriteLine("Las notas son: ");
    foreach (var nota in notasExamenes)
    {
        Console.WriteLine(nota);
    }
    Console.WriteLine($"El promedio de las notas es: {promedio}");
}

// 2.​ Dada las edades de 20 personas guardadas en una lista, imprimir por pantalla
// cuántos son mayores de edad y cuántos no.

static void Ejercicio2EdadesPersonas()
{
    List<int> edades = new List<int> { 5, 45, 23, 78, 9, 13, 34, 16, 33, 89, 7, 49, 52, 21, 67, 29, 13, 59, 10, 4 };
    int mayores = 0, menores = 0;
    Console.WriteLine($"Las edades son: {string.Join(", ", edades)}");
    foreach (var edad in edades)
    {
        if (edad > 18) mayores++;
        else menores++;
    }
    Console.WriteLine($"Mayores de edad: {mayores}");
    Console.WriteLine($"Menores de edad: {menores}");
}

// 3.​ Dado una lista de nombres de estudiantes, imprimir el que tenga más letras, y el que
// tenga menos letras de todos.

static void Ejercicio3ConteoNombresEstudiantes()
{
    List<string> nombresEstudiantes = new List<string> { "Pedro", "Maria", "Jose", "Juan", "Carolina" };
    Console.WriteLine($"Los nombres dados son: {string.Join(", ", nombresEstudiantes)}");
    Dictionary<int, int> diccionarioNombres = new Dictionary<int, int>();
    foreach (var nombre in nombresEstudiantes)
    {
        diccionarioNombres.Add(nombresEstudiantes.IndexOf(nombre), nombre.Length);
    }

    var indiceNombreMasLargo = diccionarioNombres.OrderByDescending(x => x.Value).First().Key;
    var indiceNombreMasCorto = diccionarioNombres.OrderBy(x => x.Value).First().Key;
    Console.WriteLine($"El nombre que tiene mas letras es: {nombresEstudiantes[indiceNombreMasLargo]}");
    Console.WriteLine($"El nombre que tiene menos letras es: {nombresEstudiantes[indiceNombreMasCorto]}");

}

// 4.​ Crear una variable para guardar los nombres de elementos para una “lista de
// supermercado”. Solicitar al usuario que ingrese el nombre de un elemento que va a
// comprar en el super y verificar que el elemento esté en la lista. Si no está, agregarlo
// e indicar que no estaba. Si está, quitarlo de la lista, y avisar que sí estaba. Al
// finalizar mostrar por pantalla los elementos que no compró y los que compró, pero
// no estaban en la lista. Si se quiere, mostrar también todos los elementos que el
// usuario compró. Para salir el usuario debe ingresar “fin”.

static void Ejercicio4ListaSupermercado()
{
    List<string> listaSupermercado = new List<string> { "leche", "pan", "huevos", "fruta", "carne" };

    List<string> compradosExtra = new List<string>();
    List<string> compradosDeLaLista = new List<string>();

    Console.WriteLine("Lista de Supermercado");
    Console.WriteLine("Ingresa los productos que compras. Escribe 'fin' para terminar.");
    Console.WriteLine("Lista original: " + string.Join(", ", listaSupermercado));

    while (true)
    {
        Console.Write("\nIngresa un producto: ");
        string productoIngresado = (Console.ReadLine() ?? "").ToLower().Trim();

        if (productoIngresado == "fin")
        {
            break;
        }

        if (string.IsNullOrEmpty(productoIngresado))
        {
            continue;
        }

        if (listaSupermercado.Contains(productoIngresado))
        {
            listaSupermercado.Remove(productoIngresado);
            compradosDeLaLista.Add(productoIngresado);
            Console.WriteLine($"'{productoIngresado}' SÍ estaba en la lista. ¡Comprado!");
        }
        else
        {
            compradosExtra.Add(productoIngresado);
            Console.WriteLine($"'{productoIngresado}' NO estaba en la lista, pero se agregó a las compras.");
        }
    }

    Console.WriteLine("\nResumen de Compras");

    Console.WriteLine("\nProductos que NO se compraron (quedaron en la lista):");
    if (listaSupermercado.Count > 0)
    {
        foreach (string producto in listaSupermercado)
        {
            Console.WriteLine("- " + producto);
        }
    }
    else
    {
        Console.WriteLine("Compraste todo lo que estaba en la lista");
    }

    Console.WriteLine("\nProductos que se compraron pero NO estaban en la lista original:");
    if (compradosExtra.Count > 0)
    {
        foreach (string producto in compradosExtra)
        {
            Console.WriteLine("- " + producto);
        }
    }
    else
    {
        Console.WriteLine("No compraste ningún producto extra.");
    }

    Console.WriteLine("\nResumen total de productos comprados:");
    List<string> todosLosComprados = new List<string>();
    todosLosComprados.AddRange(compradosDeLaLista);
    todosLosComprados.AddRange(compradosExtra);

    if (todosLosComprados.Count > 0)
    {
        foreach (string producto in todosLosComprados)
        {
            Console.WriteLine("- " + producto);
        }
    }
    else
    {
        Console.WriteLine("No se compró ningún producto.");
    }

}

// 5.​ Crear una matriz de 5 x 5. Almacenar una ‘I’ en lugares impares y una ‘P’ en lugares
// pares. Imprimir la matriz por pantalla

static void Ejercicio5Matriz5x5()
{
    Console.WriteLine("Matriz 5x5: ");
    string[,] matriz = new string[5, 5];
    int numero = 0;
    for (int i = 0; i < matriz.GetLength(0); i++)
    {
        for (int j = 0; j < matriz.GetLength(1); j++)
        {
            numero++;
            if (numero % 2 == 0) matriz[i, j] = "P";
            else matriz[i, j] = "I";
            Console.Write(matriz[i, j] + " ");

        }
        Console.WriteLine();
    }
}

// 6.​ Se tiene una matriz de 5x7, donde 5 representa la semana de un mes y 7 los días de
// la semana. La estructura es para registrar la temperatura diaria de una cabina de
// pago, estos oscilan entre los 7 y 38 grados. Deberá llenar la matriz de forma
// aleatoria para el mes de mayo donde el primer día inicia en lunes y el último (31) se
// ubica en el miércoles (la matriz puede ser inicializada con valores aleatorios desde el
// principio del programa, no es necesario pedir los valores al usuario para cada
// posición). Se nos pide hacer lo siguiente:
// a.​ Obtener la temperatura más alta y baja de la semana y que día se produjo
// (lunes, martes, etc.)
// b.​ Promedio de temperatura de la semana.
// c.​ Temperatura más alta del mes y su día.

static void Ejercicio6MatrizMesMayo()
{
    int[,] temperaturaMayo = new int[5, 7];
    int dias = 0;
    int diaMayor = 0;
    int temperaturaMaxima = 0;
    string[] diasSemana = new string[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
    Random random = new Random();
    Console.WriteLine("Temperaturas mes de mayo:");
    Console.WriteLine("L  M  M  J  V  S  D");
    for (int i = 0; i < temperaturaMayo.GetLength(0); i++)
    {
        List<int> semana = new List<int>();
        for (int j = 0; j < temperaturaMayo.GetLength(1); j++)
        {
            temperaturaMayo[i, j] = random.Next(7, 38);
            semana.Add(temperaturaMayo[i, j]);
            dias++;
            if (dias > 31) temperaturaMayo[i, j] = 0;

            if (temperaturaMayo[i, j] > temperaturaMaxima)
            {
                temperaturaMaxima = temperaturaMayo[i, j];
                diaMayor = j;
            }

            Console.Write($"{temperaturaMayo[i, j]:D2} ");
        }
        Console.Write($" Temperatura mas alta de la semana {i + 1}: {semana.Max():D2}");
        Console.Write($", mas baja: {semana.Min():D2}");
        Console.Write($", promedio semanal: {semana.Average().ToString("F2")}");
        Console.WriteLine();

    }
    Console.WriteLine($"La temperatura mas alta del mes es: {temperaturaMaxima}, registrada el dia {diasSemana[diaMayor]}");
}

// 7.​ Almacenar en una matriz las tablas del 1 al 9, teniendo en cuenta que en la primera
// fila y la primera columna se debe guardar los números (de 0 a 9), estando el cero en
// la primera posición (fila 0, columna 0). El resto de los lugares debe ser calculado
// usando los números que se dispone, por ejemplo, en la fila 1, calcular 1*1, 1*2, 1*3,
// etc. usando las posiciones del array o arreglo. Al finalizar el cálculo, mostrar la matriz
// por pantalla

static void Ejercicio7MatrizTablaDelNueve()
{
    Console.WriteLine("Tabla del Nueve:");
    int[,] tablaDelNueve = new int[10, 10];
    for (int i = 0; i < tablaDelNueve.GetLength(0); i++)
    {
        for (int j = 0; j < tablaDelNueve.GetLength(1); j++)
        {
            if (i == 0) tablaDelNueve[i, j] = j;
            else if (j == 0) tablaDelNueve[i, j] = i;
            else tablaDelNueve[i, j] = tablaDelNueve[0, j] * tablaDelNueve[i, 0];
            Console.Write($"{tablaDelNueve[i, j]:D2} ");

        }
        Console.WriteLine();
    }
}

// 8.​ Crear una matriz de 10 x 10, y “esconder” varias ‘X’ en lugares aleatorios (la
// cantidad que el programador decida, pero no más de la mitad de los lugares
// disponibles en la matriz). El usuario deberá ingresar el lugar donde cree que hay una
// X, ingresando la fila y la columna por separado. Informar si acertó o no por cada
// ingreso. Se debe pedir al usuario ingresar valores por tantas X que se haya
// guardado. El usuario tiene 3 intentos para fallar. Al finalizar (Ya sea porque se
// terminaron los 3 intentos, o el jugador acertó todas las X) imprimir por pantalla la
// matriz con sus correspondientes X, mostrando un * donde no haya nada.

static void Ejercicio8EquisEscondidas()
{
    Console.WriteLine("Adivina donde estan las X");
    string[,] matrizEquis = new string[10, 10];

    Random random = new Random();
    int valor = 0;
    int numeroDeEquis = 0;
    int maximoDeEquis = matrizEquis.GetLength(0) * matrizEquis.GetLength(1) / 2;
    for (int i = 0; i < matrizEquis.GetLength(0); i++)
    {
        for (int j = 0; j < matrizEquis.GetLength(1); j++)
        {
            if (numeroDeEquis < maximoDeEquis)
            {

                valor = random.Next(0, 100);
                if (valor < 50)
                {
                    matrizEquis[i, j] = "X";
                    numeroDeEquis++;
                }
                else matrizEquis[i, j] = "*";
            }
            else
            {
                matrizEquis[i, j] = "*";
            }
        }
    }

    void imprimirMatriz()
    {
        for (int i = 0; i < matrizEquis.GetLength(0); i++)
        {
            for (int j = 0; j < matrizEquis.GetLength(1); j++)
            {
                Console.Write(matrizEquis[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    int aciertos = 0, errores = 0;
    int fila = 0, columna = 0;
    void verificarAcierto()
    {
        if (matrizEquis[fila - 1, columna - 1] == "X")
        {
            aciertos++;
            Console.WriteLine("Exito: Acertó!");

        }
        else
        {
            Console.WriteLine("Error: No acertó!");
            errores++;
        }
    }
    do
    {
        if (errores < 3)
        {

            Console.WriteLine("Ingresar fila: ");
            string? filaStr = Console.ReadLine();
            if (!int.TryParse(filaStr, out fila))
            {
                Console.WriteLine("Ingrese un numero valido entre 0 y 10");
                continue;
            }
            Console.WriteLine("Ingresar columna: ");
            string? columnaStr = Console.ReadLine();
            if (!int.TryParse(columnaStr, out columna))
            {
                Console.WriteLine("Ingrese un numero valido entre 0 y 10");
                continue;
            }
            verificarAcierto();
        }
        else
        {
            imprimirMatriz();
            break;
        }
        numeroDeEquis--;
    } while (numeroDeEquis > 0);
}

// 9.​ Diccionario de calificaciones: Crear un diccionario donde la clave sea el nombre del
// alumno y el valor sea su nota. El programa debe permitir:
// a.​ Agregar alumnos y sus notas.
// b.​ Mostrar el promedio general del curso.
// c.​ Indicar el alumno con mejor nota y el de peor nota.
// d.​ Hint: usar Dictionary<string, double> y recorrer con foreach

static void Ejercicio9DiccionarioCalificaciones()
{
    var calificaciones = new Dictionary<string, double>();

    void agregarAlumnos()
    {
        Console.WriteLine("Ingrese nombre del alumno: ");
        string? nombre = Console.ReadLine();

        Console.WriteLine("Ingrese nota del alumno: ");
        string? notaStr = Console.ReadLine();
        if (double.TryParse(notaStr, out double nota) && !String.IsNullOrEmpty(nombre))
        {
            calificaciones.Add(nombre, nota);

        }
        else
        {
            Console.WriteLine("Ingrese valores validos.");
        }

    }
    void mostrarPromedioGeneral()
    {
        if (calificaciones.Count > 0)
        {
            double promedio = calificaciones.Values.Average();
            Console.WriteLine($"Promedio: {promedio:F2}");
        }
        else
        {
            Console.WriteLine("No hay calificaciones para promediar.");
        }
    }
    void mostrarMejorPeorNota()
    {
        if (calificaciones.Count > 0)
        {
            var mejorAlumno = calificaciones.OrderByDescending(item => item.Value).First();
            var peorAlumno = calificaciones.OrderBy(item => item.Value).First();
            Console.WriteLine($"Mejor alumno: {mejorAlumno.Key} -> {mejorAlumno.Value:F2}");
            Console.WriteLine($"Peor alumno: {peorAlumno.Key} -> {peorAlumno.Value:F2}");
        }
        else
        {
            Console.WriteLine("No hay calificaciones para promediar.");
        }
    }
    do
    {
        Console.WriteLine("Diccionario de Calificaciones. Menu:");
        Console.WriteLine("1. Agregar alumnos y sus notas");
        Console.WriteLine("2. Mostrar promedio general del curso");
        Console.WriteLine("3. Mostrar alumno con mejor y peor nota");
        Console.WriteLine("4. Salir");
        string? opcion = Console.ReadLine();
        if (opcion == "4")
        {
            break;
        }

        if (int.TryParse(opcion, out int numeroOpcion))
        {
            switch (numeroOpcion)
            {
                case 1:
                    agregarAlumnos();
                    break;
                case 2:
                    mostrarPromedioGeneral();
                    break;
                case 3:
                    mostrarMejorPeorNota();
                    break;

            }
        }
        else
        {
            Console.WriteLine("Opcion invalida");
        }

    } while (true);
}

// 10.​Simulador de atención en ventanilla: Usar una cola (Queue) para simular la atención
// de clientes en una ventanilla bancaria.
// a.​ Encolar nombres de clientes.
// b.​ Atender (desencolar) uno por uno hasta que no queden.
// c.​ Mostrar en pantalla quién está siendo atendido y cuántos quedan en la fila.
// d.​ Hint: usar Enqueue(), Dequeue() y Count.

static void Ejercicio10AtencionVentanilla()
{
    Queue<string> clientes = new Queue<string>();
    do
    {

        Console.WriteLine("Simulador de atención en ventanilla. Menu:");
        Console.WriteLine("1. Encolar clientes");
        Console.WriteLine("2. Atender clientes");
        Console.WriteLine("3. Salir");
        string? opcionStr = Console.ReadLine();
        if (opcionStr == "3")
        {
            break;
        }
        if (int.TryParse(opcionStr, out int opcion))
        {

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese nombre de cliente:");
                    string? cliente = Console.ReadLine();
                    if (string.IsNullOrEmpty(cliente))
                    {
                        Console.WriteLine("No puede ingresar campos vacios, ingrese un nombre");
                        continue;
                    }
                    clientes.Enqueue(cliente);
                    break;
                case 2:
                    if (clientes.Count == 0)
                    {
                        Console.WriteLine("No quedan mas clientes que atender. Agregue nuevos");
                        continue;
                    }
                    string clienteAtendido = clientes.Dequeue();
                    Console.WriteLine($"Atendiendo al cliente: {clienteAtendido}");
                    Console.WriteLine($"ahora quedan {clientes.Count} clientes en la fila");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Ingrese una opcion valida");
        }
    } while (true);

}

// Ejercicio 11 - Extra - Opcional:
// 11.​Inventario con múltiples colecciones: Diseñar un sistema de inventario básico
// usando distintas colecciones:
// a.​ Un List<string> con los productos disponibles.
// b.​ Un Dictionary<string, int> para registrar el stock de cada producto.
// c.​ Un Stack<string> para llevar el historial de acciones realizadas (agregar,
// quitar, vender).
// d.​ El programa debe permitir:
// i.​ Agregar un producto y su cantidad.
// ii.​ Vender un producto (restando stock).
// iii.​ Mostrar el inventario actual.
// iv.​ Mostrar las últimas 3 acciones registradas.
// e.​ Hint: combina listas, diccionarios y pilas para manipular distintos tipos de
// información.
static void Ejercicio11Inventario()
{
    List<string> productosDisponibles = new List<string>();
    var stock = new Dictionary<string, int>();
    Stack<string> accionesRealizadas = new Stack<string>();
    var acciones = (Agregar: "Agregar", Vender: "Vender");



    void agregarProductos()
    {
        Console.WriteLine("Ingrese nombre del producto: ");
        string? nombre = Console.ReadLine();

        Console.WriteLine("Ingrese cantidad del producto: ");
        string? cantidadStr = Console.ReadLine();
        if (int.TryParse(cantidadStr, out int cantidad) && !String.IsNullOrEmpty(nombre))
        {
            if (stock.ContainsKey(nombre.ToLower()))
            {
                stock[nombre] = stock[nombre] + cantidad;
            }
            stock.Add(nombre.ToLower(), cantidad);
            productosDisponibles.Add(nombre.ToLower());
            accionesRealizadas.Push(acciones.Agregar);
        }
        else
        {
            Console.WriteLine("Ingrese valores validos.");
        }
    }
    void venderProductos()
    {
        if (productosDisponibles.Count == 0)
        {
            Console.WriteLine("No hay productos disponibles, ingrese nuevos productos");
            return;
        }
        Console.WriteLine("Los productos disponibles son:");
        Console.WriteLine(string.Join(", ", productosDisponibles));

        Console.WriteLine("Ingrese el nombre del producto que desea comprar: ");
        string? productoElegido = Console.ReadLine();
        if (string.IsNullOrEmpty(productoElegido) || !productosDisponibles.Contains(productoElegido.ToLower()))
        {
            Console.WriteLine("Producto no encontrado, intente de nuevo.");
            return;
        }
        Console.WriteLine($"Producto: {productoElegido} , cantidad: {stock[productoElegido]}");
        Console.WriteLine("Ingrese la cantidad que desea comprar: ");
        string? cantidadComprarStr = Console.ReadLine();
        if (int.TryParse(cantidadComprarStr, out int cantidadComprar))
        {

            if (cantidadComprar == 0)
            {
                Console.WriteLine("La cantidad debe ser mayor a cero. Intente de nuevo");
                return;
            }
            stock[productoElegido] = stock[productoElegido] - cantidadComprar;
            accionesRealizadas.Push(acciones.Vender);
            Console.WriteLine($"Usted adquirio {productoElegido}. Compra confirmada.");
        }

    }
    void mostrarInventarioActual()
    {
        if (stock.Count == 0)
        {
            Console.WriteLine("El inventario esta vacio, ingrese nuevos productos");
            return;
        }
        Console.WriteLine("El inventario actual es:");
        foreach (var item in stock)
        {
            Console.WriteLine($"Producto: {item.Key} , cantidad: {item.Value}");
        }
    }
    void mostrarUltimasAcciones()
    {
        if (accionesRealizadas.Count == 0)
        {
            Console.WriteLine("El inventario esta vacio, no existen acciones realizadas.");
            return;
        }
        Console.WriteLine("Las ultimas 3 acciones realizadas fueron:");
        int count = 0;
        foreach (var accion in accionesRealizadas)
        {
            count++;
            if (count <= 3)
            {
                Console.WriteLine(accion);
            }
        }
    }

    do
    {
        Console.WriteLine("Simulador de Inventario. Menu:");
        Console.WriteLine("1. Agregar un producto y su cantidad");
        Console.WriteLine("2. Vender un producto (restando stock)");
        Console.WriteLine("3. Mostrar el inventario actual");
        Console.WriteLine("4. Mostrar las últimas 3 acciones registradas");
        Console.WriteLine("5. Salir");
        string? opcionStr = Console.ReadLine();

        if (opcionStr == "5")
        {
            break;
        }
        if (int.TryParse(opcionStr, out int opcion))
        {

            switch (opcion)
            {
                case 1:
                    agregarProductos();
                    break;
                case 2:
                    venderProductos();
                    break;
                case 3:
                    mostrarInventarioActual();
                    break;
                case 4:
                    mostrarUltimasAcciones();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Ingrese una opcion valida");
        }
    } while (true);

}