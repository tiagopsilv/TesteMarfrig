using SistemaCompraGado.Domain.Entities;
using SistemaCompraGado.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SistemaCompraGado.Infra.Data.Repositories
{
    public class CompraGadoItemRepository : IRepositoryBase<CompraGadoItem>, ICompraGadoItemRepository
    {
        private readonly ISistemaCompraGadoDGContexto Db;

        public CompraGadoItemRepository(ISistemaCompraGadoDGContexto SistemaCompraGadoDGContexto)
        {
            Db = SistemaCompraGadoDGContexto;
        }

        public void Add(CompraGadoItem obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Insert into CompraGadoItem (Quantidade, CompraGadoId, AnimalId) Values(@Quantidade, @CompraGadoId, @AnimalId)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Quantidade", obj.Quantidade);
                cmd.Parameters.AddWithValue("@CompraGadoId", obj.CompraGadoID);
                cmd.Parameters.AddWithValue("@AnimalId", obj.AnimalID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<CompraGadoItem> GetAll()
        {
            List<CompraGadoItem> lstCompraGadoItem = new List<CompraGadoItem>();
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Quantidade, CompraGadoId, AnimalId From CompraGadoItem", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CompraGadoItem _CompraGadoItem = new CompraGadoItem();
                    _CompraGadoItem.ID = Convert.ToInt32(rdr["ID"]);
                    _CompraGadoItem.Quantidade = rdr["Quantidade"].ToString();
                    _CompraGadoItem.CompraGadoID = Convert.ToInt32(rdr["CompraGadoId"]);
                    _CompraGadoItem.AnimalID = Convert.ToInt32(rdr["AnimalId"]);
                    lstCompraGadoItem.Add(_CompraGadoItem);
                }
                con.Close();
            }
            return lstCompraGadoItem;
        }

        public CompraGadoItem GetById(long ID)
        {
            CompraGadoItem _CompraGadoItem = new CompraGadoItem();
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Quantidade, CompraGadoId, AnimalId From CompraGadoItem Where ID = @CompraGadoItemId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CompraGadoItemId", ID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    _CompraGadoItem.ID = Convert.ToInt32(rdr["ID"]);
                    _CompraGadoItem.Quantidade = rdr["Quantidade"].ToString();
                    _CompraGadoItem.CompraGadoID = Convert.ToInt32(rdr["CompraGadoId"]);
                    _CompraGadoItem.AnimalID = Convert.ToInt32(rdr["AnimalId"]);
                }
                con.Close();
            }
            return _CompraGadoItem;
        }


        public List<CompraGadoItem> GetByCompraGadoId(long ID)
        {
            List<CompraGadoItem> lstCompraGadoItem = new List<CompraGadoItem>();
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Quantidade, CompraGadoId, AnimalId From CompraGadoItem Where CompraGadoId = @CompraGadoId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CompraGadoId", ID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CompraGadoItem _CompraGadoItem = new CompraGadoItem();
                    _CompraGadoItem.ID = Convert.ToInt32(rdr["ID"]);
                    _CompraGadoItem.Quantidade = rdr["Quantidade"].ToString();
                    _CompraGadoItem.CompraGadoID = Convert.ToInt32(rdr["CompraGadoId"]);
                    _CompraGadoItem.AnimalID = Convert.ToInt32(rdr["AnimalId"]);
                    lstCompraGadoItem.Add(_CompraGadoItem);
                }
                con.Close();
            }
            return lstCompraGadoItem;
        }

        public void RemoveCompraGadoId(long ID)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Delete from CompraGadoItem where CompraGadoId = @CompraGadoId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CompraGadoId", ID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Remove(CompraGadoItem obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Delete from CompraGadoItem where ID = @CompraGadoItemId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CompraGadoItemId", obj.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(CompraGadoItem obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Update CompraGadoItem set Quantidade = @Quantidade, CompraGadoId = @CompraGadoId, AnimalId = @AnimalId  where ID = @CompraGadoItemId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CompraGadoItemId", obj.ID);
                cmd.Parameters.AddWithValue("@Quantidade", obj.Quantidade);
                cmd.Parameters.AddWithValue("@CompraGadoId", obj.CompraGadoID);
                cmd.Parameters.AddWithValue("@AnimalId", obj.AnimalID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
