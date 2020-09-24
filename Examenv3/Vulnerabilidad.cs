using System;

namespace Examenv3
{
    class Vulnerabilidad
    {
        private string clave;
        private string vendedor;
        private string descripcion;
        private string type;
        private string fecha;

        public Vulnerabilidad(string clave,string vendedor,string descripcion, string type, string fecha){
            this.clave=clave;
            this.vendedor=vendedor;
            this.type=type;
            this.descripcion=descripcion;
            this.fecha=fecha;
        }

        public string Clave{
                get{return clave;}
                set{clave=value;}
            }
        
        public string Vendedor{
                get{return vendedor;}
                set{vendedor=value;}
            }
        public string Descripcion{
                get{return descripcion;}
                set{descripcion=value;}
            }
        public string Tipo{
                get{return type;}
                set{type=value;}
            }
        public string Fecha{
                get{return fecha;}
                set{fecha=value;}
            }
    }
}