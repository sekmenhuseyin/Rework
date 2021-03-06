﻿using NUnit.Framework;
using Rework;

namespace UnitTests
{
    [TestFixture]
    public class StringsTests
    {
        #region Slugify

        [Test]
        public void Slugify_WithEmptyString_ShouldReturnEmptyString()
        {
            var result = string.Empty.Slugify();

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void Slugify_WithNull_ShouldReturnEmptyString()
        {
            string str = null;
            var result = str.Slugify();

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void Slugify_WithSlugifiedString_ShouldReturnSameString()
        {
            var result = "luke-is-awesome".Slugify();

            Assert.AreEqual("luke-is-awesome", result);
        }

        [Test]
        public void Slugify_WithNonSlugifiedString_ShouldReturnSlugifiedString()
        {
            var result = "luke is awesome".Slugify();

            Assert.AreEqual("luke-is-awesome", result);
        }

        [Test]
        public void Slugify_WithNonSlugifiedStringWithInvalidChars_ShouldReturnSlugifiedString()
        {
            var result = "lukè is àwesome".Slugify();

            Assert.AreEqual("luke-is-awesome", result);
        }

        [Test]
        public void Slugify_WithNonSlugifiedStringWithInvalidPunctuation_ShouldReturnSlugifiedString()
        {
            var result = "luke,is,awesome".Slugify();

            Assert.AreEqual("lukeisawesome", result);
        }

        #endregion

        #region Truncate

        [Test]
        public void Truncate_WithEmptyString_ShouldReturnEmptyString()
        {
            var result = string.Empty.Truncate(10);

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void Truncate_WithNullString_ShouldReturnNullWithNoException()
        {
            var result = default(string).Truncate(10);

            Assert.AreEqual(null, result);
        }

        [Test]
        public void Truncate_WithLongString_ShouldTruncateString()
        {
            var result = "Some long string".Truncate(6);

            Assert.AreEqual("Some l", result);
        }

        [Test]
        public void Truncate_WithShortString_ShouldJustReturnTheString()
        {
            var result = "Some long string".Truncate(16);

            Assert.AreEqual("Some long string", result);
        }

        #endregion

        #region TruncateAtWord

        [Test]
        public void TruncateAtWord_WithNullString_ReturnsNull()
        {
            Assert.AreEqual(default(string), default(string).TruncateAtWord(10));
        }

        [Test]
        public void TruncateAtWord_WithStringWithSameLengthAsMax_ReturnsString()
        {
            Assert.AreEqual("some string", "some string".TruncateAtWord(11));
        }

        [Test]
        public void TruncateAtWord_WithStringLongerThanMax_ReturnsFirstWordPlusElipsis()
        {
            Assert.AreEqual("some&hellip;", "some string".TruncateAtWord(9));
        }

        [Test]
        public void TruncateAtWord_WithStringLongerThanMaxWithOneWord_ReturnsEmptyString()
        {
            Assert.AreEqual(string.Empty, "somestring".TruncateAtWord(9));
        }

        #endregion

        #region Captitalize

        [Test]
        public void CapitalizeWord_WithLowerString_ReturnsCapitalizedWord()
        {
            string result = Strings.CapitalizeWord("luke");

            Assert.AreEqual("Luke", result);
        }

        [Test]
        public void CapitalizeWord_WithUpperString_ReturnsCapitalizedWord()
        {
            string result = Strings.CapitalizeWord("LUKE");

            Assert.AreEqual("Luke", result);
        }

        [Test]
        public void CapitalizeWord_WithStringWithWhiteSpace_ReturnsCapitalizedWord()
        {
            string result = Strings.CapitalizeWord("    luke    ");

            Assert.AreEqual("Luke", result);
        }

        [Test]
        public void CapitalizeWord_WithNullOrEmptyOrWhiteSpaceString_ReturnsNullStringParsed()
        {
            string result1 = Strings.CapitalizeWord(string.Empty);
            string result2 = Strings.CapitalizeWord(null);
            string result3 = Strings.CapitalizeWord("   ");// Intentional whitespace

            Assert.AreEqual(string.Empty, result1);
            Assert.AreEqual(null, result2);
            Assert.AreEqual("   ", result3);
        }

        [Test]
        public void CapitalizeWord_WithStringStartingWithPunctuation_ReturnsWordUnchanged()
        {
            string result = Strings.CapitalizeWord("-luke");

            Assert.AreEqual("-luke", result);
        }

        [Test]
        public void CapitalizeWord_WithMultipleWordPassed_ReturnsOnlyFirstWordCapatalized()
        {
            string result = Strings.CapitalizeWord("luke warren");

            Assert.AreEqual("Luke warren", result);
        }

        [Test]
        public void CapitalizeSentence_WithLowerSentence_ReturnsSentenceCapatalized()
        {
            string result = Strings.CapitalizeSentence("luke warren is cool");

            Assert.AreEqual("Luke Warren Is Cool", result);
        }

        [Test]
        public void CapitalizeSentence_WithUpperSentence_ReturnsSentenceCapatalized()
        {
            string result = Strings.CapitalizeSentence("LUKE WARREN IS COOL");

            Assert.AreEqual("Luke Warren Is Cool", result);
        }

        [Test]
        public void CapitalizeSentence_WithSentenceSurroundedByWhitespace_ReturnsSentenceCapatalized()
        {
            string result = Strings.CapitalizeSentence("   luke warren is cool   ");

            Assert.AreEqual("Luke Warren Is Cool", result);
        }

        [Test]
        public void CapitalizeSentence_WithNullEmptyOrWhitespaceSentence_ReturnsParsedSentence()
        {
            string result1 = Strings.CapitalizeSentence("   ");
            string result2 = Strings.CapitalizeSentence(null);
            string result3 = Strings.CapitalizeSentence(string.Empty);

            Assert.AreEqual("   ", result1);
            Assert.AreEqual(null, result2);
            Assert.AreEqual(string.Empty, result3);
        }

        #endregion
    }
}