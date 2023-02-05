using System.Drawing;
using SDK.Interfaces;

namespace GraphicsEditor.Tests.Stubs
{
    public class PenSettingsStub : IPenSettings
    {
        public float[] DashPattern { get; set; }
        public float Width { get; set; }
        public Color Color { get; set; }
    }
}