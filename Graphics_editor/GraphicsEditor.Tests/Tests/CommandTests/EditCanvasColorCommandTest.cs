using System;
using System.Drawing;
using GraphicsEditor.Core.UndoRedo.Commands;
using GraphicsEditor.Interfaces;
using Moq;
using NUnit.Framework;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class EditCanvasColorCommandTest
    {
        [TestCase(TestName = "Выполнение команды с ненулевыми параметрами")]
        public void DoTest_WithNotNull()
        {
            // Arrange
            var paintingParametersMock = new Mock<IPaintingParameters>();
            paintingParametersMock.Setup(x => x.CanvasColor)
                .Returns(Color.Green);
            var editCanvasColorCommand = new EditCanvasColorCommand(
                paintingParametersMock.Object,
                Color.Red);

            // Act
            editCanvasColorCommand.Do();

            // Assert
            paintingParametersMock.VerifySet(x => x.CanvasColor = Color.Red);
        }

        [TestCase(TestName = "Отмена команды с ненулевыми параметрами")]
        public void UndoTest_WithNotNull()
        {
            // Arrange
            var paintingParametersMock = new Mock<IPaintingParameters>();
            paintingParametersMock.Setup(x => x.CanvasColor)
                .Returns(Color.Green);
            var editCanvasColorCommand = new EditCanvasColorCommand(
                paintingParametersMock.Object,
                Color.Red);
            editCanvasColorCommand.Do();

            // Act
            editCanvasColorCommand.Undo();

            // Assert
            paintingParametersMock.VerifySet(x => x.CanvasColor = Color.Green);
        }

        [TestCase(TestName = "Создание команды с PaintingParameters = null")]
        public void CreateCommandTest_WithNullParameter()
        {
            // Act/Assert
            Assert.Throws(typeof(NullReferenceException), () =>
            {
                var editCanvasColorCommand = new EditCanvasColorCommand(
                    null, Color.Green);
            });
        }
    }
}