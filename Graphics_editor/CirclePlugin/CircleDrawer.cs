﻿using System;
using System.Drawing;
using SDK;

namespace CirclePlugin
{
    /// <summary>
    ///     Отрисовщик кругов
    /// </summary>
    public class CircleDrawer : BaseDrawer
    {
        /// <summary>
        ///     Отрисовать круг
        /// </summary>
        /// <param name="shape">Круг</param>
        /// <param name="graphics">Ядро отрисовки</param>
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            var circle = shape as Circle;
            var startPoint = circle.StartPoint;
            var endPoint = circle.EndPoint;
            var brush = (circle as IBrushable).BrushColor;
            var pen = ConvertPen(circle.Pen);
            var size = Math.Abs(endPoint.X - startPoint.X) >
                       Math.Abs(endPoint.Y - startPoint.Y)
                ? Math.Abs(endPoint.X - startPoint.X)
                : Math.Abs(endPoint.Y - startPoint.Y);

            //сверху вниз справа налево
            if (startPoint.Y < endPoint.Y && startPoint.X > endPoint.X)
                startPoint = new Point(startPoint.X - size, startPoint.Y);
            //cнизу вверх слево на права
            else if (startPoint.Y > endPoint.Y && startPoint.X < endPoint.X)
                startPoint = new Point(startPoint.X, startPoint.Y - size);
            //cнизу вверх справа налево
            else if (startPoint.Y > endPoint.Y && startPoint.X > endPoint.X)
                startPoint = new Point(startPoint.X - size, startPoint.Y - size);

            graphics.FillEllipse(
                new SolidBrush(brush),
                startPoint.X, startPoint.Y,
                size,
                size);

            graphics.DrawEllipse(pen, startPoint.X, startPoint.Y, size, size);
        }
    }
}