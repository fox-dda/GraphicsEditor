using System;
using System.Drawing;
using Moq;
using SDK;
using SDK.Interfaces;

namespace SDKTests.Stubs
{
    internal class CloneableDraftStub : IDrawable, ICloneable
    {
        public object Clone()
        {
            return new Mock<IDrawable>().Object;
        }

        public IPenSettings Pen { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}