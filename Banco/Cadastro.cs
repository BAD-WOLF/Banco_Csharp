using System;

namespace Banco
{
  internal class Cadastro
  {
    internal string NomeTitular;
    internal float CurrentValue;
    private int _numero_conta;
    private bool _has_number_count = false;
    private bool _v_f = false;

    internal int NumeroConta
    {
      get
      {
        return _numero_conta;
      }
      set
      {
        if (value != _numero_conta)
        {
          this._numero_conta = value;
        }
      }
    }

    internal bool HasNumberCount
    {
      get
      {
        return this._has_number_count;
      }
      set
      {
        if (value)
        {
          this._has_number_count = value;
        }
      }
    }

    internal bool V_F
    {
      get
      {
        return this._v_f;
      }
      set
      {
        if (value)
        {
          this._v_f = value;
        }
      }
    }

    // criar conta sem dinheiro
    internal Cadastro(string nome_titular)
    {
      this.sneppet();
      this.NomeTitular = nome_titular;
    }

    // criar conta com dinheiro
    internal Cadastro(string nome_titular, float current_value) : this(nome_titular)
    {
      this.CurrentValue = current_value;
      this.V_F = true;
    }

    internal void sneppet()
    {
      this.NumeroConta = new Random().Next(999, 9999);
    }

  }
}

