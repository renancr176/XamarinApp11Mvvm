using System;
using XamarinApp11Mvvm.Enums;

namespace XamarinApp11Mvvm.Models
{
    public class PalavraModel
    {
        public Guid Id { get; set; }
        public string Palavra { get; set; }
        public string Significado { get; set; }
        public NivelEnum NivelDificuldade { get; set; }

        public PalavraModel(Guid id, string palavra, string significado, NivelEnum nivelDificuldade)
        {
            Id = id;
            Palavra = palavra;
            Significado = significado;
            NivelDificuldade = nivelDificuldade;
        }

        public PalavraModel(string palavra, string significado, NivelEnum nivelDificuldade)
        {
            Id = Guid.NewGuid();
            Palavra = palavra;
            Significado = significado;
            NivelDificuldade = nivelDificuldade;
        }
    }
}
