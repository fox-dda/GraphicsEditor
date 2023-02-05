using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor.Core.UndoRedo.Commands
{
    /// <summary>
    ///     Команда изменения фигуры
    /// </summary>
    [Serializable]
    public class EditDraftCommand : ICommand
    {
        /// <summary>
        ///     Бэкап фигуры
        /// </summary>
        private IDrawable _backUpDraft;

        /// <summary>
        ///     Новый цвет заливки
        /// </summary>
        private Color _brush;

        /// <summary>
        ///     Изменяемая фигура
        /// </summary>
        private IDrawable _editedDraft;

        /// <summary>
        ///     Новые настройки пера
        /// </summary>
        private IPenSettings _penSettings;

        /// <summary>
        ///     Список новых точек
        /// </summary>
        private List<Point> _pointList;

        /// <summary>
        ///     Конструктор команды
        /// </summary>
        /// <param name="draft">Изменяемая фигура</param>
        /// <param name="pointList">Список новых точек</param>
        /// <param name="pen">Новые настройки пера</param>
        /// <param name="brush">Новый цвет заливки</param>
        public EditDraftCommand(IDrawable draft, List<Point> pointList, IPenSettings pen, Color brush,
            IDraftFactory factory)
        {
            _editedDraft = draft;
            _backUpDraft = factory.Clone(draft);
            _pointList = pointList;
            _penSettings = pen;
            _brush = brush;
        }

        /// <summary>
        ///     Выполнить команду
        /// </summary>
        public void Do()
        {
            if (_editedDraft is IMultipoint multipoint)
            {
                multipoint.DotList = _pointList;
            }
            else
            {
                _editedDraft.StartPoint = _pointList[0];
                _editedDraft.EndPoint = _pointList.Last();
            }

            if (_editedDraft is IBrushable brushable) brushable.BrushColor = _brush;
            _editedDraft.Pen = _penSettings;
        }

        /// <summary>
        ///     Откатить команду
        /// </summary>
        public void Undo()
        {
            if (_editedDraft is IMultipoint multipoint)
            {
                multipoint.DotList = (_backUpDraft as IMultipoint)?.DotList;
            }
            else
            {
                _editedDraft.StartPoint = _backUpDraft.StartPoint;
                _editedDraft.EndPoint = _backUpDraft.EndPoint;
            }

            if (_editedDraft is IBrushable brushable) brushable.BrushColor = ((IBrushable)_backUpDraft).BrushColor;

            _editedDraft.Pen = _backUpDraft.Pen;
        }
    }
}