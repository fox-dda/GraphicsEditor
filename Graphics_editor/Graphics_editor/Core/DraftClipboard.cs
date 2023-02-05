using System.Collections.Generic;
using GraphicsEditor.Interfaces;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor
{
    /// <summary>
    ///     Буфер обмена
    /// </summary>
    public class DraftClipboard : IDraftClipboard
    {
        /// <summary>
        ///     Хранилище объектов буфера обмена
        /// </summary>
        private readonly List<IDrawable> _clipboard;

        /// <summary>
        ///     Фабрика фигур для клонирования
        /// </summary>
        private readonly IDraftFactory _factory;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="factory">Фабрика фигур</param>
        public DraftClipboard(IDraftFactory factory, List<IDrawable> clipboard)
        {
            _factory = factory;
            _clipboard = clipboard;
        }

        /// <summary>
        ///     Записать в буфер ряд объектов
        /// </summary>
        /// <param name="items">Записываемые объекты</param>
        public void SetRange(List<IDrawable> items)
        {
            _clipboard.Clear();
            foreach (var item in items) _clipboard.Add(_factory.Clone(item));
        }

        /// <summary>
        ///     Вернуть из буфера ряд объектов
        /// </summary>
        /// <returns></returns>
        public List<IDrawable> GetAll()
        {
            var returnList = new List<IDrawable>();

            foreach (var item in _clipboard) returnList.Add(_factory.Clone(item));
            return returnList;
        }
    }
}