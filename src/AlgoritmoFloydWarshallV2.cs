using System;
using System.Collections.Generic;

namespace ModuloGrafo
{
    public class AlgoritmoFloydWarshall
    {
        public AlgoritmoFloydWarshall()
        {}

        public static void buscarCaminosCostoMinimo(int[,] pMatDistancias, int pNumeroVertices,  
            out  int[,] pMatCostoMinimo, out int[,] pMatCaminosCostoMinimo )
        {
            int[,] _matCaminosCostoMinimo = new int[pNumeroVertices, pNumeroVertices];

            for (int i = 0; i < pNumeroVertices; i++)
                for (int j = 0; j < pNumeroVertices; j++)
                    _matCaminosCostoMinimo[i, j] = j;

            for (int k = 0; k < pNumeroVertices; k++)
                for (int i = 0; i < pNumeroVertices; i++)
                    for (int j = 0; j < pNumeroVertices; j++)
                        if (pMatDistancias[j, k] + pMatDistancias[k, i] < pMatDistancias[j, i])
                        {
                            pMatDistancias[j, i] = pMatDistancias[j, k] + pMatDistancias[k, i];
                            _matCaminosCostoMinimo[j, i] = _matCaminosCostoMinimo[j, k];
                        }

            pMatCostoMinimo = pMatDistancias;
            pMatCaminosCostoMinimo = _matCaminosCostoMinimo;
        }

        public static void ImprimirMatriz(int[,] pMatriz, int pNUmVertices)
        {
            Console.WriteLine("");
            Console.WriteLine("");

            for (int i = 0; i < pNUmVertices; ++i)
            {
                for (int j = 0; j < pNUmVertices; ++j)
                {
                    if (pMatriz[i, j] == GrafoConst.INFINITO)
                        Console.Write("INF".PadLeft(7));
                    else
                        Console.Write(pMatriz[i, j].ToString().PadLeft(7));
                }

                Console.WriteLine();
            }
        }
    }

}