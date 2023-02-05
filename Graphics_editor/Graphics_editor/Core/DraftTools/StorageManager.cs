﻿using System.Collections.Generic;
using System.Drawing;
using GraphicsEditor.Core.UndoRedo.Commands;
using GraphicsEditor.Interfaces;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor.DraftTools
{
    /// <summary>
    ///     Менеджер хранилища
    /// </summary>
    public class StorageManager : IStorageManager
    {
        private readonly ICommandFactory _commandFactory;

        /// <summary>
        ///     Стек команд
        /// </summary>
        private IUndoRedoStack _undoRedoStack;

        /// <summary>
        ///     Конструктор класса StorageManager
        /// </summary>
        /// <param name="storage">Хранилище фигур</param>
        public StorageManager(IDraftStorage storage, ICommandFactory commandFactory,
            IUndoRedoStack undoRedoStack)
        {
            Storage = storage;
            _commandFactory = commandFactory;
            _undoRedoStack = undoRedoStack;
        }

        public IDraftStorage Storage { get; }

        /// <summary>
        ///     Список отрисованных фигур
        /// </summary>
        /// <returns>Хранилище фигур</returns>
        public List<IDrawable> PaintedDraftStorage => Storage.DraftList;

        /// <summary>
        ///     Список выделенных фигур
        /// </summary>
        public List<IDrawable> HighlightDraftStorage => Storage.HighlightDraftsList;

        /// <summary>
        ///     Выполнить комманду
        /// </summary>
        /// <param name="command">Команда, которую нужно выполнить</param>
        public void DoCommand(ICommand command)
        {
            _undoRedoStack.Do(command);
        }

        /// <summary>
        ///     Вернуть стек выполненых команд
        /// </summary>
        /// <returns>Выполненные команды</returns>
        public IUndoRedoStack UndoRedoStack
        {
            get => _undoRedoStack;
            set => _undoRedoStack = value;
        }

        /// <summary>
        ///     Повторить комманду (Шаг вперед)
        /// </summary>
        public void RedoCommand()
        {
            _undoRedoStack.Redo();
        }

        /// <summary>
        ///     Отменить комманду (Шаг назад)
        /// </summary>
        public void UndoCommand()
        {
            _undoRedoStack.Undo();
        }

        /// <summary>
        ///     Добавить фигуру в хранилище
        /// </summary>
        /// <param name="draft">Добавляемая фигура</param>
        public void AddDraft(IDrawable draft)
        {
            _undoRedoStack.Do(_commandFactory.CreateAddDraftCommand(Storage.DraftList, draft));
        }

        /// <summary>
        ///     Добавить несколько фигур в хранилище
        /// </summary>
        /// <param name="drafts">Добавляемые фигуры</param>
        public void AddRangeDrafts(List<IDrawable> drafts)
        {
            _undoRedoStack.Do(_commandFactory.CreateAddRangeDraftCommand(Storage.DraftList, drafts));
        }

        /// <summary>
        ///     Очистить хранилище фигур
        /// </summary>
        public void ClearStorage()
        {
            _undoRedoStack.Do(_commandFactory.CreateClearStorageCommand(Storage.DraftList));
            DiscardAll();
        }

        /// <summary>
        ///     Изменить выдиление фигуры
        /// </summary>
        /// <param name="draft"></param>
        public void EditHighlightDraft(IDrawable draft)
        {
            if (HighlightDraftStorage.Contains(draft))
                Storage.HighlightDraftsList.Remove(draft);
            else
                Storage.HighlightDraftsList.Add(draft);
        }

        /// <summary>
        ///     Очистить список выделенных фигур
        /// </summary>
        public void DiscardAll()
        {
            Storage.HighlightDraftsList.Clear();
        }

        /// <summary>
        ///     Добавить несколько фигур в список выделенных
        /// </summary>
        /// <param name="highlightRange"></param>
        public void HighlightingDraftRange(List<IDrawable> highlightRange)
        {
            Storage.HighlightDraftsList.AddRange(highlightRange);
        }

        /// <summary>
        ///     Изменить фигуру
        /// </summary>
        /// <param name="draft">Изменяемая фигура</param>
        /// <param name="pointList">Новые точки</param>
        /// <param name="pen">Новое перо</param>
        /// <param name="brush">Новый цвет заливки</param>
        public void EditDraft(IDrawable draft, List<Point> pointList,
            IPenSettings pen, Color brush, IDraftFactory factory)
        {
            _undoRedoStack.Do(_commandFactory.CreateEditDraftCommand(
                draft, pointList, pen, brush, factory));
        }

        /// <summary>
        ///     Удалить выделенные фигуры из хранилища
        /// </summary>
        public void RemoveRangeHighlightDrafts()
        {
            _undoRedoStack.Do(_commandFactory.CreateRemoveRangeDraftsCommand(
                Storage.DraftList, Storage.HighlightDraftsList));
            DiscardAll();
        }

        /// <summary>
        ///     Получить точки из фигуры
        /// </summary>
        /// <param name="item">Фигура, из которой нужно вытащить точки</param>
        /// <returns>Точки фигуры</returns>
        public List<Point> PullPoints(IDrawable item)
        {
            var pullPointList = new List<Point>();
            if (item is IMultipoint multipoint)
            {
                foreach (var pointInDraft in multipoint.DotList) pullPointList.Add(pointInDraft);
            }
            else
            {
                pullPointList.Add(item.StartPoint);
                pullPointList.Add(item.EndPoint);
            }

            return pullPointList;
        }

        /// <summary>
        ///     Изменить цвет канвы
        /// </summary>
        /// <param name="paintingParameters">Настройки канвы, которые необходимо изменить</param>
        /// <param name="newColor">Новый цвет</param>
        public void EditCanvasColor(IPaintingParameters paintingParameters, Color newColor)
        {
            _undoRedoStack.Do(_commandFactory.CreateEditCanvasColorCommand(
                paintingParameters, newColor));
        }

        /// <summary>
        ///     Очистить историю команд и хранилище фигур для создания нового проекта
        /// </summary>
        public void ClearHistory()
        {
            Storage.DraftList.Clear();
            DiscardAll();
            _undoRedoStack.Reset();
        }
    }
}