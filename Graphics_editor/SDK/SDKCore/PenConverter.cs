﻿using System.Drawing;
using SDK.Interfaces;

namespace SDK
{
    public class PenConventer : IPenConverter
    {
        /// <summary>
        ///     Создать перо
        /// </summary>
        /// <param name="settings">Настройки пера</param>
        /// <returns>Перо</returns>
        public Pen ConvertToPen(IPenSettings settings)
        {
            return settings.DashPattern != null
                ? new Pen(settings.Color, settings.Width)
                {
                    DashPattern = settings.DashPattern
                }
                : new Pen(settings.Color, settings.Width);
        }
    }
}