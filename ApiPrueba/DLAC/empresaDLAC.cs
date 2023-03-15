using ApiPrueba.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System;

namespace ApiPrueba.DLAC
{
    public class empresaDLAC
    {
        public IEnumerable<Empresa> listado()
        {
            List<Empresa> seller = new List<Empresa>();
            var cn = new conexionDLAC();

            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("listar_Empresa", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataReader dr = cmd.ExecuteReader();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        seller.Add(new Empresa()
                        {
                            idEmpresa = Convert.ToInt32(dr["idEmpresa"]),
                            nombre = dr["nombre"].ToString()
                        });
                    }
                }
                 
            }
            return seller;
        }

        public string insertar(Empresa reg)
        {
            string mensaje = "";
            var cn = new conexionDLAC();

            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("registrar_Empresa", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@idEmpresa", reg.idEmpresa));
                    cmd.Parameters.Add(new SqlParameter("@nombre", reg.nombre));
                    cmd.ExecuteNonQuery();
                    mensaje = "Empresa Registrado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { conexion.Close(); }
            }
            return mensaje;
        }
        public string actualizar(Empresa reg)
        {
            string mensaje = "";
            var cn = new conexionDLAC();

            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("actualizar_Empresa", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idEmpresa", reg.idEmpresa));
                    cmd.Parameters.Add(new SqlParameter("@nombre", reg.nombre));
                    cmd.ExecuteNonQuery();
                    mensaje = "Empresa Actualizado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { conexion.Close(); }
            }
            return mensaje;
        }

        public string eliminar(Empresa reg)
        {
            string mensaje = "";
            var cn = new conexionDLAC();

            using (var conexion = new SqlConnection(cn.obtenerSql()))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("eliminar_Empresa", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idEmpresa", reg.idEmpresa));
                    cmd.ExecuteNonQuery();
                    mensaje = "Empresa Eliminado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { conexion.Close(); }
            }
            return mensaje;
        }
    }
}
