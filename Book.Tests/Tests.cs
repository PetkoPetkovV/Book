namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Book book;
        [SetUp]
        public void Setup()
        {
            book = new Book("bogat tatko, beden tatko", "Robert Kiyosaki");
            book.AddFootnote(5, "houseOfDragon");
        }
        [Test]
        public void FootNote_IsValid()
        {
            var expectedCollection = book.FootnoteCount;
            Assert.AreEqual(expectedCollection, 1);
        }
        [Test]
        public void Name_IsNull()
        {
            Assert.Throws<ArgumentException>(() => new Book(null, "ico"));
        }
        [Test]
        public void Name_isCorrectly()
        {
            var exp = "bogat tatko, beden tatko";
            Assert.AreEqual(exp, "bogat tatko, beden tatko");
        }
        [Test]
        public void Author_IsNull()
        {
            Assert.Throws<ArgumentException>(() => new Book("panam", null));
        }
        [Test]
        public void Author_IsCorrectly()
        {
            var exp = "Robert Kiyosaki";
            Assert.AreEqual(exp, "Robert Kiyosaki");
        }
        [Test]
        public void FootNote_IsContains()
        {
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(5, "houseOfDragon"));
        }
        [Test]
        public void FootNote_IsCorrectly()
        {
            book.AddFootnote(50, "Renal");

            Assert.AreEqual(2, book.FootnoteCount);
        }
        [Test]
        public void FindFootNote_IsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(500051));
        }
        [Test]
        public void FindFootNote_CorrectlyWorking()
        {
            var demo = book.FindFootnote(5);
            Assert.AreEqual(demo,book.FindFootnote(5));
        }
        [Test]
        public void FindAlterFootNote_IsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(500051, "alibaba"));
        }
        [Test]
        public void FindAlterFootNote_IsWorkingCorrectly()
        {
            book.AlterFootnote(500, "newText");
            book.AddFootnote(500, "newText");
            var exp = book.FindFootnote(500);
            Assert.AreEqual(exp, "newText");
        }

        [Test]
        public void FindAlterFootNote_IsWorkingCorrectly1()
        {
            book.AddFootnote(7, "defy");
            book.AlterFootnote(7, "resemble");
            Assert.AreEqual("Footnote #7: resemble", book.FindFootnote(7));
           
            
        }

    }
}