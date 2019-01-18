﻿using System.Collections.Generic;
using System.Drawing;
using GraphicsEditor.Model;
using GraphicsEditor.Model.Shapes;
using GraphicsEditor.Engine.UndoRedo;
using GraphicsEditor.Engine.UndoRedo.Commands;

namespace GraphicsEditor.DraftTools
{
    /// <summary>
    /// Менеджер хранилища
    /// </summary>
    public class StorageManager
    {
        /// <summary>
        /// Хранилище объектов
        /// </summary>
        private DraftStorage _storage;
        /// <summary>
        /// Стек команд
        /// </summary>
        private UndoRedoStack _undoRedoStack = new UndoRedoStack();

        /// <summary>
        /// Очистить стек комманд
        /// </summary>
        public void ClearCommandStack()
        {
            _undoRedoStack.Reset();
        }

        /// <summary>
        /// Вернуть ссылку на хранилище фигур, для дальнейшей актуализации ссылок в десериализованных командах 
        /// </summary>
        /// <returns>Хранилище фигур</returns>
        public List<IDrawable> GetStorageForRepairCommands()
        {
            return _storage.DraftList;
        }

        /// <summary>
        /// Выполнит комманду
        /// </summary>
        /// <param name="command">Команда, которую нужно выполнить</param>
        public void DoCommand(ICommand command)
        {
            _undoRedoStack.Do(command);
        }

        /// <summary>
        /// Вернуть стек выполненых команд
        /// </summary>
        /// <returns>Выполненные команды</returns>
        public UndoRedoStack GetUndoRedoStack()
        {
            return _undoRedoStack;
        }

        /// <summary>
        /// Повторить комманду (Шаг вперед)
        /// </summary>
        public void RedoCommand()
        {
            _undoRedoStack.Redo();
        }

        /// <summary>
        /// Отменить комманду (Шаг назад)
        /// </summary>
        public void UndoCommand()
        {
            _undoRedoStack.Undo();
        }
        
        /// <summary>
        /// Конструктор класса StorageManager
        /// </summary>
        /// <param name="storage">Хранилище фигур</param>
        public StorageManager(DraftStorage storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Вернуть все фигуры
        /// </summary>
        /// <returns></returns>
        public List<IDrawable> GetDrafts()
        {
            return _storage.DraftList;
        }

        /// <summary>
        /// Вернуть выделенные фигуры
        /// </summary>
        /// <returns></returns>
        public List<IDrawable> GetHighlights()
        {
            return _storage.HighlightDraftsList;
        }

        /// <summary>
        /// Добавить фигуру в хранилище
        /// </summary>
        /// <param name="draft">Добавляемая фигура</param>
        public void AddDraft(IDrawable draft)
        {
            _undoRedoStack.Do(CommandFactory.CreateAddDraftCommand(_storage.DraftList, draft));
        }

        /// <summary>
        /// Добавить несколько фигур в хранилище
        /// </summary>
        /// <param name="drafts">Добавляемые фигуры</param>
        public void AddRangeDrafts(List<IDrawable> drafts)
        {
            _undoRedoStack.Do(CommandFactory.CreateAddRangeDraftCommand(_storage.DraftList, drafts));
        }

        /// <summary>
        /// Добавить несклько фигур в список выделенных фигур
        /// </summary>
        /// <param name="drafts">Добавляемые фигуры</param>
        public void AddHighlightRangeDraft(List<IDrawable> drafts)
        {
            foreach (IDrawable draft in drafts)
            {
                if (GetHighlights().Contains(draft))
                    _storage.HighlightDraftsList.Remove(draft);
                else
                    _storage.HighlightDraftsList.Add(draft);
            }
        }

        /// <summary>
        /// Очистить хранилище фигур
        /// </summary>
        public void ClearStorage()
        {
            _undoRedoStack.Do(CommandFactory.CreateClearStorageCommand(_storage.DraftList));
            _storage.HighlightDraftsList.Clear();
        }

        /// <summary>
        /// Изменить выдиление фигуры
        /// </summary>
        /// <param name="draft"></param>
        public void AddHighlightDraft(IDrawable draft)
        {
            if (GetHighlights().Contains(draft))
                _storage.HighlightDraftsList.Remove(draft);
            else
                _storage.HighlightDraftsList.Add(draft);
        }

        /// <summary>
        /// Очистить список выделенных фигур
        /// </summary>
        public void DiscardAll()
        {
            _storage.HighlightDraftsList.Clear();
        }
        
        /// <summary>
        /// Добавить несколько фигур в список выделенных
        /// </summary>
        /// <param name="highlightRange"></param>
        public void HighlightingDraftRange(List<IDrawable> highlightRange)
        {
            _storage.HighlightDraftsList.AddRange(highlightRange);
        }

        /// <summary>
        /// Изменить фигуру
        /// </summary>
        /// <param name="draft">Изменяемая фигура</param>
        /// <param name="pointList">Новые точки</param>
        /// <param name="pen">Новое перо</param>
        /// <param name="brush">Новый цвет заливки</param>
        public void EditDraft(IDrawable draft, List<Point> pointList, PenSettings pen, Color brush)
        {
            _undoRedoStack.Do(CommandFactory.CreateEditDraftCommand(draft, pointList, pen, brush));
        }

        /// <summary>
        /// Удалить фигуру из хранилища
        /// </summary>
        /// <param name="draft">Удаляемая фигура</param>
        public void RemoveDraft(IDrawable draft)
        {
            if (GetHighlights().Contains(draft))
            {
                _storage.HighlightDraftsList.Remove(draft);
            }
            _undoRedoStack.Do(CommandFactory.CreateRemoveDraftCommand(_storage.DraftList, draft));
        }

        /// <summary>
        /// Удалить несколько фигур из хранилища
        /// </summary>
        /// <param name="drafts">Удаляемые фигуры</param>
        public void RemoveRangeDrafts(List<IDrawable> drafts)
        {
            foreach (IDrawable draft in drafts)
            {
                if (_storage.HighlightDraftsList.Contains(draft))
                {
                    _storage.HighlightDraftsList.Remove(draft);
                }
            }
            _undoRedoStack.Do(CommandFactory.CreateRemoveRangeDraftsCommand(_storage.DraftList, drafts));
        }

        /// <summary>
        /// Удалить выделенные фигуры из хранилища
        /// </summary>
        public void RemoveRangeHighligtDrafts()
        {
            _undoRedoStack.Do(CommandFactory.CreateRemoveRangeDraftsCommand(_storage.DraftList, _storage.HighlightDraftsList));
            _storage.HighlightDraftsList.Clear();
        }

        /// <summary>
        /// Получить точки из фигуры
        /// </summary>
        /// <param name="item">Фигура, из которой нужно вытащить точки</param>
        /// <returns>Точки фигуры</returns>
        public List<Point> PullPoints(IDrawable item)
        {
            List<Point> pullPointList = new List<Point>();
            if (item is Polygon)
            {
                foreach (Point pointInDraft in (item as Polygon).DotList)
                {
                    pullPointList.Add(pointInDraft);
                }
            }
            else if (item is Polyline)
            {
                foreach (Point pointInDraft in (item as Polyline).DotList)
                {
                    pullPointList.Add(pointInDraft);
                }
            }
            else
            {
                pullPointList.Add(item.StartPoint);
                pullPointList.Add(item.EndPoint);
            }

            return pullPointList;
        }

        /// <summary>
        /// Изменить цвет канвы
        /// </summary>
        /// <param name="paintingParameters">Настройки канвы, которые необходимо изменить</param>
        /// <param name="newColor">Новый цвет</param>
        public void EditCanvasColor(PaintingParameters paintingParameters, Color newColor)
        {
            _undoRedoStack.Do(CommandFactory.CreateEditCanvasColorCommand(paintingParameters, newColor));
        }

        /// <summary>
        /// Очистить историю команд и хранилище фигур для создания нового проекта
        /// </summary>
        public void ClearHistory()
        {
            _storage.DraftList.Clear();
            _storage.HighlightDraftsList.Clear();
            _undoRedoStack.Reset();
        }
    }
}
