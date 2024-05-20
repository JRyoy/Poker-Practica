
using System.Runtime.InteropServices;

namespace Poker12.Core.Jugadas;

public class EscaleraReal : IJugada
{
    public string Nombre => "Escalera Real";
    public byte Prioridad => 1;
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

        if (sonCorazones || sonDiamantes || sonPicas || sonTreboles && cartas.Count == 5)
        {
            var x=esEscalera(cartas);
            return new Resultado(Prioridad, x);
        }

        return new Resultado(Prioridad, (byte)0);
    }
    public byte esEscalera(List<Carta> cartas)
    {
         var ordenadasPorValor = cartas.OrderBy(x => x.Valor);
            int contador = 0;

            foreach (var carta in ordenadasPorValor)
            {
                if (carta.Valor == EValor.As ||
                    carta.Valor == EValor.Diez ||
                    carta.Valor == EValor.J ||
                    carta.Valor == EValor.Q ||
                    carta.Valor == EValor.K)
                {
                    contador++;
                }
            }

            var valor = contador == 5 ? (byte)14 : (byte)0;

            return  (byte)valor;
    }
}