using Application.Employees.CreateEmployee;
using Domain.Common;
using Domain.Employees;
using MediatR;
using Moq;
using UnitTest.Mocs;

namespace UnitTest.Application
{
    public class CreateEmployeeComandHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        public CreateEmployeeComandHandlerTests()
        {
            _employeeRepositoryMock = MockEmployeeRepository.GetEmployeeRepository();
        }

        [Fact]
        public async Task CreateEmployee_IsSuccessful()
        {
            var employees = await _employeeRepositoryMock.Object.GetAllAsync();
            var employeesCount = employees.Count();
            var handler = new CreateEmployeeCommandHandler(_employeeRepositoryMock.Object);
            var result = await handler.Handle(new CreateEmployeeCommand("TestLastName", Gender.Male), CancellationToken.None);
            Assert.IsType<Unit>(result);
            
            var employeesAfterAdded = await _employeeRepositoryMock.Object.GetAllAsync();
            Assert.Equal(employeesCount + 1, employeesAfterAdded.Count());
        }

        [Fact]
        public async Task CreateEmployee_WithNullCommand_ThrowArgumentNullException()
        {
            var handler = new CreateEmployeeCommandHandler(_employeeRepositoryMock.Object);
            await Assert.ThrowsAsync<ArgumentNullException>("command", () => handler.Handle(null, CancellationToken.None));
        }
    }
}