using aurm.core.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace aurm.core.tests.utilities
{
    public class PhoneUtilsTests
    {
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

            var value = PhoneUtils.IsValidNumber(number);
            Assert.True(value);
        }
    }
}
