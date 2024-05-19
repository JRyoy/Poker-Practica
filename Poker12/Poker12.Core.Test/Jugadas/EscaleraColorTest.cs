using Poker12.Core.Jugadas;

namespace Poker12.Core.Test.Jugadas;

public class EscaleraColorTest
{
    private IJugada _escaleraColor;
    public EscaleraColorTest() => _escaleraColor = new EscaleraColor();

    [Fact]
    public void FallaPorJugadaSinCartas()
    {
        var jugada = new List<Carta>();

        Assert.Throws<ArgumentException>(() => _escaleraColor.Aplicar(jugada));
    }


    public void PruebaEscaleraColorfalla()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Picas, EValor.Ocho),
            new(EPalo.Picas, EValor.Siete),
            new(EPalo.Picas, EValor.Cinco),
            new(EPalo.Picas, EValor.Diez),
            new(EPalo.Picas, EValor.As),
        };

        var resultado = _escaleraColor.Aplicar(jugada);

        Assert.Equal(0, resultado.Valor);
    }

}
