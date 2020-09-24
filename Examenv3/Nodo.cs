using System;
using System.Collections.Generic;
using System.Linq;

namespace Examenv3
{
    class Nodo
    {
        private string ip;
        private string tipo;
        private int puertos;
        private int saltos;
        private string so;

        private List<Vulnerabilidad> vulnerabilidad;

        public Nodo(){}

        public Nodo(string ip, string tipo, int puertos, int saltos, string so){
            this.ip=ip;
            this.tipo=tipo;
            this.puertos=puertos;
            this.saltos=saltos;
            this.so=so;
            vulnerabilidad=new List<Vulnerabilidad>();

        }

        public string Ip{
            get{return ip;}
            set{ip=value;}
        }

        public string Tipo{
            get{return tipo;}
            set{tipo=value;}
        }

        public int Saltos{
            get{return saltos;}
            set{saltos=value;}
            }
         public int Puertos{
            get{return puertos;}
            }
        
         public string So{
            get{return so;}
            set{so=value;}
            }
        
        public List<Vulnerabilidad> Vul{
            get{return vulnerabilidad;}

            
            
        }

        public void AgregarVul(Vulnerabilidad Vu){
            vulnerabilidad.Add(Vu);
        }
       

       
    }
}