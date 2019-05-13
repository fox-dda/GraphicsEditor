﻿using System.Collections.Generic;
using System.Drawing;
using StructureMap;
using SDK;

namespace GraphicsEditor.Model.Drawers
{
    /// <summary>
    /// Фасад отрисовщиков
    /// </summary>
    public class DrawerFacade
    {
        /// <summary>
        /// Словарь отрисовщиков фигур
        /// </summary>
        private readonly Dictionary<string, BaseDrawer> _drawerDictionary 
            = new Dictionary<string, BaseDrawer>();

        /// <summary>
        /// Отрисовщик выделения. Является системным типом, не загружается как плагин.
        /// </summary>
        private readonly HighlightDrawer _highlightDrawer = new HighlightDrawer();

        /// <summary>
        /// Конструктор фасада отрисовщиков
        /// </summary>
        public DrawerFacade()
        {
            var container = new Container(_ =>
            {
                _.Scan(o =>
                {
                    o.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    o.AddAllTypesOf<BaseDrawer>().NameBy(x => x.Name);
                });
            });

            var instances = container.GetAllInstances<BaseDrawer>();
            foreach (var drawerInstance in instances)
            {
                var name = drawerInstance.GetType().Name.ToString();
                _drawerDictionary.Add(name.Substring(0, name.Length - 6),
                    container.GetInstance<BaseDrawer>(name));
            }
        }

        /// <summary>
        /// Отрисовать фигуру
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <param name="graphics">Ядро отрисовки</param>
        public void DrawShape(IDrawable shape, Graphics graphics)
        {
            if (shape == null)
                return;

            _drawerDictionary[(shape as INamed).GetName()]?.DrawShape(shape, graphics);
        }

        /// <summary>
        /// Отрисовать выделение
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <param name="graphics">Ядро отрисовки</param>
        public void DrawHighlight(IDrawable shape, Graphics graphics)
        {
            _highlightDrawer.DrawShape(shape, graphics);
        }
    }
}