using Avaliacao.Models;

public class FolhaPagamento
{
    public FolhaPagamento(double valor, int quantidade)
    {
        Quantidade = quantidade;
        Valor = valor;
        CalcularSalarioBruto(); 
        CalcularImpostoDeRenda();
    }
    
    public int FolhaPagamentoId { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }

    public double IRRF { get; set; }
    
    public Funcionario? Funcionario { get; set; }
    

    public int FuncionarioId { get; set; }

    public double SalarioBruto { get; set; }

    public void CalcularSalarioBruto() => SalarioBruto = Valor * Quantidade;

     public void CalcularImpostoDeRenda()
    {
        if (SalarioBruto <= 1903.99)
            IRRF = 0;
        else if (SalarioBruto <= 2826.65)
            IRRF = (SalarioBruto * 0.075) - 142.80;
        else if (SalarioBruto <= 3751.05)
            IRRF = (SalarioBruto * 0.15) - 354.80;
        else if (SalarioBruto <= 4664.68)
            IRRF = (SalarioBruto * 0.225) - 636.13;
        else
            IRRF = (SalarioBruto * 0.275) - 869.36;
    }

}