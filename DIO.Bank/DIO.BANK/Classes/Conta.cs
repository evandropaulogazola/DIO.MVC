using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.BANK
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }//limite da conta
        private TipoConta Tipoconta { get; set; }

        public Conta(TipoConta tipoconta, double saldo, double credito, string nome)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Tipoconta = tipoconta;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da Conta de {0} é {1}",this.Nome, this.Saldo);
            return true;
        }

        public bool Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da Conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public bool Trasnferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.Tipoconta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito + " | ";
            return retorno;
        }

    }
}
