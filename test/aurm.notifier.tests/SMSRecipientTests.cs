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
    }
}
