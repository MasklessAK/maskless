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
        string rid = guid.ToString();

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
          int MAX = 25;
          int power,speed,resiliency,technique;
          int AA = 0 ;
          string name;
          
          Console.Write(e.Message + "\n" );
          Console.Write("");
          Console.Write("Lets create your Luchador\n");
          Console.Write("Enter your Luchadors's name: ");
          name = Console.ReadLine();
         
          
          while (AA != MAX){
          Console.Write("You have 25 points to use\n");
          Console.Write("POWER | SPEED | RESILIENCY | TECHNIQUE \n");
          Console.Write("POWER: ");
          power = Convert.ToInt32(Console.ReadLine());
          Console.Write("\nSPEED: ");
          speed = Convert.ToInt32(Console.ReadLine());
          Console.Write("\nRESILIENCY: ");
          resiliency = Convert.ToInt32(Console.ReadLine());
          Console.Write("\nTECHNIQUE: ");
          technique = Convert.ToInt32(Console.ReadLine());
          AA = power + speed + resiliency + technique;
          }
          
          
          
          
          
            return luchadorfile;
        }





        return luchadorfile;
    }

}