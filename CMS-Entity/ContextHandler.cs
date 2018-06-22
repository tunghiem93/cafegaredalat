
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using CMS_Entity;
using CMS_Entity.Initialization;
using CMS_Entity.Entity;

namespace CMS_Entity
{
    public class ContextHandler : CreateDatabaseIfNotExists<CMS_Context>
    {

        protected override void Seed(CMS_Context context)
        {
            base.Seed(context);
            CreateDefaultData(context);
        }

        public override void InitializeDatabase(CMS_Context context)
        {
            try
            {
                if (context.Database.Exists()) return;
                base.InitializeDatabase(context);
            }
            catch (SqlException ex) { throw new ArgumentException(ex.Message, ex); }
        }

        private void CreateDefaultData(CMS_Context context)
        {
            try
            {
              
                var hier = HierarchyData.HierarchyConfigs;

                /*-- Insert Employee --*/
                #region -- Employee --
                if (hier.Employees != null && hier.Employees.Count > 0)
                {
                    foreach (EmployeeConfigElement pro in hier.Employees)
                    {
                        var emp = new CMS_Employee()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Employee_Email = pro.Email,
                            Employee_Phone = "",
                            FirstName ="FirstName",
                            LastName = "LastName",
                            IsActive = true,
                            BirthDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            CreatedDate = DateTime.Now,
                            Password = "5bodbeBGJXU="
                        };
                        context.CMS_Employees.Add(emp);
                    }
                }
                #endregion
                    

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private static bool FindError(SqlErrorCollection errors, string error)
        {
            return errors.Cast<SqlError>().ToList().Exists(x => x.ToString().ToLower().Contains(error));
        }
    }
}
