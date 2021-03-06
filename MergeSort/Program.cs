﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace MergeSort
{
    class Program
    {
        static string nomeArquivo = @"C:\\teste\\Arquivo.dat";
        public static void Main(string[] args)
        {
            OrdenarPartes ordenar = new OrdenarPartes();            
            CriarArquivo criar = new CriarArquivo();
            UnindoPartes unindo = new UnindoPartes();
            Dividir dividir = new Dividir();
            Int32 tam1 = 100004000; // equivale a 1 gb 
            Int32 tam2 = 500009000; // equivale a 6 gb
            //Int32 tamanho = 100000; // equivale a 1 mb            
            int opcao;
            do
            {
                Console.WriteLine("[ 1 ] Criar arquivo de 1 GIGABYTE");
                Console.WriteLine("[ 2 ] Criar arquivo de 6 GIGABYTES");
                Console.WriteLine("[ 0 ] Sair do Programa");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("\n\n");
                Console.Write("Digite uma opção: ");
                opcao = Int32.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Informe a quantidades de partes: ");
                        opcao = Int32.Parse(Console.ReadLine());
                        criar.Criar(nomeArquivo, tam1);
                        UsoMemoria();                        
                        dividir.DividirArquivo(nomeArquivo, tam1/opcao);                        
                        UsoMemoria();                        
                        ordenar.OrdenandoPartes();            
                        UsoMemoria();                        
                        unindo.MergePartes();            
                        UsoMemoria();            
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Informe a quantidades de partes");
                        opcao = Int32.Parse(Console.ReadLine());
                        criar.Criar(nomeArquivo, tam2);
                        UsoMemoria();                        
                        dividir.DividirArquivo(nomeArquivo, tam2/opcao);                        
                        UsoMemoria();                 
                        ordenar.OrdenandoPartes();            
                        UsoMemoria();                        
                        unindo.MergePartes();            
                        UsoMemoria();            
                        break;
                    default:
                        Console.ReadKey();
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (opcao != 0);                                        
        }        

        // Imprimo o uso de memoria
        static void UsoMemoria()
        {
            Console.WriteLine(String.Format("{0} MB memoria em uso | {1} MB memoria reservada.",
            Process.GetCurrentProcess().PeakWorkingSet64 / 1024 / 1024,
            Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024
            ));
        }        
    }
}
