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
    public class AnimalRepository : IRepositoryBase<Animal>, IAnimalRepository
    {

        private readonly ISistemaCompraGadoDGContexto Db;

        public AnimalRepository(ISistemaCompraGadoDGContexto SistemaCompraGadoDGContexto)
        {
            Db = SistemaCompraGadoDGContexto;
        }

        public void Add(Animal obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Insert into Animal (Descricao,Preco) Values(@Descricao, @Preco)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@Preco", obj.Preco);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Dispose()
        {
        }

        public List<Animal> GetAll()
        {
            List<Animal> lstAnimal = new List<Animal>();
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Descricao, Preco From Animal", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Animal _Animal = new Animal();
                    _Animal.ID = Convert.ToInt32(rdr["ID"]);
                    _Animal.Descricao = rdr["Descricao"].ToString();
                    _Animal.Preco = rdr["Preco"].ToString();
                    lstAnimal.Add(_Animal);
                }
                con.Close();
            }
            return lstAnimal;
        }

        public Animal GetById(long ID)
        {
            Animal _Animal = new Animal();
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, Descricao, Preco From Animal Where ID = @AnimalId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@AnimalId", ID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    _Animal.ID = Convert.ToInt32(rdr["ID"]);
                    _Animal.Descricao = rdr["Descricao"].ToString();
                    _Animal.Preco = rdr["Preco"].ToString();
                }
                con.Close();
            }
            return _Animal;
        }

        public void Remove(Animal obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Delete from Animal where ID = @AnimalId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@AnimalId", obj.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(Animal obj)
        {
            using (SqlConnection con = new SqlConnection(Db.getconnectionString()))
            {
                string comandoSQL = "Update Animal set Descricao = @Descricao, Preco = @Preco where ID = @AnimalId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@AnimalId", obj.ID);
                cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@Preco", obj.Preco);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
