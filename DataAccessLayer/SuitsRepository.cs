using Shared;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class SuitsRepository : ISuitsRepository
    {
        public List<Suit> GetAllSuits()
        {
            List<Suit> suits = new List<Suit>();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM SUITS";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Suit suit = new Suit
                    {
                        Id = sqlDataReader.GetInt32(0),
                        OrderId = sqlDataReader.GetString(1),
                        Size = sqlDataReader.GetInt32(2),
                        PrimaryMaterial = sqlDataReader.GetString(3),
                        SecondaryMaterial = sqlDataReader.GetString(4),
                        TertiaryMaterial = sqlDataReader.GetString(5),
                        PrimaryColor = sqlDataReader.GetString(6),
                        SecondaryColor = sqlDataReader.GetString(7),
                        TertiaryColor = sqlDataReader.GetString(8),
                        Vest = sqlDataReader.GetBoolean(9),
                        Cut = sqlDataReader.GetString(10),
                        Buttons = sqlDataReader.GetInt32(11),
                        Lapel = sqlDataReader.GetString(12),
                        Price = sqlDataReader.GetInt32(13)
                    };
                    suits.Add(suit);
                }
                return suits;
            }
        }
        public int DeleteSuit(int Id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "DELETE FROM SUITS WHERE Id = @Id";
                    sqlCommand.Parameters.AddWithValue("Id", Id);

                    return sqlCommand.ExecuteNonQuery();
                }

            }
        }
        public int InsertSuit(Suit suit)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "INSERT INTO SUITS VALUES (@Id, @OrderId, @Size, @PrimaryMaterial, @SecondaryMaterial, @TertiaryMaterial, @PrimaryColor, @SecondaryColor, @TertiaryColor, @Vest, @Cut, @Buttons, @Lapel, @Price)";
                    sqlCommand.Parameters.AddWithValue("@Id", suit.Id);
                    sqlCommand.Parameters.AddWithValue("@OrderId", suit.OrderId);
                    sqlCommand.Parameters.AddWithValue("@PrimaryMaterial", suit.PrimaryMaterial);
                    sqlCommand.Parameters.AddWithValue("@SecondaryMaterial", suit.SecondaryMaterial);
                    sqlCommand.Parameters.AddWithValue("@TertiaryMaterial", suit.TertiaryMaterial);
                    sqlCommand.Parameters.AddWithValue("@PrimaryColor", suit.PrimaryColor);
                    sqlCommand.Parameters.AddWithValue("@SecondaryColor", suit.SecondaryColor);
                    sqlCommand.Parameters.AddWithValue("@TertiaryColor", suit.TertiaryColor);
                    sqlCommand.Parameters.AddWithValue("@Vest", suit.Vest);
                    sqlCommand.Parameters.AddWithValue("@Cut", suit.Cut);
                    sqlCommand.Parameters.AddWithValue("@Buttons", suit.Buttons);
                    sqlCommand.Parameters.AddWithValue("@Lapel", suit.Lapel);
                    sqlCommand.Parameters.AddWithValue("@Price", suit.Price);

                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public int UpdateSuit(Suit suit)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                string command = "UPDATE SUITS SET Id=@Id, OrderId = @OrderId , " +
                    "PrimaryMaterial = @PrimaryMaterial, SecondaryMaterial=@SecondaryMaterial, TertiaryMaterial = @TertiaryMaterial, PrimaryColor=@PrimaryColor, SecondaryColor = @SecondaryColor, " +
                    "TertiaryColor = @TertiaryColor, Vest = @Vest,Cut=@Cut,Buttons=@Buttons" +
                    ",Lapel=@Lapel, Price=@Price  WHERE Id=@Id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", suit.Id);
                sqlCommand.Parameters.AddWithValue("@OrderId", suit.OrderId);
                sqlCommand.Parameters.AddWithValue("@PrimaryMaterial", suit.PrimaryMaterial);
                sqlCommand.Parameters.AddWithValue("@SecondaryMaterial", suit.SecondaryMaterial);
                sqlCommand.Parameters.AddWithValue("@TertiaryMaterial", suit.TertiaryMaterial);
                sqlCommand.Parameters.AddWithValue("@PrimaryColor", suit.PrimaryColor);
                sqlCommand.Parameters.AddWithValue("@SecondaryColor", suit.SecondaryColor);
                sqlCommand.Parameters.AddWithValue("@TertiaryColor", suit.TertiaryColor);
                sqlCommand.Parameters.AddWithValue("@Vest", suit.Vest);
                sqlCommand.Parameters.AddWithValue("@Cut", suit.Cut);
                sqlCommand.Parameters.AddWithValue("@Buttons", suit.Buttons);
                sqlCommand.Parameters.AddWithValue("@Lapel", suit.Lapel);
                sqlCommand.Parameters.AddWithValue("@Price", suit.Price);

                return sqlCommand.ExecuteNonQuery();

            }
        }
    }
}
