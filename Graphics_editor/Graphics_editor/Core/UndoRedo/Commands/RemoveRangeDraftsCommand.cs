using System;
using System.Collections.Generic;
using SDK;

namespace GraphicsEditor.Core.UndoRedo.Commands
{
    /// <summary>
    ///     Команда удаления нескольких фигур
    /// </summary>
    [Serializable]
    public class RemoveRangeDraftsCommand : ICommand
    {
        /// <summary>
        ///     Целевой список
        /// </summary>
        [field: NonSerialized] private List<IDrawable> _draftList;

        /// <summary>
        ///     Удаляемые фигуры
        /// </summary>
        private List<IDrawable> _removebleList;

        /// <summary>
        ///     Конструктор команды удаления несколькиз фигур
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="removebleList"></param>
        public RemoveRangeDraftsCommand(List<IDrawable> storage, List<IDrawable> removebleList)
        {
            TargetStorage = storage;
            _removebleList = new List<IDrawable>();
            foreach (var draft in removebleList) _removebleList.Add(draft);
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
        ///     Выпонить команду
        /// </summary>
        public void Do()
        {
            foreach (var draft in _removebleList) TargetStorage.Remove(draft);
        }

        /// <summary>
        ///     Откатить команду
        /// </summary>
        public void Undo()
        {
            foreach (var draft in _removebleList) TargetStorage.Add(draft);
        }
    }
}