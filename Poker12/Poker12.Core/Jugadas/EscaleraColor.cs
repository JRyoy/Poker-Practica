using System.ComponentModel.DataAnnotations;

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
            var ordenadasPorValor = cartas.OrderBy(x => x.Valor);
            var i = (byte)ordenadasPorValor.First().Valor;
            var valor = (byte)ordenadasPorValor.Last().Valor;
            

        }

        return new Resultado(Prioridad, (byte)0);
    }


}
