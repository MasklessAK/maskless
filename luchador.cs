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

    public static string[] CreateALuchador()
    {
      // path to the csv file
      string[] luchadorfile =  new string[11];;
      string path = "Luchador.csv";
      int i = 0;
      Guid guid = Guid.NewGuid();
      string rid = Convert.ToBase64String(guid.ToByteArray());
      rid = rid.Substring(0, rid.Length-2);

      int MAX = 25;
      int power = 0,speed = 0,resiliency = 0,technique = 0;
      int AA = 0 ;
      int pointsleft = 25;
      string name;
      string gimmick="";

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
                  return luchadorfile;
                }
            }
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message + "\n" );
          
          
        }
        
          
        
        Console.WriteLine("");
        Console.WriteLine("Lets create your Luchador\n");
        Console.WriteLine("Enter your Luchadors's name: ");
        name = Console.ReadLine();
         
        while (AA != MAX){
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
          if(AA != MAX){
            Console.WriteLine("You need to use 25 points. Try again");
          }
          
          }

          Console.WriteLine("Write:\nHeel (for bad guy) \nFace (for good guy) "); 
          gimmick = Console.ReadLine().ToUpper();
          Console.WriteLine(gimmick + "_____________");
            if(gimmick == "HEEL")
               Console.WriteLine("You lie, You cheat, You steal!\n");
            else if(gimmick == "FACE")
               Console.WriteLine("The crowd loves you\n");
            else{
              Console.WriteLine("since you didn't write face or heel... start over!");
              return luchadorfile;
              }
          
          // Create a file to write to.
          string delimiter = ",";
          string createText = rid + delimiter +  name.ToUpper() + delimiter +  "100" + delimiter +  power.ToString() + delimiter +  speed.ToString() + delimiter + resiliency.ToString() + delimiter + technique.ToString() + delimiter + gimmick + delimiter + "UNDERDOG" + delimiter +"1"+ delimiter +"0"+ delimiter +"0"+ Environment.NewLine;
          File.WriteAllText(path, createText);
          



        return luchadorfile;
    }

}