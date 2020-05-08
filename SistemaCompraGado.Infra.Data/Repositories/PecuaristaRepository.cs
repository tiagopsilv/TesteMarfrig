using SistemaCompraGado.Domain.Entities;
using SistemaCompraGado.Domain.Interfaces.Repository;
using SistemaCompraGado.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SistemaCompraGado.Infra.Data.Repositories
{
    public class PecuaristaRepository : IRepositoryBase<Pecuarista>, IPecuaristaRepository
    {
        private readonly ISistemaCompraGadoDGContexto Db;

        public PecuaristaRepository(ISistemaCompraGadoDGContexto SistemaCompraGadoDGContexto)
        {
            Db = SistemaCompraGadoDGContexto;
        }

        public void Add(Pecuarista obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Insert into Pecuarista (Nome) Values(@Nome)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", obj.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Dispose()
        {
        }

        public List<Pecuarista> GetAll()
        {
            List<Pecuarista> lstPecuarista = new List<Pecuarista>();
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Nome From Pecuarista", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Pecuarista _Pecuarista = new Pecuarista();
                    _Pecuarista.ID = Convert.ToInt32(rdr["ID"]);
                    _Pecuarista.Nome = rdr["Nome"].ToString();
                    lstPecuarista.Add(_Pecuarista);
                }
                con.Close();
            }
            return lstPecuarista;
        }

        public Pecuarista GetById(long ID)
        {
            Pecuarista _Pecuarista = new Pecuarista();
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Nome From Pecuarista Where ID = @PecuaristaId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PecuaristaId", ID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    _Pecuarista.ID = Convert.ToInt32(rdr["ID"]);
                    _Pecuarista.Nome = rdr["Nome"].ToString();
                }
                con.Close();
            }
            return _Pecuarista;
        }

        public void Remove(Pecuarista obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Delete from Pecuarista From Pecuarista where ID = @PecuaristaId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PecuaristaId", obj.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(Pecuarista obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Update Pecuarista set Nome = @Nome where ID = @PecuaristaId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PecuaristaId", obj.ID);
                cmd.Parameters.AddWithValue("@Nome", obj.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
