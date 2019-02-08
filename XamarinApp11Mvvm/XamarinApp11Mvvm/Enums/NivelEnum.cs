namespace XamarinApp11Mvvm.Enums
{
    public class NivelEnum : BaseNivelEnum
    {
        public static NivelEnum Aleatorio = new AleatorioVal();
        public static NivelEnum Facil = new FacilVal();
        public static NivelEnum Medio = new MedioVal();
        public static NivelEnum Dificil = new DificilVal();

        public NivelEnum(int id, string descricao)
            : base(id, descricao)
        { }

        private class AleatorioVal : NivelEnum
        {
            public AleatorioVal()
                : base(1, "Aleatório")
            { }
        }

        private class FacilVal : NivelEnum
        {
            public FacilVal()
                : base(2, "Fácil")
            { }
        }

        private class MedioVal : NivelEnum
        {
            public MedioVal()
                : base(3, "Médio")
            { }
        }

        private class DificilVal : NivelEnum
        {
            public DificilVal()
                : base(4, "Difícil")
            { }
        }
    }
}
