using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GraphicsEditor.Enums;
using GraphicsEditor.Interfaces;
using SDK;
using StructureMap;

namespace GraphicsEditor.View
{
    public partial class FigureToolBox : UserControl
    {
        private readonly IPainterState _painterState;

        public FigureToolBox(IPainterState painterState)
        {
            InitializeComponent();
            _painterState = painterState;

            var container = new Container(_ =>
            {
                _.Scan(o =>
                {
                    o.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    o.AddAllTypesOf<IDrawable>().NameBy(x => x.Name);
                });
            });

            var instances = container.GetAllInstances<IDrawable>();

            foreach (var drawerInstance in instances)
            {
                var name = drawerInstance.GetType().Name;
                ModelNames.Add(name);
            }

            //PluginLoader pluginloader = new PluginLoader();
            //foreach (var name in pluginloader.LoadModels().Keys.ToList())
            //{
            //    _modelNames.Add(name);
            //}
            var verticalSpace = 12;

            foreach (var model in ModelNames)
            {
                var figureButton = new Button { Text = model };
                figureButton.Click += EditState;
                figureButton.Location = new Point(10, verticalSpace);
                toolGroupBox.Controls.Add(figureButton);
                verticalSpace += figureButton.Height + 10;
            }
        }

        public List<string> ModelNames { get; } = new List<string>();

        public void EditState(object sender, EventArgs e)
        {
            _painterState.Figure = (sender as Button).Text;
            _painterState.DrawAction = DrawAction.Draw;
        }
    }
}