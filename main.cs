using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



class Program
{
    public static void Main(string[] args)
    {






        /*
         int lenDECK = P1.Count();
          Console.WriteLine(lenDECK);
          int L = 0;
          while (L != lenDECK){
            Console.WriteLine(P1[L].NAME+ "_____________________________");
            L++;
          }
    */

        //double probability =  GameMechanics.Prob();

        // CREATE P1 DECK VARIABLE
        List<Card> P1 = new List<Card>();
        List<Card> CPUDECK = new List<Card>();

        //GET THE DECK FROM NAME ---MAKE A DECK NAME SYSTEM---
        string Deck1 = "Deck1.csv";
        string Deck2 = "Deck2.csv";
        //DECK IS IN P1
        P1 = Card.GetDeck(Deck1);
        CPUDECK = Card.GetDeck(Deck2);




        // Name of the players file
        string p1filename = "Luchador.csv";
        string cpufilename = "Cpu.csv";


        //Creates Two Players
        Luchador PLAYER1 = Luchador.CreateALuchador(p1filename);
        Luchador CPU = Luchador.CreateALuchador(cpufilename);
        Console.WriteLine(PLAYER1.NAME);
        Console.WriteLine(CPU.NAME);

        //Create a temporary Card List to use in change card method()
        List<Card> P1TEMPCARD = new List<Card>();
        List<Card> CPUTEMPCARD = new List<Card>();


        // create a temp card to use in for buff and nefrs on character
        Card P1TEMP = new Card();
        Card P1SPECIAL = new Card();
        Card P1FINISHER = new Card();
        Card P1PIN = new Card("MASK-S01-0070", "SMALL PACKAGE", "Oldest trick in the book", 0, "PIN", "NEUTRAL", 0, 0, "PINS YOUR OPPONENT", 1, 0, "NONE", "NONE", 0);

        // create a temp card to use in for buff and nerfs on character
        Card CPUTEMP = new Card();
        Card CPUSPECIAL = new Card();
        Card CPUFINISHER = new Card();
        Card CPUPIN = new Card("MASK-S01-0070", "SMALL PACKAGE", "Oldest trick in the book", 0, "PIN", "NEUTRAL", 0, 0, "PINS YOUR OPPONENT", 1, 0, "NONE", "NONE", 0);




        // Create lists,stacks and queue we are going to use in the game
        List<Card> P1Hand = new List<Card>();
        Queue<Card> P1Cooldown = new Queue<Card>();
        Stack<Card> P1Board = new Stack<Card>();
        List<Card> P1Graveyard = new List<Card>();
        List<Card> P1Changes = new List<Card>();



        // Create lists,stacks and queue we are going to use in the game
        List<Card> CPUHand = new List<Card>();
        Queue<Card> CPUCooldown = new Queue<Card>();
        Stack<Card> CPUBoard = new Stack<Card>();
        List<Card> CPUGraveyard = new List<Card>();
        List<Card> CPUChanges = new List<Card>();


        //GET SPECIAL AND FINISHER FROM DECK
        P1SPECIAL = P1[15];
        P1FINISHER = P1[16];
        CPUSPECIAL = CPUDECK[15];
        CPUFINISHER = CPUDECK[16];

        //REMOVE SPECIAL AND FINISHER FROM DECK
        P1.Remove(P1[15]);
        P1.Remove(P1[15]);
        CPUDECK.Remove(CPUDECK[15]);
        CPUDECK.Remove(CPUDECK[15]);



        int turns = 0;
        bool pinned = false;
        int P1selection = 0;
        int CPUselection = 0;

        int lenP1Hand = P1Hand.Count();
        int lenCPUHand = CPUHand.Count();
        int r = 0;
        int p1deckcounter = 0;
        int cpudeckcounter = 0;




        // DRAW 5 CARDS FOR PLAYER 1
        GameMechanics.Draw(5, P1, P1Hand);
        // DRAW 5 CARDS FOR CPU
        GameMechanics.Draw(5, CPUDECK, CPUHand);





        /*int len = P1.Count();
        Console.WriteLine(len);
        int i = 0;
        while (i != len){
          Console.WriteLine(P1[i].ID+ "_____________________________");
          i++;
        }*/



        turns++;
        Console.WriteLine("|Turn #" + turns + "|");
        Console.WriteLine("---------");
        Console.WriteLine("");



        Card.checkcooldownQ(PLAYER1, P1Cooldown, P1Hand);
        Card.checkcooldownQ(CPU, CPUCooldown, CPUHand);

        GameMechanics.CheckEmptyHand(P1Hand, P1, P1Cooldown, P1Graveyard);
        GameMechanics.CheckEmptyHand(CPUHand, CPUDECK, CPUCooldown, CPUGraveyard);

        GameMechanics.Turn5(turns, P1Hand, P1Graveyard, P1, P1SPECIAL);
        GameMechanics.Turn5(turns, CPUHand, CPUGraveyard, CPUDECK, CPUSPECIAL);




        GameMechanics.Showhand(P1Hand, PLAYER1.NAME); //SHOW PLAYER 1 HAND
        Luchador.playcard(turns, P1Hand, PLAYER1, CPU, P1TEMPCARD, P1TEMP, P1, P1Graveyard, P1FINISHER, P1PIN, pinned, P1Cooldown, P1Board);




        GameMechanics.Showhand(CPUHand, CPU.NAME); //SHOW CPU HAND
        Luchador.playcard(turns, CPUHand, CPU, PLAYER1, CPUTEMPCARD, CPUTEMP, CPUDECK, CPUGraveyard, CPUFINISHER, CPUPIN, pinned, CPUCooldown, CPUBoard);












        //*****************************************************************BUFF CODE STARTS********************************************************************************
        if (P1TEMP.TYPE == "S - LIGHT ATTACK" || P1TEMP.TYPE == "S - HEAVY ATTACK" || P1TEMP.TYPE == "GIMMICK")
        {
            P1Changes.Add(P1TEMP);
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








        Console.WriteLine(CPUTEMP.TYPE + "-----------");



        CPUTEMP.TIMESUSED = CPUTEMP.TIMESUSED + 1;
        if (CPUTEMP.TIMESUSED == CPUTEMP.LIMIT)
        {
            CPUGraveyard.Add(CPUTEMP);
            CPUBoard.Clear();
            Console.WriteLine("The crowd is bored of the " + CPUTEMP.NAME);
            //

        }
        else if (CPUTEMP.TIMESUSED < CPUTEMP.LIMIT)
        {
            Console.WriteLine("What a " + CPUTEMP.NAME);
            CPUCooldown.Enqueue(CPUTEMP);
            CPUBoard.Clear();
            // TEMP = null;
        }
        //*****************************************************************TIMES USED CODE ENDS****************************************************************************
        //*****************************************************************BUFF CODE STARTS********************************************************************************
        if (CPUTEMP.TYPE == "S - LIGHT ATTACK" || CPUTEMP.TYPE == "S - HEAVY ATTACK" || CPUTEMP.TYPE == "GIMMICK")
        {
            CPUChanges.Add(CPUTEMP);
        }
        else
        {
            Console.WriteLine("CARD HAS NO BUFFS OR NERFS");
        }


        int CPUChangeslen = CPUChanges.Count();
        //Console.WriteLine(Changeslen);
        int d = 0;
        while (d != CPUChangeslen)
        {
            if (CPUChanges[d].TURNSBUFFED != 0)
            {
                CPUChanges[d].TURNSBUFFED = CPUChanges[d].TURNSBUFFED - 1;
            }


            else
            {
                if (CPUChanges[d].GIMMICK == "FACE")
                {
                    if (CPUChanges[d].TYPE1 == "PWR")
                    {
                        CPU.PWR = CPU.PWR - CPUChanges[d].EFF1;
                        Console.WriteLine("PLAYER 1 POWER: " + CPU.PWR);
                    }
                    else if (CPUChanges[d].TYPE1 == "SPD")
                    {
                        CPU.SPD = CPU.SPD - CPUChanges[d].EFF1;
                        Console.WriteLine("PLAYER 1 SPEED: " + CPU.SPD);
                    }
                    else if (CPUChanges[d].TYPE1 == "RESLNCY")
                    {
                        CPU.RESLNCY = CPU.RESLNCY - CPUChanges[d].EFF1;
                    }
                    else if (CPUChanges[d].TYPE1 == "TCHNQ")
                    {
                        CPU.TCHNQ = CPU.TCHNQ - CPUChanges[d].EFF1;
                    }
                }

                else if (CPUChanges[d].GIMMICK == "HEEL")
                {
                    if (CPUChanges[d].TYPE1 == "PWR")
                    {
                        PLAYER1.PWR = PLAYER1.PWR - CPUChanges[d].EFF1;
                        Console.WriteLine("CPU POWER: " + PLAYER1.PWR);
                    }
                    else if (CPUChanges[d].TYPE1 == "SPD")
                    {
                        PLAYER1.SPD = PLAYER1.SPD - CPUChanges[d].EFF1;
                        Console.WriteLine("CPU SPEED: " + PLAYER1.SPD);
                    }
                    else if (CPUChanges[d].TYPE1 == "RESLNCY")
                    {
                        PLAYER1.RESLNCY = PLAYER1.RESLNCY - CPUChanges[d].EFF1;
                    }
                    else if (CPUChanges[d].TYPE1 == "TCHNQ")
                    {
                        PLAYER1.TCHNQ = PLAYER1.TCHNQ - CPUChanges[d].EFF1;
                    }
                }


                //dpends on the type of card remove buff
                CPUChanges.Remove(CPUChanges[d]);


            }

            d++;


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