using System;

namespace p15cuentabancariav1
{
    class CuentaDeCheques : CuentaBancaria{
    private double proteccionsobregiro; 
    
    public CuentaDeCheques(double saldo,double proteccionsobregiro)
        :base(saldo)
        {
            this.proteccionsobregiro=proteccionsobregiro;
        }

        public override bool Retira(double cantidad){ //sobre carga el metodo retira
            bool resultado=true;
            double proteccionrequirida=cantidad-saldo;
            if(proteccionsobregiro<proteccionrequirida){
                return false;
            }else {
                saldo=0.0;
                proteccionsobregiro-=proteccionrequirida;
            }
            return resultado;
        }
    
    }

}