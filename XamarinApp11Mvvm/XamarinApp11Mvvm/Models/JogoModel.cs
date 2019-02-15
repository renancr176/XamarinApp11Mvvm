using System.Collections.Generic;
using System.Linq;
using XamarinApp11Mvvm.Enums;

namespace XamarinApp11Mvvm.Models
{
    public class JogoModel
    {
        public List<GrupoModel> Grupos { get; set; }
        public NivelEnum Nivel { get; set; }
        public short TempoPalavra { get; set; }
        public short Rodadas { get; set; }

        public JogoModel()
        {
            Grupos = new List<GrupoModel>();
            Grupos.Add(new GrupoModel(1, null, 0));
            Grupos.Add(new GrupoModel(2, null, 0));
            Nivel = NivelEnum.Aleatorio;
            TempoPalavra = 120;
            Rodadas = 8;
        }

        public JogoModel(List<GrupoModel> grupos, NivelEnum nivel, short tempoPalavra, short rodadas)
        {
            Grupos = grupos;
            Nivel = nivel;
            TempoPalavra = tempoPalavra;
            Rodadas = rodadas;
        }

        public GrupoModel GetGrupo(int numeroGrupo)
        {
            return Grupos.FirstOrDefault(g => g.Id == numeroGrupo);
        }
    }
}
