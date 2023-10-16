using Microsoft.AspNetCore.Mvc; 
using Avaliacao.Models;
using Avaliacao.Data;


[Route("api/funcionario")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly AppDataContext _ctx;

    public FuncionarioController(AppDataContext ctx) =>
        _ctx = ctx;

    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        var funcionarios = _ctx.Funcionarios.ToList();
        return Ok(funcionarios);
    }

    [HttpPost]
    [Route("cadastrar")]
    public  IActionResult Cadastrar([FromBody] Funcionario funcionario)
    {
        
        {
            // Valide o funcionário, execute outras lógicas se necessário e salve no banco de dados
            _ctx.Funcionarios.Add(funcionario);
            _ctx.SaveChanges();

            return Created("", funcionario);
        }
      
    }
}
