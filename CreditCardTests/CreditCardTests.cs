using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// These are unit tests for a coding exercise to implement a library to handle
/// some simple checks against the format of a credit card number. No GUI or
/// command-line interface is necessary. The following tests specify how the
/// library needs to work.
/// 
/// Your implementation must pass all of these existing tests, which should not
/// be changed.For behavior that is not explicitly specified, feel free to add
/// additional tests.
/// 
/// Implementations should exhibit best practices and common coding conventions.
/// When you are brought in for a face-to-face interview, we will discuss your
/// implementation and possibly make modifications.
/// 
/// These unit tests use the Microsoft Unit Testing (MSTest) framework.
/// Reference the following wiki for http://en.wikipedia.org/wiki/Bank_card_number
/// </summary>
namespace Coveros.CreditCards {
    [TestClass]
    public class CreditCardTests {
        [TestMethod]
        public void TestCalculateCheckDigit() {
            Assert.AreEqual(1, CreditCard.CalculateCheckDigit("4111 1111 1111 111"));
        }

        [TestMethod]
        [ExpectedException(typeof(BadCheckDigitException))]
        public void TestBadCheckDigit() {
            new CreditCard("4111 1111 1111 1110");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCardLengthException))]
        public void TestShortValidCheckDigit() {
            new CreditCard("411-111-111-117");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCardLengthException))]
        public void TestLongValidCheckDigit() {
            new CreditCard("4111 1111 1111 1111 3");
        }

        [TestMethod]
        [ExpectedException(typeof(BadCheckDigitException))]
        public void TestLongInvalidCheck() {
            new CreditCard("4111 1111 1111 1111 9");
        }

        [TestMethod]
        public void TestCardTypeVisa() {
            CreditCard creditCard = new CreditCard("4111 1111 1111 1111");
            Assert.AreEqual(CreditCardType.VISA, creditCard.CardType);
        }

        [TestMethod]
        public void TestGetCardMasterCard() {
            CreditCard creditCard = new CreditCard("5555 5555 5555 4444");
            Assert.AreEqual(CreditCardType.MASTERCARD, creditCard.CardType);
        }

        [TestMethod]
        public void TestGetCardAmericanExpress34() {
            CreditCard creditCard = new CreditCard("3411 111111 11111");
            Assert.AreEqual(CreditCardType.AMERICAN_EXPRESS, creditCard.CardType);
        }

        [TestMethod]
        public void TestGetCardAmericanExpress37() {
            CreditCard creditCard = new CreditCard("3700-000000-00002");
            Assert.AreEqual(CreditCardType.AMERICAN_EXPRESS, creditCard.CardType);
        }

        [TestMethod]
        public void TestGetCardDiscover() {
            CreditCard creditCard = new CreditCard("6011111111111117");
            Assert.AreEqual(CreditCardType.DISCOVER_CARD, creditCard.CardType);
        }

        [TestMethod]
        public void TestGetCardUnknown() {
            CreditCard creditCard = new CreditCard("9999 9999 9999 9995");
            Assert.AreEqual(CreditCardType.UNKNOWN, creditCard.CardType);
        }
    }
}
