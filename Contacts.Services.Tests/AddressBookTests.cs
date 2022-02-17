using System;
using System.IO;
using System.Linq;
using Contacts.Models;
using FluentAssertions;
using Xunit;

namespace Contacts.Services.Tests;

public class AddressBookTests
{
    [Fact]
    public void Возвращается_список_контактов()
    {
        var addressBook = LoadAddressBook("Contacts.xml");

        var persons = addressBook.GetContacts().ToList();

        persons.Count().Should().Be(3);
        persons[0].Name.Should().Be("Abc");
        persons[2].Phone.Should().Be("+7-903-215-00-02");

        persons[2].Phone = "+7-903-215-00-22";

        var persons2 = addressBook.GetContacts().ToList();

        persons2.Count().Should().Be(3);
        persons2[0].Name.Should().Be("Abc");
        persons2[2].Phone.Should().Be("+7-903-215-00-02");
    }

    [Fact]
    public void Добавляется_новый_контакт()
    {
        File.Copy("Contacts.xml", "ContactsTest.xml", overwrite: true);

        var addressBook = LoadAddressBook("ContactsTest.xml");

        addressBook.AddContact(new Contact { Name = "NewPerson", Phone = "+7-800-250-00-01" });

        var persons = addressBook.GetContacts().ToList();

        persons.Count().Should().Be(4);
        persons[3].Phone.Should().Be("+7-800-250-00-01");
    }

    [Fact]
    public void Удаляется_контакт()
    {
        File.Copy("Contacts.xml", "ContactsTest.xml", overwrite: true);

        var addressBook = LoadAddressBook("ContactsTest.xml");

        addressBook.DeleteContact(contactId: 2);

        var persons = addressBook.GetContacts().ToList();

        persons.Count().Should().Be(2);
        persons[0].ContactId.Should().Be(1);
        persons[1].ContactId.Should().Be(3);
    }

    [Fact]
    public void Отклоняется_некорректный_ИД_контакта_при_удалении()
    {
        var addressBook = LoadAddressBook("Contacts.xml");

        Assert.Throws<ArgumentOutOfRangeException>(() => addressBook.DeleteContact(contactId: 12));
    }

    [Fact]
    public void Отклоняется_некорректный_ИД_контакта_при_изменении()
    {
        var addressBook = LoadAddressBook("Contacts.xml");

        Assert.Throws<ArgumentOutOfRangeException>(() => addressBook.DeleteContact(contactId: 12));
    }

    [Fact]
    public void Изменяется_контакт()
    {
        File.Copy("Contacts.xml", "ContactsTest.xml", overwrite: true);

        var addressBook = LoadAddressBook("ContactsTest.xml");

        var persons = addressBook.GetContacts().ToList();

        persons[2].Name = "Name2";
        persons[2].Phone = "+7-000-000-00-00";

        addressBook.UpdateContact(persons[2]);

        persons.Count().Should().Be(3);
        persons[2].Name.Should().Be("Name2");
        persons[2].Phone.Should().Be("+7-000-000-00-00");
    }

    private static IAddressBook LoadAddressBook(string filePath)
    {
        var validator = new ContactValidator();
        var settings = new AddressBookSettings { StorageFilePath = filePath };
        return new AddressBook(settings, validator);
    }
}