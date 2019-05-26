﻿using NUnit.Framework;
using SDK.Interfaces;
using SDK;
using Moq;
using System.Collections.Generic;
using GraphicsEditor.Engine;
using GraphicsEditor.Interfaces;
using GraphicsEditor.Enums;
using System;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class PaintingParametersTest
    {
        private PaintingParameters _paintingsParameters;
        private Mock<IPenSettings> _penSettingsMock;

        public void SetUp()
        {
            _penSettingsMock = new Mock<IPenSettings>();
            _paintingsParameters = new PaintingParameters(_penSettingsMock.Object);
        }

        [Test]
        public void DashPatternProperty_SetAny(
            [Values(new float[]{float.MaxValue, float.MaxValue},
                    new float[]{float.MaxValue, float.MinValue},
                    new float[]{float.MinValue, float.MaxValue},
                    new float[]{float.MinValue, float.MinValue},
                    new float[]{0, 0})] float[] inputPattern)
        {
            SetUp();
            
            _paintingsParameters.DashPattern = inputPattern;
        }

        [Test]
        public void DashPatternProperty_GetWhenPropertyIsZero_ExpectNullInCaches()
        {
            SetUp();
            _paintingsParameters.DashPattern = new float[] {0, 100};

            Assert.IsNull(_paintingsParameters.DashPattern);
        }


        [Test]
        public void BrushColorTestSet()
        {
            SetUp();

            _paintingsParameters.BrushColor = System.Drawing.Color.AliceBlue;

            Assert.IsNotNull(_paintingsParameters.BrushColor);
        }

        [Test]
        public void CanvasColorTestSet()
        {
            SetUp();

            _paintingsParameters.CanvasColor = System.Drawing.Color.AliceBlue;

            Assert.IsNotNull(_paintingsParameters.CanvasColor);
        }

        [Test]
        public void BrushColorTestGet()
        {
            SetUp();
            _paintingsParameters.BrushColor = System.Drawing.Color.AliceBlue;

            Assert.DoesNotThrow(() =>
            {
                var color = _paintingsParameters.BrushColor;
            });
        }

        [Test]
        public void CanvasColorTestGet()
        {
            SetUp();
            _paintingsParameters.CanvasColor = System.Drawing.Color.AliceBlue;

            Assert.DoesNotThrow(() =>
            {
                var color = _paintingsParameters.CanvasColor;
            });
        }
    }
}