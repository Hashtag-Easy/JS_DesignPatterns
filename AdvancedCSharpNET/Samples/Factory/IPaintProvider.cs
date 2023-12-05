using System.Drawing;

namespace DesignPatterns.Samples.WithDI
{
    public interface IPaintProvider
    {
        Color GetColor();
    }

    class MattPaint : IPaintProvider
    {
        public Color GetColor()
        {
            return Color.Azure;
        }
    }
}