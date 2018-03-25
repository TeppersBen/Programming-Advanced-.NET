namespace School.Data.Migrations
{
    using School.Data.DomainClasses;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SchoolDB context)
        {
            context.Departments.AddOrUpdate(d => d.Name, new Department { Name = "PXL-IT" }, new Department { Name = "PXL-TECH" }, new Department { Name = "PXL-BUSINESS" });

            context.SaveChanges();

            var pxlIT = context.Departments.First(d => d.Name == "PXL-IT");

            context.Courses.AddOrUpdate(c => c.Title, new Course { Title = "Programming Advanced", Credits = 9, DepartmentID = pxlIT.DepartmentID }, new Course { Title = ".Net Advanced", Credits = 3, DepartmentID = pxlIT.DepartmentID }, new Course { Title = "Java Advanced", Credits = 3, DepartmentID = pxlIT.DepartmentID });
        }
    }
}
