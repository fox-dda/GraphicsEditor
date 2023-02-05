using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor.Tests
{
    public class MultipointStub : IMultipoint, IDrawable
    {
        public IPenSettings Pen { get; set; }

        public Point StartPoint
        {
            get => DotList[0];
            set { }
        }

        public Point EndPoint
        {
            get => DotList.Last();
            set { }
        }

        public List<Point> DotList { get; set; }
    }
}