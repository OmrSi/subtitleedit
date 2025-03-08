﻿using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Core.SubtitleFormats;
using System;

namespace Tests.Core
{
    [TestClass]
    public class ActorConverterTest
    {
        [TestMethod]
        public void SquareToSquare()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToSquare = true,
            };

            var p = new Paragraph() { Text = "[Joe] How are you?" };
            var text = c.FixActors(p, '[', ']', null, null);
            Assert.AreEqual("[Joe] How are you?", text);
        }

        [TestMethod]
        public void SquareToSquareUppercase()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToSquare = true,
            };

            var p = new Paragraph() { Text = "[Joe] How are you?" };
            var text = c.FixActors(p, '[', ']', ActorConverter.UpperCase, null);
            Assert.AreEqual("[JOE] How are you?", text);
        }

        [TestMethod]
        public void SquareToParentheses()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToParentheses = true,
            };

            var p = new Paragraph() { Text = "[Joe] How are you?" };
            var text = c.FixActors(p, '[', ']', null, null);
            Assert.AreEqual("(Joe) How are you?", text);
        }

        [TestMethod]
        public void SquareToParenthesesUppercase()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToParentheses = true,
            };

            var p = new Paragraph() { Text = "[Joe] How are you?" };
            var text = c.FixActors(p, '[', ']', ActorConverter.UpperCase, null);
            Assert.AreEqual("(JOE) How are you?", text);
        }

        [TestMethod]
        public void SquareToParenthesesLowercase()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToParentheses = true,
            };

            var p = new Paragraph() { Text = "[Joe] How are you?" };
            var text = c.FixActors(p, '[', ']', ActorConverter.LowerCase, null);
            Assert.AreEqual("(joe) How are you?", text);
        }

        [TestMethod]
        public void ParenthesesToSquareLowercase()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToSquare = true,
            };

            var p = new Paragraph() { Text = "(JOE) How are you?" };
            var text = c.FixActors(p, '(', ')', ActorConverter.NormalCase, null);
            Assert.AreEqual("[Joe] How are you?", text);
        }

        [TestMethod]
        public void ColorToParenthesesLowercase()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToParentheses = true,
            };

            var p = new Paragraph() { Text = "Joe: How are you?" };
            var text = c.FixActorsFromBeforeColon(p, ':', ActorConverter.LowerCase, null);
            Assert.AreEqual("(joe) How are you?", text);
        }

        [TestMethod]
        public void FromActorToSquare()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToSquare = true,
            };

            var p = new Paragraph() { Text = "How are you?", Actor = "Joe" };
            var text = c.FixActorsFromActor(p, null, null);
            Assert.AreEqual("[Joe] How are you?", text);
        }

        [TestMethod]
        public void SquareToActorUppercase()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToActor = true,
            };

            var p = new Paragraph() { Text = "[Joe] How are you?" };
            var text = c.FixActors(p, '[', ']', ActorConverter.UpperCase, null);
            Assert.AreEqual("How are you?", text);
            Assert.AreEqual("JOE", p.Actor);
        }

        [TestMethod]
        public void ColonDialogToSquare1()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToSquare = true,
            };

            var p = new Paragraph() { Text = "Joe: How are you?" + Environment.NewLine + "Jane: I'm fine." };
            var text = c.FixActorsFromBeforeColon(p, ':', null, null);
            Assert.AreEqual("[Joe] How are you?" + Environment.NewLine + "[Jane] I'm fine.", text);
        }

        [TestMethod]
        public void ColonDialogToSquare2()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToSquare = true,
            };

            var p = new Paragraph() { Text = "- Joe: How are you?" + Environment.NewLine + "- Jane: I'm fine." };
            var text = c.FixActorsFromBeforeColon(p, ':', null, null);
            Assert.AreEqual("[Joe] How are you?" + Environment.NewLine + "[Jane] I'm fine.", text);
        }

        [TestMethod]
        public void SquareToParenthesesDialog()
        {
            var c = new ActorConverter(new SubRip())
            {
                ToParentheses = true,
            };

            var p = new Paragraph() { Text = "[Joe] How are you?" + Environment.NewLine + "[Jane] I am fine." };
            var text = c.FixActors(p, '[', ']', null, null);
            Assert.AreEqual("(Joe) How are you?" + Environment.NewLine + "(Jane) I am fine.", text);
        }
    }
}
