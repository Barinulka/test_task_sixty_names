using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data;
using System.IO;
using System.Reflection.PortableExecutable;

namespace TestApp.Controllers
{
    internal class DefaultController
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["ConsoleAppDB"].ConnectionString;
        private static SqlConnection _connection = new SqlConnection(connectionString);


        public int GetSumContracts()
        {
            _connection.Open();
            int result = 0;

            string command = "SELECT SUM(Contract_sum) FROM dbo.Contracts WHERE Status = 'Signed' AND DATEPART(year, Date) = DATEPART(year, GETDATE())";

            SqlCommand cmd = new SqlCommand(command, _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                result = reader.GetInt32(0);
            }

            _connection.Close();

            if (reader != null) { reader.Close(); }

            return result;
        }

        public int GetLegalSumContractsFromRus()
        {
            _connection.Open();
            int result = 0;

            string command = "SELECT SUM(c.Contract_sum) FROM dbo.Contracts as c " +
                "INNER JOIN dbo.LegalPersons as l ON l.Id = c.LegalPersonId " +
                "WHERE c.Status = 'Signed' AND c.NaturalPersonId = 0 AND l.Country = 'Россия'";

            SqlCommand cmd = new SqlCommand(command, _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result = reader.GetInt32(0);
            }

            _connection.Close();

            if (reader != null) { reader.Close(); }

            return result;
        }

        public List<string> GetLegalEmailsList()
        {
            _connection.Open();
            List<string> result = new List<string>();

            string command = "SELECT n.Email FROM dbo.NaturalPersons as n " +
                "INNER JOIN dbo.Contracts as c ON n.Id = c.NaturalPersonId " +
                "WHERE c.Status = 'Signed' AND c.LegalPersonId = 0 AND c.Contract_sum > 40000 AND c.Date BETWEEN DATEADD(mm,-1,GETDATE()) AND DATEADD(mm,0,c.Date)";

            SqlCommand cmd = new SqlCommand(command, _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Add(reader.GetString(0));
            }

            _connection.Close();

            if (reader != null) { reader.Close(); }

            return result;
        }

        public int ChanheContractStatus()
        {
            _connection.Open();

            int result = 0;
           
            string command = "UPDATE c " +
                "SET c.Status = 'Terminated' " +
                "FROM dbo.Contracts as c " +
                "INNER JOIN dbo.NaturalPersons as n ON n.Id = c.NaturalPersonId " +
                "WHERE n.Age > 60 AND c.Status != 'Terminated'";

            SqlCommand cmd = new SqlCommand(command, _connection);
           
            result = cmd.ExecuteNonQuery();

            _connection.Close();    

            return result;
        }

        public string UploadData()
        {
            string result = string.Empty;

            try
            {
                _connection.Open();

                string command = "SELECT n.FirstName, n.LastName, n.Patronymic, n.Email, n.Phone, n.Age, n.City FROM dbo.NaturalPersons as n " +
                    "INNER JOIN dbo.Contracts as c ON n.Id = c.NaturalPersonId " +
                    "WHERE c.Status = 'Signed' AND n.City = 'Москва'";

                SqlCommand cmd = new SqlCommand(command, _connection);

                SqlDataReader reader = cmd.ExecuteReader();


                using (StreamWriter csvSW = new StreamWriter(
                    $"{AppDomain.CurrentDomain.BaseDirectory}/upload_{DateTime.Now.ToString().Replace(':', '_').Replace(' ', '_')}.csv",
                    true, Encoding.UTF8)
                )
                {
                    csvSW.WriteLine("Имя; Фамилия; Отчество; Email; Телефон; Возраст; Город");
                    while (reader.Read())
                    {
                        csvSW.WriteLine($"{reader["FirstName"]};{reader["LastName"]};{reader["Patronymic"]};{reader["Email"]};{reader["Phone"]};{reader["Age"]};{reader["City"]};");
                        result += $"{reader["FirstName"]};{reader["LastName"]};{reader["Patronymic"]};{reader["Email"]};{reader["Phone"]};{reader["Age"]};{reader["City"]};\n";
                    }
                }


                _connection.Close();

                if (reader != null) { reader.Close(); }

            } catch (Exception ex) { 
                result = $"Ошибка: {ex.Message}";
                _connection.Close();
            }

            return result;
        }

    }
}
