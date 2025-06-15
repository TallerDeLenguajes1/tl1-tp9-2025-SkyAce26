namespace EtiquetasMP3
{
    public class Id3v1Tag
    {
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
        public string Anio { get; set; }

        public Id3v1Tag(string titulo, string artista, string album, string anio)
        {
            Titulo = titulo;
            Artista = artista;
            Album = album;
            Anio = anio;
        }

        public void mostrar()
        {
            Console.WriteLine($"Titulo: {Titulo}");
            Console.WriteLine($"Artista: {Artista}");
            Console.WriteLine($"Album: {Album}");
            Console.WriteLine($"Año: {Anio}");
        }
    }

}