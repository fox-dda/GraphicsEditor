﻿using GraphicsEditor.Core;
using GraphicsEditor.Enums;
using GraphicsEditor.Tests.Stubs;
using Moq;
using NUnit.Framework;
using SDK;
using StructureMap;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class StrategyDeterminerTest
    {
        private Mock<IContainer> _containerMock;

        private StrategyDeterminer StrategyDeterminer
        {
            get
            {
                _containerMock = new Mock<IContainer>();
                return new StrategyDeterminer(_containerMock.Object);
            }
        }

        [TestCase(TestName = "Определение стратегии ожидая результат Selection")]
        public void DefineStrategy_ExpectSelection()
        {
            // Act
            var strategy = StrategyDeterminer.DefineStrategy(DrawAction.Highlight);

            // Assert
            Assert.IsTrue(strategy == Strategy.Selection);
        }

        [TestCase(DrawAction.DragDraft, TestName = "Определение стратегии ожидая результат DragAndDrop")]
        [TestCase(DrawAction.DragPoint, TestName = "Определение стратегии ожидая результат DragAndDrop")]
        public void DefineStrategy_ExpectDragAndDrop(DrawAction action)
        {
            // Act
            var strategy = StrategyDeterminer.DefineStrategy(action);

            // Assert
            Assert.IsTrue(strategy == Strategy.DragAndDrop);
        }

        [TestCase(TestName = "Определение стратегии ожидая результат Multipoint")]
        public void DefineStrategy_ExpectMultipoint()
        {
            // Arrange
            var determiner = StrategyDeterminer;
            _containerMock.Setup(x => x.GetInstance<IDrawable>("SomeFigure"))
                .Returns(new MultipointStub());

            // Act
            var strategy = determiner.DefineStrategy("SomeFigure");

            // Assert
            Assert.IsTrue(strategy == Strategy.Multipoint);
        }

        [TestCase(TestName = "Определение стратегии ожидая результат TwoPoint")]
        public void DefineStrategy_ExpectTwoPoint()
        {
            // Arrange
            var determiner = StrategyDeterminer;
            _containerMock.Setup(x => x.GetInstance<IDrawable>("SomeFigure"))
                .Returns(new TwoPointStub());

            // Act
            var strategy = determiner.DefineStrategy("SomeFigure");

            // Assert
            Assert.IsTrue(strategy == Strategy.TwoPoint);
        }

        [TestCase("588-M1 Group",
            TestName = "Определение стратегии ожидая результат по-умолчанию - TwoPoint")]
        [TestCase("TUSUR",
            TestName = "Определение стратегии ожидая результат по-умолчанию - TwoPoint")]
        [TestCase("Dmitry Domaskin",
            TestName = "Определение стратегии ожидая результат по-умолчанию - TwoPoint")]
        [TestCase("TRPO2019",
            TestName = "Определение стратегии ожидая результат по-умолчанию - TwoPoint")]
        public void DefineStrategy_WithAnyString_ExpectTwoPoint(string str)
        {
            // Act
            var strategy = StrategyDeterminer.DefineStrategy(str);

            // Assert
            Assert.IsTrue(strategy == Strategy.TwoPoint);
        }
    }
}