using System.Drawing;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor.Tests.Stubs
{
    public class BrushableTwoPointStub : IDrawable, IBrushable
    {
        public Color BrushColor { get; set; }
        public IPenSettings Pen { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}