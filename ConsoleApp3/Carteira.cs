using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Carteira
    {
        public double Saldo
        {
            get;
            private set;
        }
        public string Dono { get; set; }

        public bool Sacar(double Valor)
        {
            if (Valor > this.Saldo)
                return false;

            this.Saldo -= Valor;
            //this.Saldo = Saldo - Valor;
            return true;
        }

        public bool Depositar(double Valor)
        {
            this.Saldo += Valor;
            return true;
        }

        public bool Transferir
            (Carteira destino, double valor)
        {  
            //se nao tiver saldo cancela transferencia retornando falso
            if (this.Saldo <= valor)
                return false;

            //Executa transferencia tirando da conta principal e depositando na conta destino
            this.Sacar(valor);
            bool tOK = destino.Depositar(valor);
            if (tOK)// se transferencia ocorreu com sucesso retorna true
                return true;
            else// caso ocorrer erro faz a reversão voltando dinheiro para conta principal
            {
                this.Depositar(valor);
                return false;
            }
        }
    }
}
