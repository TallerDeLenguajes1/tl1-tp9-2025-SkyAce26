using EtiquetasMP3;

string ruta = "";
bool valido = true;
while (valido)
{
    Console.WriteLine("Ingrese la ruta del archivo MP3:");
    ruta = Console.ReadLine();

    if (!File.Exists(ruta))
    {
        Console.WriteLine("Error, el archivo no existe");
    }
    else
    {
        valido = false;
    }
}

FileStream MiStream = new FileStream(ruta, FileMode.Open, FileAccess.Read);

if (MiStream.Length < 128)
{
    Console.WriteLine("El archivo es demasiado pequeño para contener una etiqueta Id3v1.");
    return;
}

MiStream.Seek(-128, SeekOrigin.End);
byte[] tag = new byte[128];
MiStream.Read(tag, 0, 128);

string cabecera = System.Text.Encoding.ASCII.GetString(tag, 0, 3);
if (cabecera != "TAG")
{
    Console.WriteLine("El archivo no contiene un tag Id3v1.");
    return;
}

string titulo = System.Text.Encoding.ASCII.GetString(tag, 3, 30).TrimEnd('\0');
string artista = System.Text.Encoding.ASCII.GetString(tag, 33, 30).TrimEnd('\0');
string album = System.Text.Encoding.ASCII.GetString(tag, 63, 30).TrimEnd('\0');
string anio = System.Text.Encoding.ASCII.GetString(tag, 93, 4).TrimEnd('\0');

Id3v1Tag informacion = new Id3v1Tag(titulo, artista, album, anio);

Console.WriteLine("Información del archivo MP3:");

informacion.mostrar();

MiStream.Close();