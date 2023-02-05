﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SDK.Interfaces;
using StructureMap;

namespace SDK.SDKCore
{
    /// <summary>
    ///     Фабрика фигур
    /// </summary>
    public class DraftFactory : IDraftFactory
    {
        /// <summary>
        ///     DI контейнер
        /// </summary>
        private readonly IContainer _container;

        public DraftFactory(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        ///     Создать фигуру
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="pointList">Список точек</param>
        /// <param name="gPen">Перо</param>
        /// <param name="brushColor">Цвет заливки</param>
        /// <returns>Созданная фигура</returns>
        public IDrawable CreateDraft(string figure, List<Point> pointList,
            IPenSettings gPen, Color brushColor)
        {
            if (figure == null)
            {
                var highlight = _container.TryGetInstance<IDrawable>();
                if (highlight == null) return null;
                highlight.StartPoint = pointList[0];
                highlight.EndPoint = pointList.Last();
                return highlight;
            }

            var draft = _container.GetInstance<IDrawable>(figure);

            draft.Pen = (PenSettings)gPen;
            if (draft is IBrushable brushableDraft) brushableDraft.BrushColor = brushColor;

            if (draft is IMultipoint multipointDraft)
            {
                multipointDraft.DotList = pointList;
            }
            else
            {
                draft.StartPoint = pointList[0];
                draft.EndPoint = pointList.Last();
            }

            return draft;
        }

        /// <summary>
        ///     Создать клон фигуры
        /// </summary>
        /// <param name="draft">Клонируемая фигура</param>
        /// <returns>Клон фигуры</returns>
        public IDrawable Clone(IDrawable draft)
        {
            return (IDrawable)(draft as ICloneable)?.Clone();
        }

        /// <summary>
        ///     Определить однородность фигур, в случае неоднородности вернуть null
        /// </summary>
        /// <param name="draftList">Список фигур</param>
        /// <returns>Тип однородных фигур</returns>
        public Type CheckUniformity(List<IDrawable> draftList)
        {
            if (draftList == null)
                return null;

            var type = draftList[0].GetType();

            return draftList.Any(draft => draft.GetType() != type) ? null : type;
        }
    }
}