﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SDK;
using SDK.Interfaces;

namespace PolygonPlugin
{
    /// <summary>
    ///     Полигон
    /// </summary>
    [Serializable]
    public class Polygon : IDrawable, IBrushable, IMultipoint, INamed, ICloneable
    {
        /// <summary>
        ///     Цвет заливки
        /// </summary>
        private Color _brush;

        /// <summary>
        ///     Список точек
        /// </summary>
        private List<Point> _dotList = new List<Point>();

        /// <summary>
        ///     Настройки пера
        /// </summary>
        private IPenSettings _pen;

        /// <summary>
        ///     Конструктор полигона
        /// </summary>
        /// <param name="dotlist">Список точек</param>
        /// <param name="pen">Настройки пера</param>
        private Polygon(List<Point> dotlist, PenSettings pen)
        {
            Pen = pen;
            DotList = dotlist;
        }

        public Polygon()
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
            var cloneList = new List<Point>();
            foreach (var point in DotList) cloneList.Add(new Point(point.X, point.Y));

            return new Polygon(
                    cloneList,
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
            get => DotList[0];
            set => DotList[0] = value;
        }

        /// <summary>
        ///     Точка конца
        /// </summary>
        public Point EndPoint
        {
            get => DotList.Last();
            set => DotList[DotList.Count - 1] = value;
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
        ///     Список точек
        /// </summary>
        public List<Point> DotList
        {
            get => _dotList;
            set
            {
                if (value.Count > 2) _dotList = value;
            }
        }

        /// <summary>
        ///     Вернуть имя
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return "Polygon";
        }
    }
}