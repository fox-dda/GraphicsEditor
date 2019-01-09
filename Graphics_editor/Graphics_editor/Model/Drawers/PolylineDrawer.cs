﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
    class PolylineDrawer: BaseDrawer
    {
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            var dotList = (shape as Polyline).DotList;
            var pen = shape.Pen;

            for (int i = 0; i < dotList.Count - 1; i++)
                graphics.DrawLine(pen, dotList[i].X, dotList[i].Y, dotList[i + 1].X, dotList[i + 1].Y);
        }
    }
}