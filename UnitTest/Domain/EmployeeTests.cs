using Domain.Employees;

namespace UnitTest.Domain
{
    public class EmployeeTests
    {
        [Fact]
        public void CreateEmployee_IsSuccessful()
        {
            ReferenceNumberHelper.SetCurrentValue("00000001");
            var personalData = new PersonalData("TestLastName", Gender.Male);
            var employee = new Employee(personalData);

            Assert.Equal(personalData, employee.PersonalData);
            Assert.Equal("00000002", employee.ReferenceNumber.Number);
            Assert.NotEqual(employee.Id, Guid.Empty);
        }

        [Fact]
        public void UpdateEmployee_IsSuccessful()
        {
            var employee = new Employee(new PersonalData("TestLastName", Gender.Male));
            var newPersonalData = new PersonalData("EditedLastName", Gender.Female);
            employee.UpdatePersonalData(newPersonalData);
            Assert.Equal(newPersonalData, employee.PersonalData);
        }
    }
}