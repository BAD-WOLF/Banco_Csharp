using System;

namespace Banco
{
  internal class Cadastro
  {
    internal string NomeTitular;
    internal float CurrentValue;
    private int _numeroConta;
    private bool _hasNumberCount;
    private bool _vF;

    internal int NumeroConta
    {
      get
      {
        return _numeroConta;
      }
      set
      {
        if (value != _numeroConta)
        {
          this._numeroConta = value;
        }
      }
    }

    internal bool HasNumberCount
    {
      get
      {
        return this._hasNumberCount;
      }
      set
      {
        if (value)
        {
          this._hasNumberCount = true;
        }
      }
    }

    internal bool VF
    {
      get
      {
        return this._vF;
      }
      set
      {
        if (value)
        {
          this._vF = true;
        }
      }
    }

    // criar conta sem dinheiro
    internal Cadastro(string nomeTitular)
    {
      this.Sneppet();
      this.NomeTitular = nomeTitular;
    }

    // criar conta com dinheiro
    internal Cadastro(string nomeTitular, float currentValue) : this(nomeTitular)
    {
      this.CurrentValue = currentValue;
      this.VF = true;
    }

    internal void Sneppet()
    {
      this.NumeroConta = new Random().Next(999, 9999);
    }

  }
}

