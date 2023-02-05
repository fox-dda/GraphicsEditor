using System.Drawing;
using Moq;
using NUnit.Framework;
using SDK.Interfaces;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class PaintingParametersTest
    {
        private Mock<IPenSettings> _penSettingsMock;

        private PaintingParameters PaintingsParameters
        {
            get
            {
                _penSettingsMock = new Mock<IPenSettings>();
                return new PaintingParameters(_penSettingsMock.Object);
            }
        }

        [TestCase(new[] { float.MaxValue, float.MaxValue },
            TestName = "Запись в свойство DashPattern нраничных значений float")]
        [TestCase(new[] { float.MaxValue, float.MinValue },
            TestName = "Запись в свойство DashPattern нраничных значений float")]
        [TestCase(new[] { float.MinValue, float.MaxValue },
            TestName = "Запись в свойство DashPattern нраничных значений float")]
        [TestCase(new[] { float.MinValue, float.MinValue },
            TestName = "Запись в свойство DashPattern нраничных значений float")]
        [TestCase(new float[] { 0, 0 })]
        public void DashPatternProperty_SetAny(float[] inputPattern)
        {
            // Act/Assert
            Assert.DoesNotThrow(() => { PaintingsParameters.DashPattern = inputPattern; });
        }

        [TestCase(TestName = "Считывание свойства DashPattern")]
        public void DashPatternProperty_GetWhenPropertyIsZero_ExpectNullInCaches()
        {
            // Arrange
            var parameters = PaintingsParameters;

            // Act
            parameters.DashPattern = new float[] { 0, 100 };

            // Assert
            Assert.IsNull(parameters.DashPattern);
        }


        [TestCase(TestName = "Запись в свойство BrushColor")]
        public void BrushColorTestSet()
        {
            // Arrange
            var parameters = PaintingsParameters;

            // Act
            parameters.BrushColor = Color.AliceBlue;

            // Assert
            Assert.IsNotNull(parameters.BrushColor);
        }

        [TestCase(TestName = "Запись в свойство CanvasColor")]
        public void CanvasColorTestSet()
        {
            // Arrange
            var parameters = PaintingsParameters;

            // Act
            parameters.CanvasColor = Color.AliceBlue;

            // Assert
            Assert.IsNotNull(parameters.CanvasColor);
        }

        [TestCase(TestName = "Считывание из свойства BrushColor")]
        public void BrushColorTestGet()
        {
            // Arrange
            var parameters = PaintingsParameters;
            parameters.BrushColor = Color.AliceBlue;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var color = parameters.BrushColor;
            });
        }

        [TestCase(TestName = "Считывание из свойства CanvasColor")]
        public void CanvasColorTestGet()
        {
            // Arrange
            var parameters = PaintingsParameters;
            parameters.CanvasColor = Color.AliceBlue;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                var color = parameters.CanvasColor;
            });
        }
    }
}