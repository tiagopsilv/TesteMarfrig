using SistemaCompraGado.Domain.Entities;
using SistemaCompraGado.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SistemaCompraGado.Infra.Data.Repositories
{
    public class CompraGadoRepository : IRepositoryBase<CompraGado>, ICompraGadoRepository
    {

        private readonly ISistemaCompraGadoDGContexto Db;

        public CompraGadoRepository(ISistemaCompraGadoDGContexto SistemaCompraGadoDGContexto)
        {
            Db = SistemaCompraGadoDGContexto;
        }

        public void Add(CompraGado obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Insert into CompraGado (ID, DataEntrega, PecuaristaId) Values(@ID, @DataEntrega, @PecuaristaId)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@DataEntrega", obj.DataEntrega);
                cmd.Parameters.AddWithValue("@PecuaristaId", obj.PecuaristaID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Dispose()
        {
        }

        public List<CompraGado> GetAll()
        {
            List<CompraGado> lstCompraGado = new List<CompraGado>();
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, DataEntrega, PecuaristaId From CompraGado", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CompraGado _CompraGado = new CompraGado();
                    _CompraGado.ID = Convert.ToInt32(rdr["ID"]);
                    _CompraGado.DataEntrega = Convert.ToDateTime(rdr["DataEntrega"]);
                    _CompraGado.PecuaristaID = Convert.ToInt32(rdr["PecuaristaId"]);
                    lstCompraGado.Add(_CompraGado);
                }
                con.Close();
            }
            return lstCompraGado;
        }

        public CompraGado GetById(long ID)
        {
            CompraGado _CompraGado = new CompraGado();
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, DataEntrega, PecuaristaId From CompraGado Where ID = @CompraGadoId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CompraGadoId", ID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    _CompraGado.ID = Convert.ToInt32(rdr["ID"]);
                    _CompraGado.DataEntrega = Convert.ToDateTime(rdr["DataEntrega"]);
                    _CompraGado.PecuaristaID = Convert.ToInt32(rdr["PecuaristaId"]);
                }
                con.Close();
            }
            return _CompraGado;
        }

        public void Remove(CompraGado obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Delete from CompraGado where ID = @CompraGadoId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CompraGadoId", obj.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(CompraGado obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Update CompraGado set DataEntrega = @DataEntrega, PecuaristaId = @PecuaristaId where ID = @CompraGadoId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CompraGadoId", obj.ID);
                cmd.Parameters.AddWithValue("@DataEntrega", obj.DataEntrega);
                cmd.Parameters.AddWithValue("@PecuaristaId", obj.PecuaristaID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
