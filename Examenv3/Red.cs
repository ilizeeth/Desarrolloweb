using System;
using System.Collections.Generic;

namespace Examenv3
{
    class Red
    {   
        private string empresa;
        private string propietario;
        private string domicilio;

        private List<Nodo> nodo;
        public Nodo nod;

        public Red(string empresa, string propietario, string domicilio){
            this.empresa=empresa;
            this.domicilio=domicilio;
            this.propietario=propietario;
            nodo=new List<Nodo>();
        }

        public string Empresa{
            get{return empresa;}
            set{empresa=value;}
        }

        public string Propietario{
            get{return propietario;}
            set{propietario=value;}
        }

        public string Domicilio{
            get{return domicilio;}
            set{domicilio=value;}
        }

        public List<Nodo> nodos {
            get {return nodo;}
        }
        public void AgregarNodo(Nodo node) {
            nodo.Add(node);
        }

        public int TotalNode(List<Nodo> node){
           
            return (node.Count);
        }

        
        
    }
}
