using ApiPrueba.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ApiPrueba.DLAC
{
    public class clienteDLAC
    {
        public IEnumerable<Cliente> listado()
        {
            List<Cliente> seller = new List<Cliente>();
            var cn = new conexionDLAC();

            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("listar_Clientes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataReader dr = cmd.ExecuteReader();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        seller.Add(new Cliente()
                        {
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            nombre = dr["nombre"].ToString(),
                            apellido = dr["apellido"].ToString(),
                            direccion = dr["direccion"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            estado = dr["estado"].ToString(),
                        });
                    }
                }
                
            }
            return seller;
        }

        

        public string insertar(Cliente reg)
        {
            string mensaje = "";
            var cn = new conexionDLAC();
            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("registrar_Cliente", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@idCliente", reg.idCliente));
                    cmd.Parameters.Add(new SqlParameter("@nombre", reg.nombre));
                    cmd.Parameters.Add(new SqlParameter("@apellido", reg.apellido));
                    cmd.Parameters.Add(new SqlParameter("@direccion", reg.direccion));
                    cmd.Parameters.Add(new SqlParameter("@telefono", reg.telefono));
                    cmd.Parameters.Add(new SqlParameter("@estado", reg.estado));
                    cmd.ExecuteNonQuery();
                    mensaje = "Cliente Registrado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { conexion.Close(); }
            }
            return mensaje;
        }
        public string actualizar(Cliente reg)
        {
            string mensaje = "";
            var cn = new conexionDLAC();

            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("actualizar_Cliente", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idCliente", reg.idCliente));
                    cmd.Parameters.Add(new SqlParameter("@nombre", reg.nombre));
                    cmd.Parameters.Add(new SqlParameter("@apellido", reg.apellido));
                    cmd.Parameters.Add(new SqlParameter("@direccion", reg.direccion));
                    cmd.Parameters.Add(new SqlParameter("@telefono", reg.telefono));
                    cmd.Parameters.Add(new SqlParameter("@estado", reg.estado));
                    cmd.ExecuteNonQuery();
                    mensaje = "Cliente Actualizado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { conexion.Close(); }
            }
            return mensaje;
        }

        public string eliminar(Cliente reg)
        {
            string mensaje = "";
            var cn = new conexionDLAC();

            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("eliminar_Cliente", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idCliente", reg.idCliente));
                    cmd.ExecuteNonQuery();
                    mensaje = "Cliente Eliminado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { conexion.Close(); }
            }
            return mensaje;
        }
    }
}

