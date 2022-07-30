using System;

namespace Battaglia_Navale_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Benvenuto al gioco della Battaglia Navale");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Inserisci il nome del Primo giocatore!");
            string Giocatore1 = Console.ReadLine();
            Console.WriteLine("Inserisci il nome del Secondo giocatore!");
            string Giocatore2 = Console.ReadLine();

            Console.ReadKey();

            int NumFlotte = 0;
            int Flotte5 = 0;

            while (Flotte5 == 0)
            {
                Console.Clear();
                Console.WriteLine("Quante flotte a testa volete utilizzare? ( Massimo 5 flotte per giocatore )");
                NumFlotte = int.Parse(Console.ReadLine());
                if (NumFlotte > 0 && NumFlotte < 6)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Per favore non fare il furbo.");
                    Console.ReadKey();
                }
            }


            int NumFlotteG1 = NumFlotte;
            int NumFlotteG2 = NumFlotte;
            int ContaTurniInsFlotte = 0;
            int ToccaA = 0;
            int CordX = 0;
            int CordY = 0;
            string[,] GrigliaG1Att = new string[10, 10];
            string[,] GrigliaG1Dif = new string[10, 10];
            string[,] GrigliaG2Att = new string[10, 10];
            string[,] GrigliaG2Dif = new string[10, 10];
            for (CordX = 0; CordX < 10; CordX++)
            {
                for (CordY = 0; CordY < 10; CordY++)
                {
                    GrigliaG1Att[CordX, CordY] = ("  ");
                    GrigliaG1Dif[CordX, CordY] = ("  ");
                    GrigliaG2Att[CordX, CordY] = ("  ");
                    GrigliaG2Dif[CordX, CordY] = ("  ");
                }
            }
            CordX = 0;
            CordY = -1;
            while (ContaTurniInsFlotte < 2)
            {
                if (ToccaA == 0)                                           //inserimento flotte Giocatore 1
                {
                    int CordAscisse = 0;
                    int CordOrdinata = 0;
                    Console.Clear();
                    StampaGrigliaG1Dif(GrigliaG1Dif, Giocatore1, CordX, CordY);
                    Console.WriteLine();
                    while (NumFlotteG1 > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine(Giocatore1 + " ora devi inserire la flotta da " + NumFlotteG1 + " caselle");
                        Console.WriteLine("Dove la vuoi inserire? (digita le cordinate Es. 'A1')");
                        string InsFlotta = Console.ReadLine();
                        int Ascissa = (ConvertiAscissa(InsFlotta, CordAscisse));
                        int Ordinata = (ConvertiOrdinata(InsFlotta, CordOrdinata));
                        int conta = 0;
                        string VersoFlotta;
                        int controlloFlotta = 0;
                        int k = 0;
                        if (NumFlotteG1 > 0)   // mettere 0 PER NON INSERIRE SEMPRE O / V  == 1 -> normale
                        {
                            VersoFlotta = "O";
                        }
                        else
                        {
                            Console.WriteLine("La flotta la vuoi mettere in orizzontale 'O' o in Verticale 'V' ?");
                            VersoFlotta = Console.ReadLine();
                        }
                        if (VersoFlotta == "O")
                        {
                            if ((Ascissa + NumFlotteG1) <= 10)               //Controllo flotte dentro la griglia
                            {
                                for (int j = 0; j < NumFlotteG1; j++)                                       //Controllo caselle libere intorno alla flotta
                                {
                                    controlloFlotta = 0;
                                    if (GrigliaG1Dif[Ascissa + k, Ordinata] == "[]")                                 //controllo stessa cella occupata
                                    {
                                        controlloFlotta++;
                                    }
                                    if (Ordinata + 1 <= 9)                                                            //controllo cella libera sotto
                                    {
                                        if (GrigliaG1Dif[Ascissa + k, Ordinata + 1] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ordinata - 1 >= 0)                                                          //controllo cella libera sopra
                                    {
                                        if (GrigliaG1Dif[Ascissa + k, Ordinata - 1] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ascissa + k + 1 < 10)                                                 //controllo cella libera dx
                                    {
                                        if (GrigliaG1Dif[Ascissa + k + 1, Ordinata] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ascissa + k - 1 >= 0)                                                            //controllo cella libera sx
                                    {
                                        if (GrigliaG1Dif[Ascissa + k - 1, Ordinata] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (controlloFlotta > 0)
                                    {
                                        Console.WriteLine("Non puoi mettere li la flotta");
                                        j = NumFlotteG1;
                                        Console.WriteLine("Premere Invio..");
                                        Console.ReadKey();
                                        conta = 10;
                                    }
                                    if (GrigliaG1Dif[Ascissa + k, Ordinata] == "  ")
                                    {
                                        conta++;
                                    }
                                    if (conta == NumFlotteG1)
                                    {
                                        for (int l = 0; l < NumFlotteG1; l++)
                                        {
                                            GrigliaG1Dif[Ascissa + l, Ordinata] = "[]";
                                        }
                                        NumFlotteG1--;
                                    }
                                    k++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("No esce fuori Orizzontale");
                                Console.WriteLine("Premere Invio..");
                                Console.ReadKey();
                            }
                        }
                        else if (VersoFlotta == "V")
                        {
                            if ((Ordinata + NumFlotteG1) <= 10)               //Controllo flotte dentro la griglia
                            {
                                for (int j = 0; j < NumFlotteG1; j++)                                       //Controllo caselle libere intorno alla flotta
                                {
                                    controlloFlotta = 0;                                                        //controllo stessa cella occupata
                                    if (GrigliaG1Dif[Ascissa, Ordinata + k] == "[]")
                                    {
                                        controlloFlotta++;
                                    }
                                    if (Ascissa + 1 <= 9)                                                 //controllo cella libera dx
                                    {
                                        if (GrigliaG1Dif[Ascissa + 1, Ordinata + k] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ascissa - 1 >= 0)                                                            //controllo cella libera sx
                                    {
                                        if (GrigliaG1Dif[Ascissa - 1, Ordinata + k] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ordinata + k + 1 <= 9)                                                            //controllo cella libera sotto
                                    {
                                        if (GrigliaG1Dif[Ascissa, Ordinata + k + 1] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ordinata + k - 1 >= 0)                                                          //controllo cella libera sopra
                                    {
                                        if (GrigliaG1Dif[Ascissa, Ordinata + k - 1] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }

                                    if (controlloFlotta > 0)
                                    {
                                        Console.WriteLine("Non puoi mettere li la flotta");
                                        j = NumFlotteG1;
                                        Console.WriteLine("Premere Invio..");
                                        Console.ReadKey();
                                        conta = 10;
                                    }
                                    if (GrigliaG1Dif[Ascissa, Ordinata + k] == "  ")
                                    {
                                        conta++;
                                    }
                                    if (conta == NumFlotteG1)
                                    {
                                        for (int l = 0; l < NumFlotteG1; l++)
                                        {
                                            GrigliaG1Dif[Ascissa, Ordinata + l] = "[]";
                                        }
                                        NumFlotteG1--;
                                    }
                                    k++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("No esce fuori Verticale");
                                Console.WriteLine("Premere Invio..");
                                Console.ReadKey();
                            }
                        }
                        Console.WriteLine();
                        Console.Clear();
                        StampaGrigliaG1Dif(GrigliaG1Dif, Giocatore1, CordX, CordY);
                    }
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Disposizione delle flotte " + Giocatore1);
                    StampaGrigliaG1Dif(GrigliaG1Dif, Giocatore1, CordX, CordY);
                    Console.WriteLine("Premere Invio..");
                    Console.ReadKey();
                    ToccaA = 1;
                    ContaTurniInsFlotte++;
                }
                else if (ToccaA == 1)                             //inserimento flotte Giocatore 2
                {
                    int CordAscisse = 0;
                    int CordOrdinata = 0;
                    Console.Clear();
                    StampaGrigliaG2Dif(GrigliaG2Dif, Giocatore2, CordX, CordY);        // Stampa griglia giocatore 2                    
                    Console.WriteLine();
                    while (NumFlotteG2 > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine(Giocatore2 + " ora devi inserire la flotta da " + NumFlotteG2 + " caselle");
                        Console.WriteLine("Dove la vuoi inserire? (digita le cordinate Es. A1)");
                        string InsFlotta = Console.ReadLine();
                        int Ascissa = (ConvertiAscissa(InsFlotta, CordAscisse));
                        int Ordinata = (ConvertiOrdinata(InsFlotta, CordOrdinata));
                        int conta = 0;
                        string VersoFlotta;
                        int controlloFlotta = 0;
                        int k = 0;
                        if (NumFlotteG2 > 0)   //PER NON INSERIRE SEMPRE O / V
                        {
                            VersoFlotta = "O";
                        }
                        else
                        {
                            Console.WriteLine("La flotta la vuoi mettere in orizzontale 'O' o in Verticale 'V' ?");
                            VersoFlotta = Console.ReadLine();
                        }
                        if (VersoFlotta == "O")
                        {
                            if ((Ascissa + NumFlotteG2) <= 10)               //Controllo flotte dentro la griglia
                            {
                                for (int j = 0; j < NumFlotteG2; j++)                                       //Controllo caselle libere intorno alla flotta
                                {
                                    controlloFlotta = 0;
                                    if (GrigliaG2Dif[Ascissa + k, Ordinata] == "[]")                                 //controllo stessa cella occupata
                                    {
                                        controlloFlotta++;
                                    }
                                    if (Ordinata + 1 <= 9)                                                            //controllo cella libera sotto
                                    {
                                        if (GrigliaG2Dif[Ascissa + k, Ordinata + 1] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ordinata - 1 >= 0)                                                          //controllo cella libera sopra
                                    {
                                        if (GrigliaG2Dif[Ascissa + k, Ordinata - 1] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ascissa + k + 1 < 10)                                                 //controllo cella libera dx
                                    {
                                        if (GrigliaG2Dif[Ascissa + k + 1, Ordinata] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ascissa + k - 1 >= 0)                                                            //controllo cella libera sx
                                    {
                                        if (GrigliaG2Dif[Ascissa + k - 1, Ordinata] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (controlloFlotta > 0)
                                    {
                                        Console.WriteLine("Non puoi mettere li la flotta");
                                        j = NumFlotteG2;
                                        Console.WriteLine("Premere Invio..");
                                        Console.ReadKey();
                                        conta = 10;
                                    }
                                    if (GrigliaG2Dif[Ascissa + k, Ordinata] == "  ")
                                    {
                                        conta++;
                                    }
                                    if (conta == NumFlotteG2)
                                    {
                                        for (int l = 0; l < NumFlotteG2; l++)
                                        {
                                            GrigliaG2Dif[Ascissa + l, Ordinata] = "[]";
                                        }
                                        NumFlotteG2--;
                                    }
                                    k++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("No esce fuori Orizzontale");
                                Console.WriteLine("Premere Invio..");
                                Console.ReadKey();
                            }
                        }
                        else if (VersoFlotta == "V")
                        {
                            if ((Ordinata + NumFlotteG2) <= 10)               //Controllo flotte dentro la griglia
                            {
                                for (int j = 0; j < NumFlotteG2; j++)                                       //Controllo caselle libere intorno alla flotta
                                {
                                    controlloFlotta = 0;                                                        //controllo stessa cella occupata
                                    if (GrigliaG2Dif[Ascissa, Ordinata + k] == "[]")
                                    {
                                        controlloFlotta++;
                                    }
                                    if (Ascissa + 1 <= 9)                                                 //controllo cella libera dx
                                    {
                                        if (GrigliaG2Dif[Ascissa + 1, Ordinata + k] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ascissa - 1 >= 0)                                                            //controllo cella libera sx
                                    {
                                        if (GrigliaG2Dif[Ascissa - 1, Ordinata + k] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ordinata + k + 1 <= 9)                                                            //controllo cella libera sotto
                                    {
                                        if (GrigliaG2Dif[Ascissa, Ordinata + k + 1] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }
                                    if (Ordinata + k - 1 >= 0)                                                          //controllo cella libera sopra
                                    {
                                        if (GrigliaG2Dif[Ascissa, Ordinata + k - 1] == "[]")
                                        {
                                            controlloFlotta++;
                                        }
                                    }

                                    if (controlloFlotta > 0)
                                    {
                                        Console.WriteLine("Non puoi mettere li la flotta");
                                        j = NumFlotteG2;
                                        Console.WriteLine("Premere Invio..");
                                        Console.ReadKey();
                                        conta = 10;
                                    }
                                    if (GrigliaG2Dif[Ascissa, Ordinata + k] == "  ")
                                    {
                                        conta++;
                                    }
                                    if (conta == NumFlotteG2)
                                    {
                                        for (int l = 0; l < NumFlotteG2; l++)
                                        {
                                            GrigliaG2Dif[Ascissa, Ordinata + l] = "[]";
                                        }
                                        NumFlotteG2--;
                                    }
                                    k++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("No esce fuori Verticale");
                                Console.WriteLine("Premere Invio..");
                                Console.ReadKey();
                            }
                        }
                        Console.WriteLine();
                        Console.Clear();
                        StampaGrigliaG2Dif(GrigliaG2Dif, Giocatore2, CordX, CordY);
                    }
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Disposizione delle flotte " + Giocatore2);
                    StampaGrigliaG2Dif(GrigliaG2Dif, Giocatore2, CordX, CordY);
                    Console.WriteLine("Premere Invio..");
                    Console.ReadKey();
                    ToccaA = 0;
                    ContaTurniInsFlotte++;
                }
            }

            Console.Clear();
            Console.WriteLine("Ora si puo Iniziare ad Attaccare!!!");
            Console.WriteLine("Premere Invio..");
            Console.ReadKey();
            int i = 0;
            int Att = 0;
            int FlottaDxKo = 0;
            int FlottaSxKo = 0;
            int FlottaSudKo = 0;
            int FlottaNordKo = 0;
            NumFlotteG1 = NumFlotte;
            NumFlotteG2 = NumFlotte;


            while (Att == 0)
            {
                if (ToccaA == 0)          // Attacco Giocatore1
                {
                    for (i = NumFlotteG1; i > 0; i--)
                    {
                        Console.Clear();
                        int CordAscisse = 0;
                        int CordOrdinata = 0;
                        //int ContFlotte = 0;
                        StampaGrigliaG1Dif(GrigliaG1Dif, Giocatore1, CordX, CordY);
                        StampaGrigliaG1Att(GrigliaG1Att, Giocatore1, CordX, CordY);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(Giocatore1 + " hai a disposizione " + NumFlotteG1 + " attacchi per turno.");
                        Console.WriteLine("Quale casella vuoi attaccare? Ti rimangono " + (i) + " colpi.");

                        string CordAttG1 = Console.ReadLine();
                        int Ascissa = (ConvertiAscissa(CordAttG1, CordAscisse));
                        int Ordinata = (ConvertiOrdinata(CordAttG1, CordOrdinata));
                        int Cont = 1;
                        if (GrigliaG2Dif[Ascissa, Ordinata] == "[]")
                        {
                            Console.Clear();
                            FlottaNordKo = FlottaSudKo = FlottaSxKo = FlottaDxKo = 0;
                            GrigliaG1Att[Ascissa, Ordinata] = "><";
                            GrigliaG2Dif[Ascissa, Ordinata] = "><";
                            StampaGrigliaG1Dif(GrigliaG1Dif, Giocatore1, CordX, CordY);
                            Console.WriteLine();
                            StampaGrigliaG1Att(GrigliaG1Att, Giocatore1, CordX, CordY);
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Bravo hai colpito la flotta! Premi invio.");
                            Console.ReadKey();
                            //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                            if (Ascissa + Cont < 10)                                               // controllo orizzotale Destra 
                            {
                                if (GrigliaG2Dif[Ascissa + Cont, Ordinata] == "><")
                                {
                                    //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                    Cont++;
                                    if (Ascissa + Cont < 10)
                                    {
                                        if (GrigliaG2Dif[Ascissa + Cont, Ordinata] == "><")
                                        {
                                            //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                            Cont++;
                                            if (Ascissa + Cont < 10)
                                            {
                                                if (GrigliaG2Dif[Ascissa + Cont, Ordinata] == "><")
                                                {
                                                    //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                                    Cont++;
                                                    if (Ascissa + Cont < 10)
                                                    {
                                                        if (GrigliaG2Dif[Ascissa + Cont, Ordinata] == "><")
                                                        {
                                                            //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                                            Cont++;
                                                            if (Ascissa + Cont < 10)
                                                            {
                                                                if (GrigliaG2Dif[Ascissa + Cont, Ordinata] == "  ")
                                                                {
                                                                    FlottaDxKo = 1;
                                                                }
                                                            }
                                                            else if (GrigliaG2Dif[Ascissa + Cont, Ordinata] == "  ")
                                                            {
                                                                FlottaDxKo = 1;
                                                            }
                                                        }
                                                        else if (GrigliaG2Dif[Ascissa + Cont, Ordinata] == "  ")
                                                        {
                                                            FlottaDxKo = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        FlottaDxKo = 1;
                                                    }
                                                }
                                                else if (GrigliaG2Dif[Ascissa + Cont, Ordinata] == "  ")
                                                {
                                                    FlottaDxKo = 1;
                                                }
                                            }
                                            else
                                            {
                                                FlottaDxKo = 1;
                                            }
                                        }
                                        else if (GrigliaG2Dif[Ascissa + Cont, Ordinata] == "  ")
                                        {
                                            FlottaDxKo = 1;
                                        }
                                    }
                                    else
                                    {
                                        FlottaDxKo = 1;
                                    }
                                }
                                else if (GrigliaG2Dif[Ascissa + Cont, Ordinata] == "  ")
                                {
                                    FlottaDxKo = 1;
                                }
                            }
                            else
                            {
                                FlottaDxKo = 1;
                            }
                            Cont = 1;
                            if (Ascissa - Cont > 0)                                               // controllo orizzotale Sinistra
                            {
                                if (GrigliaG2Dif[Ascissa - Cont, Ordinata] == "><")
                                {
                                    //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                    Cont++;
                                    if (Ascissa - Cont > 0)
                                    {
                                        if (GrigliaG2Dif[Ascissa - Cont, Ordinata] == "><")
                                        {
                                            //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                            Cont++;
                                            if (Ascissa - Cont > 0)
                                            {
                                                if (GrigliaG2Dif[Ascissa - Cont, Ordinata] == "><")
                                                {
                                                    //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                                    Cont++;
                                                    if (Ascissa - Cont > 0)
                                                    {
                                                        if (GrigliaG2Dif[Ascissa - Cont, Ordinata] == "><")
                                                        {
                                                            //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                                            Cont++;
                                                            if (Ascissa + Cont > 0)
                                                            {
                                                                if (GrigliaG2Dif[Ascissa - Cont, Ordinata] == "  ")
                                                                {
                                                                    FlottaSxKo = 1;
                                                                }
                                                            }
                                                            else if (GrigliaG2Dif[Ascissa - Cont, Ordinata] == "  ")
                                                            {
                                                                FlottaSxKo = 1;
                                                            }
                                                        }
                                                        else if (GrigliaG2Dif[Ascissa - Cont, Ordinata] == "  ")
                                                        {
                                                            FlottaSxKo = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        FlottaSxKo = 1;
                                                    }
                                                }
                                                else if (GrigliaG2Dif[Ascissa - Cont, Ordinata] == "  ")
                                                {
                                                    FlottaSxKo = 1;
                                                }
                                            }
                                            else
                                            {
                                                FlottaSxKo = 1;
                                            }
                                        }
                                        else if (GrigliaG2Dif[Ascissa - Cont, Ordinata] == "  ")
                                        {
                                            FlottaSxKo = 1;
                                        }
                                    }
                                    else
                                    {
                                        FlottaSxKo = 1;
                                    }
                                }
                                else if (GrigliaG2Dif[Ascissa - Cont, Ordinata] == "  ")
                                {
                                    FlottaSxKo = 1;
                                }
                            }
                            else
                            {
                                FlottaSxKo = 1;
                            }
                            Cont = 1;
                            if (Ordinata + Cont < 10)                                               // controllo Verticale Sud 
                            {
                                if (GrigliaG2Dif[Ascissa, Ordinata + Cont] == "><")
                                {
                                    //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                    Cont++;
                                    if (Ordinata + Cont < 10)
                                    {
                                        if (GrigliaG2Dif[Ascissa, Ordinata + Cont] == "><")
                                        {
                                            //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                            Cont++;
                                            if (Ordinata + Cont < 10)
                                            {
                                                if (GrigliaG2Dif[Ascissa, Ordinata + Cont] == "><")
                                                {
                                                    //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                                    Cont++;
                                                    if (Ordinata + Cont < 10)
                                                    {
                                                        if (GrigliaG2Dif[Ascissa, Ordinata + Cont] == "><")
                                                        {
                                                            //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                                            Cont++;
                                                            if (Ordinata + Cont < 10)
                                                            {
                                                                if (GrigliaG2Dif[Ascissa, Ordinata + Cont] == "  ")
                                                                {
                                                                    FlottaSudKo = 1;
                                                                }
                                                            }
                                                            else if (GrigliaG2Dif[Ascissa, Ordinata + Cont] == "  ")
                                                            {
                                                                FlottaSudKo = 1;
                                                            }
                                                        }
                                                        else if (GrigliaG2Dif[Ascissa, Ordinata + Cont] == "  ")
                                                        {
                                                            FlottaSudKo = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        FlottaSudKo = 1;
                                                    }
                                                }
                                                else if (GrigliaG2Dif[Ascissa, Ordinata + Cont] == "  ")
                                                {
                                                    FlottaSudKo = 1;
                                                }
                                            }
                                            else
                                            {
                                                FlottaSudKo = 1;
                                            }
                                        }
                                        else if (GrigliaG2Dif[Ascissa, Ordinata + Cont] == "  ")
                                        {
                                            FlottaSudKo = 1;
                                        }
                                    }
                                    else
                                    {
                                        FlottaSudKo = 1;
                                    }
                                }
                                else if (GrigliaG2Dif[Ascissa, Ordinata + Cont] == "  ")
                                {
                                    FlottaSudKo = 1;
                                }
                            }
                            else
                            {
                                FlottaSudKo = 1;
                            }
                            Cont = 1;
                            if (Ordinata - Cont > 0)                                               // controllo Verticale Nord 
                            {
                                if (GrigliaG2Dif[Ascissa, Ordinata - Cont] == "><")
                                {
                                    //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                    Cont++;
                                    if (Ordinata - Cont > 0)
                                    {
                                        if (GrigliaG2Dif[Ascissa, Ordinata - Cont] == "><")
                                        {
                                            //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                            Cont++;
                                            if (Ordinata + Cont > 0)
                                            {
                                                if (GrigliaG2Dif[Ascissa, Ordinata - Cont] == "><")
                                                {
                                                    //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                                    Cont++;
                                                    if (Ordinata - Cont > 0)
                                                    {
                                                        if (GrigliaG2Dif[Ascissa, Ordinata - Cont] == "><")
                                                        {
                                                            //GrigliaG2Dif[Ascissa, Ordinata] = "++";
                                                            Cont++;
                                                            if (Ordinata + Cont > 0)
                                                            {
                                                                if (GrigliaG2Dif[Ascissa, Ordinata - Cont] == "  ")
                                                                {
                                                                    FlottaNordKo = 1;
                                                                }
                                                            }
                                                            else if (GrigliaG2Dif[Ascissa, Ordinata - Cont] == "  ")
                                                            {
                                                                FlottaNordKo = 1;
                                                            }
                                                        }
                                                        else if (GrigliaG2Dif[Ascissa, Ordinata - Cont] == "  ")
                                                        {
                                                            FlottaNordKo = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        FlottaNordKo = 1;
                                                    }
                                                }
                                                else if (GrigliaG2Dif[Ascissa, Ordinata - Cont] == "  ")
                                                {
                                                    FlottaNordKo = 1;
                                                }
                                            }
                                            else
                                            {
                                                FlottaNordKo = 1;
                                            }
                                        }
                                        else if (GrigliaG2Dif[Ascissa, Ordinata - Cont] == "  ")
                                        {
                                            FlottaNordKo = 1;
                                        }
                                    }
                                    else
                                    {
                                        FlottaNordKo = 1;
                                    }
                                }
                                else if (GrigliaG2Dif[Ascissa, Ordinata - Cont] == "  ")
                                {
                                    FlottaNordKo = 1;
                                }
                            }
                            else
                            {
                                FlottaNordKo = 1;
                            }
                            if (FlottaDxKo + FlottaSxKo + FlottaNordKo + FlottaSudKo == 4)                                                     //    Abbattimento flotta 
                            {
                                NumFlotteG2--;
                                if (NumFlotteG2 == 0)
                                {
                                    Console.WriteLine("Complimenti!!!" + Giocatore1 + " Non ci sono più flotte avversarie!");
                                    Console.WriteLine("Hai vinto la partita!");
                                    Console.ReadKey();
                                    Att = 1;
                                    break;
                                }
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine();
                                StampaGrigliaG1Dif(GrigliaG1Dif, Giocatore1, CordX, CordY);
                                StampaGrigliaG1Att(GrigliaG1Att, Giocatore1, CordX, CordY);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Bravo hai eliminato una flotta!!! Te ne rimangono ancora " + (NumFlotte - (NumFlotte - NumFlotteG2)) + " da abbattere !!!");
                                Console.WriteLine("Premere Invio..");
                                Console.ReadKey();
                            }
                        }
                        else if (GrigliaG2Dif[Ascissa, Ordinata] == "()")
                        {
                            Console.Clear();
                            Console.WriteLine("Bravo, hai sparato dove hai già MANCATO il bersaglio..");
                            Console.ReadKey();
                        }
                        else if (GrigliaG2Dif[Ascissa, Ordinata] == "><")
                        {
                            Console.Clear();
                            Console.WriteLine("Bravo, hai sparato dove hai già COLPITO il bersaglio..");
                            Console.ReadKey();
                        }
                        else                                                                                                                    // Colpo andato a vuoto
                        {
                            Console.Clear();
                            GrigliaG1Att[Ascissa, Ordinata] = "()";
                            GrigliaG2Dif[Ascissa, Ordinata] = "()";
                            StampaGrigliaG1Att(GrigliaG1Att, Giocatore1, CordX, CordY);
                            StampaGrigliaG1Dif(GrigliaG1Dif, Giocatore1, CordX, CordY);
                            Console.WriteLine("Bersaglio MANCATO!!!");
                            Console.WriteLine("Premere Invio..");
                            Console.ReadKey();
                        }
                    }
                    ToccaA = 1;
                }








                else if (ToccaA == 1)                           // Attacco Giocatore2
                {
                    for (i = NumFlotteG2; i > 0; i--)
                    {
                        Console.Clear();
                        int CordAscisse = 0;
                        int CordOrdinata = 0;
                        //int ContFlotte = 0;
                        StampaGrigliaG2Dif(GrigliaG2Dif, Giocatore2, CordX, CordY);
                        StampaGrigliaG2Att(GrigliaG2Att, Giocatore2, CordX, CordY);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(Giocatore2 + " hai a disposizione " + NumFlotteG2 + " attacchi per turno.");
                        Console.WriteLine("Quale casella vuoi attaccare? Ti rimangono " + (i) + " colpi.");
                        string CordAttG2 = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        int Ascissa = (ConvertiAscissa(CordAttG2, CordAscisse));
                        int Ordinata = (ConvertiOrdinata(CordAttG2, CordOrdinata));
                        int Cont = 1;
                        if (GrigliaG1Dif[Ascissa, Ordinata] == "[]")
                        {
                            Console.Clear();
                            FlottaNordKo = FlottaSudKo = FlottaSxKo = FlottaDxKo = 0;
                            GrigliaG2Att[Ascissa, Ordinata] = "><";
                            GrigliaG1Dif[Ascissa, Ordinata] = "><";
                            StampaGrigliaG2Dif(GrigliaG2Dif, Giocatore2, CordX, CordY);
                            Console.WriteLine();
                            StampaGrigliaG2Att(GrigliaG2Att, Giocatore2, CordX, CordY);
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Bravo hai colpito la flotta! Premi invio.");
                            Console.ReadKey();
                            //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                            if (Ascissa + Cont < 10)                                               // controllo orizzotale Destra 
                            {
                                if (GrigliaG1Dif[Ascissa + Cont, Ordinata] == "><")
                                {
                                    //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                    Cont++;
                                    if (Ascissa + Cont < 10)
                                    {
                                        if (GrigliaG1Dif[Ascissa + Cont, Ordinata] == "><")
                                        {
                                            //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                            Cont++;
                                            if (Ascissa + Cont < 10)
                                            {
                                                if (GrigliaG1Dif[Ascissa + Cont, Ordinata] == "><")
                                                {
                                                    //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                                    Cont++;
                                                    if (Ascissa + Cont < 10)
                                                    {
                                                        if (GrigliaG1Dif[Ascissa + Cont, Ordinata] == "><")
                                                        {
                                                            //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                                            Cont++;
                                                            if (Ascissa + Cont < 10)
                                                            {
                                                                if (GrigliaG1Dif[Ascissa + Cont, Ordinata] == "  ")
                                                                {
                                                                    FlottaDxKo = 1;
                                                                    //ContFlotte =5;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                FlottaDxKo = 1;
                                                                //ContFlotte = 5;
                                                            }
                                                        }
                                                        else if (GrigliaG1Dif[Ascissa + Cont, Ordinata] == "  ")
                                                        {
                                                            FlottaDxKo = 1;
                                                            //ContFlotte = 4;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        FlottaDxKo = 1;
                                                        //ContFlotte = 4;
                                                    }
                                                }
                                                else if (GrigliaG1Dif[Ascissa + Cont, Ordinata] == "  ")
                                                {
                                                    FlottaDxKo = 1;
                                                    //ContFlotte = 3;
                                                }
                                            }
                                            else
                                            {
                                                FlottaDxKo = 1;
                                                //ContFlotte = 3;
                                            }
                                        }
                                        else if (GrigliaG1Dif[Ascissa + Cont, Ordinata] == "  ")
                                        {
                                            FlottaDxKo = 1;
                                            //ContFlotte = 2;
                                        }
                                    }
                                    else
                                    {
                                        FlottaDxKo = 1;
                                        //ContFlotte = 2;
                                    }
                                }
                                else if (GrigliaG1Dif[Ascissa + Cont, Ordinata] == "  ")
                                {
                                    FlottaDxKo = 1;
                                    //ContFlotte = 1;
                                }
                            }
                            else
                            {
                                FlottaDxKo = 1;
                                //ContFlotte = 1;
                            }
                            Cont = 1;
                            if (Ascissa - Cont > 0)                                               // controllo orizzotale Sinistra
                            {
                                if (GrigliaG1Dif[Ascissa - Cont, Ordinata] == "><")
                                {
                                    //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                    Cont++;
                                    if (Ascissa - Cont > 0)
                                    {
                                        if (GrigliaG1Dif[Ascissa - Cont, Ordinata] == "><")
                                        {
                                            //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                            Cont++;
                                            if (Ascissa + Cont > 0)
                                            {
                                                if (GrigliaG1Dif[Ascissa - Cont, Ordinata] == "><")
                                                {
                                                    //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                                    Cont++;
                                                    if (Ascissa - Cont > 0)
                                                    {
                                                        if (GrigliaG1Dif[Ascissa - Cont, Ordinata] == "><")
                                                        {
                                                            //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                                            Cont++;
                                                            if (Ascissa + Cont > 0)
                                                            {
                                                                if (GrigliaG1Dif[Ascissa - Cont, Ordinata] == "  ")
                                                                {
                                                                    FlottaSxKo = 1;
                                                                }
                                                            }
                                                            else if (GrigliaG1Dif[Ascissa - Cont, Ordinata] == "  ")
                                                            {
                                                                FlottaSxKo = 1;
                                                            }
                                                        }
                                                        else if (GrigliaG1Dif[Ascissa - Cont, Ordinata] == "  ")
                                                        {
                                                            FlottaSxKo = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        FlottaSxKo = 1;
                                                    }
                                                }
                                                else if (GrigliaG1Dif[Ascissa - Cont, Ordinata] == "  ")
                                                {
                                                    FlottaSxKo = 1;
                                                }
                                            }
                                            else
                                            {
                                                FlottaSxKo = 1;
                                            }
                                        }
                                        else if (GrigliaG1Dif[Ascissa - Cont, Ordinata] == "  ")
                                        {
                                            FlottaSxKo = 1;
                                        }
                                    }
                                    else
                                    {
                                        FlottaSxKo = 1;
                                    }
                                }
                                else if (GrigliaG1Dif[Ascissa - Cont, Ordinata] == "  ")
                                {
                                    FlottaSxKo = 1;
                                }
                            }
                            else
                            {
                                FlottaSxKo = 1;
                            }
                            Cont = 1;
                            if (Ordinata + Cont < 10)                                               // controllo Verticale Sud 
                            {
                                if (GrigliaG1Dif[Ascissa, Ordinata + Cont] == "><")
                                {
                                    //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                    Cont++;
                                    if (Ordinata + Cont < 10)
                                    {
                                        if (GrigliaG1Dif[Ascissa, Ordinata + Cont] == "><")
                                        {
                                            //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                            Cont++;
                                            if (Ordinata + Cont < 10)
                                            {
                                                if (GrigliaG1Dif[Ascissa, Ordinata + Cont] == "><")
                                                {
                                                    //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                                    Cont++;
                                                    if (Ordinata + Cont < 10)
                                                    {
                                                        if (GrigliaG1Dif[Ascissa, Ordinata + Cont] == "><")
                                                        {
                                                            //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                                            Cont++;
                                                            if (Ordinata + Cont < 10)
                                                            {
                                                                if (GrigliaG1Dif[Ascissa, Ordinata + Cont] == "  ")
                                                                {
                                                                    FlottaSudKo = 1;
                                                                }
                                                            }
                                                            else if (GrigliaG1Dif[Ascissa, Ordinata + Cont] == "  ")
                                                            {
                                                                FlottaSudKo = 1;
                                                            }
                                                        }
                                                        else if (GrigliaG1Dif[Ascissa, Ordinata + Cont] == "  ")
                                                        {
                                                            FlottaSudKo = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        FlottaSudKo = 1;
                                                    }
                                                }
                                                else if (GrigliaG1Dif[Ascissa, Ordinata + Cont] == "  ")
                                                {
                                                    FlottaSudKo = 1;
                                                }
                                            }
                                            else
                                            {
                                                FlottaSudKo = 1;
                                            }
                                        }
                                        else if (GrigliaG1Dif[Ascissa, Ordinata + Cont] == "  ")
                                        {
                                            FlottaSudKo = 1;
                                        }
                                    }
                                    else
                                    {
                                        FlottaSudKo = 1;
                                    }
                                }
                                else if (GrigliaG1Dif[Ascissa, Ordinata + Cont] == "  ")
                                {
                                    FlottaSudKo = 1;
                                }
                            }
                            else
                            {
                                FlottaSudKo = 1;
                            }
                            Cont = 1;
                            if (Ordinata - Cont > 0)                                               // controllo Verticale Nord 
                            {
                                if (GrigliaG1Dif[Ascissa, Ordinata - Cont] == "><")
                                {
                                    //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                    Cont++;
                                    if (Ordinata - Cont > 0)
                                    {
                                        if (GrigliaG1Dif[Ascissa, Ordinata - Cont] == "><")
                                        {
                                            //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                            Cont++;
                                            if (Ordinata + Cont > 0)
                                            {
                                                if (GrigliaG1Dif[Ascissa, Ordinata - Cont] == "><")
                                                {
                                                    //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                                    Cont++;
                                                    if (Ordinata - Cont > 0)
                                                    {
                                                        if (GrigliaG1Dif[Ascissa, Ordinata - Cont] == "><")
                                                        {
                                                            //GrigliaG1Dif[Ascissa, Ordinata] = "++";
                                                            Cont++;
                                                            if (Ordinata + Cont > 0)
                                                            {
                                                                if (GrigliaG1Dif[Ascissa, Ordinata - Cont] == "  ")
                                                                {
                                                                    FlottaNordKo = 1;
                                                                }
                                                            }
                                                            else if (GrigliaG1Dif[Ascissa, Ordinata - Cont] == "  ")
                                                            {
                                                                FlottaNordKo = 1;
                                                            }
                                                        }
                                                        else if (GrigliaG1Dif[Ascissa, Ordinata - Cont] == "  ")
                                                        {
                                                            FlottaNordKo = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        FlottaNordKo = 1;
                                                    }
                                                }
                                                else if (GrigliaG1Dif[Ascissa, Ordinata - Cont] == "  ")
                                                {
                                                    FlottaNordKo = 1;
                                                }
                                            }
                                            else
                                            {
                                                FlottaNordKo = 1;
                                            }
                                        }
                                        else if (GrigliaG1Dif[Ascissa, Ordinata - Cont] == "  ")
                                        {
                                            FlottaNordKo = 1;
                                        }
                                    }
                                    else
                                    {
                                        FlottaNordKo = 1;
                                    }
                                }
                                else if (GrigliaG1Dif[Ascissa, Ordinata - Cont] == "  ")
                                {
                                    FlottaNordKo = 1;
                                }
                            }
                            else
                            {
                                FlottaNordKo = 1;
                            }
                            if (FlottaDxKo + FlottaSxKo + FlottaNordKo + FlottaSudKo == 4)                                                     //    Abbattimento flotta 
                            {
                                NumFlotteG1--;
                                if (NumFlotteG1 == 0)
                                {
                                    Console.WriteLine("Complimenti!!!" + Giocatore1 + " Non ci sono più flotte avversarie!");
                                    Console.WriteLine("Hai vinto la partita!");
                                    Console.ReadKey();
                                    Att = 1;
                                    break;
                                }
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine();
                                StampaGrigliaG2Dif(GrigliaG2Dif, Giocatore2, CordX, CordY);
                                StampaGrigliaG2Att(GrigliaG2Att, Giocatore2, CordX, CordY);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Bravo hai eliminato una flotta!!! Te ne rimangono ancora " + (NumFlotte - (NumFlotte - NumFlotteG1)) + " da abbattere !!!");
                                Console.WriteLine("Premere Invio..");
                                Console.ReadKey();

                            }
                        }
                        else if (GrigliaG1Dif[Ascissa, Ordinata] == "()")
                        {
                            Console.Clear();
                            Console.WriteLine("Bravo, hai sparato dove hai già MANCATO il bersaglio..");
                            Console.ReadKey();
                        }
                        else if (GrigliaG1Dif[Ascissa, Ordinata] == "><")
                        {
                            Console.Clear();
                            Console.WriteLine("Bravo, hai sparato dove hai già COLPITO il bersaglio..");
                            Console.ReadKey();
                        }
                        else                                                                                                                    // Colpo andato a vuoto
                        {
                            Console.Clear();
                            GrigliaG2Att[Ascissa, Ordinata] = "()";
                            GrigliaG1Dif[Ascissa, Ordinata] = "()";
                            StampaGrigliaG2Att(GrigliaG2Att, Giocatore2, CordX, CordY);
                            StampaGrigliaG2Dif(GrigliaG2Dif, Giocatore2, CordX, CordY);
                            Console.WriteLine("Bersaglio MANCATO!!!");
                            Console.WriteLine("Premere Invio..");
                            Console.ReadKey();
                        }

                    }




                    ToccaA = 0;
                }
            }
        }




        static void StampaGrigliaG1Att(string[,] GrigliaG1Att, string Giocatore1, int CordX, int CordY)   // STAMPA GLIRGLIA GIOCATORE 1 ATTACCO
        {
            string Alfab = "ABCDEFGHIL";
            int lettera = 0;
            Console.WriteLine();
            Console.WriteLine(" Griglia " + Giocatore1 + " Attacco");
            Console.WriteLine();
            for (int i = 0; i < 21; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (j < 4)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            if (j < 19)
                            {
                                Console.Write("--");
                            }
                            else if (j == 21)
                            {
                                Console.Write("-");
                            }
                        }
                    }
                }
                else
                {
                    CordY++;
                    for (int j = 0; j < 26; j++)
                    {
                        if (j < 4)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write("|");
                            }
                            else if (j < 24)
                            {
                                Console.Write(GrigliaG1Att[CordX, CordY]);
                                CordX++;
                            }
                        }
                        if (j == 25)
                        {
                            Console.Write(" " + ((i / 2) - 10) * -1);
                        }
                    }
                }
                CordX = 0;
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int j = 0; j < (24); j++)
            {
                if (j < 4)
                {
                    Console.Write("  ");
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(Alfab[lettera] + " ");
                        lettera++;
                    }
                }
            }
            lettera = 0;
            CordY = -1;
        }
        static void StampaGrigliaG1Dif(string[,] GrigliaG1Dif, string Giocatore1, int CordX, int CordY)    // STAMPA GLIRGLIA GIOCATORE 1 DIFESA
        {
            string Alfab = "ABCDEFGHIL";
            int lettera = 0;
            Console.WriteLine();
            Console.WriteLine(" Griglia " + Giocatore1 + " Difesa");
            Console.WriteLine();
            for (int i = 0; i < 21; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (j < 4)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            if (j < 19)
                            {
                                Console.Write("--");
                            }
                            else if (j == 21)
                            {
                                Console.Write("-");
                            }
                        }
                    }
                }
                else
                {
                    CordY++;
                    for (int j = 0; j < 26; j++)
                    {
                        if (j < 4)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write("|");
                            }
                            else if (j < 24)
                            {
                                Console.Write(GrigliaG1Dif[CordX, CordY]);
                                CordX++;
                            }
                        }
                        if (j == 25)
                        {
                            Console.Write(" " + ((i / 2) - 10) * -1);
                        }
                    }
                }
                CordX = 0;

                Console.WriteLine();
            }
            Console.WriteLine();
            for (int j = 0; j < (24); j++)
            {
                if (j < 4)
                {
                    Console.Write("  ");
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(Alfab[lettera] + " ");
                        lettera++;
                    }
                }
            }
            lettera = 0;
            CordY = -1;
            Console.WriteLine();
            Console.WriteLine();
        }
        static void StampaGrigliaG2Att(string[,] GrigliaG2Att, string Giocatore2, int CordX, int CordY)    // STAMPA GLIRGLIA GIOCATORE 2 ATTACCO
        {
            string Alfab = "ABCDEFGHIL";
            int lettera = 0;
            Console.WriteLine();
            Console.WriteLine(" Griglia " + Giocatore2 + " Attacco");
            Console.WriteLine();
            for (int i = 0; i < 21; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (j < 4)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            if (j < 19)
                            {
                                Console.Write("--");
                            }
                            else if (j == 21)
                            {
                                Console.Write("-");
                            }
                        }
                    }
                }
                else
                {
                    CordY++;
                    for (int j = 0; j < 26; j++)
                    {
                        if (j < 4)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write("|");
                            }
                            else if (j < 24)
                            {
                                Console.Write(GrigliaG2Att[CordX, CordY]);
                                CordX++;
                            }
                        }
                        if (j == 25)
                        {
                            Console.Write(" " + ((i / 2) - 10) * -1);
                        }
                    }
                }
                CordX = 0;
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int j = 0; j < (24); j++)
            {
                if (j < 4)
                {
                    Console.Write("  ");
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(Alfab[lettera] + " ");
                        lettera++;
                    }
                }
            }
            lettera = 0;
            CordY = -1;

        }
        static void StampaGrigliaG2Dif(string[,] GrigliaG2Dif, string Giocatore2, int CordX, int CordY)    // STAMPA GLIRGLIA GIOCATORE 2 DIFESA
        {
            string Alfab = "ABCDEFGHIL";
            int lettera = 0;
            Console.WriteLine();
            Console.WriteLine(" Griglia " + Giocatore2 + " Difesa");
            Console.WriteLine();
            for (int i = 0; i < 21; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (j < 4)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            if (j < 19)
                            {
                                Console.Write("--");
                            }
                            else if (j == 21)
                            {
                                Console.Write("-");
                            }
                        }
                    }
                }
                else
                {
                    CordY++;
                    for (int j = 0; j < 26; j++)
                    {
                        if (j < 4)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write("|");
                            }
                            else if (j < 24)
                            {
                                Console.Write(GrigliaG2Dif[CordX, CordY]);
                                CordX++;
                            }
                        }
                        if (j == 25)
                        {
                            Console.Write(" " + ((i / 2) - 10) * -1);
                        }
                    }
                }
                CordX = 0;
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int j = 0; j < (24); j++)
            {
                if (j < 4)
                {
                    Console.Write("  ");
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(Alfab[lettera] + " ");
                        lettera++;
                    }
                }
            }
            lettera = 0;
            CordY = -1;
            Console.WriteLine();
            Console.WriteLine();
        }

        static int ConvertiAscissa(string InsFlotta, int CordAscisse)   // FUNZIONE CONVERSIONE ASCISSE
        {
            if (InsFlotta[0] == 'A')
            {
                CordAscisse = 0;
            }
            else if (InsFlotta[0] == 'B')
            {
                CordAscisse = 1;
            }
            else if (InsFlotta[0] == 'C')
            {
                CordAscisse = 2;
            }
            else if (InsFlotta[0] == 'D')
            {
                CordAscisse = 3;
            }
            else if (InsFlotta[0] == 'E')
            {
                CordAscisse = 4;
            }
            else if (InsFlotta[0] == 'F')
            {
                CordAscisse = 5;
            }
            else if (InsFlotta[0] == 'G')
            {
                CordAscisse = 6;
            }
            else if (InsFlotta[0] == 'H')
            {
                CordAscisse = 7;
            }
            else if (InsFlotta[0] == 'I')
            {
                CordAscisse = 8;
            }
            else if (InsFlotta[0] == 'L')
            {
                CordAscisse = 9;
            }
            return CordAscisse;
        }
        static int ConvertiOrdinata(string InsFlotta, int CordOrdinata)     // FUNZIONE CONVERSIONE ORDINATE
        {
            if (InsFlotta.Length == 3)
            {
                CordOrdinata = 0;
            }
            else if (InsFlotta[1] == '1')
            {
                CordOrdinata = 9;
            }
            else if (InsFlotta[1] == '2')
            {
                CordOrdinata = 8;
            }
            else if (InsFlotta[1] == '3')
            {
                CordOrdinata = 7;
            }
            else if (InsFlotta[1] == '4')
            {
                CordOrdinata = 6;
            }
            else if (InsFlotta[1] == '5')
            {
                CordOrdinata = 5;
            }
            else if (InsFlotta[1] == '6')
            {
                CordOrdinata = 4;
            }
            else if (InsFlotta[1] == '7')
            {
                CordOrdinata = 3;
            }
            else if (InsFlotta[1] == '8')
            {
                CordOrdinata = 2;
            }
            else if (InsFlotta[1] == '9')
            {
                CordOrdinata = 1;
            }
            return CordOrdinata;
        }
    }
}




