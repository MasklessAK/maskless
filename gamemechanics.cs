using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class GameMechanics
{

    public char RPS()
    {
        char first;
        int P1A;
        first = 'c';


        Random rnd = new Random();
        int CPU = rnd.Next(1, 3);


        Console.WriteLine("Rock | Paper | Scissors \n");
        Console.WriteLine("______________________________\n");
        Console.WriteLine("1 for Rock\n");
        Console.WriteLine("2 for Paper\n");
        Console.WriteLine("3 for Scissors\n");
        P1A = Convert.ToInt32(Console.ReadLine());



        Console.WriteLine("\nYou picked " + P1A + "\n");
        Console.WriteLine("Opponent picked " + CPU + "\n");

        if (P1A == 1 && CPU == 3)
        {
            Console.WriteLine("Rock Beats Scissors. You go 1st\n");
            first = 'f';
            return first;
        }
        else if (P1A == 1 && CPU == 2)
        {
            Console.WriteLine("Paper Beats Rock. You go 2nd\n");
            first = 's';
            return first;

        }
        else if (P1A == 2 && CPU == 1)
        {
            Console.WriteLine("Paper Beats Rock. You go 1st\n");
            first = 'f';
            return first;
        }
        else if (P1A == 2 && CPU == 3)
        {
            Console.WriteLine("Scissors Beats Paper. You go 2nd\n");
            first = 's';
            return first;
        }
        else if (P1A == 3 && CPU == 2)
        {
            Console.WriteLine("Scissors Beat Paper. You go 1st\n");
            first = 'f';
            return first;
        }
        else if (P1A == 3 && CPU == 1)
        {
            Console.WriteLine("Rock Beats Scissors. You go 2nd\n");
            first = 's';
            return first;
        }
        else
        {
            first = 't';
            return first;
        }

    }

    public string MatchPick()
    {

        int pick;
        string match;
        Random rnd = new Random();
        pick = rnd.Next(1, 6);

        if (pick == 1 || pick == 6)
        {
            match = "match0001";
            Console.WriteLine("In a Singles match\n");
            return match;
        }
        else if (pick == 2 || pick == 5)
        {
            match = "match0002";
            Console.WriteLine("In a No DQ match\n");
            return match;
        }
        else
        {
            match = "match0003";
            Console.WriteLine("In a Cage match\n");
            return match;
        }
    }

    public double Prob()
    {
        double probability;
        DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;
        probability = Convert.ToInt64(now.ToUnixTimeMilliseconds());
        probability = probability % 100;
        return probability;
    }

    public static void Showhand(List<Card> playerhand, String playername)
    {
        int r = 0, PlayerHandLenght = 0;
        String PlayerName = playername;
        List<Card> Playerhand = new List<Card>();
        Playerhand = playerhand;
        PlayerHandLenght = Playerhand.Count();
        Console.WriteLine(PlayerName + "'s Hand:");


        while (r != PlayerHandLenght)
        {
            Console.WriteLine((r + 1) + "- " + Playerhand[r].NAME + " | " + Playerhand[r].TYPE + " | " + Playerhand[r].DESC + " | " + Playerhand[r].EFFDESCRIPTION);
            r++;
        }
        Console.WriteLine("_____________________________\n");
    }

    public static void Draw(int cards, List<Card> deck, List<Card> hand)
    {
        int CARDS = cards;
        int i = 0;
        List<Card> PlayerDeck = deck;
        List<Card> Playerhand = hand;
        while (i != CARDS)
        {
            Playerhand.Add(PlayerDeck[0]);
            i++;
            PlayerDeck.Remove(PlayerDeck[0]);

        }
    }


    public static void CheckEmptyHand(List<Card> hand, List<Card> deck, Queue<Card> cooldown, List<Card> grave)
    {
        List<Card> PlayerHand = hand;
        List<Card> PlayerDeck = deck;
        Queue<Card> Cooldown = cooldown;
        List<Card> Graveyard = grave;

        if (PlayerHand.Count() == 0)
        {
            //check the deck
            int cardsremainingindeck = PlayerDeck.Count();
            if (cardsremainingindeck <= 3)
            {
                Draw(cardsremainingindeck, PlayerDeck, PlayerHand);
            }
            else
            {
                Draw(3, PlayerDeck, PlayerHand);
            }

        }

    }



    public static void Turn5(int giventurns, List<Card> playerhand, List<Card> grave, List<Card> deck, Card Signature)
    {
        List<Card> PlayerHand = playerhand;
        List<Card> Graveyard = grave;
        List<Card> PlayerDeck = deck;
        Card signaturecard = Signature;
        int selection = 0;

        int turns = giventurns;

        if ((turns % 5) == 0)
        {



            Console.WriteLine("Enter 1 to get Signature Move, Enter 2 to reset your deck.\n");
            selection = Convert.ToInt32(Console.ReadLine());


            if (selection == 1)
            {
                PlayerHand.Add(signaturecard);
                Console.WriteLine("You now can use " + signaturecard.NAME + "!");
                //GameMechanics.Showhand(PlayerHand,"You");

            }
            //int len = PlayerHand.Count();
            //Console.WriteLine(len);
            else if (selection == 2)
            {
                int gravecount = Graveyard.Count();
                int x = 0;


                while (x != gravecount)
                {
                    PlayerDeck.Add(Graveyard[x]);
                    x++;
                }

                Graveyard.Clear();
                Console.WriteLine("You can use your moves again!");
                PlayerDeck = Card.Shuffle(PlayerDeck);
            }
        }
    }



    public static bool PinOpponent(Luchador Player1, Luchador Player2)
    {
        bool pinned = false;
        double formula = 0;
        Random rnd = new Random();
        int pinroll = rnd.Next(1, 10);
        Console.WriteLine(Player1.TCHNQ + "tech");
        Console.WriteLine(Player2.RESLNCY + "res");
        Console.WriteLine(pinroll + "pinroll");

        formula = Math.Abs(Player1.TCHNQ - Player2.RESLNCY) + 1;
        Console.WriteLine(formula + "absolutepower plus1");

        formula += pinroll;
        Console.WriteLine(formula + "random plus formula");

        formula *= 10;
        Console.WriteLine(formula);
        Player2.HP = 10;

        if (Player2.HP >= formula)
        {
            pinned = false;
            Console.WriteLine(Player2.NAME + " kicked out!");
        }
        else
        {

            pinned = true;
            Console.WriteLine("1.2.3 " + Player2.NAME + " fue planchado! The match has ended " + Player1.NAME + " wins");
            return pinned;


        }


        return pinned;
    }

}


