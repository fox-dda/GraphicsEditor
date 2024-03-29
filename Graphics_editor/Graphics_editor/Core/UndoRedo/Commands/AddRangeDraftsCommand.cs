﻿using System;
using System.Collections.Generic;
using SDK;

namespace GraphicsEditor.Core.UndoRedo.Commands
{
    /// <summary>
    ///     Команда добавления нескольких фигур
    /// </summary>
    [Serializable]
    public class AddRangeDraftCommand : ICommand
    {
        /// <summary>
        ///     Добавляемая фигура
        /// </summary>
        private List<IDrawable> _addebleList;

        /// <summary>
        ///     Целевой список
        /// </summary>
        [field: NonSerialized] private List<IDrawable> _draftList;

        /// <summary>
        ///     Конструктор комманды
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="addebleList">Добавляемая фигура</param>
        public AddRangeDraftCommand(List<IDrawable> storage, List<IDrawable> addebleList)
        {
            TargetStorage = storage;
            _addebleList = new List<IDrawable>();
            foreach (var draft in addebleList) _addebleList.Add(draft);
        }

        /// <summary>
        ///     Список, в который нужно добавить фигуру
        /// </summary>
        public List<IDrawable> TargetStorage
        {
            get => _draftList;
            set => _draftList = value;
        }

        /// <summary>
        ///     Выполнить команду
        /// </summary>
        public void Do()
        {
            foreach (var draft in _addebleList) TargetStorage.Add(draft);
        }

        /// <summary>
        ///     Откатить команду
        /// </summary>
        public void Undo()
        {
            foreach (var draft in _addebleList) TargetStorage.Remove(draft);
        }
    }
}