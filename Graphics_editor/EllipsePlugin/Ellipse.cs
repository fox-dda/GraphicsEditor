using System;
using System.Drawing;
using SDK;
using SDK.Interfaces;

namespace EllipsePlugin
{
    /// <summary>
    ///     Эллипс
    /// </summary>
    [Serializable]
    public class Ellipse : IDrawable, IBrushable, INamed, ICloneable
    {
        /// <summary>
        ///     Цвет заливки
        /// </summary>
        protected Color _brush;

        /// <summary>
        ///     Точка конца
        /// </summary>
        private Point _endPoint;

        /// <summary>
        ///     Настройки пера
        /// </summary>
        private IPenSettings _pen;

        /// <summary>
        ///     Точка старта
        /// </summary>
        private Point _startPoint;

        /// <summary>
        ///     Конструктор эллипса
        /// </summary>
        /// <param name="startPoint">Точка старта</param>
        /// <param name="endPoint">Точка конца</param>
        /// <param name="pen">Настройки пера</param>
        private Ellipse(Point startPoint, Point endPoint, PenSettings pen)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Pen = pen;
        }

        public Ellipse()
        {
        }

        /// <summary>
        ///     Цвет заливки
        /// </summary>
        public Color BrushColor
        {
            get => _brush;
            set => _brush = value;
        }

        /// <summary>
        ///     Клонировать
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Ellipse(
                    new Point(StartPoint.X, StartPoint.Y),
                    new Point(EndPoint.X, EndPoint.Y),
                    new PenSettings(Pen.Color, Pen.Width)
                    {
                        DashPattern = Pen.DashPattern
                    })
                { BrushColor = BrushColor };
        }

        /// <summary>
        ///     Точка старта
        /// </summary>
        public Point StartPoint
        {
            get => _startPoint;
            set => _startPoint = value;
        }

        /// <summary>
        ///     Точка конца
        /// </summary>
        public Point EndPoint
        {
            get => _endPoint;
            set => _endPoint = value;
        }

        /// <summary>
        ///     Настройки пера
        /// </summary>
        public IPenSettings Pen
        {
            get => _pen;
            set => _pen = value;
        }

        /// <summary>
        ///     Вернуть имя
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return "Ellipse";
        }
    }
}