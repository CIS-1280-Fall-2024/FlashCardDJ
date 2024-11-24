using FlashCard.FlashCard;
using System.ComponentModel;

namespace FlashCard
{
    public interface IDBManager
    {
        string ConnectionString { get; set; }

        void AddCard(Card card);
        bool Equals(object obj);
        void GetCards(BindingList<Card> cards);
        void RemoveCard(Card card);
        void UpdateCard(Card card);
    }
}