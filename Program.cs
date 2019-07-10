using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModuloGrafo;

namespace grafoV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int INF = GrafoConst.INFINITO;

            int[,] matAlquiler = { 
                {   0,   3, INF,  40,  30 },
                { INF,   0,   2,  35, INF },
                { INF, INF,   0,  30,   4 },
                { INF, INF, INF,   0,   5 },
                { INF, INF, INF, INF,   0 }
                };
            int numeroDeAldeas = 5;

            int[,] matCaminosCostoMinimo = new int[numeroDeAldeas, numeroDeAldeas];
            int[,] matCostoMinimoDeXaY = new int[numeroDeAldeas, numeroDeAldeas];

            AlgoritmoFloydWarshall.buscarCaminosCostoMinimo(matAlquiler, numeroDeAldeas, out matCostoMinimoDeXaY, out matCaminosCostoMinimo);

            Console.WriteLine(" __________________________");
            Console.WriteLine("|   Matriz Costo Minimo    | ");
            Console.WriteLine("|__________________________|");
            
            AlgoritmoFloydWarshall.ImprimirMatriz( matCostoMinimoDeXaY, numeroDeAldeas );

            Console.WriteLine("");

            Console.WriteLine(" ____________________________________________");
            Console.WriteLine("|   Matriz - Caminos Costo Minimo de A -> B  |");
            Console.WriteLine("|____________________________________________|");    

            AlgoritmoFloydWarshall.ImprimirMatriz( matCaminosCostoMinimo, numeroDeAldeas );

            Console.WriteLine("");

              for ( int i = 0; i < numeroDeAldeas; i++  )
                for ( int j = 0; j < numeroDeAldeas; j++  )
                {
                    if (i != j && matCostoMinimoDeXaY[i, j] != GrafoConst.INFINITO)
                    {
                        List<int> lstCamino = new List<int>();

                        int idxOrigenTmp = i;
                        int idxDestinoTmp = j;

                        while (idxOrigenTmp != idxDestinoTmp)
                        {
                            lstCamino.Add(idxOrigenTmp);

                            idxOrigenTmp = matCaminosCostoMinimo[idxOrigenTmp, idxDestinoTmp];
                        }

                        lstCamino.Add(idxDestinoTmp);

                        // mostramos la ruta para llegar de A -> B
                        Console.WriteLine("    {0} -> {1}    COSTO = {2}    Camino: {3}", i, j, 
                            matCostoMinimoDeXaY[i, j].ToString().PadLeft(6), String.Join(" -> ", lstCamino));
                    }
                }

        }
    }
}
