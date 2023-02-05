using System.Drawing;
using SDK;

namespace PolylinePlugin
{
    /// <summary>
    ///     Отрисовщик полилиний
    /// </summary>
    public class PolylineDrawer : BaseDrawer
    {
        /// <summary>
        ///     Отрисовать полилинию
        /// </summary>
        /// <param name="shape">Полилиния</param>
        /// <param name="graphics">Ядро отрисовки</param>
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            var dotList = (shape as Polyline)?.DotList;
            var pen = ConvertPen(shape.Pen);

            for (var i = 0; i < dotList.Count - 1; i++)
                graphics.DrawLine(pen,
                    dotList[i].X,
                    dotList[i].Y,
                    dotList[i + 1].X,
                    dotList[i + 1].Y);
        }
    }
}