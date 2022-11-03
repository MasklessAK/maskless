using System;
using System.IO;

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


        int MAX = 25;
        int power = 0, speed = 0, resiliency = 0, technique = 0;
        int hp = 100;
        int AA = 0;
        int pointsleft = 25;
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
            Console.WriteLine("You have 25 points to use in:\n");
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

}