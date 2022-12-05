using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



class Luchador
{
    public string ID;
    public string NAME;
    public int HP;
    public int PWR;
    public int SPD;
    public int RESLNCY;
    public int TCHNQ;
    public string GMMCK;
    public string ABLT;
    public int LVL;
    public int EXP;
    public int BOOST;




    public Luchador()
    {
        ID = "";
        NAME = "";
        HP = 100;
        PWR = 0;
        SPD = 0;
        RESLNCY = 0;
        TCHNQ = 0;
        GMMCK = "HEEL";
        ABLT = "UNDERDOG";
        LVL = 1;
        EXP = 0;
        BOOST = 0;
    }
    public Luchador(string id, string name, int hp, int power, int speed, int resiliency, int technique, string gimmick, string ability)
    {
        ID = id;
        NAME = name;
        HP = hp;
        PWR = power;
        SPD = speed;
        RESLNCY = resiliency;
        TCHNQ = technique;
        GMMCK = gimmick;
        ABLT = ability;
        LVL = 1;
        EXP = 0;
        BOOST = 0;
    }

    public static Luchador CreateALuchador(string filename)
    {
        // path to the csv file
        string[] luchadorfile = new string[12];
        string path = filename;
        int i = 0;
        Guid guid = Guid.NewGuid();
        string rid = Convert.ToBase64String(guid.ToByteArray());
        rid = rid.Substring(0, rid.Length - 2);
        Luchador player1;


        int MAX = 20;
        int power = 0, speed = 0, resiliency = 0, technique = 0;
        int hp = 100;
        int AA = 0;
        int pointsleft = 20;
        string name;
        string gimmick = "HEEL";
        string ability = "UNDERDOG";

        try
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                foreach (string column in columns)
                {
                    luchadorfile[i] = column;
                    //Console.WriteLine(column);
                    i++;


                }
                player1 = new Luchador(luchadorfile[0], luchadorfile[1], Convert.ToInt32(luchadorfile[2]), Convert.ToInt32(luchadorfile[3]), Convert.ToInt32(luchadorfile[4]), Convert.ToInt32(luchadorfile[5]), Convert.ToInt32(luchadorfile[6]), luchadorfile[7], luchadorfile[8]);

                return player1;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n");


        }



        Console.WriteLine("");
        Console.WriteLine("Lets create your Luchador\n");
        Console.WriteLine("Enter your Luchadors's name: ");
        name = Console.ReadLine();

        while (AA != MAX)
        {
            Console.WriteLine("You have 20 points to use in:\n");
            Console.WriteLine("POWER | SPEED | RESILIENCY | TECHNIQUE \n");
            Console.WriteLine("POWER: ");
            power = Convert.ToInt32(Console.ReadLine());
            pointsleft = pointsleft - power;
            Console.WriteLine("\nYou have " + pointsleft + " points left...\n");
            Console.WriteLine("\nSPEED: ");
            speed = Convert.ToInt32(Console.ReadLine());
            pointsleft = pointsleft - speed;
            Console.WriteLine("\nYou have " + pointsleft + " points left...\n");
            Console.WriteLine("\nRESILIENCY: ");
            resiliency = Convert.ToInt32(Console.ReadLine());
            pointsleft = pointsleft - resiliency;
            Console.WriteLine("\nYou have " + pointsleft + " points left...\n");
            Console.WriteLine("\nTECHNIQUE: ");
            technique = Convert.ToInt32(Console.ReadLine());
            pointsleft = pointsleft - technique;
            Console.WriteLine("\nYou have " + pointsleft + " points left...\n");

            AA = power + speed + resiliency + technique;
            if (AA != MAX)
            {
                Console.WriteLine("You need to use 25 points. Try again");
            }

        }

        Console.WriteLine("Write:\nHeel (for bad guy) \nFace (for good guy) ");
        gimmick = Console.ReadLine().ToUpper();
        Console.WriteLine(gimmick + "_____________");
        if (gimmick == "HEEL")
            Console.WriteLine("You lie, You cheat, You steal!\n");
        else if (gimmick == "FACE")
            Console.WriteLine("The crowd loves you\n");
        else
        {
            Console.WriteLine("since you didn't write face or heel... start over!");

            player1 = new Luchador(rid, name, hp, power, speed, resiliency, technique, gimmick, ability);

            return player1;


        }

        // Create a file to write to.
        string delimiter = ",";
        string createText = rid + delimiter + name.ToUpper() + delimiter + hp + delimiter + power.ToString() + delimiter + speed.ToString() + delimiter + resiliency.ToString() + delimiter + technique.ToString() + delimiter + gimmick + delimiter + ability + delimiter + "1" + delimiter + "0" + delimiter + "0" + Environment.NewLine;
        File.WriteAllText(path, createText);



        player1 = new Luchador(rid, name, hp, power, speed, resiliency, technique, gimmick, ability);
        Console.WriteLine(player1.NAME);
        return player1;
    }











    public static void playcard(int Turns, List<Card> PLAYERHAND, Luchador PLAYER1, Luchador CPU, List<Card> temp, Card buff, List<Card> PDeck, List<Card> pgraveyard, Card FINISHER, Card PIN, bool getpin, Queue<Card> cool, Stack<Card> board)
    {
        bool pinned = getpin;
        Luchador luchadorupdate = new Luchador();
        Card finisher = FINISHER;
        Card pin = PIN;
        Card buffcard = buff;
        Queue<Card> Cooldown = cool;
        Stack<Card> Board = board;
        List<Card> playerhand = PLAYERHAND;
        int playerhandlenght = playerhand.Count();
        int divided;
        int turns = Turns;
        int selection = 0;
        List<Card> tempcard = temp;
        List<Card> Pdeck = PDeck;
        List<Card> PGraveyard = pgraveyard;



        Console.WriteLine("Press 1 to Play a Card | Press 2 to change a card:  ");
        int P1selection = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\n");


        //**********************************************PLAY A CARD***********************************************************************************************



        if (P1selection == 1)
        {

            int cardselection = 0;
            Console.WriteLine("Press the number to the left to play the card (P1): ");
            cardselection = Convert.ToInt32(Console.ReadLine());
            cardselection = cardselection - 1;


            if (cardselection >= playerhandlenght)
            {
                while (cardselection >= playerhandlenght)
                {
                    Console.WriteLine("Again...Press the number to the left to play the card: ");
                    cardselection = Convert.ToInt32(Console.ReadLine());
                    cardselection = cardselection - 1;
                }
            }


            Console.WriteLine("\nP1 You played " + playerhand[cardselection].NAME);
            buffcard = playerhand[cardselection];



            if (turns < 4)
            {
                //CHECK THE TYPE OF CARD. BASED ON THAT WE CAN DETERMINE DAMAGE.

                if (playerhand[cardselection].TYPE == "LIGHT ATTACK" || playerhand[cardselection].TYPE == "S - LIGHT ATTACK")
                {

                    //Console.WriteLine("You played a light attack");
                    // P1Board.Push(P1Hand[cardselection]);
                    //P1TEMP = P1Board.Peek //Carta que jugo
                    // P1Hand.Remove(P1Hand[cardselection]);

                    divided = 2;
                    DamageCalc(divided, cardselection, playerhandlenght, playerhand, PLAYER1, CPU);


                }


                else if (playerhand[cardselection].TYPE == "HEAVY ATTACK" || playerhand[cardselection].TYPE == "S - HEAVY ATTACK" || playerhand[cardselection].TYPE == "GIMMICK")
                {
                    Console.WriteLine("1 Play This Turn");



                }

            }
            else
            {

                //CHECK THE TYPE OF CARD. BASED ON THAT WE CAN DETERMINE DAMAGE.

                if (playerhand[cardselection].TYPE == "LIGHT ATTACK" || playerhand[cardselection].TYPE == "S - LIGHT ATTACK")
                {

                    //Console.WriteLine("You played a light attack");
                    // P1Board.Push(P1Hand[cardselection]);
                    //P1TEMP = P1Board.Peek //Carta que jugo
                    // P1Hand.Remove(P1Hand[cardselection]);

                    divided = 2;
                    DamageCalc(divided, cardselection, playerhandlenght, playerhand, PLAYER1, CPU);


                }


                else if (playerhand[cardselection].TYPE == "HEAVY ATTACK" || playerhand[cardselection].TYPE == "S - HEAVY ATTACK")
                {
                    divided = 3;
                    DamageCalc(divided, cardselection, playerhandlenght, playerhand, PLAYER1, CPU);
                }


                else if (playerhand[cardselection].TYPE == "GIMMICK")
                {

                    Console.WriteLine("GIMMICK CARD");

                }

                else if (playerhand[cardselection].TYPE == "SPECIAL")
                {
                    playerhand.Add(finisher);
                    Console.WriteLine("You now can use you Finisher.");
                    divided = 3;
                    DamageCalc(divided, cardselection, playerhandlenght, playerhand, PLAYER1, CPU);

                }


                else if (playerhand[cardselection].TYPE == "FINISHER")
                {
                    Console.WriteLine("Do you want to pin your opponent?\n"
                                     + "1- Yes\n" +
                                      "2- No");
                    selection = Convert.ToInt32(Console.ReadLine());

                    if (selection == 1)
                    {
                        divided = 3;
                        DamageCalc(divided, cardselection, playerhandlenght, playerhand, PLAYER1, CPU);
                        pinned = GameMechanics.PinOpponent(PLAYER1, CPU);
                        //run pin mechanic... 
                    }
                    else if (selection == 2)
                    {
                        divided = 3;
                        DamageCalc(divided, cardselection, playerhandlenght, playerhand, PLAYER1, CPU);
                        playerhand.Add(pin);
                        Console.WriteLine("You have a pinning card in your hands. You can use this card to pin the opponent.");
                    }

                }
                else if (playerhand[cardselection].TYPE == "PIN")
                {
                    pinned = GameMechanics.PinOpponent(PLAYER1, CPU);
                }
            }

            //*********************************************************************PLAY A CARD END***************************************************************************************



            //***************************************************************CHANGE A CARD***************************************************************************************
        }

        else if (P1selection == 2)
        {
            ChangeCard(playerhandlenght, playerhand, Pdeck, tempcard, PGraveyard);

        }

        UpdateUse(buffcard, PGraveyard, Cooldown, Board);
    }




    public static void DamageCalc(int divided, int cardselection, int playerhandlenght, List<Card> playerhand, Luchador PLAYER1, Luchador CPU)
    {
        int DAMAGE = (PLAYER1.PWR + playerhand[cardselection].DMG);
        DAMAGE = DAMAGE / divided;
        //Console.WriteLine(PLAYER1.PWR + " Power | " + playerhand[cardselection].DMG + " CARD PWR ");
        //Console.WriteLine(DAMAGE + "DAMAGE");
        Console.WriteLine(CPU.NAME + " started with " + CPU.HP + " HP ");
        Console.WriteLine(PLAYER1.NAME + " did " + DAMAGE + " to " + CPU.NAME);
        CPU.HP = CPU.HP - DAMAGE;
        Console.WriteLine(CPU.NAME + " Now has " + CPU.HP + " HP \n");

    }





    public static void ChangeCard(int handlength, List<Card> playerhand, List<Card> P1deck, List<Card> tempcard, List<Card> P1Graveyard)
    {

        List<Card> PlayerHand = playerhand;
        int playerhandlenght = PlayerHand.Count();
        List<Card> Graveyard = P1Graveyard;
        List<Card> Deck = P1deck;
        List<Card> TEMPCARD = tempcard;


        //List<Card> TEMP = new List<Card>();
        Console.WriteLine("Press the number to the left to change the card: ");
        int selection = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("You discarded " + PlayerHand[selection - 1].NAME);


        int gravelength = Graveyard.Count();
        int i = 0;
        if (Deck.Count() == 0)
        {

            while (i != gravelength)
            {
                Deck.Add(Graveyard[0]);
                Graveyard.Remove(Graveyard[0]);

                i++;
            }
        }
        else
        {
            //SWITCHES CARD AND DRAWS A NEW ONE FROM DECK
            TEMPCARD.Add(Deck[0]);
            Deck.Remove(Deck[0]);
            Deck.Add(PlayerHand[selection - 1]);

            PlayerHand.Remove(PlayerHand[selection - 1]);
            PlayerHand.Add(TEMPCARD[0]);
            Console.WriteLine("You drew " + TEMPCARD[0].NAME + "\n\n");
            TEMPCARD.Remove(TEMPCARD[0]);
            Deck = Card.Shuffle(Deck);

        }

    }








    public void Changestats(Luchador player1, Luchador player2, Card tempcard)
    {
        Luchador PLAYER1 = player1;
        Luchador PLAYER2 = player1;
        Card P1TEMP = tempcard;

        //ADD BUFFS OR NERFS OF THE CARDS
        Console.WriteLine("\nDEFAULT PLAYER 1 POWER: " + PLAYER1.PWR);
        Console.WriteLine("DEFAULT PLAYER 1 SPEED: " + PLAYER1.SPD);
        Console.WriteLine("DEFAULT CPU POWER: " + PLAYER2.PWR);
        Console.WriteLine("DEFAULT CPU SPEED: " + PLAYER2.SPD);

        if (P1TEMP.GIMMICK == "FACE")
        {
            if (P1TEMP.TYPE1 == "PWR")
            {
                PLAYER1.PWR = PLAYER1.PWR + P1TEMP.EFF1;
                Console.WriteLine("PLAYER 1 POWER: " + PLAYER1.PWR);


            }
            else if (P1TEMP.TYPE1 == "SPD")
            {
                PLAYER1.SPD = PLAYER1.SPD + P1TEMP.EFF1;
                Console.WriteLine("PLAYER 1 SPEED: " + PLAYER1.SPD);

            }
            else if (P1TEMP.TYPE1 == "RESLNCY")
            {
                PLAYER1.RESLNCY = PLAYER1.RESLNCY + P1TEMP.EFF1;
            }
            else if (P1TEMP.TYPE1 == "TCHNQ")
            {
                PLAYER1.TCHNQ = PLAYER1.TCHNQ + P1TEMP.EFF1;
            }
        }


        else if (P1TEMP.GIMMICK == "HEEL")
        {
            if (P1TEMP.TYPE1 == "PWR")
            {
                PLAYER2.PWR = PLAYER2.PWR + P1TEMP.EFF1;
                Console.WriteLine("CPU POWER: " + PLAYER2.PWR);
            }
            else if (P1TEMP.TYPE1 == "SPD")
            {
                PLAYER2.SPD = PLAYER2.SPD + P1TEMP.EFF1;
                Console.WriteLine("CPU SPEED: " + PLAYER2.SPD);
            }
            else if (P1TEMP.TYPE1 == "RESLNCY")
            {
                PLAYER2.RESLNCY = PLAYER2.RESLNCY + P1TEMP.EFF1;
            }
            else if (P1TEMP.TYPE1 == "TCHNQ")
            {
                PLAYER2.TCHNQ = PLAYER2.TCHNQ + P1TEMP.EFF1;
            }
        }

        else
        {
            Console.WriteLine("--------------------");

        }
    }





    public static void UpdateUse(Card buffcard, List<Card> grave, Queue<Card> cool, Stack<Card> board)
    {

        Card Tempcard = buffcard;
        List<Card> Graveyard = grave;
        Stack<Card> Board = board;
        Queue<Card> Cooldown = cool;
        Console.WriteLine("UPDATE USE");

        Tempcard.TIMESUSED = Tempcard.TIMESUSED + 1;
        if (Tempcard.TIMESUSED == Tempcard.LIMIT)
        {
            Graveyard.Add(Tempcard);
            Board.Clear();
            Console.WriteLine("The crowd is bored of the " + Tempcard.NAME);


        }
        else if (Tempcard.TIMESUSED < Tempcard.LIMIT)
        {
            Console.WriteLine("What a " + Tempcard.NAME);
            Cooldown.Enqueue(Tempcard);
            Board.Clear();

        }
    }
}





