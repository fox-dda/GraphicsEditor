using System.Drawing;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor.Tests.Stubs
{
    public class TwoPointStub : IDrawable
    {
        public IPenSettings Pen { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}