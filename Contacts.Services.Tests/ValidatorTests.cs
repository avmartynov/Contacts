using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Contacts.Services.Tests;

public class ValidatorTests
{
    [Theory] [MemberData(nameof(ValidNames))]
    public void Принимается_действительное_имя(string name)
    {
        new ContactValidator().ValidateName(name, out _).Should().BeTrue();
    }

    [Theory] [MemberData(nameof(InvalidNames))]
    public void Отклоняется_недействительное_имя(string name)
    {
        new ContactValidator().ValidateName(name, out _).Should().BeFalse();
    }

    [Theory] [MemberData(nameof(ValidPhones))]
    public void Принимается_действительный_номер_телефона(string phone)
    {
        new ContactValidator().ValidatePhone(phone, out _).Should().BeTrue();
    }

    [Theory] [MemberData(nameof(InvalidPhones))]
    public void Отклоняется_недействительный_номер_телефона(string phone)
    {
        new ContactValidator().ValidatePhone(phone, out _).Should().BeFalse();
    }


    private static IEnumerable<object[]> ValidNames() => new[]
    {
        "Az",
        "   GH   \t  ",
        "Asasdfasdf   GH   \t     ",
        "              Asasdfasdf   GH   \t     ",
    }.Select(x => new[] { x });

    private static IEnumerable<object[]> InvalidNames() => new[]
    {
        "A",
        "   G   \t  ",
        "Asasdfasdf   GH   \t  fasd asd fasd fsad fsad sadf asdf  asdf asdfas  ",
        "              Asasdfasdf   GH   \t     asdf asd fasdf asdf asdf asdf asdf asdf ",
    }.Select(x => new[] { x });

    private static IEnumerable<object[]> ValidPhones() => new[]
    {
        "+7-903-215-44-44",
        "+7-003-000-00-00",
    }.Select(x => new[] { x });

    private static IEnumerable<object[]> InvalidPhones() => new[]
    {
        "+8-903-215-44-44",
        "+71-903-215-44-44",
        "+7-90-215-44-44",
        "+7-903-215-44",
        "+7-903-215-44-1",
        "-7-903-215-44-15",
        "+7-90ф-215-44-15",
        "+7-9 0-215-44-15",
        "+7 903-215-44-15",
        "+7-(903)-215-4415",
        "+7 (903)215 4415",
    }.Select(x => new[] { x });
}
