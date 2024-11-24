using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Configuration;
using FlashCard.FlashCard;

public class DBManager
{
    private string connectionString;

    public DBManager()
    {
        connectionString = ConfigurationManager.ConnectionStrings["CatalogDB"].ConnectionString;
    }

    public void GetCards(BindingList<Card> cards)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Card", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cards.Add(new Card(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetInt32(4),
                    reader.GetInt32(5)
                ));
            }
        }
    }

    public void AddCard(Card card)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Card (Title, Question, Answer, NumRight, NumWrong) VALUES (@Title, @Question, @Answer, @NumRight, @NumWrong)", conn);
            cmd.Parameters.AddWithValue("@Title", card.Title);
            cmd.Parameters.AddWithValue("@Question", card.Question);
            cmd.Parameters.AddWithValue("@Answer", card.Answer);
            cmd.Parameters.AddWithValue("@NumRight", card.NumRight);
            cmd.Parameters.AddWithValue("@NumWrong", card.NumWrong);
            cmd.ExecuteNonQuery();
        }
    }

    public void RemoveCard(Card card)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Card WHERE CardID=@CardID", conn);
            cmd.Parameters.AddWithValue("@CardID", card.CardID);
            cmd.ExecuteNonQuery();
        }
    }

    public void Update(Card card)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Card SET Title=@Title, Question=@Question, Answer=@Answer, NumRight=@NumRight, NumWrong=@NumWrong WHERE CardID=@CardID", conn);
            cmd.Parameters.AddWithValue("@Title", card.Title);
            cmd.Parameters.AddWithValue("@Question", card.Question);
            cmd.Parameters.AddWithValue("@Answer", card.Answer);
            cmd.Parameters.AddWithValue("@NumRight", card.NumRight);
            cmd.Parameters.AddWithValue("@NumWrong", card.NumWrong);
            cmd.Parameters.AddWithValue("@CardID", card.CardID);
            cmd.ExecuteNonQuery();
        }
    }
}