using System;

namespace p23Interfaz1
{
    public interface IAnimal{
        string Nombre {get; set;}
        void Llorar();
    }

    class Perro : IAnimal{
        public Perro(string nombre)=> Nombre = nombre;
        public string Nombre {get; set;}
        public void Llorar() => Console.WriteLine("Woff Woff");
    }

    class Gato : IAnimal{
        public Gato(string nombre)=> Nombre = nombre;
        public string Nombre {get; set;}
        public void Llorar() => Console.WriteLine("Miau Miau");
    }
    
        
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Primer ejemplo de uso de interfaces\n");
            Perro miperro = new Perro("Sabueso");
            Console.WriteLine($"El perro {miperro.Nombre}");
            miperro.Llorar();

            Gato migato = new Gato("Hunter");
            Console.WriteLine($"El gato {migato.Nombre}");
            migato.Llorar();
        }
    }
}
