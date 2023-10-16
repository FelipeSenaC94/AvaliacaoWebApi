using Microsoft.AspNetCore.Mvc;
using Avaliacao.Models; // Certifique-se de importar o namespace correto para sua classe de modelo
using Avaliacao.Data;
using Microsoft.EntityFrameworkCore; // Importe o namespace do contexto de banco de dados

[Route("api/folhapagamento")]
[ApiController]
public class FolhaPagamentoController : ControllerBase
{
    private readonly AppDataContext _ctx;

    public FolhaPagamentoController(AppDataContext ctx) =>
        _ctx = ctx;
    [HttpGet("listar")]
    public IActionResult Listar()
    {
        var folhasPagamento = _ctx.FolhaPagamentos.Include(fp => fp.Funcionario).ToList();

        if (!folhasPagamento.Any())
        {
            return NotFound("Nenhuma folha de pagamento encontrada.");
        }

        return Ok(folhasPagamento);
    }
    [HttpGet()]
    [Route("buscar/{cpf}/{mes}/{ano}")]
    public IActionResult GetFolhaPorCpfMesAno([FromRoute] string cpf, [FromRoute] int mes, [FromRoute] int ano)
    {
        FolhaPagamento? folhaPagamento = _ctx.FolhaPagamentos
            .Include(fp => fp.Funcionario)
            .FirstOrDefault(fp => fp.Funcionario.CPF == cpf && fp.Mes == mes && fp.Ano == ano);
        

        if (folhaPagamento == null)
        {
            return NotFound();
        }

        return Ok(folhaPagamento);
    }
    
    [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromBody] FolhaPagamento folhaPagamento)
    {
       
        Funcionario? funcionario = _ctx.Funcionarios.Find(folhaPagamento.FuncionarioId);
        if (funcionario == null)
        {
            return NotFound();
        }

      
        {
            folhaPagamento.Funcionario = funcionario;
            _ctx.FolhaPagamentos.Add(folhaPagamento);
            _ctx.SaveChanges();
            return Created("", folhaPagamento);
        }
    
    }
}

