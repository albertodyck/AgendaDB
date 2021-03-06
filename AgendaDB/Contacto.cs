using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaDB
{
    public class Contacto
    {
        private string connectionString;
        public Contacto()
        {
            connectionString = "Server=localhost;Database=AgendaDB;Trusted_Connection=True;";
        }

        public bool ProbarConexion() 
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo establecer conexión {ex.Message}");
            }
            finally 
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public DataTable ObtenerContactos(bool activo = true)
        {
            try
            {
                string strQuery = "SELECT * FROM Contactos WHERE Activo = @Activo";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(strQuery, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Activo", activo);

                try
                {
                    sqlConnection.Open();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
                finally 
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerContactosPorNombre(string nombre) 
        {
            try
            {
                string strQuery = "SELECT * FROM Contactos WHERE Nombre like '%' + @Nombre + '%'";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(strQuery, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Nombre", nombre);

                try
                {
                    sqlConnection.Open();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarContacto(string nombre, DateTime fechaNacimiento, 
            string email, string telefonoParticular, string telefonoCelular) 
        {
            try
            {
                string strQuery = "INSERT INTO [Contactos] (" +
                    "[FechaCaptura],[Nombre],[FechaNacimiento],[Email],[TelefonoParticular],[TelefonoCelular],[Activo]) " +
                    "VALUES (" +
                    "GETDATE(),@Nombre,@FechaNacimiento,@Email,@TelefonoParticular,@TelefonoCelular, 1);";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(strQuery, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                sqlCommand.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@Email", email);
                sqlCommand.Parameters.AddWithValue("@TelefonoParticular", telefonoParticular);
                sqlCommand.Parameters.AddWithValue("@TelefonoCelular", telefonoCelular);

                try
                {
                    //Scalar -> 1 solo valor
                    //ExecuteNonQuery -> No regresa nada
                    //Reader -> 1 registro

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally 
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AgregarContactoSP(string nombre, DateTime fechaNacimiento,
           string email, string telefonoParticular, string telefonoCelular)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("spContactosInserta", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                sqlCommand.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@Email", email);
                sqlCommand.Parameters.AddWithValue("@TelefonoParticular", telefonoParticular);
                sqlCommand.Parameters.AddWithValue("@TelefonoCelular", telefonoCelular);

                try
                {
                    //Scalar -> 1 solo valor
                    //ExecuteNonQuery -> No regresa nada
                    //Reader -> 1 registro

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public SqlDataReader LeerRegistro(int contactoId)
        {
            try
            {
                string strQuery = "SELECT * FROM Contactos WHERE ContactoId = @ContactoId";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(strQuery, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@ContactoId", contactoId);

                sqlConnection.Open();
                    
                SqlDataReader registro = sqlCommand.ExecuteReader();

                //sqlConnection.Close();
                //sqlConnection.Dispose();

                return registro;
                
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarContacto(string nombre, DateTime fechaNacimiento,
           string email, string telefonoParticular, string telefonoCelular, int contactoId)
        {
            try
            {
                string strQuery = "UPDATE [Contactos] SET " +
                    "[FechaCaptura] = GETDATE()," +
                    "[Nombre] = @Nombre," +
                    "[FechaNacimiento] = @FechaNacimiento," +
                    "[Email] = @Email," +
                    "[TelefonoParticular] = @TelefonoParticular," +
                    "[TelefonoCelular] = @TelefonoCelular,[Activo]=1 " +
                    "WHERE [ContactoId] = @ContactoId";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(strQuery, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                sqlCommand.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@Email", email);
                sqlCommand.Parameters.AddWithValue("@TelefonoParticular", telefonoParticular);
                sqlCommand.Parameters.AddWithValue("@TelefonoCelular", telefonoCelular);
                sqlCommand.Parameters.AddWithValue("@ContactoId", contactoId);

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EliminarContacto(int contactoId)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Registro?", "Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                try
                {
                    string strQuery = "DELETE FROM Contactos WHERE ContactoId = @ContactoId";

                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    SqlCommand sqlCommand = new SqlCommand(strQuery, sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;

                    sqlCommand.Parameters.AddWithValue("@ContactoId", contactoId);

                    sqlConnection.Open();

                    sqlCommand.ExecuteReader();

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
