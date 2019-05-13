﻿using System.Collections.Generic;
using SDK;

namespace GraphicsEditor.Interfaces
{
    public interface IDraftStorage
    {
        /// <summary>
        /// Список отрисованных фигур
        /// </summary>
        IList<IDrawable> DraftList { get; set; }

        /// <summary>
        /// Список выделенных фигур
        /// </summary>
        IList<IDrawable> HighlightDraftsList { get; set; }
    }
}
