using Poker12.Core.Jugadas;

namespace Poker12.Core.Test.Jugadas;

public class EscaleraRealTest
{
    private IJugada _escaleraReal;
    public EscaleraRealTest() => _escaleraReal = new EscaleraReal();

    [Fact]
    public void FallaPorJugadaSinCartas()
    {
        var jugada = new List<Carta>();

        Assert.Throws<ArgumentException>(() => _escaleraReal.Aplicar(jugada));
    }

    [Fact]
    public void PruebaEscaleraReal()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Trebol, EValor.As),
            new(EPalo.Trebol, EValor.Diez),
            new(EPalo.Trebol, EValor.J),
            new(EPalo.Trebol, EValor.Q),
            new(EPalo.Trebol, EValor.K)
        };

        var resultado = _escaleraReal.Aplicar(jugada);

        Assert.Equal(14, resultado.Valor);
    }
}
