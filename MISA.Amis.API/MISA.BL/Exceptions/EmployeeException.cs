using System;

namespace MISA.BL.Exceptions
{
    public class EmployeeException : Exception
    {
        public EmployeeException(string msg) : base(msg)
        {
        }

        public EmployeeException(string msg, string employeeCode) : base(msg)
        {
        }
    }
}