// Clase Libro implementada según el diagrama
public class Libro
{
    private string titulo;
    private string autor;
    private int anyo;
    private bool disponible;

    public Libro(string titulo, string autor, int anyo, bool disponible)
    {
        this.titulo = titulo;
        this.autor = autor;
        this.anyo = anyo;
        this.disponible = disponible;
    }

    public string getTitulo() => titulo;
    public string getAutor() => autor;
    public int getAnyo() => anyo;
    public bool isDisponible() => disponible;

    public override string ToString() => $"{titulo} - {autor} ({anyo})";
}
