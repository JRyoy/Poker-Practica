using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Poker12.Core.Jugadas;

public class EscaleraColor : IJugada
{
    public string Nombre => "Escalera de color";
    public byte Prioridad => 2;
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count < 5)
            throw new ArgumentException("No se puede realizar esta jugada");
        
        bool sonCorazones = cartas.All(x => x.Palo == EPalo.Corazon);
        bool sonDiamantes = cartas.All(x => x.Palo == EPalo.Diamante);
        bool sonPicas = cartas.All(x => x.Palo == EPalo.Picas);
        bool sonTreboles = cartas.All(x => x.Palo == EPalo.Trebol);

        if (sonCorazones || sonDiamantes || sonPicas || sonTreboles)
        {
            var mayor = EsEscalera(cartas);
            return new Resultado(Prioridad, mayor);
        }

        return new Resultado(Prioridad, (byte)0);
    }
    public byte EsEscalera(List<Carta> cartas)
    {
        var ordenadasPorValor = cartas.OrderBy(x => x.Valor);
        var inicio = (byte)ordenadasPorValor.First().Valor;
        var ultimo = (byte)ordenadasPorValor.Last().Valor;

        foreach (var item in ordenadasPorValor)
        {
            if ((byte)item.Valor != inicio)
            {
                return 0; // No es una escalera
            }
            inicio++;
        }
        return ultimo;
    }

}