using System;
using System.Linq;
using System.Collections.Generic;

namespace p22Linq3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Estudiante> estudiantes = new List<Estudiante>(){
                new Estudiante{Matricula=111,Nombre="Juan",Domicilio="Principal 123 Zacatecas",
                Calif=new  List<float>{97,92,81,60}},
                new Estudiante{Matricula=222,Nombre="Maria Lopez",Domicilio="Principal 126 Fresnillo",
                Calif=new  List<float>{75,82,91,40}},
                 new Estudiante{Matricula=333,Nombre="Rodrigo Mata",Domicilio="Luis Moya Rio Grande",
                Calif=new  List<float>{95,92,81,60}},
                  new Estudiante{Matricula=444,Nombre="Miguel Mejia",Domicilio="Juan de Tolosa 22 Zacatecas",
                Calif=new  List<float>{90,92,61,40}},
            };

            estudiantes.Add(new Estudiante{Matricula=555,Nombre="Manuel Mejia",Domicilio="Juan de Tolosa 22 Zacatecas",
                Calif=new  List<float>{90,92,61,40}});

            //Todos los registros sin consulta ni filtro
            Console.WriteLine("\nTodos los estudiantes: {0}",estudiantes.Count());
            estudiantes.ForEach(est=>Console.WriteLine(est.ToString()));
        
            //Filtrar los estudiantes que son de zacatecas
            
            var estzac=(from est in estudiantes where est.Domicilio.Contains("Zacatecas") select est).ToList();
            Console.WriteLine("\n estudiantes de zacatecas: {0}\n",estzac.Count());
            estzac.ForEach(estzac=>Console.WriteLine(estzac.ToString()));

            //Filtrar estudiantes con promedio de 8, y mostrar ordenados por nombre descendete
            var otros = (from est in estudiantes
                where est.Calif.Average()>=70
                orderby est.Nombre descending
                select est).ToString();
            
            Console.WriteLine("\nEstudiantes con promedio de 8 {0}: \n",otros.Count());
            otros.ForEach(estudiantes=>Console.WriteLine(est.ToString()));

            //Consulta con datos agrupados
            var gpoest = from est in estudiantes group est by est.Matricula;

            foreach(var gpo in gpoest){
                Console.WriteLine(gpo.Key);
                foreach(Estudiante est in gpo)
                    Console.WriteLine(est.ToString());
            }

            //Estudiantes y sus promedios
            var prom = ( from est in estudiantes
                select $"Nombre={est.Nombre}  prom={est.Calif.Average()}").ToList();
            
            prom.ForEach(p=>Console.WriteLine(p));
        }

        
    }
}
