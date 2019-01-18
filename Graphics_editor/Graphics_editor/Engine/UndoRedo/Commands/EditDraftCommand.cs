﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Shapes;
using System.Windows.Forms;

namespace GraphicsEditor.Engine.UndoRedo.Commands
{
    /// <summary>
    /// Команда изменения фигуры 
    /// </summary>
    [Serializable]
    public class EditDraftCommand : ICommand
    {
        /// <summary>
        /// Изменяемая фигура
        /// </summary>
        private IDrawable _editedDraft;
        /// <summary>
        /// Бэкап фигуры
        /// </summary>
        private IDrawable _backUpDraft;
        /// <summary>
        /// Список новых точек
        /// </summary>
        private List<Point> _pointList;
        /// <summary>
        /// Новые настройки пера
        /// </summary>
        private PenSettings _penSettings;
        /// <summary>
        /// Новый цвет заливки
        /// </summary>
        private Color _brush;

        /// <summary>
        /// Выполнить команду
        /// </summary>
        public void Do()
        {
            if (_editedDraft is Polygon)
            {
                (_editedDraft as Polygon).DotList = _pointList;
                (_editedDraft as IBrushable).BrushColor = _brush;
                _editedDraft.Pen = _penSettings;
            }
            else if (_editedDraft is Polyline)
            {
                (_editedDraft as Polyline).DotList = _pointList;
                _editedDraft.Pen = _penSettings;
            }
            else
            {
                _editedDraft.StartPoint = _pointList[0];
                _editedDraft.EndPoint = _pointList.Last();
                if(_editedDraft is IBrushable)
                    (_editedDraft as IBrushable).BrushColor = _brush;
                _editedDraft.Pen = _penSettings;
            }
        }

        /// <summary>
        /// Откатить команду
        /// </summary>
        public void Undo()
        {          
            if (_editedDraft is Polygon)
            {
                (_editedDraft as Polygon).DotList = (_backUpDraft as Polygon).DotList;
                (_editedDraft as IBrushable).BrushColor = (_backUpDraft as IBrushable).BrushColor;
                _editedDraft.Pen = _backUpDraft.Pen;
            }
            if (_editedDraft is Polyline)
            {
                (_editedDraft as Polyline).DotList = (_backUpDraft as Polyline).DotList;
                _editedDraft.Pen = _backUpDraft.Pen;
            }
            else
            {
                _editedDraft.StartPoint = _backUpDraft.StartPoint;
                _editedDraft.EndPoint = _backUpDraft.EndPoint;
                if(_editedDraft is IBrushable)
                    (_editedDraft as IBrushable).BrushColor = (_backUpDraft as IBrushable).BrushColor;
                _editedDraft.Pen = _backUpDraft.Pen;
            }
        }

        /// <summary>
        /// Конструктор команды
        /// </summary>
        /// <param name="draft">Изменяемая фигура</param>
        /// <param name="pointList">Список новых точек</param>
        /// <param name="pen">Новые настройки пера</param>
        /// <param name="brush">Новый цвет заливки</param>
        public EditDraftCommand(IDrawable draft, List<Point> pointList, PenSettings pen, Color brush)
        {
            _editedDraft = draft;
            _backUpDraft = DraftFactory.Clone(draft);
            _pointList = pointList;
            _penSettings = pen;
            if (brush != null)
                _brush = brush;
        }
    }
}
