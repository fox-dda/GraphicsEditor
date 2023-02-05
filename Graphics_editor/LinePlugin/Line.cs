using System;
using System.Drawing;
using SDK;
using SDK.Interfaces;

namespace LinePlugin
{
    /// <summary>
    ///     Линия
    /// </summary>
    [Serializable]
    public class Line : IDrawable, INamed, ICloneable
    {
        /// <summary>
        ///     Точка конца
        /// </summary>
        private Point _endPoint;

        /// <summary>
        ///     Настройки пера
        /// </summary>
        private PenSettings _pen;

        /// <summary>
        ///     Точка старта
        /// </summary>
        private Point _startPoint;

        /// <summary>
        ///     Конструктор линии
        /// </summary>
        /// <param name="startPoint">Точка старта</param>
        /// <param name="endPoint">Точка конца</param>
        /// <param name="pen">Настройки пера</param>
        private Line(Point startPoint, Point endPoint, PenSettings pen)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Pen = pen;
        }

        public Line()
        {
        }

        /// <summary>
        ///     Клонировать
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Line(
                new Point(StartPoint.X, StartPoint.Y),
                new Point(EndPoint.X, EndPoint.Y),
                new PenSettings(Pen.Color, Pen.Width)
                {
                    DashPattern = Pen.DashPattern
                });
        }

        /// <summary>
        ///     Точка начала
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
            set => _pen = (PenSettings)value;
        }

        /// <summary>
        ///     Вернуть имя
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return "Line";
        }
    }
}