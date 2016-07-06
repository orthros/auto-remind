using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace aurm.notifier.tests
{
    public class SMSRecipientTests
    {
        [Fact]
        public void TestNullName()
        {
            string name = null;
            string number = null;
            Assert.Throws<ArgumentNullException>("name", () =>
             {
                 SMSRecipient rec = new SMSRecipient(name, number);
             });
        }

        [Fact]
        public void TestNullNumber()
        {
            string name = "";
            string number = null;
            Assert.Throws<ArgumentNullException>("phoneNumber", () =>
            {
                SMSRecipient rec = new SMSRecipient(name, number);
            });
        }

        [Fact]
        public void TestValidParametersAreSet()
        {
            string name = "";
            string number = "1234567890";
            SMSRecipient rec = new SMSRecipient(name, number);
            Assert.Equal(number, rec.PhoneNumber);
            Assert.Equal(name, rec.Name);
        }

        [Fact]
        public void TestInvalidNumber()
        {
            string name = "";
            string number = "12345678900001";
            Assert.Throws<ArgumentException>(() =>
            {
                SMSRecipient rec = new SMSRecipient(name, number);
            });
        }

        [Theory]
        [InlineData("3087774825")]
        [InlineData("(281)388-0388")]
        [InlineData("(281)388-0300")]
        [InlineData("(979) 778-0978")]
        [InlineData("(281)934-2479")]
        [InlineData("(281)934-2447")]
        [InlineData("(979)826-3273")]
        [InlineData("(979)826-3255")]
        [InlineData("1334714149")]
        [InlineData("(281)356-2530")]
        [InlineData("(281)356-5264")]
        [InlineData("(936)825-2081")]
        [InlineData("(832)595-9500")]
        [InlineData("(832)595-9501")]
        [InlineData("281-342-2452")]
        [InlineData("1334431660")]
        public void TestPhoneNumberTypes(string number)
        {
            string name = "";
            SMSRecipient rec = new SMSRecipient(name, number);
            Assert.Equal(rec.PhoneNumber, number);
        }
    }
}
