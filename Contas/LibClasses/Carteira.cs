﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contas.LibClasses
{
    public class Carteira
    {
        public double Saldo
        {
            get;
            private set;
        }
        public string Dono { get; set; }

        
        public double LimiteConta  // adiciona o limite na conta
        {

            get;
            set;
        }
       
        public DateTime Tarifa // adicionaa tarifa
        {
            get;
            set;
        }
        
        public bool cobrarTarifa(DateTime dataTarifa)
        {
            this.Saldo -= 19.90;
            this.Tarifa = dataTarifa;
            return true;
        }
        public string Cpf// adiciona cpf
        {
            get;
            set;
        }
        
        public bool Sacar(double Valor, DateTime dataSistema) //limita o horario para sacar
        {

            if (!(dataSistema.Hour >= 8 && dataSistema.Hour < 18))
                return false;


            if (Valor > (this.Saldo + LimiteConta ))
                return false;

            this.Saldo -= Valor;
            //this.Saldo = Saldo - Valor;
            return true;
        }

        public bool Sacar(double Valor)
		{


			if (Valor > this.Saldo )
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
