using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



class Card
{


    public string ID;
    public string NAME;
    public string DESC;
    public int DMG;
    public string TYPE;
    public string GIMMICK;
    public int EFF1;
    public int EFF2;
    public string EFFDESCRIPTION;
    public int LIMIT;
    public int COOLDOWN;
    public string TYPE1;
    public string TYPE2;
    public int TURNSBUFFED;
    public int TIMESUSED;
    public int COOLCOUNT;
    public int ORIGINALVALUE;




    public Card(string id, string name, string description, int damage, string type, string gimmick, int eff1, int eff2, string effdesc, int limit, int cooldown, string type1, string type2, int turnsbuffed)
    {

        ID = id;
        NAME = name;
        DESC = description;
        DMG = damage;
        TYPE = type;
        GIMMICK = gimmick;
        EFF1 = eff1;
        EFF2 = eff2;
        EFFDESCRIPTION = effdesc;
        LIMIT = limit;
        COOLDOWN = cooldown;
        TYPE1 = type1;
        TYPE2 = type2;
        TURNSBUFFED = turnsbuffed;
        TIMESUSED = 0;
        COOLCOUNT = 0;
        ORIGINALVALUE = 0;


    }
    public Card()
    {
        ID = "";
        NAME = "";
        DESC = "";
        DMG = 0;
        TYPE = "";
        GIMMICK = "";
        EFF1 = 0;
        EFF2 = 0;
        EFFDESCRIPTION = "";
        LIMIT = 0;
        COOLDOWN = 0;
        TYPE1 = "";
        TYPE2 = "";
        TURNSBUFFED = 0;
        TIMESUSED = 0;
        COOLCOUNT = 0;
        ORIGINALVALUE = 0;
    }

    public static List<Card> Shuffle(List<Card> Deck)
    {
        int n = Deck.Count;
        Random rnd = new Random();
        while (n > 1)
        {
            int k = (rnd.Next(0, n) % n);
            n--;
            Card value = Deck[k];
            Deck[k] = Deck[n];
            Deck[n] = value;
        }

        return Deck;
    }


    public static List<Card> GetDeck(string deckname)
    {
        List<Card> Deck = new List<Card>();
        string[,] fullcards = new string[17, 1000];
        Card[] cards = new Card[17];


        //Left of, is the card... right of , the values in the cards.
        string path = deckname;
        int i = 0, k = 0;
        try
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                //Console.WriteLine(i + " _____________");

                string[] columns = line.Split(',');
                foreach (string column in columns)
                {
                    fullcards[i, k] = column;
                    //Console.WriteLine(column);
                    // Console.WriteLine(fullcards[i,k]);
                    if (k == 13)
                    {
                        k = 0;
                    }
                    else
                        k++;




                }

                //THIS RIGHT HERE
                cards[i] = new Card(fullcards[i, 0], fullcards[i, 1], fullcards[i, 2], Convert.ToInt32(fullcards[i, 3]), fullcards[i, 4], fullcards[i, 5], Convert.ToInt32(fullcards[i, 6]), Convert.ToInt32(fullcards[i, 7]), fullcards[i, 8], Convert.ToInt32(fullcards[i, 9]), Convert.ToInt32(fullcards[i, 10]), fullcards[i, 11], fullcards[i, 12], Convert.ToInt32(fullcards[i, 13]));

                Deck.Add(cards[i]);
                //Console.WriteLine(CardSet[i].ID);

                i++;



            }
            //CardSet = Shuffle(CardSet);
            //Console.WriteLine(Deck[8].ID + "_______");
            return Deck;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n");


        }
        return Deck;
    }

    public static List<Card> AllCards()
    {
        Random rng = new Random();
        string[,] fullcards = new string[95, 1000];
        Card[] cards = new Card[95];
        List<Card> CardSet = new List<Card>();
        //Left of, is the card... right of , the values in the cards.
        string path = "allcards.csv";
        int i = 0, k = 0;


        try
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                //Console.WriteLine(i + " _____________");

                string[] columns = line.Split(',');
                foreach (string column in columns)
                {
                    fullcards[i, k] = column;
                    //Console.WriteLine(column);
                    //Console.WriteLine(fullcards[i, k]);
                    if (k == 13)
                    {
                        k = 0;
                    }
                    else
                        k++;




                }

                //THIS RIGHT HERE
                cards[i] = new Card(fullcards[i, 0], fullcards[i, 1], fullcards[i, 2], Convert.ToInt32(fullcards[i, 3]), fullcards[i, 4], fullcards[i, 5], Convert.ToInt32(fullcards[i, 6]), Convert.ToInt32(fullcards[i, 7]), fullcards[i, 8], Convert.ToInt32(fullcards[i, 9]), Convert.ToInt32(fullcards[i, 10]), fullcards[i, 11], fullcards[i, 12], Convert.ToInt32(fullcards[i, 13]));

                CardSet.Add(cards[i]);
                //Console.WriteLine(CardSet[i].ID);

                i++;



            }
            //CardSet = Shuffle(CardSet);
            Console.WriteLine(CardSet[8].ID + "_______");
            return CardSet;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n");


        }
        return CardSet;
    }

}
