namespace Poker12.Core.Jugadas;

public class EscaleraColor : IJugada
{
    public string Nombre => "Escalera de color";
    public byte Prioridad => 2;
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count == 0)
        {
            throw new ArgumentException("No hay cartas");
        }

        bool sonCorazones = cartas.All(x => x.Palo == EPalo.Corazon);
        bool sonDiamantes = cartas.All(x => x.Palo == EPalo.Diamante);
        bool sonPicas = cartas.All(x => x.Palo == EPalo.Picas);
        bool sonTreboles = cartas.All(x => x.Palo == EPalo.Trebol);

        if (cartas.Count < 5)
        {
            throw new ArgumentException("No se puede realizar esta jugada");
        }

        if (sonCorazones || sonDiamantes || sonPicas || sonTreboles)
        {
            List<byte> cartasByte = new List<byte>();
            List<byte> valoresByte = new List<byte>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            var ordenadasPorValor = cartas.OrderBy(x => x.Valor);

            foreach (var item in ordenadasPorValor)
            {
                cartasByte.Add((byte)item.Valor);
            }

            var recortarValoresByte = Slice(valoresByte, cartasByte[1], cartasByte.Last());

            if (recortarValoresByte.Count < 5 && cartasByte.Contains(1))
            {
                var valor = ordenadasPorValor.First().Valor == EValor.As ? (byte)14 : (byte)0;

                return new Resultado(Prioridad, valor);
            }
            else if (recortarValoresByte.Count < 5)
            {
                var valor = ordenadasPorValor.First().Valor == EValor.As ? (byte)14 :
                            (byte)ordenadasPorValor.Last().Valor;

                return new Resultado(Prioridad, valor);
            }
        }

        return new Resultado(Prioridad, (byte)0);
    }

    private List<byte> Slice(List<byte> lista, byte begin, byte end)
    {
        List<byte> list = new List<byte>();
        foreach (var item in lista)
        {
            if (item >= begin && item <= end)
            {
                list.Add(item);
            }
        }

        return list;
    }
}
