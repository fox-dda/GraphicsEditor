using GraphicsEditor.Enums;
using GraphicsEditor.Interfaces;
using SDK;
using StructureMap;

namespace GraphicsEditor.Core
{
    /// <summary>
    ///     Определитель стратегии
    /// </summary>
    public class StrategyDeterminer : IStrategyDeterminer
    {
        /// <summary>
        ///     DI контейнер
        /// </summary>
        private readonly IContainer _container;

        /// <summary>
        ///     Конструктор StrategyDeterminer
        /// </summary>
        /// <param name="container"></param>
        public StrategyDeterminer(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        ///     Определить статегию отрисовки по фигуре
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Стратегия</returns>
        public Strategy DefineStrategy(string figure)
        {
            var draft = _container.GetInstance<IDrawable>(figure);

            return draft is IMultipoint ? Strategy.Multipoint : Strategy.TwoPoint;
        }

        /// <summary>
        ///     Определить статегию отрисовки по фигуре
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Стратегия</returns>
        public Strategy DefineStrategy(DrawAction action)
        {
            if (action == DrawAction.DragDraft || action == DrawAction.DragPoint)
                return Strategy.DragAndDrop;
            return Strategy.Selection;
        }
    }
}