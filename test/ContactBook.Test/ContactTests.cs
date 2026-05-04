using Xunit;
using ContactBook;

namespace ContactBook.Tests
{
    public class ContactTests
    {
        [Fact]
        public void Constructor_WithDefaultValues_ShouldSetAllFieldsToEmptyStrings()
        {
            // Arrange & Act
            Contact contact = new Contact();

            // Assert
            Assert.Equal("", contact.GetFName());
            Assert.Equal("", contact.GetLName());
            Assert.Equal("", contact.GetPhone());
            Assert.Equal("", contact.GetEmail());
        }

        [Fact]
        public void Constructor_WithValues_ShouldSetAllFieldsCorrectly()
        {
            // Arrange & Act
            Contact contact = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            // Assert
            Assert.Equal("Gabriela", contact.GetFName());
            Assert.Equal("Rivera", contact.GetLName());
            Assert.Equal("787-123-4567", contact.GetPhone());
            Assert.Equal("gabriela@email.com", contact.GetEmail());
        }

        [Fact]
        public void SetFName_ShouldUpdateFirstName()
        {
            // Arrange
            Contact contact = new Contact();

            // Act
            contact.SetFName("Neithan");

            // Assert
            Assert.Equal("Neithan", contact.GetFName());
        }

        [Fact]
        public void SetLName_ShouldUpdateLastName()
        {
            // Arrange
            Contact contact = new Contact();

            // Act
            contact.SetLName("Rivera");

            // Assert
            Assert.Equal("Rivera", contact.GetLName());
        }

        [Fact]
        public void SetPhone_ShouldUpdatePhone()
        {
            // Arrange
            Contact contact = new Contact();

            // Act
            contact.SetPhone("939-123-0298");

            // Assert
            Assert.Equal("939-123-0298", contact.GetPhone());
        }

        [Fact]
        public void SetEmail_ShouldUpdateEmail()
        {
            // Arrange
            Contact contact = new Contact();

            // Act
            contact.SetEmail("test@email.com");

            // Assert
            Assert.Equal("test@email.com", contact.GetEmail());
        }

        [Fact]
        public void ToString_ShouldReturnFormattedContactString()
        {
            // Arrange
            Contact contact = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            string expected =
                "Contact[fname=Gabriela, lname=Rivera, phone=787-123-4567, email=gabriela@email.com]";

            // Act
            string actual = contact.ToString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equals_WithSameValues_ShouldReturnTrue()
        {
            // Arrange
            Contact contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact contact2 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            // Act & Assert
            Assert.True(contact1.Equals(contact2));
        }

        [Fact]
        public void Equals_WithSameReference_ShouldReturnTrue()
        {
            // Arrange
            Contact contact = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact sameContact = contact;

            // Act & Assert
            Assert.True(contact.Equals(sameContact));
        }

        [Fact]
        public void Equals_WithNullContact_ShouldReturnFalse()
        {
            // Arrange
            Contact contact = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact? nullContact = null;

            // Act & Assert
            Assert.False(contact.Equals(nullContact));
        }

        [Fact]
        public void Equals_WithDifferentObjectType_ShouldReturnFalse()
        {
            // Arrange
            Contact contact = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            object otherObject = "Not a contact";

            // Act & Assert
            Assert.False(contact.Equals(otherObject));
        }

        [Theory]
        [InlineData("Ana", "Rivera", "787-123-4567", "gabriela@email.com")]
        [InlineData("Gabriela", "Santos", "787-123-4567", "gabriela@email.com")]
        [InlineData("Gabriela", "Rivera", "939-000-0000", "gabriela@email.com")]
        [InlineData("Gabriela", "Rivera", "787-123-4567", "other@email.com")]
        public void Equals_WithDifferentFieldValues_ShouldReturnFalse(
            string fname,
            string lname,
            string phone,
            string email)
        {
            // Arrange
            Contact original = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact different = new Contact(fname, lname, phone, email);

            // Act & Assert
            Assert.False(original.Equals(different));
        }

        [Fact]
        public void Equals_ObjectOverride_WithSameContactValues_ShouldReturnTrue()
        {
            // Arrange
            Contact contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            object contact2 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            // Act & Assert
            Assert.True(contact1.Equals(contact2));
        }

        [Fact]
        public void EqualityOperator_WithSameValues_ShouldReturnTrue()
        {
            // Arrange
            Contact contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact contact2 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            // Act & Assert
            Assert.True(contact1 == contact2);
        }

        [Fact]
        public void EqualityOperator_WithDifferentValues_ShouldReturnFalse()
        {
            // Arrange
            Contact contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact contact2 = new Contact(
                "Ana",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            // Act & Assert
            Assert.False(contact1 == contact2);
        }

        [Fact]
        public void EqualityOperator_WithBothNull_ShouldReturnTrue()
        {
            // Arrange
            Contact? contact1 = null;
            Contact? contact2 = null;

            // Act & Assert
            Assert.True(contact1 == contact2);
        }

        [Fact]
        public void EqualityOperator_WithOneNull_ShouldReturnFalse()
        {
            // Arrange
            Contact? contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact? contact2 = null;

            // Act & Assert
            Assert.False(contact1 == contact2);
        }

        [Fact]
        public void InequalityOperator_WithDifferentValues_ShouldReturnTrue()
        {
            // Arrange
            Contact contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact contact2 = new Contact(
                "Ana",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            // Act & Assert
            Assert.True(contact1 != contact2);
        }

        [Fact]
        public void InequalityOperator_WithSameValues_ShouldReturnFalse()
        {
            // Arrange
            Contact contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact contact2 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            // Act & Assert
            Assert.False(contact1 != contact2);
        }

        [Fact]
        public void InequalityOperator_WithBothNull_ShouldReturnFalse()
        {
            // Arrange
            Contact? contact1 = null;
            Contact? contact2 = null;

            // Act & Assert
            Assert.False(contact1 != contact2);
        }

        [Fact]
        public void InequalityOperator_WithOneNull_ShouldReturnTrue()
        {
            // Arrange
            Contact? contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact? contact2 = null;

            // Act & Assert
            Assert.True(contact1 != contact2);
        }

        [Fact]
        public void GetHashCode_WithSameValues_ShouldReturnSameHashCode()
        {
            // Arrange
            Contact contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact contact2 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            // Act
            int hashCode1 = contact1.GetHashCode();
            int hashCode2 = contact2.GetHashCode();

            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }

        [Fact]
        public void GetHashCode_WithDifferentValues_ShouldUsuallyReturnDifferentHashCode()
        {
            // Arrange
            Contact contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact contact2 = new Contact(
                "Ana",
                "Santos",
                "939-000-0000",
                "ana@email.com"
            );

            // Act
            int hashCode1 = contact1.GetHashCode();
            int hashCode2 = contact2.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode1, hashCode2);
        }

        [Fact]
        public void Setters_WithEmptyStrings_ShouldUpdateFieldsToEmptyStrings()
        {
            // Arrange
            Contact contact = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            // Act
            contact.SetFName("");
            contact.SetLName("");
            contact.SetPhone("");
            contact.SetEmail("");

            // Assert
            Assert.Equal("", contact.GetFName());
            Assert.Equal("", contact.GetLName());
            Assert.Equal("", contact.GetPhone());
            Assert.Equal("", contact.GetEmail());
        }

        [Fact]
        public void Contacts_ShouldBeCaseSensitive_WhenCheckingEquality()
        {
            // Arrange
            Contact contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact contact2 = new Contact(
                "gabriela",
                "rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            // Act & Assert
            Assert.False(contact1.Equals(contact2));
            Assert.True(contact1 != contact2);
        }

        [Fact]
        public void Contacts_WithWhitespaceDifferences_ShouldNotBeEqual()
        {
            // Arrange
            Contact contact1 = new Contact(
                "Gabriela",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            Contact contact2 = new Contact(
                " Gabriela ",
                "Rivera",
                "787-123-4567",
                "gabriela@email.com"
            );

            // Act & Assert
            Assert.False(contact1.Equals(contact2));
        }
    }
}