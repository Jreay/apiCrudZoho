using ApiPrueba.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System;

namespace ApiPrueba.DLAC
{
    public class contactoDLAC
    {
        public IEnumerable<Contacto> listado()
        {
            List<Contacto> seller = new List<Contacto>();
            var cn = new conexionDLAC();

            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("listar_Contactos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {
                    while (dr.Read())
                    {
                        seller.Add(new Contacto()
                        {
                            idContacto = Convert.ToInt32(dr["idContacto"]),
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

        public string insertar(Contacto reg)
        {
            string mensaje = "";
            var cn = new conexionDLAC();

            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("registrar_Contacto", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@idContacto", reg.idContacto));
                    cmd.Parameters.Add(new SqlParameter("@nombre", reg.nombre));
                    cmd.Parameters.Add(new SqlParameter("@apellido", reg.apellido));
                    cmd.Parameters.Add(new SqlParameter("@direccion", reg.direccion));
                    cmd.Parameters.Add(new SqlParameter("@telefono", reg.telefono));
                    cmd.Parameters.Add(new SqlParameter("@estado", reg.estado));
                    cmd.ExecuteNonQuery();
                    mensaje = "Contacto Registrado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { conexion.Close(); }
            }
            return mensaje;
        }
        public string actualizar(Contacto reg)
        {
            string mensaje = "";
            var cn = new conexionDLAC();

            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("actualizar_Contacto", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idContacto", reg.idContacto));
                    cmd.Parameters.Add(new SqlParameter("@nombre", reg.nombre));
                    cmd.Parameters.Add(new SqlParameter("@apellido", reg.apellido));
                    cmd.Parameters.Add(new SqlParameter("@direccion", reg.direccion));
                    cmd.Parameters.Add(new SqlParameter("@telefono", reg.telefono));
                    cmd.Parameters.Add(new SqlParameter("@estado", reg.estado));
                    cmd.ExecuteNonQuery();
                    mensaje = "Contacto Actualizado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { conexion.Close(); }
            }
            return mensaje;
        }

        public string eliminar(Contacto reg)
        {
            string mensaje = "";
            var cn = new conexionDLAC();

            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("eliminar_Contacto", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idContacto", reg.idContacto));
                    cmd.ExecuteNonQuery();
                    mensaje = "Contacto Eliminado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { conexion.Close(); }
            }
            return mensaje;
        }
    }
}
