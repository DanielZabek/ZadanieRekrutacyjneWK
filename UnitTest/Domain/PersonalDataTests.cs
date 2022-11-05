using Domain.Common;
using Domain.Employees;

namespace UnitTest.Domain
{
    public class PersonalDataTest
    {
        [Fact]
        public void Create_PersonalData_IsSuccessful()
        {
            var personalData = new PersonalData("TestLastName", Gender.Female);
            Assert.Equal("TestLastName", personalData.LastName);
            Assert.Equal(Gender.Female, personalData.Gender);
        }

        [Fact]
        public void Create_PersonalData_WithTooLongLastName_ThrowsOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>("lastName", () => new PersonalData(new string('a', 51), Gender.Female));
        }

        [Fact]
        public void Create_PersonalData_WithNullOrEmptyLastName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("lastName", () => new PersonalData(string.Empty, Gender.Female));
            Assert.Throws<ArgumentNullException>("lastName", () => new PersonalData(null, Gender.Female));
            Assert.Throws<ArgumentNullException>("lastName", () => new PersonalData(" ", Gender.Female));
        }

        [Fact]
        public void Create_PersonalData_WithNullGender_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("gender", () => new PersonalData("test", null));
        }
    }
}