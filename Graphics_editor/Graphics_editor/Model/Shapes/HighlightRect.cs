﻿using System.Drawing;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor.Model
{
    /// <summary>
    ///     Рамка выделения
    /// </summary>
    public class HighlightRect : IDrawable, INamed
    {
        /// <summary>
        ///     Точка конца
        /// </summary>
        private Point _endPoint;

        /// <summary>
        ///     Точка старта
        /// </summary>
        private Point _startPoint;

        /// <summary>
        ///     Консткуктор прямоугольника выделения
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        private HighlightRect(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        /// <summary>
        ///     Конструктор по молчанию
        /// </summary>
        public HighlightRect()
        {
        }

        /// <summary>
        ///     Настройки пера
        /// </summary>
        public IPenSettings Pen
        {
            get
            {
                return new PenSettings(Color.Gray, 1)
                {
                    DashPattern = new float[] { 2, 2 }
                };
            }
            set { }
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

        public string GetName()
        {
            return "HighlightRect";
        }
    }
}