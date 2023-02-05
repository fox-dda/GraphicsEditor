using System;
using System.Collections.Generic;
using SDK;

namespace GraphicsEditor.Core.UndoRedo.Commands
{
    /// <summary>
    ///     Команда очистки хранилища объектов
    /// </summary>
    [Serializable]
    public class ClearStorageCommand : ICommand
    {
        /// <summary>
        ///     Бэкап хранилища
        /// </summary>
        private List<IDrawable> _backUp;

        /// <summary>
        ///     Целевой список
        /// </summary>
        [field: NonSerialized] private List<IDrawable> _draftList;

        /// <summary>
        ///     Конструктор команды очистки
        /// </summary>
        /// <param name="storage">Очищаемый список</param>
        public ClearStorageCommand(List<IDrawable> storage)
        {
            TargetStorage = storage;
            _backUp = new List<IDrawable>();
            foreach (var draft in storage) _backUp.Add(draft);
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
            TargetStorage.Clear();
        }

        /// <summary>
        ///     Откатить команду
        /// </summary>
        public void Undo()
        {
            foreach (var draft in _backUp) TargetStorage.Add(draft);
        }
    }
}