using System.Collections.Generic;
using XamarinApp11Mvvm.Enums;

namespace XamarinApp11Mvvm.Models
{
    public class JogoModel
    {
        public List<GrupoModel> Grupos { get; set; }
        public NivelEnum Nivel { get; set; }
        public short TempoPalavra { get; set; }
        public short Rodadas { get; set; }

        public JogoModel(List<GrupoModel> grupos, NivelEnum nivel, short tempoPalavra, short rodadas)
        {
            Grupos = grupos;
            Nivel = nivel;
            TempoPalavra = tempoPalavra;
            Rodadas = rodadas;
        }
    }
}
