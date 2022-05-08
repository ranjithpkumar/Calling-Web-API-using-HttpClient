namespace WebAPI.Controllers
{
    using EntityModelLib;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    public class DepartmentController : ApiController
    {
        //EntityModel context = new EntityModel();

        public IHttpActionResult Get()
        {
            using (var context = new EntityModel())
            {
                var departments = context.Departments;
                return Ok(departments);
            }
        }
        public IHttpActionResult Get(int id)
        {
            using (var context = new EntityModel())
            {
                Department department = (from d in context.Departments.Include("Employees")
                                         where d.DepartmentId == id
                                         select d).FirstOrDefault();
                if (department == null)
                {
                    return NotFound();
                }
                return Ok(department);
            }
        }

        public IHttpActionResult Post(Department department)
        {
            if (department != null)
            {
                using (var context = new EntityModel())
                {
                    context.Departments.Add(department);
                    context.SaveChanges();
                    return CreatedAtRoute("DefaultApi", new { id = department.DepartmentId }, department);
                }
            }
            return BadRequest();
        }
        public IHttpActionResult Put(Department department)
        {
            if (department != null)
            {
                using (var context = new EntityModel())
                {

                    Department departmentId = (from d in context.Departments.Include("Employees")
                                               where d.DepartmentId == department.DepartmentId
                                               select d).FirstOrDefault();
                    if (departmentId.DepartmentId == department.DepartmentId)
                    {
                        departmentId.DepartmentName = department.DepartmentName;
                        context.Departments.Add(departmentId);
                        context.SaveChanges();
                        return Ok(context.Departments); 

                    }
                }
            }
            return BadRequest();
        }
        public IHttpActionResult Delete(int id)
        {

            using (var context = new EntityModel())
            {

                Department departmentId = (from d in context.Departments.Include("Employees")
                                           where d.DepartmentId == id
                                           select d).FirstOrDefault();
                if (departmentId.DepartmentId == departmentId.DepartmentId)
                {
                    context.Departments.Remove(departmentId);
                    context.SaveChanges();
                    return Ok(context.Departments);

                }
            }

            return BadRequest();
           

        }
    }
}
