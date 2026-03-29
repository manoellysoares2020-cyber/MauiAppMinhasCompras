 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiAppMinhasCompras.Model;

namespace MauiAppMinhasCompras.Helpers // classe auxiliar, serve para controlar o banco de dados SQLite
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
           // conexão com o db
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        // inserir produtos
        public int Insert(Produto p)
        {
            return _conn.InsertAsync(p).Result;
        }

        // atualizar produtos
        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";
            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
                );
        }

        //deletar produtos
        public Task<int> Delete(int id)
        {
            
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        // listar tudo
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        // buscar produtos
        public Task<List<Produto>> Searnch(string q)
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE ? OR categoria LIKE ?";
            return _conn.QueryAsync<Produto>(sql, "%" + q + "%", "%" + q + "%");

        }

       
        }
    }

