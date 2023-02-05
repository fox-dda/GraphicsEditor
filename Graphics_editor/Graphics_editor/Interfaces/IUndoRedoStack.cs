using System.Collections.Generic;
using GraphicsEditor.Core.UndoRedo.Commands;

namespace GraphicsEditor.Interfaces
{
    public interface IUndoRedoStack
    {
        /// <summary>
        ///     Cтек отката
        /// </summary>
        /// <returns></returns>
        Stack<ICommand> UndoStack { get; }

        /// <summary>
        ///     Стек наката
        /// </summary>
        Stack<ICommand> RedoStack { get; set; }

        /// <summary>
        ///     Перезагрузить стек
        /// </summary>
        void Reset();

        /// <summary>
        ///     Выполнить команду
        /// </summary>
        /// <param name="command"></param>
        void Do(ICommand command);

        /// <summary>
        ///     Откатить команду
        /// </summary>
        void Undo();

        /// <summary>
        ///     Накатить команду
        /// </summary>
        void Redo();
    }
}