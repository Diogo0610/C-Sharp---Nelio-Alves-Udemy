using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastramento_de_conta___Aula_60
{
    class ContaBancaria
{ 
        public int Numero { get; private set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
            Saldo = 0.0;
        }

        public ContaBancaria(int numero, string titular, double saldo) : this(numero, titular)
        {
            Depositar(saldo);
        }

        public override string ToString()
        {
            return "Conta " + Numero + ", Titular: " + Titular + ", Saldo: $ " + Saldo.ToString("F2");
        }

        public void Depositar(double quantiaDep)
        {
            Saldo += quantiaDep;
        }
        public void Sacar(double quantiaSaq)
        {
            Saldo -= quantiaSaq + 5;
        }

    }
}
