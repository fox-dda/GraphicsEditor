using System.Drawing;
using SDK.Interfaces;

namespace GraphicsEditor.Interfaces
{
    public interface IPenConverter
    {
        Pen ConvertToPen(IPenSettings settings);
    }
}