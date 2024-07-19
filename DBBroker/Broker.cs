using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Domain;

namespace DBBroker
{
    public class Broker
    {
        private DbConnection connection;
        public Broker()
        {
            connection = new DbConnection();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }
        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }

        public Korisnik Login(Korisnik k)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Korisnik where KorisnickoIme='{k.KorisnickoIme}' and Sifra='{k.Sifra}'";
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    k.Ime = reader["Ime"].ToString();
                    k.Prezime = reader["Prezime"].ToString();
                    k.KorisnikId = (int)reader["KorisnikID"];
                    return k;
                }
            }catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            finally { reader.Close(); }
            return null;
        }
        public Bibliotekar LoginB(Bibliotekar b)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Bibliotekar where KorisnickoIme='{b.KorisnickoIme}' and Sifra='{b.Sifra}'";
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    b.Ime = reader["Ime"].ToString();
                    b.Prezime = reader["Prezime"].ToString();
                    b.BibliotekarId = (int)reader["BibliotekarID"];
                    return b;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally { reader.Close(); }
            return null;
        }
    }
}
