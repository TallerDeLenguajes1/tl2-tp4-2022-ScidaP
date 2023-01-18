using System.Data.SQLite;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Tp4MvcNuevo.Models;

public interface IRepositorioUsuarios {
    public Usuario GetUsuario(int id);

    public bool DatosCorrectos(string? usuario, string? pass);
}

public class RepositorioUsuarios : IRepositorioUsuarios {
    public Usuario GetUsuario(int id) {
        Usuario usuario = new Usuario();
        using (var conexion = new SQLiteConnection("Data Source=DB/basededatos.db")) {
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = @"SELECT * FROM usuarios WHERE id = $id";
            command.Parameters.AddWithValue("$id", id);
            using (var reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    usuario = new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                }
            }
            conexion.Close();
        }
        return usuario;
    }

    public bool DatosCorrectos(string? usuario, string? pass) {
        bool res;
        if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(pass)) {
            return false;
        } else {
            using (var conexion = new SQLiteConnection("Data Source=DB/basededatos.db")) {
                conexion.Open();
                var command = conexion.CreateCommand();
                command.CommandText = @"SELECT * FROM usuarios WHERE usuario = $usuario AND pass = $pass";
                command.Parameters.AddWithValue("$usuario", usuario);
                command.Parameters.AddWithValue("$pass", pass);
                    using (var reader = command.ExecuteReader()) {
                        res = reader.HasRows;
                    }
                conexion.Close();
                return res;
            }
        }
    }
}