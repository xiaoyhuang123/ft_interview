using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTInterviewModel;
using FTInterviewDAL;

namespace FTInterviewBLL
{
    public class DepartmentManage
    {
        public static int Add ( Department department )
        {
            return FTInterviewDAL.DepartmentService.Add ( department );

        }
        public static int Delete(int did)//假删
        {
            return FTInterviewDAL.DepartmentService.Delete(did);
        }

        public static List<Department> GetAllDepartment()
        {
            return FTInterviewDAL.DepartmentService.GetAllDepartment();
        }

        public static List<Department> GetDepartmentByName(string depname)
        {
            return FTInterviewDAL.DepartmentService.GetDepartmentByName(depname);
        }

        public static Department GetDepartmentByID(int dep_id)
        {
            return FTInterviewDAL.DepartmentService.GetDepartmentByID(dep_id);
        }

        public static int UpdateDepartment( Department department )
        {
            return FTInterviewDAL.DepartmentService.UpdateDepartment(department);
        }
    }
}
