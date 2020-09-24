using System;
using System.Collections.Generic;
using System.Linq;

namespace Examenv3
{
    class Program
    {
        static void Main(string[] args)

        {
          

           Red red = new Red("Red Patito, S.A. de C.V.","Propietario: Mr Pato Macdonald","Av. Princeton 123, Orlando Florida");
        
            red.AgregarNodo(new Nodo("192.168.0.12","servidor",5,10,"Linux"));
            red.AgregarNodo(new Nodo("192.168.0.12","equipoactivo",2,12,"Linux"));
            red.AgregarNodo(new Nodo("192.168.0.20","computadora",8,5,"Windows"));
            red.AgregarNodo(new Nodo("192.168.0.15","servidor",10,22,"Linux"));

            Console.WriteLine("\t\t=============================");
            Console.WriteLine("\t\tDATOS GENERALES DE LA RED");
            Console.WriteLine("\t\t=============================");
            Console.WriteLine($"\t\tEmpresa:{red.Empresa}\n\t\tPropietario:{red.Propietario},\n\t\tDomicilio:{red.Domicilio}");   
            
          //Agregar vunerabilidades a los nodos
           red.nodos[0].AgregarVul(new Vulnerabilidad("CVE-2015-1635","Microsoft","HTTP.sys permite a atacantes remotos ejecutar código arbitrario","Remota","04/14/2015"));
           red.nodos[0].AgregarVul(new Vulnerabilidad("CVE-2017-0004","Microsoft","El servicio LSASS permite causar una denegación de servicio","Local","01/10/2001"));
           red.nodos[1].AgregarVul(new Vulnerabilidad("CVE-2017-3847","cisco","Cisco Firepower Management Center XSS","Remota","02/21/2017"));
           red.nodos[2].AgregarVul(new Vulnerabilidad("CVE-2009-2504","microsoft","Múltiples desbordamientos de enteros en APIs Microsoft .NET 1.1","Local","02/21/2009"));
           red.nodos[2].AgregarVul(new Vulnerabilidad("CVE-2016-7271","microsoft","Elevación de privilegios Kernel Segura en Windows 10 Gold","Local","12/20/2016"));
           red.nodos[2].AgregarVul(new Vulnerabilidad("CVE-2017-2996","adobe","Adobe Flash Player 24.0.0.194 corrupción de memoria explotable","Remota","15/02/2017"));
        
            Console.WriteLine();
            
            Console.WriteLine($"\t\tTotal de nodos en la red: {red.TotalNode(red.nodos)}");
            
            

            Console.WriteLine("\n\t\t Datos generales de los nodos");
            Console.WriteLine();

            foreach(Nodo node in red.nodos){

               Console.WriteLine($"\t\tIp: {node.Ip} Tipo:{node.Tipo} Puertos:{node.Puertos} Saltos:{node.Saltos} SO:{node.So} TotVul:{node.Vul.Count}");  
                    
            } 
            

            foreach(Nodo node in red.nodos){
               Console.WriteLine("\t\tVulnerabilidades por nodo");
               Console.WriteLine($"\t\tIp: {node.Ip} Tipo:{node.Tipo}");  

               foreach(Vulnerabilidad vul in node.Vul){
                   DateTime now = DateTime.Now;
                   
                   Console.WriteLine($"\t\tClave:{vul.Clave} Vendedor:{vul.Vendedor} Descripcion:{vul.Descripcion} Tipo:{vul.Tipo} Fecha:{vul.Fecha}");
               }
               Console.WriteLine();
            } 

            //Filtrar los nodos de tipo remota
            

            var rem=(from nod in red.nodos where nod.Tipo.Contains("servidor") select nod).ToList();
            Console.WriteLine("\n\n\t\tNodos de tipo remota: {0}",rem.Count());
            rem.ForEach(rem=>Console.WriteLine(rem.ToString()));
            
            //Filtrar los nodos del so de linux
            var so=(from nod in red.nodos where nod.Tipo.Contains("Linux") select nod).ToList();
            Console.WriteLine("\n\n\t\tNodos con el so linux: {0}",so.Count());
            so.ForEach(so=>Console.WriteLine(so.ToString()));

            //Filtrar vunerabilidades con el vendedor microsoft
            foreach(Nodo node in red.nodos){
                foreach(Vulnerabilidad vu in node.Vul){
                    var vendedor=(from vul in node.Vul 
                    where vul.Vendedor.Contains("microsoft")select vul);

                    Console.WriteLine("\n\n\t\tVulnerabilidad con vendedor microsoft: {0}",vendedor.Count());
                    

                }
                
            }

        }

      
     
    }
}
