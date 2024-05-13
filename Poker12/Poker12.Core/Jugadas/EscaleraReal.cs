
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
        bool escaleraReal = cartas.All(x => x.Palo == EPalo.Corazon || 
                                            x.Palo == EPalo.Diamante || 
                                            x.Palo == EPalo.Picas || 
                                            x.Palo == EPalo.Trebol);

        if (escaleraReal)
        {  
            cartas.OrderBy(x => x.Valor);
            bool escaleraRealValor = cartas.All(x => x.Valor == EValor.Diez && 
                                                    x.Valor == EValor.J && 
                                                    x.Valor == EValor.Q && 
                                                    x.Valor == EValor.K && 
                                                    x.Valor == EValor.As);
        }
    }
}
