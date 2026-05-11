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

    public string getTitulo()
    {
        return titulo;
    }

    public string getAutor()
    {
        return autor;
    }

    public int getAnyo()
    {
        return anyo;
    }

    public bool isDisponible()
    {
        return disponible;
    }

    public override string ToString()
    {
        return $"{titulo} - {autor} ({anyo})";
    }
}
