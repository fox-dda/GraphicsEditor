﻿using NUnit.Framework;
using System.Drawing;
using GraphicsEditor.Model.Drawers;
using GraphicsEditor.Tests.Stubs;
using System;
using GraphicsEditor.Model;

namespace GraphicsEditor.Tests
{
    [TestFixture]
    public class DotInDraftTest
    {
        [TestCase(TestName = "Запись в структуру не нулевых значений")]
        public void DotInDraftTest_Set()
        {
            var dotInDraft = new DotInDraft();
            var point = new Point(0, 0);
            var draft = new TwoPointStub()
            {
                StartPoint = point,
                EndPoint = new Point(1, 1)
            };

            Assert.DoesNotThrow( () =>
            {
                dotInDraft.Set(draft, point);
            });
        }

        [TestCase(TestName = "Запись в структуру нулевых значений")]
        public void DotInDraftTest_SetNullDraft()
        {
            var dotInDraft = new DotInDraft();
            var point = new Point(0, 0);

            Assert.DoesNotThrow(() =>
            {
                dotInDraft.Set(null, point);
            });
        }
    }
}