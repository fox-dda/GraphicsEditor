using System;
using System.Drawing;
using SDK;
using SDK.Interfaces;

namespace CirclePlugin
{
    /// <summary>
    ///     Эллипс
    /// </summary>
    [Serializable]
    public class Circle : IDrawable, IBrushable, INamed, ICloneable
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
        private Circle(Point startPoint, Point endPoint, PenSettings pen)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Pen = pen;
        }

        public Circle()
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
            return new Circle(
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
        ///     Верныть имя
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return "Circle";
        }
    }
}