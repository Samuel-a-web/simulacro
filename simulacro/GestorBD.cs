using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class GestorBD
{
    private readonly MySqlConnection conexion;

    public GestorBD()
    {
        var csb = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            UserID = "root",
            Password = "",
            Database = "bibliotech"
        };

        conexion = new MySqlConnection(csb.ConnectionString);
    }

    public void Insertar(Libro l)
    {
        conexion.Open();
        try
        {
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = "INSERT INTO libros (titulo, autor, anyo, disponible) VALUES (@titulo, @autor, @anyo, @disponible);";
            cmd.Parameters.AddWithValue("@titulo", l.getTitulo());
            cmd.Parameters.AddWithValue("@autor", l.getAutor());
            cmd.Parameters.AddWithValue("@anyo", l.getAnyo());
            cmd.Parameters.AddWithValue("@disponible", l.isDisponible());
            cmd.ExecuteNonQuery();
        }
        finally
        {
            conexion.Close();
        }
    }

    public List<Libro> ObtenerTodos()
    {
        var lista = new List<Libro>();
        conexion.Open();
        try
        {
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = "SELECT titulo, autor, anyo, disponible FROM libros;";
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var titulo = dr["titulo"] as string ?? string.Empty;
                var autor = dr["autor"] as string ?? string.Empty;
                var anyo = Convert.ToInt32(dr["anyo"]);
                var disponible = Convert.ToBoolean(dr["disponible"]);

                lista.Add(new Libro(titulo, autor, anyo, disponible));
            }
            dr.Close();
        }
        finally
        {
            conexion.Close();
        }

        return lista;
    }
}
