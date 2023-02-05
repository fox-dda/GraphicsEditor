using System;
using GraphicsEditor.Interfaces;
using Moq;
using NUnit.Framework;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DraftSerealizerTest
    {
        [TestCase(TestName = "Сериализация с Stream=null")]
        public void Serealize_TestWithNullStream()
        {
            // Arrange
            var serealizer = new DraftSerealizer();
            var undoRedoStackMock = new Mock<IUndoRedoStack>();

            // Act/Assert
            Assert.Throws(typeof(ArgumentNullException),
                () => { serealizer.Serialize(null, undoRedoStackMock.Object); });
        }

        [TestCase(TestName = "Десериализация с Stream=null")]
        public void Deserealize_TestWithNullStream()
        {
            // Arrange
            var serealizer = new DraftSerealizer();

            // Act/Assert
            Assert.Throws(typeof(ArgumentNullException), () => { serealizer.Deserialize(null); });
        }
    }
}