using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System;
using FlashCard.FlashCard;

public partial class Form1 : Form
{
    private List<Card> cards;
    private Card currentCard;
    private DBManager dbManager;

    public Form1()
    {
        InitializeComponent();
        this.Text = "Your Name - Flash Card Application";
        dbManager = new DBManager();
        cards = new List<Card>();
        GetCards();
        DisplayCardQuestion();
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    private void GetCards() => dbManager.GetCards(new BindingList<Card>(cards));

    private void GetRandomCard()
    {
        Random rand = new Random();
        currentCard = cards[rand.Next(cards.Count)];
    }

    private void DisplayCardQuestion()
    {
        GetRandomCard();
        // Display card details on the form
        // Example: lblQuestion.Text = currentCard.Question;
    }

    private void btnShowAnswer_Click(object sender, EventArgs e)
    {
        // Show the answer and enable right/wrong buttons
    }

    private void btnRight_Click(object sender, EventArgs e)
    {
        currentCard.NumRight++;
        dbManager.Update(currentCard);
        DisplayCardQuestion();
    }

    private void btnWrong_Click(object sender, EventArgs e)
    {
        currentCard.NumWrong++;
        dbManager.Update(currentCard);
        DisplayCardQuestion();
    }

    // Add methods for managing cards (Add, Update, Remove)
}