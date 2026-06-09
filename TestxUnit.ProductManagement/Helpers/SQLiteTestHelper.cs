using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestxUnit.ProductManagement.Helpers
{
   
        public class SqliteTestHelper
        {
            //Criação de uma base de dados limpa,
            //in-memory (não cria ficheiro)
            //com tabela já pronta a usar

            public static SqliteConnection CreateInMemoryDataBase()
            {
                var connection = new SqliteConnection("DataSource=:memory:");

                connection.Open();

                //criar a tabela
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"CREATE TABLE Produtos(Id INTEGER PRIMARY KEY AUTOINCREMENT, 
            Nome TEXT NOT NULL, Preco REAL NOT NULL);";

                cmd.ExecuteNonQuery();

                return connection;
                //este return vai devolver a ligação aberta e com a tabela criada.
            }
        }
    }

