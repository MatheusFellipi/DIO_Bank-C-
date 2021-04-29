using System;

namespace bank
{
  public class Conta
  {
    private TipoConta tipoConta { get; set; }
    private double Saldo { get; set; }
    private double Credito { get; set; }
    private string Nome { get; set; }

    public Conta(TipoConta TipoConta, double saldo, double credito, string nome)
    {
      this.tipoConta = tipoConta;
      this.Saldo = saldo; 
      this.Credito = credito;
      this.Nome = nome;

    }

    public bool Sacar(double valorSaque)
    {
      if (this.Saldo - valorSaque < (this.Credito * -1))
      {
        Console.WriteLine("Saldo insuficiente!");
        return false;
      }
      this.Saldo -= valorSaque;
      Console.WriteLine("Saldo atual da conta de {0} e {1}", this.Nome, this.Saldo);

      return true;

    }
    public void Depositar(double valorDeposito)
    {
      this.Saldo += valorDeposito;
      Console.WriteLine("Saldo atual da conta de {0} e {1}", this.Nome, this.Saldo);
    }
    public void Transferir(double valorTranferencia, Conta contaDestino)
    {
      if (this.Sacar(valorTranferencia))
      {
        this.Depositar(valorTranferencia);
      }
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "TipoConta " + this.tipoConta + " | ";
      retorno += "Nome " + this.Nome + " | ";
      retorno += "Saldo " + this.Saldo + " | ";
      retorno += "Crédito " + this.Credito + " | ";

      return retorno;
    }

  }

}