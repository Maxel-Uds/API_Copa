using System;

namespace API_Copa.Models
{
    public class Jogo
    {
        public Jogo()
        {
            SelecaoA = new Selecao();
            SelecaoB = new Selecao();
            CriadoEm = DateTime.Now;
            SelecaoBGol = 0;
            SelecaoAGol = 0;
        }
        
        public int Id { get; set; }
        public int SelecaoAId { get; set; }
        public Selecao SelecaoA { get; set; }
        public int SelecaoAGol { get; set; }
        public int SelecaoBId { get; set; }
        public Selecao SelecaoB { get; set; }
        public int SelecaoBGol { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
