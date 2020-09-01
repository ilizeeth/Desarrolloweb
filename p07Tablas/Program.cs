//Programa que imprime las tablas de multipliclar
/* Paola Lizeth Medina Trejo
    01 Septiembre 2020*/

using System;

namespace p07Tablas
{
    class Program
    {
        static int Main(string[] args)
        {
            int op,ini,fin,tab;
            if(args.Length==0){Menu(); return 1;}
            
            op=int.Parse(args[0]); //Opcion del menu
            tab=int.Parse(args[1]); //La tabla
            ini=int.Parse(args[2]); //inicio
            fin=int.Parse(args[3]); //fin
            switch(op){
                case 1:{
                    for(int i=ini;i<=fin;i++){
                        Console.WriteLine($"{tab} X {i} = {tab*i}");
                    }
                }break;

                case 2: {
                    for(int t=1;t<=tab;t++){
                        for(int i=ini;i<=fin;i++){
                            Console.WriteLine($"{t}X{i}={t*i}");
                        }
                        Console.WriteLine("\n");
                    }
                }break;
            }
            
            
            
            
            return 0;
        }

        static void Menu(){
        Console.Clear();
        Console.WriteLine("[1] Imprime la tabla que quieras hasta donde quieras [ej. 1..10]");
        Console.WriteLine("[2]Imprime todas las tablas hasta donde quieras[ej. 5 10]");

    }

    
 }
}