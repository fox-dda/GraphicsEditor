﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SDK;
using SDK.Interfaces;

namespace PolylinePlugin
{
    /// <summary>
    ///     Полилиния
    /// </summary>
    [Serializable]
    public class Polyline : IDrawable, IMultipoint, INamed, ICloneable
    {
        /// <summary>
        ///     Список точек
        /// </summary>
        private List<Point> _dotList = new List<Point>();

        /// <summary>
        ///     Настройки пера
        /// </summary>
        private PenSettings _pen;

        /// <summary>
        ///     Конструктор полилинии
        /// </summary>
        /// <param name="dotlist">Список точек</param>
        /// <param name="pen">Настройки пера</param>
        private Polyline(List<Point> dotlist, PenSettings pen)
        {
            Pen = pen;
            DotList = dotlist;
        }

        public Polyline()
        {
        }

        /// <summary>
        ///     Клонировать
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var cloneList = new List<Point>();
            foreach (var point in DotList) cloneList.Add(new Point(point.X, point.Y));

            return new Polyline(
                cloneList,
                new PenSettings(Pen.Color, Pen.Width)
                {
                    DashPattern = Pen.DashPattern
                });
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
            set => _pen = (PenSettings)value;
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
            return "Polyline";
        }
    }
}