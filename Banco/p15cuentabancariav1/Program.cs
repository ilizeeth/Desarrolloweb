using System;

namespace p15cuentabancariav1
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco mibanco = new Banco("La alcancía","Paola Medina");
            mibanco.AgregarCliente(new Cliente("Juana Gallo"));
            mibanco.AgregarCliente(new Cliente("Miguel Hidalgo"));
            mibanco.AgregarCliente(new Cliente("Juan Escutia"));
            mibanco.AgregarCliente(new Cliente("Pedro Lopez"));

            mibanco.Clientes[0].Cuenta=new CuentaBancaria(100);
            mibanco.Clientes[1].Cuenta=new CuentaBancaria(600);
            mibanco.Clientes[2].Cuenta=new CuentaBancaria(10000);
            mibanco.Clientes[3].Cuenta=new CuentaBancaria(200);
            mibanco.Clientes[2].Cuenta.Retira(200);
            mibanco.Clientes[1].Cuenta.Deposita(20);

            Console.WriteLine("Reporte General \n");
            Console.WriteLine($"Banco: {mibanco.Nombre} \n Propietario de {mibanco.Propietario}\n");

            foreach(Cliente cte in mibanco.Clientes){
                Console.WriteLine($"El cliente ed nombre: {cte.Nombre}");
                Console.WriteLine($"Tiene un saldo de: {cte.Cuenta.Saldo}");
            }     
        }
    }
}
