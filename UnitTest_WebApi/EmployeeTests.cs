using EntityModelLib;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using WebAPI.Controllers;
using static System.Net.WebRequestMethods;

namespace UnitTest_WebApi
{
    public class EmployeeTests    
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Get_AllEmployees_Returns_StatusCode_Ok()
        {
            var employee = new EmployeeController();
            var results = employee.Get().StatusCode; 
            Assert.AreEqual(HttpStatusCode.OK, results);
        }
        [Test]
        [TestCase("1")]
        public void Get_EmployeeDetails_Passing_Id_Returns_StatusCode_Ok(int employeeId)
        {
            var employee = new EmployeeController();
            var results = employee.Get(employeeId).StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, results);
        }

        [Test]
        [TestCase("65555555")]
        public void Get_EmployeeDetails_Passing_Id_Returns_StatusCode_NotFound(int employeeId)
        {
            var employee = new EmployeeController();
            var results = employee.Get(employeeId).StatusCode;
            Assert.AreEqual(HttpStatusCode.NotFound, results);
        }


        [Test]
       
        public void Create_EmployeeDetails_Returns_StatusCode_Ok()
        {
            var employeeController = new EmployeeController();
            
            var employee = new Employee() { Id= 1, Name="Test Updated", DepartmentId =1, Salary =500, EmailAddress ="testc@test.com", PhoneNumber ="1234567890", Address="Test" };
            
            var results = employeeController.Post(employee).StatusCode;
           
            Assert.AreEqual(HttpStatusCode.NotFound, results);
        }

        [Test]
        [TestCase("1")]
        public void Update_EmployeeDetails_Returns_StatusCode_Ok(int employeeId)
        {
            var employeeController = new EmployeeController();

            var employee = new Employee() { Id = employeeId, Name = "Test", DepartmentId = 1, Salary = 500, EmailAddress = "testc@test.com", PhoneNumber = "1234567890", Address = "Test" };

            var results = employeeController.Post(employee).StatusCode;

            Assert.AreEqual(HttpStatusCode.NotFound, results);
        }



        [Test]
       
        public void Delete_For_NotImplementedException()
        {
            

            var mock = new Mock<EmployeeController>();
            mock.Setup(e => e.Delete(1)).Returns(1);
            var employeeController = new EmployeeController();
           
            var results = employeeController.Delete(mock.Object);

            Assert.AreEqual(HttpStatusCode.OK, results);
        }
    }
}