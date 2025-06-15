using Archivos;

string ruta = "";
bool valido = true;

while (valido)
{
    Console.WriteLine("Ingrese la dirección del directorio que quiere analizar:");
    ruta = Console.ReadLine();

    if (Directory.Exists(ruta))
    {
        Console.WriteLine("El directorio existe");
        valido = false;
    }
    else
    {
        Console.WriteLine("Error, el directorio no existe.");
    }
}

string[] subCarpetas = Directory.GetDirectories(ruta);
Console.WriteLine("\nSubcarpetas encontradas:");
foreach (string carpeta in subCarpetas)
{
    Console.WriteLine(Path.GetFileName(carpeta));
}

string[] archivos = Directory.GetFiles(ruta);

List<string> lista = [];
lista.Add("Nombre del Archivo  ||  Tamaño (KB)  ||  Fecha de Última Modificación");

Console.WriteLine("\nArchivos encontrados:");
foreach (string archi in archivos)
{

    FileInfo archivo = new FileInfo(archi);
    double tamanioKB = Math.Round(archivo.Length / 1024.0, 2);
    DateTime fechaModificacion = archivo.CreationTime;

    Console.WriteLine($"Nombre: {archivo.Name}       Tamaño: {tamanioKB} KB");

    lista.Add($"{archivo.Name}  ||  {tamanioKB}  ||  {fechaModificacion}");

}

string nombreArchivo = "reporte_archivos.csv";
string nuevaRuta = Path.Combine(ruta, nombreArchivo);

File.WriteAllLines(nuevaRuta, lista);

string[] lineas = File.ReadAllLines(nuevaRuta);

Console.WriteLine("\nContenido del archivo CSV generado:");
foreach (string linea in lineas)
{
    Console.WriteLine(linea);
}