﻿using System.Collections.Generic;
using System.Drawing;
using GraphicsEditor.Core.UndoRedo.Commands;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor.Interfaces
{
    public interface IStorageManager
    {
        /// <summary>
        ///     Список отрисованных фигур
        /// </summary>
        /// <returns>Хранилище фигур</returns>
        List<IDrawable> PaintedDraftStorage { get; }

        /// <summary>
        ///     Список выделенных фигур
        /// </summary>
        List<IDrawable> HighlightDraftStorage { get; }

        /// <summary>
        ///     Вернуть стек выполненых команд
        /// </summary>
        /// <returns>Выполненные команды</returns>
        IUndoRedoStack UndoRedoStack { get; set; }

        /// <summary>
        ///     Выполнить комманду
        /// </summary>
        /// <param name="command">Команда, которую нужно выполнить</param>
        void DoCommand(ICommand command);

        /// <summary>
        ///     Повторить комманду (Шаг вперед)
        /// </summary>
        void RedoCommand();

        /// <summary>
        ///     Отменить комманду (Шаг назад)
        /// </summary>
        void UndoCommand();

        /// <summary>
        ///     Добавить фигуру в хранилище
        /// </summary>
        /// <param name="draft">Добавляемая фигура</param>
        void AddDraft(IDrawable draft);

        /// <summary>
        ///     Добавить несколько фигур в хранилище
        /// </summary>
        /// <param name="drafts">Добавляемые фигуры</param>
        void AddRangeDrafts(List<IDrawable> drafts);

        /// <summary>
        ///     Очистить хранилище фигур
        /// </summary>
        void ClearStorage();

        /// <summary>
        ///     Изменить выдиление фигуры
        /// </summary>
        /// <param name="draft"></param>
        void EditHighlightDraft(IDrawable draft);

        /// <summary>
        ///     Очистить список выделенных фигур
        /// </summary>
        void DiscardAll();

        /// <summary>
        ///     Добавить несколько фигур в список выделенных
        /// </summary>
        /// <param name="highlightRange"></param>
        void HighlightingDraftRange(List<IDrawable> highlightRange);

        /// <summary>
        ///     Изменить фигуру
        /// </summary>
        /// <param name="draft">Изменяемая фигура</param>
        /// <param name="pointList">Новые точки</param>
        /// <param name="pen">Новое перо</param>
        /// <param name="brush">Новый цвет заливки</param>
        void EditDraft(IDrawable draft, List<Point> pointList,
            IPenSettings pen, Color brush, IDraftFactory draftFactory);

        /// <summary>
        ///     Удалить выделенные фигуры из хранилища
        /// </summary>
        void RemoveRangeHighlightDrafts();

        /// <summary>
        ///     Получить точки из фигуры
        /// </summary>
        /// <param name="item">Фигура, из которой нужно вытащить точки</param>
        /// <returns>Точки фигуры</returns>
        List<Point> PullPoints(IDrawable item);

        /// <summary>
        ///     Изменить цвет канвы
        /// </summary>
        /// <param name="paintingParameters">Настройки канвы, которые необходимо изменить</param>
        /// <param name="newColor">Новый цвет</param>
        void EditCanvasColor(IPaintingParameters paintingParameters, Color newColor);

        /// <summary>
        ///     Очистить историю команд и хранилище фигур для создания нового проекта
        /// </summary>
        void ClearHistory();
    }
}