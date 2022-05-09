using System;

namespace puissance4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grils = new int[6, 7]
            {
                { 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0}
            };

            columncheck(grils);
            
        }

        static bool Passerel(int[,] grils)
        {
            bool puis4 = false;

            puis4 = false;
            if (!VerifPuis4Hor(grils))
            {
                if (!VerifPuis4Ver(grils))
                {
                    if (!VerifPuis4OblG(grils))
                    {
                        if (!VerifPuis4OblD(grils))
                        {
                        
                        }
                        else 
                        { 
                            puis4 = true; 
                        }
                    }
                    else { puis4 = true; }
                }
                else { puis4 = true; }
            }
            else { puis4 = true; }

            if (puis4)
            {
                AfficheMatrice(grils);
                grils = new int[6, 7]
                {
                    { 0, 0, 0, 0, 0, 0, 0},
                    { 0, 0, 0, 0, 0, 0, 0},
                    { 0, 0, 0, 0, 0, 0, 0},
                    { 0, 0, 0, 0, 0, 0, 0},
                    { 0, 0, 0, 0, 0, 0, 0},
                    { 0, 0, 0, 0, 0, 0, 0}
                };
                recommencer(ref grils);
            }
            return puis4;
        }
        static void columncheck(int[,]grils)
        {
            // nbrcolumn=0;
            int platab=0;
            bool player=true;
            int ligne = 5;
            bool okpass=false;
            

            while (!Passerel(grils))
            {
                //Console.Clear();
                AfficheMatrice(grils);

                if(player)
                {
                    Console.WriteLine("  Entrez la colone");
                    string platab_=Console.ReadLine();
                    
                    stringtoint(platab_,ref platab);
                    if(platab>7)
                    {
                        platab = 7;
                    }
                    else if(platab<1)
                    {
                        platab=1;
                    }
                }   
                else {
                    Random rnd = new Random();
                    int valeur = rnd.Next(1,6);
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
        }

        static void recommencer(ref int[,] grils)
        {
            string recom = " ";

            while (recom !="oui" & recom !="non")
            {
                Console.WriteLine("Voulez vous rejouer");
                recom = Console.ReadLine();
            }
            if (recom=="oui")
            {
                columncheck(grils);
            }
            if (recom == "non")
            {
                System.Environment.Exit(0);
            }
        }
        static bool VerifPuis4Hor(int[,] grils)
        {
            bool puis4 =false;
            bool pass = true;
            int column = grils.GetLength(1) - 1;
            int ligne = grils.GetLength(0) - 1;
            int rouge = 0;
            int jaune = 0;

            //Verif puissance 4 horizontal

            //Etat : fini
            while (pass)
            {

                for (int i = 0; i < 7; i++)
                {
                    if (ligne == 0)
                    {
                        pass = false;
                        i = 6;
                    }
                    if (grils[ligne, column] == 1)
                    {
                        rouge++;
                        jaune = 0;
                    }

                    if (grils[ligne, column] == 2)
                    {
                        jaune++;
                        rouge = 0;
                    }
                    if (grils[ligne, column] == 0)
                    {
                        jaune = 0;
                        rouge = 0;
                    }

                    if (rouge == 4)
                    {
                        Console.WriteLine("Un puissance 4 rouge a ete détecté");
                        Console.WriteLine("AFFICHER");
                        Console.ReadLine();
                        pass = false;
                        puis4 = true;
                        i = 6;
                        jaune = 0;
                        rouge = 0;

                    }
                    else if (jaune == 4)
                    {
                        Console.WriteLine("Un puissance 4 jaune a ete détecté");
                        Console.WriteLine("AFFICHER");
                        Console.ReadLine();
                        puis4 = true;
                        pass = false;
                        i = 6;
                        jaune = 0;
                        rouge = 0;
                    }

                    if (column == 0)
                    {
                        if (ligne != 0)
                        {
                            ligne--;
                            jaune = 0;
                            rouge = 0;
                        }
                        else
                        {
                            pass = false;
                            i = 6;

                        }
                        column = grils.GetLength(1);

                    }

                    column--;
                }

            }
            return puis4;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        static bool VerifPuis4Ver(int[,] grils)
        {
            bool puis4 = false;
            bool pass = true;
            int column = grils.GetLength(1) - 1;
            int ligne = grils.GetLength(0)-1;
            int rouge = 0;
            int jaune = 0;

            //Verif puissance 4 vertical

            //Etat : fini

            while (pass)
            {
                for (int i = 0; i < grils.GetLength(1); i++)
                {
                    if (ligne == 0)
                    {
                        pass = false;
                        i = 6;
                    }
                    if (grils[ligne, column] == 1)
                    {
                        rouge++;
                        jaune = 0;
                    }

                    if (grils[ligne, column] == 2)
                    {
                        jaune++;
                        rouge = 0;
                    }

                    if (grils[ligne, column] == 0)
                    {
                        jaune = 0;
                        rouge = 0;
                    }

                    if (rouge == 4)
                    {
                        Console.WriteLine("Un puissance 4 rouge a ete détecté");
                        Console.WriteLine("AFFICHER");
                        Console.ReadLine();
                        pass = false;
                        puis4 = true;
                        i = 10;
                        jaune = 0;
                        rouge = 0;
                    }
                    else if (jaune == 4)
                    {
                        Console.WriteLine("Un puissance 4 jaune a ete détecté");
                        Console.WriteLine("AFFICHER");
                        Console.ReadLine();
                        pass = false;
                        puis4 = true;
                        i = 10;
                        jaune = 0;
                        rouge = 0;
                    }

                    if (ligne == 1)
                    {
                        if (column != 0)
                        {
                            column--;
                            jaune = 0;
                            rouge = 0;
                        }
                        else
                        {
                            pass = false;
                            i = 10;
                        }
                        ligne = grils.GetLength(0);
                    }

                    ligne--;
                }
            }
            return puis4;
        }


        static bool VerifPuis4OblD(int[,] grils)
        {

            // ---------------------------------------------
            // BOOL
            bool puis4 = false;
            bool pass = true;
            bool vod = true;

            // ---------------------------------------------
            // INT
            int column = grils.GetLength(1) - 1;
            int ligne = grils.GetLength(0) - 1;
            int column2;
            int ligne2;
            int rouge = 0;
            int jaune = 0;

            // ---------------------------------------------

            //Verif puissance 4 OblD

            //Etat : en cours de correction
            while (pass)
            {
                for (int i = 0; i < 8; i++)
                {
                    if(column!=0)
                    {
                        column--;
                    }
                    else
                    {
                        if (ligne != 0) { ligne--; }else vod = false;jaune = 0;rouge = 0;}      

                    if (grils[ligne, column] !=0)
                    {
                        column2 = column;
                        ligne2 = ligne;
                        while(vod)
                        {

                            if(column2!=grils.GetLength(1)-1)
                            {
                                column2++;

                                if (ligne2 != 0)
                                {
                                    ligne2--;
                                }
                                else vod = false;//
                            }

                            if(column2==grils.GetLength(1)-1 & ligne2==0)
                            {
                                vod = true;
                                i = 10; 
                            }
                            

                            if (grils[ligne2, column2] == 1)
                            {
                                rouge++;
                                jaune = 0;
                            }
                            
                            if (grils[ligne2, column2] == 2)
                            {
                                jaune++;
                                rouge=0;
                            }

                            Console.WriteLine(rouge);

                            if (grils[ligne2, column2] == 0)
                            {
                                vod = false;
                                jaune = 0;
                                rouge = 0;
                            }

                            if (rouge == 4)
                            {
                                Console.WriteLine("Un puissance 4 rouge a ete détecté");
                                Console.ReadLine();
                                pass = false;
                                i = 9;
                                puis4 = true;
                                vod = false;
                      
                            }

                            if (jaune == 4)
                            {
                                Console.WriteLine("Un puissance 4 jaune a ete détecté");
                                Console.ReadLine();
                                pass = false;
                                i = 9;
                                vod = false;
                                puis4 = true;
                     
                            }
                        }
                    }
                    if (column == 0)
                    {
                        if (ligne == 0)
                        {
                            pass = false;
                            i = 10;
                        }
                    }
                }
            }
            return puis4;
        }

        static bool VerifPuis4OblG(int[,] grils)
        {

            // ---------------------------------------------
            // BOOL
            bool puis4 = false;
            bool pass = true;
            bool Obd = true;

            // ---------------------------------------------
            // INT
            int column = grils.GetLength(1) - 1;
            int ligne = grils.GetLength(0) - 1;
            int column2;
            int ligne2;
            int rouge = 0;
            int jaune = 0;

            // ---------------------------------------------

            //Verif puissance 4 OblG
           
            //Etat : en cours
            while (pass)
            { 

                for (int i = 0; i < 8; i++)
                {
                    if (ligne == 0)
                    {
                        pass = false;
                        i = 9;
                    }
                    if (grils[ligne, column] == 1)
                    {
                        rouge++;
                        jaune = 0;
                    }

                    if (grils[ligne, column] == 2)
                    {
                        jaune++;
                        rouge = 0;
                    }

                    if (grils[ligne, column] == 0)
                    {
                        jaune = 0;
                        rouge = 0;
                    }

                    if (grils[ligne, column] != 0)
                    {
                        column2 = column;
                        ligne2 = ligne;

                        while (Obd)
                        {
                            if (ligne2 != 0)
                            {
                                ligne2--;
                            }
                            else { Obd = false; }

                            if (column2 != 0)
                            {
                                column2--;
                            }

                            if (grils[ligne2, column2] == 1)
                            {
                                rouge++;
                            }
                            else if (grils[ligne2, column2] == 2)
                            {
                                jaune++;
                            }
                            else if (grils[ligne2, column2] == 0)
                            {
                                rouge = 0;
                                jaune = 0;
                                Obd = false;
                            }

                            if (rouge == 4)
                            {
                                Console.WriteLine("Un puissance 4 rouge a ete détecté");
                                Console.ReadLine();
                                Console.WriteLine("AFFICHER");
                                Console.ReadLine();
                                pass = false;
                                puis4 = true;
                                i = 9;
                                Obd = false;
                                jaune = 0;
                                rouge = 0;
                            }

                            if (jaune == 4)
                            {
                                Console.WriteLine("Un puissance 4 jaune a ete détecté");
                                Console.WriteLine("AFFICHER");
                                Console.ReadLine();
                                pass = false;
                                puis4 = true;
                                i = 9;
                                Obd = false;
                                jaune = 0;
                                rouge = 0;
                            }
                        }
                    }

                    if (column == 0)
                    {
                        if (ligne != 0)
                        {
                            ligne--;
                            jaune = 0;
                            rouge = 0;
                        }
                        else
                        {
                            pass = false;
                            i = 9;

                        }
                        column = grils.GetLength(1);

                    }

                    column--;
                }
            }
            return puis4;
        }

        static void stringtoint(string chaine,ref int nbr)
        {
            while(!int.TryParse(chaine,out nbr))
	        {
                Console.WriteLine("Merci de rentrer un nombre.");
                chaine = Console.ReadLine();
            }
        }

        static void AfficheMatrice(int[,]grils)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int x = 0; x < 7; x++)
                {
                    if(grils[i, x]==1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  "+ "o");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (grils[i, x] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("  " + "o");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else{
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  " + "o");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}