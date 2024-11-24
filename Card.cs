using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCard
{

    namespace FlashCard
    {
        public class Card
        {
            public int CardID { get; set; }
            public string Title { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }
            public int NumRight { get; set; }
            public int NumWrong { get; set; }

            public Card() { }

            public Card(int cardID, string title, string question, string answer, int numRight, int numWrong)
            {
                CardID = cardID;
                Title = title;
                Question = question;
                Answer = answer;
                NumRight = numRight;
                NumWrong = numWrong;
            }

            public override string ToString()
            {
                return $"{Title} (Right: {NumRight}, Wrong: {NumWrong})";
            }
        }
    }
}
