using System.Collections.Generic;
using System.Linq;
using api.Models;
using API_Copa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/jogo")]
    public class JogoController : ControllerBase
    {
        private readonly Context _context;
        public JogoController(Context context) =>
            _context = context;

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Jogo jogo)
        {
            jogo.SelecaoA = _context.Selecoes.Find(jogo.SelecaoA.Id);
            jogo.SelecaoB = _context.Selecoes.Find(jogo.SelecaoB.Id);
            _context.Jogos.Add(jogo);
            _context.SaveChanges();
            return Created("", jogo);
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            var jogos = _context.Jogos.ToList();

            foreach(Jogo jogo in jogos)
            {
                jogo.SelecaoA = _context.Selecoes.Find(jogo.SelecaoAId);
                jogo.SelecaoB = _context.Selecoes.Find(jogo.SelecaoBId);
            }

            return jogos.Count != 0 ? Ok(jogos) : NotFound();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            var jogo = _context.Jogos.Find(id);
            jogo.SelecaoA = _context.Selecoes.Find(jogo.SelecaoAId);
            jogo.SelecaoB = _context.Selecoes.Find(jogo.SelecaoBId);

            return Ok(jogo);
        }

        [HttpPatch]
        [Route("alterar")]
        public IActionResult Buscar([FromBody] Jogo jogoUpdate)
        {
            _context.Jogos.Update(jogoUpdate);
            _context.SaveChanges();
            return Ok(jogoUpdate);
        }
    }
}