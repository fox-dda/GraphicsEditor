﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor.Model
{
    /// <summary>
    /// Эллипс
    /// </summary>
    [Serializable]
    class Ellipse : IDrawable, IBrushable
    {
        /// <summary>
        /// Цвет заливки
        /// </summary>
        public Color BrushColor
        {
            get
            {
                return _brush;
            }
            set
            {
                _brush = value;
            }
        }

        /// <summary>
        /// Точка старта
        /// </summary>
        private Point _startPoint;

        /// <summary>
        /// Точка конца
        /// </summary>
        private Point _endPoint;

        /// <summary>
        /// Настройки пера
        /// </summary>
        private PenSettings _pen;

        /// <summary>
        /// Цвет заливки
        /// </summary>
        protected  Color _brush;

        /// <summary>
        /// Точка старта
        /// </summary>
        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
            set
            {
                _startPoint = value;
            }
        }

        /// <summary>
        /// Точка конца
        /// </summary>
        public Point EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                _endPoint = value;
            }
        }

        /// <summary>
        /// Настройки пера
        /// </summary>
        public PenSettings Pen
        {
            get
            {
                return _pen;
            }
            set
            {
                _pen = value;
            }
        }

        /// <summary>
        /// Конструктор эллипса
        /// </summary>
        /// <param name="_startPoint">Точка старта</param>
        /// <param name="_endPoint">Точка конца</param>
        /// <param name="_pen">Настройки пера</param>
        public Ellipse(Point _startPoint, Point _endPoint, PenSettings _pen)
        {
            StartPoint = _startPoint;
            EndPoint = _endPoint;
            Pen = _pen;
        }
    }
}
