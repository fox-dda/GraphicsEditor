using System;
using System.Collections.Generic;
using SDK;

namespace GraphicsEditor.Core.UndoRedo.Commands
{
    /// <summary>
    ///     Команда добавления фигуры в хранилище
    /// </summary>
    [Serializable]
    public class AddDraftCommand : ICommand
    {
        /// <summary>
        ///     Добавляемая фигура
        /// </summary>
        private IDrawable _draft;

        /// <summary>
        ///     Целевой список
        /// </summary>
        [field: NonSerialized] private List<IDrawable> _draftList;

        /// <summary>
        ///     Конструктор команды
        /// </summary>
        /// <param name="storage">Список, в который нужно добавить фигуру</param>
        /// <param name="draft">Добавляемая фигура</param>
        public AddDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            DraftList = storage;
            _draft = draft;
        }

        /// <summary>
        ///     Список, в который нужно добавить фигуру
        /// </summary>
        public List<IDrawable> DraftList
        {
            get => _draftList;
            set => _draftList = value;
        }

        /// <summary>
        ///     Выполнить команду
        /// </summary>
        public void Do()
        {
            DraftList.Add(_draft);
        }

        /// <summary>
        ///     Откатить команду
        /// </summary>
        public void Undo()
        {
            DraftList.Remove(_draft);
        }
    }
}