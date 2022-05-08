namespace WebAPI.Controllers
{
    using EntityModelLib;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class EmployeeController : ApiController
    {
        EntityModel context = new EntityModel();

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, context.Employees);
        }
        public HttpResponseMessage Get(int id)
        {

            var employee = context.Employees.Where(p => p.Id == id).FirstOrDefault();
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        public HttpResponseMessage Post(Employee employee)
        {
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            employee = context.Employees.Add(employee);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }
        public IHttpActionResult Put(Employee employee)
        {
            if (employee != null)
            {
                using (var context = new EntityModel())
                {

                    Employee employeeId = (from e in context.Employees
                                               where e.Id == employee.Id
                                               select e).FirstOrDefault();
                    if (employeeId.Id == employee.Id)
                    {
                        employeeId.Name = employee.Name;
                        context.Employees.Add(employeeId);
                        context.SaveChanges();
                        return Ok(context.Employees);

                    }
                }
            }
            return BadRequest();
        }
        public int Delete(object employeeId)
        {
             throw new NotImplementedException();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        //public HttpResponseMessage Delete(EmployeeController @object)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
