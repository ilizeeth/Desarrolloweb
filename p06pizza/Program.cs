using System;
//Programa que permite pedir una pizza en base a la eleccion del usuario
//Paola Lizeth Medina Trejo
//01 septiembre 2020
namespace p06pizza
{
    class Program
    {
        static int Main(string[] args)
        {
            //Variables para recibir los parametros
            char tam,cub,don;
            string[] ings;
            //Variables para guardar la eleccion del usuario
            string tamaño,Ingrediente="",cubierta,donde;
            
            Console.Clear();
            if(args.Length==0){ //Revisar que exitan parametros en la linea de comandos
                Menu();
                return 1;
            }
            //Elegir tamaño
            tam=char.Parse(args[0].ToUpper()); //Tomar el primer parametro
            if(tam=='P') tamaño="pequeña";
            else if (tam=='M') tamaño="Mediana";
            else tamaño="Grande";

            //Elegir Ingrediente
            ings=args[1].Split("+");//Separa los ingredientes en base al signo y toma el parametro 2
            foreach(string i in ings){
                switch(char.Parse(i.ToUpper())){
                    case 'E': Ingrediente="Extraqueso"; break;
                    case 'C': Ingrediente="Champiñones"; break;
                    case 'P': Ingrediente="Piña"; break;
                }
            }

            //Tipo de Cubierta
            cub=char.Parse(args[2].ToUpper()); //Toma el tercer parametro
            cubierta=cub=='D' ? "Delgada" : "Gruesa";

            //Elegir donde comer
            don=char.Parse(args[2].ToUpper());
            donde=don=='A' ? "Aqui" :  "Llevar";
            
            Console.WriteLine("\nLa pizza que pediste es la siguiente: ");
            Console.WriteLine($"Tamaño: {tamaño}");
            Console.WriteLine($"Ingredientes: {Ingrediente}");
            Console.WriteLine($"Cubierta: {cubierta}");
            Console.WriteLine($"Donde: {donde}");
            return 0;
        }

       static void Menu(){
            Console.Clear();
            Console.WriteLine("Elige las opciones segun deseas tu pizza ");
            Console.WriteLine("Tamalo: (P)equeña (M)ediana (G)rande");
            Console.WriteLine("Ingredientes: (E)xtra queso, (C)hampiñones, (P)iña unidos por +" );
            Console.WriteLine("Cubierta: (D)elgada, (G)ruesa" );
            Console.WriteLine("Donde la comes: (A)qui, (L)levar");
        }
    }
}
