using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Contacts.Models;
using Xunit;

namespace Contacts.Services.Tests;

public class Utility
{
    [Fact, Category("NotTest")]
    public void Генерирует_большую_адресную_книгу()
    {
        const int countOfContacts = 2_000;
        const string filePath = "Contacts.xml";

        const string emptyFile = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Contacts></Contacts>";

        File.WriteAllText(filePath, emptyFile, Encoding.UTF8);
        var r = new Random();

        var addressBook = LoadAddressBook(filePath);

        for(var i = 0; i < countOfContacts; i++)
        {
            var contact = CreateTestContact(r);

            addressBook.AddContact(contact);
        }
    }

    private static Contact CreateTestContact(Random r)
    {
        var name = CreateTestName(r);
        var phone = CreateTestPhone(r);

        return new Contact { Name = name, Phone = phone };
    }

    private static string CreateTestName(Random r)
    {
        var a = CreateTestName(r, 10);
        var b = CreateTestName(r, 20);
        var c = CreateTestName(r, 10);

        return $"{a} {b} {c}";
    }

    private static string CreateTestName(Random r, int size)
    {
        var c = NextCapitalLetter(r);
        return c + new string(Enumerable.Range(0, r.Next(2, size - 1)).Select(_ => NextLetter(r)).ToArray());
    }

    private static string CreateTestPhone(Random r)
    {
        var a = NextDigitString(r, 3);
        var b = NextDigitString(r, 3);
        var c = NextDigitString(r, 2);
        var d = NextDigitString(r, 2);
        return $"+7-{a}-{b}-{c}-{d}";
    }

    private static IAddressBook LoadAddressBook(string filePath)
    {
        var validator = new ContactValidator();
        var settings = new AddressBookSettings { StorageFilePath = filePath };
        return new AddressBook(settings, validator);
    }

    private static string NextDigitString(Random r, int size) =>
        new(Enumerable.Range(0, size).Select(_ => NextDigit(r)).ToArray());

    private static char NextLetter(Random r)
    {
        var minValue = char.ConvertToUtf32("a", 0);
        var maxValue = char.ConvertToUtf32("z", 0);
        var utf32Code = r.Next(minValue, maxValue+1);

        var s = char.ConvertFromUtf32(utf32Code);
        return s[0];
    }

    private static char NextCapitalLetter(Random r)
    {
        var minValue = char.ConvertToUtf32("A", 0);
        var maxValue = char.ConvertToUtf32("Z", 0);
        var utf32Code = r.Next(minValue, maxValue+1);

        var s = char.ConvertFromUtf32(utf32Code);
        return s[0];
    }

    private static char NextDigit(Random r)
    {
        var minValue = char.ConvertToUtf32("0", 0);
        var maxValue = char.ConvertToUtf32("9", 0);
        var utf32Code = r.Next(minValue, maxValue+1);
        var s = char.ConvertFromUtf32(utf32Code);
        return s[0];
    }
}