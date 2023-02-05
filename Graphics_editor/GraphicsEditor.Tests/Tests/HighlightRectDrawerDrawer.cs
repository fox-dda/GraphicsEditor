﻿using System;
using System.Drawing;
using GraphicsEditor.Model.Drawers;
using GraphicsEditor.Tests.Stubs;
using NUnit.Framework;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class HighlightRectDrawerTest
    {
        [TestCase(TestName = "Отрисовка прмямоугольника выделения с Graphics=null")]
        public void DrawShapeTest_WithNullGraphics()
        {
            // Arange
            var drawer = new HighlightRectDrawer();
            var draft = new TwoPointStub
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };

            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () => { drawer.DrawShape(draft, null); });
        }
    }
}