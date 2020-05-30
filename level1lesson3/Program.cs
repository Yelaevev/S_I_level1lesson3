using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static int ConquestCampaign(int N, int M, int L, int[] battalion)
        {
            if (L < 0)
            {
                Console.WriteLine("initial conditions is falls");
                return 0;
            }
            if (battalion.Length != 2 * L)
            {
                Console.WriteLine("initial conditions is falls");
                return 0;
            }

            if (N == M)
            {
                Console.WriteLine("initial conditions is falls");
                return 0;
            }
            if ((N <= 0) || (M <= 0))
            {
                Console.WriteLine("initial conditions is falls");
                return 0;
            }
            for (int i = 0; i < battalion.Length; i++)
            {
                battalion[i] = battalion[i] - 1;
            }
            for (int i = 0; i < battalion.Length-1; i=i+2)
            {
                if (battalion[i]>=N)
                {
                    Console.WriteLine("initial conditions is falls");
                    return 0;
                }

                if (battalion[i+1] >= M)
                {
                    Console.WriteLine("initial conditions is falls");
                    return 0;
                }
            }

            int[,] pole1 = new int[N, M];
            int[] zahvat(int[] desant, int[,] pole)
            {
                int strminus, strplus, stroka;
                int stlplus, stlminus, stolbets;
                int[] pokolenie1 = new int[4 * desant.Length];

              
                int pc = 0;
                int i1, i2, i3, i4, j1, j2, j3, j4;
                i1 = i2 = i3 = i4 = j1 = j2 = j3 = j4 = -1;

                for (int tk = 0; tk < (desant.Length - 1); tk = tk + 2)
                {
                    if (desant[tk] >= 0)
                    {

                        i1 = i2 = i3 = i4 = j1 = j2 = j3 = j4 = -1;
                        stroka = desant[tk];
                        stolbets = desant[tk + 1];
                        strminus = stroka;
                        strplus = stroka;
                        stlminus = stolbets;
                        stlplus = stolbets;
                        pole[stroka, stolbets] = 5;

                        if ((strplus < N - 1) && (pole[strplus + 1, stolbets] == 0))
                        {
                            pole[strplus + 1, stolbets] = pole[strplus, stolbets];
                            i1 = strplus + 1;
                            j1 = stolbets;
                           
                        }

                        if ((strminus > 0) && (pole[strminus - 1, stolbets] == 0))
                        {
                            pole[strminus - 1, stolbets] = pole[strminus, stolbets];
                            i2 = strminus - 1;
                            j2 = stolbets;
                       
                        }

                        //pole[stroka, stlplus + 1] = pole[stroka, stolbets];

                        if ((stlplus < M - 1) && (pole[stroka, stlplus + 1] == 0))
                        {
                            pole[stroka, stlplus + 1] = pole[stroka, stolbets];
                            i3 = stroka;
                            j3 = stlplus + 1;
                          
                        }

                        if ((stlminus > 0) && (pole[stroka, stlminus - 1] == 0))
                        {
                            pole[stroka, stlminus - 1] = pole[stroka, stolbets];
                            i4 = stroka;
                            j4 = stlplus - 1;
                          
                        }
                        pc = 4 * tk;
                        pokolenie1[pc] = i1; pokolenie1[pc + 2] = i2; pokolenie1[pc + 4] = i3; pokolenie1[pc + 6] = i4;
                        pokolenie1[pc + 1] = j1; pokolenie1[pc + 3] = j2; pokolenie1[pc + 5] = j3; pokolenie1[pc + 7] = j4;

                    }
                }

                return pokolenie1;
            }
            
            int chet = 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    while (pole1[i, j] == 0)
                    {
                        int[] c = zahvat(battalion, pole1);
                        battalion = c;
                        chet = chet + 1;
                       
                    }
                }
            }
            return chet;
        }
        //static void Main(string[] args)
        //{
        //    int N = 5;
        //    int M = 7;
         
        //    int[,] pole1 = new int[N, M];
        //    int chet;

         
        //        int[] test = { 3, 4, 1,4};
        //    chet = ConquestCampaign(3, 4, 2, test);
        //    Console.WriteLine($"znachenie chet= {chet}");
            //for (int n = 0; n < N; n++)
            //{
            //    for (int m = 0; m < M; m++)
            //    {
            //        Console.Write(pole1[n, m] + " ");
            //    }
            //    Console.WriteLine("");
            //}

            //  Console.WriteLine($"znachenie chet= {chet}");

        //}
    }
}
