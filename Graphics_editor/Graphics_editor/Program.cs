using System;
using System.Windows.Forms;
using GraphicsEditor.Interfaces;
using SDK;
using SDK.Interfaces;
using StructureMap;

namespace GraphicsEditor
{
    internal static class Program
    {
        /// <summary>
        ///     Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var container = new Container(_ =>
            {
                _.Scan(o =>
                {
                    o.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    o.AddAllTypesOf<IDrawable>().NameBy(x => x.Name);
                    o.AddAllTypesOf<BaseDrawer>().NameBy(x => x.Name);
                    o.AddAllTypesOf<ISelector>();
                    o.AddAllTypesOf<ICommandFactory>();
                    o.AddAllTypesOf<IDraftStorage>();
                    o.AddAllTypesOf<IUndoRedoStack>();
                    o.AddAllTypesOf<IDraftFactory>();
                    o.AddAllTypesOf<IDraftClipboard>();
                    o.AddAllTypesOf<IPenSettings>();
                    o.AddAllTypesOf<IPaintingParameters>();
                    o.AddAllTypesOf<IDrawerFacade>();
                    o.AddAllTypesOf<IStrategyDeterminer>();
                    o.AddAllTypesOf<IPainterState>();
                    o.AddAllTypesOf<IStorageManager>();
                    o.AddAllTypesOf<IDraftPainter>();
                    o.AddAllTypesOf<IDrawManager>();
                    o.AddAllTypesOf<IDraftSerealizer>();
                });
            });

            container.Configure(r => r.For<IPenSettings>()
                .Use<PenSettings>());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(container));
        }
    }
}