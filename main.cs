using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


class Program
{
    public static void Main(string[] args)
    {






        /*
        int len = P1.Count();
        Console.WriteLine(len);
        int i = 0;
        while (i != len){
          Console.WriteLine(P1[i].ID+ "_____________________________");
          i++;
        }*/

        //double probability =  GameMechanics.Prob();

        // CREATE P1 DECK VARIABLE
        List<Card> P1 = new List<Card>();
        //GET THE DECK FROM NAME ---MAKE A DECK NAME SYSTEM---
        string Deck1 = "Deck1.csv";
        //DECK IS IN P1
        P1 = Card.GetDeck(Deck1);
        //P1 DECK IS SHUFFLED
        P1 = Card.Shuffle(P1);
        string p1filename = "Luchador.csv";
        string cpufilename = "Cpu.csv";

        Luchador PLAYER1 = Luchador.CreateALuchador(p1filename);
        Luchador CPU = Luchador.CreateALuchador(cpufilename);
        Console.WriteLine(PLAYER1.NAME);
        Console.WriteLine(CPU.NAME);
        List<Card> TEMPCARD = new List<Card>();
        Card TEMP = new Card();




        List<Card> P1Hand = new List<Card>();
        Queue<Card> P1Cooldown = new Queue<Card>();
        Stack<Card> P1Board = new Stack<Card>();
        List<Card> P1Graveyard = new List<Card>();
        List<Card> P1Changes = new List<Card>();





        int turns = 0;
        bool pinned = false;
        int P1selection = 0;
        int lenP1Hand = P1Hand.Count();
        int r = 0;



        P1Hand.Add(P1[0]);
        P1Hand.Add(P1[1]);
        P1Hand.Add(P1[2]);
        P1Hand.Add(P1[3]);
        P1Hand.Add(P1[4]);


        P1.Remove(P1[0]);
        P1.Remove(P1[0]);
        P1.Remove(P1[0]);
        P1.Remove(P1[0]);
        P1.Remove(P1[0]);

        /*int len = P1.Count();
        Console.WriteLine(len);
        int i = 0;
        while (i != len){
          Console.WriteLine(P1[i].ID+ "_____________________________");
          i++;
        }*/




        Console.WriteLine("|Turn #" + turns + "|");
        Console.WriteLine("---------");
        Console.WriteLine("");


        //CHECK THE COOLDOWN QUEUE 
        try
        {
            Card PEEK = P1Cooldown.Peek();
            if (PEEK != null)
            {
                foreach (Card card in P1Cooldown)
                {
                    if (card.COOLCOUNT == card.COOLDOWN)
                    {
                        card.COOLCOUNT = 0;
                        P1Hand.Add(P1Cooldown.Dequeue());
                    }

                    else if (card.COOLCOUNT < card.COOLDOWN)
                    {
                        card.COOLCOUNT = card.COOLCOUNT + 1;
                    }
                    //COOLCOUNT +1... if COOLCOUNT = COOLDOWN ... RESET COOLCOUNT AND SEND IT TO THE HAND!
                    // IF NOT INCREASE COOLCOUNT AND KEEP IT MOVING
                    // CAN WE USE THE COOLDOWN LOOP TO UPDATE CHARACTER STATS SINCE WE HAVE ALL THE INFO HERE.
                    Console.WriteLine(card.NAME + " has cooled " + card.COOLCOUNT + " of " + card.COOLDOWN + " for you to use.");
                }

            }

        }
        catch (Exception e)
        {
            Console.WriteLine("NO CARD ON COOLDOWN");
        }
        if (P1Hand.Count() == 0)
        {
            //check the deck
            int cardsremainingindeck = P1.Count();
            int cardsincooldown = P1Cooldown.Count;
            int sac = 0;
            if (cardsremainingindeck == 0 && cardsincooldown == 0)
            {
                Console.WriteLine("You have no cards remaining in the Deck");
                int len = P1Hand.Count();
                //Console.WriteLine(len);
                int i = 0;
                while (i != len)
                {
                    if (P1Hand[i].NAME != "PIN")
                    {
                        i++;
                    }
                    else if (P1Hand[i].NAME == "PIN")
                    {
                        Console.WriteLine("Do you want to sacrifice a PIN card to regain the cards from your graveyard? 1-Yes | 2-No ");
                        sac = Convert.ToInt32(Console.ReadLine());
                        if (sac == 1)
                        {
                            int gracecount = P1Graveyard.Count();
                            int x = 0;
                            while (x != len)
                            {
                                P1.Add(P1Graveyard[x]);
                            }
                            P1Graveyard.Clear();
                            P1Hand.Remove(P1Hand[i]);
                            P1 = Card.Shuffle(P1);
                            P1Hand.Add(P1[0]);
                            P1Hand.Add(P1[1]);
                            P1Hand.Add(P1[2]);

                        }

                        else if (sac == 2)
                        {
                            Console.WriteLine("You are not sacrificing your PIN, you can't draw any more cards");
                        }

                    }




                }


            }
        }







        Console.Write("Press 1 to Play a Card | Press 2 to change a card:  ");
        P1selection = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\n");


        //**********************************************PLAY A CARD***********************************************************************************************

        if (P1selection == 1)
        {
            lenP1Hand = P1Hand.Count();
            r = 0;
            Console.WriteLine("Press the number to the left to play the card: ");
            while (r != lenP1Hand)
            {

                Console.WriteLine((r + 1) + "- " + P1Hand[r].NAME + " | " + P1Hand[r].TYPE + " | " + P1Hand[r].DESC + " | " + P1Hand[r].EFFDESCRIPTION);
                r++;
            }
            Console.WriteLine("");
            P1selection = Convert.ToInt32(Console.ReadLine());
            P1selection = P1selection - 1;
            Console.WriteLine("You played " + P1Hand[P1selection].NAME);
            //CHECK THE TYPE OF CARD. BASED ON THAT WE CAN DETERMINE DAMAGE.

            if (turns < 4)
            {
                Console.WriteLine("TURN 1-4");
                if (P1Hand[P1selection].TYPE == "LIGHT ATTACK" || P1Hand[P1selection].TYPE == "S - LIGHT ATTACK")
                {

                    Console.WriteLine("You played a light attack");
                    P1Board.Push(P1Hand[P1selection]);
                    TEMP = P1Board.Peek();
                    P1Hand.Remove(P1Hand[P1selection]);

                    int DAMAGE = 0;
                    int divided = 2;
                    if (PLAYER1.SPD > CPU.SPD)
                    {
                        DAMAGE = (PLAYER1.PWR + TEMP.DMG) / divided;
                        Console.WriteLine(CPU.NAME + " started with " + CPU.HP + " HP ");
                        Console.WriteLine(PLAYER1.NAME + " did " + DAMAGE + " to " + CPU.NAME);
                        CPU.HP = CPU.HP - DAMAGE;
                        Console.WriteLine(CPU.NAME + " Now has " + CPU.HP + " HP ");

                    }
                    else
                    {
                        Console.WriteLine("Can only use light attacks in the first 4 turns");
                    }

                    //ADD BUFFS OR NERFS OF THE CARDS
                    Console.WriteLine("DEFAULT PLAYER 1 POWER: " + PLAYER1.PWR);
                    Console.WriteLine("DEFAULT PLAYER 1 SPEED: " + PLAYER1.SPD);
                    Console.WriteLine("DEFAULT CPU POWER: " + CPU.PWR);
                    Console.WriteLine("DEFAULT CPU SPEED: " + CPU.SPD);

                    if (TEMP.GIMMICK == "FACE")
                    {
                        if (TEMP.TYPE1 == "PWR")
                        {
                            PLAYER1.PWR = PLAYER1.PWR + TEMP.EFF1;
                            Console.WriteLine("PLAYER 1 POWER: " + PLAYER1.PWR);


                        }
                        else if (TEMP.TYPE1 == "SPD")
                        {
                            PLAYER1.SPD = PLAYER1.SPD + TEMP.EFF1;
                            Console.WriteLine("PLAYER 1 SPEED: " + PLAYER1.SPD);

                        }
                        else if (TEMP.TYPE1 == "RESLNCY")
                        {
                            PLAYER1.RESLNCY = PLAYER1.RESLNCY + TEMP.EFF1;
                        }
                        else if (TEMP.TYPE1 == "TCHNQ")
                        {
                            PLAYER1.TCHNQ = PLAYER1.TCHNQ + TEMP.EFF1;
                        }
                    }


                    else if (TEMP.GIMMICK == "HEEL")
                    {
                        if (TEMP.TYPE1 == "PWR")
                        {
                            CPU.PWR = CPU.PWR + TEMP.EFF1;
                            Console.WriteLine("CPU POWER: " + CPU.PWR);
                        }
                        else if (TEMP.TYPE1 == "SPD")
                        {
                            CPU.SPD = CPU.SPD + TEMP.EFF1;
                            Console.WriteLine("CPU SPEED: " + CPU.SPD);
                        }
                        else if (TEMP.TYPE1 == "RESLNCY")
                        {
                            CPU.RESLNCY = CPU.RESLNCY + TEMP.EFF1;
                        }
                        else if (TEMP.TYPE1 == "TCHNQ")
                        {
                            CPU.TCHNQ = CPU.TCHNQ + TEMP.EFF1;
                        }
                    }


                }
                else if (turns % 5 == 0)
                {
                    //Create Signature Card  and give it to players...
                    Console.WriteLine("SIGNATURE TIME");
                }

                else if (turns > 5)
                {
                    Console.WriteLine("more than 5");
                }
            }
        }




        //*********************************************************************PLAY A CARD END***************************************************************************************



        //***************************************************************CHANGE A CARD***************************************************************************************


        else if (P1selection == 2)
        {
            lenP1Hand = P1Hand.Count();
            r = 0;
            //List<Card> TEMP = new List<Card>();
            Console.WriteLine("Press the number to the left to change the card: ");
            while (r != lenP1Hand)
            {
                Console.WriteLine((r + 1) + "- " + P1Hand[r].NAME + " | " + P1Hand[r].DESC + " | " + P1Hand[r].EFFDESCRIPTION);
                r++;
            }
            Console.WriteLine("");
            P1selection = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You chose " + P1Hand[P1selection - 1].NAME + "\n\n");


            int gravelength = 0;
            int i = 0;
            if (P1.Count() == 0)
            {

                while (i != gravelength)
                {
                    P1.Add(P1Graveyard[0]);
                    P1Graveyard.Remove(P1Graveyard[0]);

                    i++;
                }
            }
            else
            {
                //SWITCHES CARD AND DRAWS A NEW ONE FROM DECK
                TEMPCARD.Add(P1[0]);
                P1.Remove(P1[0]);
                P1.Add(P1Hand[P1selection - 1]);
                P1Hand.Remove(P1Hand[P1selection - 1]);
                P1Hand.Add(TEMPCARD[0]);
                Console.WriteLine("You drew " + TEMPCARD[0].NAME);
                TEMPCARD.Remove(TEMPCARD[0]);
                P1 = Card.Shuffle(P1);


                P1Hand.Add(TEMPCARD[0]);
                Console.WriteLine("You drew " + TEMPCARD[0].NAME);
                TEMPCARD.Remove(TEMPCARD[0]);
                P1 = Card.Shuffle(P1);



            }

        }
        //******************************************************************CHANGE A CARD END****************************************************************************************

        Console.WriteLine("TIMES USED CODE");
        //*****************************************************************TIMES USED CODE*****************************************************************************************
        TEMP.TIMESUSED = TEMP.TIMESUSED + 1;
        if (TEMP.TIMESUSED == TEMP.LIMIT)
        {
            P1Graveyard.Add(TEMP);
            P1Board.Clear();
            Console.WriteLine("The crowd is bored of the " + TEMP.NAME);
            //

        }
        else if (TEMP.TIMESUSED < TEMP.LIMIT)
        {
            Console.WriteLine("What a " + TEMP.NAME);
            P1Cooldown.Enqueue(TEMP);
            P1Board.Clear();
            // TEMP = null;
        }
        //*****************************************************************TIMES USED CODE ENDS****************************************************************************
        //*****************************************************************BUFF CODE STARTS********************************************************************************
        if (TEMP.TYPE == "S - LIGHT ATTACK" || TEMP.TYPE == "S - HEAVY ATTACK" || TEMP.TYPE == "GIMMICK")
        {
            P1Changes.Add(TEMP);
        }
        else
        {
            Console.WriteLine("CARD HAS NO BUFFS OR NERFS");
        }


        int Changeslen = P1Changes.Count();
        //Console.WriteLine(Changeslen);
        int c = 0;
        while (c != Changeslen)
        {
            if (P1Changes[c].TURNSBUFFED != 0)
            {
                P1Changes[c].TURNSBUFFED = P1Changes[c].TURNSBUFFED - 1;
            }


            else
            {
                if (P1Changes[c].GIMMICK == "FACE")
                {
                    if (P1Changes[c].TYPE1 == "PWR")
                    {
                        PLAYER1.PWR = PLAYER1.PWR - P1Changes[c].EFF1;
                        Console.WriteLine("PLAYER 1 POWER: " + PLAYER1.PWR);
                    }
                    else if (P1Changes[c].TYPE1 == "SPD")
                    {
                        PLAYER1.SPD = PLAYER1.SPD - P1Changes[c].EFF1;
                        Console.WriteLine("PLAYER 1 SPEED: " + PLAYER1.SPD);
                    }
                    else if (P1Changes[c].TYPE1 == "RESLNCY")
                    {
                        PLAYER1.RESLNCY = PLAYER1.RESLNCY - P1Changes[c].EFF1;
                    }
                    else if (P1Changes[c].TYPE1 == "TCHNQ")
                    {
                        PLAYER1.TCHNQ = PLAYER1.TCHNQ - P1Changes[c].EFF1;
                    }
                }

                else if (P1Changes[c].GIMMICK == "HEEL")
                {
                    if (P1Changes[c].TYPE1 == "PWR")
                    {
                        CPU.PWR = CPU.PWR - P1Changes[c].EFF1;
                        Console.WriteLine("CPU POWER: " + CPU.PWR);
                    }
                    else if (P1Changes[c].TYPE1 == "SPD")
                    {
                        CPU.SPD = CPU.SPD - P1Changes[c].EFF1;
                        Console.WriteLine("CPU SPEED: " + CPU.SPD);
                    }
                    else if (P1Changes[c].TYPE1 == "RESLNCY")
                    {
                        CPU.RESLNCY = CPU.RESLNCY - P1Changes[c].EFF1;
                    }
                    else if (P1Changes[c].TYPE1 == "TCHNQ")
                    {
                        CPU.TCHNQ = CPU.TCHNQ - P1Changes[c].EFF1;
                    }
                }


                //dpends on the type of card remove buff
                P1Changes.Remove(P1Changes[c]);


            }

            c++;


        }












        //while(pinned == false){
        // turns++;

        //if(turns <4){






        //}


        //}










        /*
        Firstturn = GameMechanics.RPS();
        Console.WriteLine(Firstturn);

        while (Firstturn == 't')
        {
          Console.WriteLine("Try again\n");
          Firstturn = GameMechanics.RPS();
          Console.WriteLine(Firstturn);


        }*/


        /*int n = 0;
            while (n != lenP1Hand)
            {
                Console.WriteLine((r + 1) + "- " + P1Hand[n].NAME + " | " + P1Hand[n].DESC + " | " + P1Hand[n].EFFDESCRIPTION + "NEW P1Hand");
                n++;
            }*/

    }
}