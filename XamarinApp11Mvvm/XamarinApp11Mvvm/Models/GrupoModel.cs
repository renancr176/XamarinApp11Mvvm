namespace XamarinApp11Mvvm.Models
{
    public class GrupoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public short Pontuacao { get; set; }

        public GrupoModel(int id, string nome, short pontuacao)
        {
            Id = id;
            Nome = nome;
            Pontuacao = pontuacao;
        }
    }
}
