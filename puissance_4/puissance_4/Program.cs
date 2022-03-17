using System;

namespace puissance4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grils = new int[6, 6]
            {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };

            columncheck(grils);
        }

        static void columncheck(int[,]grils)
        {
            // nbrcolumn=0;
            int platab=0;
            bool player=true;
            int ligne = 5;
            bool okpass=false;

            while(!verifPuis4(grils))
            {
                Console.Clear();
                AfficheMatrice(grils);

                if(player)
                {
                    Console.WriteLine("  Entrez la colone");
                    string platab_=Console.ReadLine();
                    
                    stringtoint(platab_,ref platab);
                }
                else {
                    Random rnd = new Random();
                    int valeur = rnd.Next(1,5);
                    platab = valeur;
                }
                platab--;
                while(!okpass)
                {
                    if(grils[ligne, platab] != 0)
                    {
                        ligne--;
                    }
                    else
                    {
                        okpass = true; 
                    }
                }
                okpass=false;
                if(player)
                {
                    grils[ligne,platab] = 1;
                    player = false;
                }
                else
                {
                    grils[ligne, platab] = 2;
                    player = true;
                }
                platab = 0;
                ligne = 5;
                
                
            }

            AfficheMatrice(grils);
        }

        static bool verifPuis4(int[,] grils)
        {
            bool puis4 = false; //puissance 4
            bool pass = false; //passage ok
            bool reu = false; //reussite
            int column = 0; //colone
            int ligne = 5;
            int rouge = 0; //rouge =1
            int jaune = 0; //jaune =2

            //Verif puissance 4 horizontal

            while (!pass)
            {
                if(grils[ligne, column] == 0)
                {
                    column++;
                    if (column == 5)//for
                    {
                        ligne--;
                        column = 0;
                        rouge = 0;
                        jaune = 0;

                    }
                    if(ligne==0)
                    {
                        pass = true;//passage
                        reu = true;//reussite
                    }
                }
                else if (grils[ligne, column] == 1)
                {
                    rouge++;
                    column++;
                }
                else
                {
                    jaune++;
                    column++;
                }

                if (rouge == 4)
                {
                    
                    Console.WriteLine("Un puissance 4 rouge a ete détecté");
                    Console.ReadLine();
                    pass = true;
                    reu = false;
                    puis4 = true;
                }
                else if (jaune==4)
                {
                    Console.WriteLine("Un puissance 4 jaune a ete détecté");
                    Console.ReadLine();
                    pass = true;
                    reu = false;
                    puis4 = true;

                }                
            }

            //(reu)
            //{
            //Console.WriteLine("Aucun puissance 4 n'a ete détecté");
            //}
            return puis4;
        }

        static void stringtoint(string chaine,ref int nbr)
        {
            while(!int.TryParse(chaine,out nbr))
	        {
                Console.WriteLine("Merci de rentrer un nombre.");
	        }
        }

        static void AfficheMatrice(int[,]grils)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write("  "+grils[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}