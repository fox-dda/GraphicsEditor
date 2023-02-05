using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsEditor.Tests.Stubs;
using NUnit.Framework;
using SDK;
using SDK.SDKCore;
using SDKTests.Exceptions;
using SDKTests.Stubs;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DraftFactoryTest
    {
        [TestCase(TestName = "Клонирование фигуры")]
        public void CloneTest_WithClonableStub()
        {
            // Arrange
            var container = new ContainerStub();
            var draftFactory = new DraftFactory(container);

            // Act/Assert
            Assert.DoesNotThrow(() => { draftFactory.Clone(new CloneableDraftStub()); });
        }

        [TestCase(TestName = "Проверка однородности, ожидая результат null")]
        public void CheckUniformityTest_WithDraftList_ExpectNull()
        {
            // Arrange
            var container = new ContainerStub();
            var draftFactory = new DraftFactory(container);
            var draftList = new List<IDrawable>
            {
                new TwoPointStub(),
                new MultipointStub()
            };

            // Act
            var result = draftFactory.CheckUniformity(draftList);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase(TestName = "Проверка однородности, ожидая ненулевой результат")]
        public void CheckUniformityTest_WithDraftList_ExpectNotNull()
        {
            // Arrange
            var container = new ContainerStub();
            var draftFactory = new DraftFactory(container);
            var draftList = new List<IDrawable>
            {
                new TwoPointStub()
            };

            // Act
            var result = draftFactory.CheckUniformity(draftList);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase(TestName = "Проверка однородности null списка, ожидая результат null")]
        public void CheckUniformityTest_NullDraftList_ExpectNull()
        {
            // Arrange
            var container = new ContainerStub();
            var draftFactory = new DraftFactory(container);

            // Act
            var result = draftFactory.CheckUniformity(null);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase(TestName = "Создание фигуры с параметрами null")]
        public void CreateDraftTest_CheckContainerCall_ExpectExeption()
        {
            // Arrange
            var container = new ContainerStub();
            var draftFactory = new DraftFactory(container);

            // Act/Assert
            Assert.Throws(typeof(GetInstanceExeption),
                () => { draftFactory.CreateDraft(null, null, null, Color.AliceBlue); });
        }
    }
}