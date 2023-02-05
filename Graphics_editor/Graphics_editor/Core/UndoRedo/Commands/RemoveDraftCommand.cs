using System;
using System.Collections.Generic;
using SDK;

namespace GraphicsEditor.Core.UndoRedo.Commands
{
    /// <summary>
    ///     Команда удаления фигуры
    /// </summary>
    [Serializable]
    public class RemoveDraftCommand : ICommand
    {
        /// <summary>
        ///     Целевой список
        /// </summary>
        [field: NonSerialized] private List<IDrawable> _draftList;

        /// <summary>
        ///     Удаляемая фигура
        /// </summary>
        private IDrawable _removebleDraft;

        /// <summary>
        ///     Конструктор команды удаления фигуры
        /// </summary>
        /// <param name="storage">Целевой список</param>
        /// <param name="draft">Удаляемая фигура</param>
        public RemoveDraftCommand(List<IDrawable> storage, IDrawable draft)
        {
            TargetStorage = storage;
            _removebleDraft = draft;
        }

        /// <summary>
        ///     Целевой список
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
            TargetStorage.Remove(_removebleDraft);
        }

        /// <summary>
        ///     Откатить команду
        /// </summary>
        public void Undo()
        {
            TargetStorage.Add(_removebleDraft);
        }
    }
}