using System;
using System.IO;

class GameMechanics
{

    public static char RPS()
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

    public static string MatchPick()
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



}
