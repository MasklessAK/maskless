using System;
using System.IO;

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
    public int LIMIT;
    public int COOLDOWN;
    public int TIMESUSED;
    public int COOLCOUNT;
    public int ORIGINALVALUE;



    public Card(string id, string name, string description, int damage, string type, string gimmick, int eff1, int eff2, int limit, int cooldown)
    {

        ID = id;
        NAME = name;
        DESC = description;
        DMG = damage;
        TYPE = type;
        GIMMICK = gimmick;
        EFF1 = eff1;
        EFF2 = eff2;
        LIMIT = limit;
        COOLDOWN = cooldown;
        TIMESUSED = 0;
        COOLCOUNT = 0;
        ORIGINALVALUE = 0;

    }
  public Card(){
        ID = "";
        NAME = "";
        DESC = "";
        DMG = 0;
        TYPE = "";
        GIMMICK = "";
        EFF1 = 0;
        EFF2 = 0;
        LIMIT = 0;
        COOLDOWN = 0;
        TIMESUSED = 0;
        COOLCOUNT = 0;
        ORIGINALVALUE = 0;
  }



    public static string[,] AllCards()
    {
        string[,] fullcards = new string[75, 750];
        Card[] cards = new Card [75];
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
                    //Console.WriteLine(fullcards[i,k]);
                    if (k == 9)
                    {
                        k = 0;
                    }
                    else
                        k++;




                }
              
              //THIS RIGHT HERE
              cards[i] = new Card(fullcards[i, 0], fullcards[i, 1], fullcards[i, 2], Convert.ToInt32(fullcards[i, 3]), fullcards[i, 4], fullcards[i, 5], Convert.ToInt32(fullcards[i, 6]), Convert.ToInt32(fullcards[i, 7]), Convert.ToInt32(fullcards[i, 8]), Convert.ToInt32(fullcards[i, 9]));
              //Console.WriteLine(cards[i].NAME);
              /*
              cards[i].ID = fullcards[i, 0];
              cards[i].NAME = fullcards[i, 1];
              cards[i].DESC = fullcards[i, 2];
              cards[i].DMG = Convert.ToInt32(fullcards[i, 3]);
              cards[i].TYPE = fullcards[i, 4];
              cards[i].GIMMICK = fullcards[i, 5];
              cards[i].EFF1 = Convert.ToInt32(fullcards[i, 6]);
              cards[i].EFF2 = Convert.ToInt32(fullcards[i, 7]);
              cards[i].LIMIT = Convert.ToInt32(fullcards[i, 8]);
              cards[i].COOLDOWN = Convert.ToInt32(fullcards[i, 9]);
              Console.WriteLine(cards[i].NAME);
              i++;*/
              


            }
            //Console.WriteLine(fullcards[70,9]);
            return fullcards;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n");


        }
        return fullcards;
    }



   





}