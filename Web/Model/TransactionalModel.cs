using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Montessari.Model
{
    public class TransactionalModel
    {
        public bool ReturnStatus { get; set; }
        public string ErrorMessage { get; set; }
        public int iTotalPageCount { get; set; }
        public int iRowCount { get; set; }
        public int PageSize { get; set; }
        public Boolean IsAuthenicated { get; set; }
        public string SortExpression { get; set; }
        public int? SortDirection { get; set; }
        public int PageNumber { get; set; }

        public string UserName { get; set; }
        public int RowUserCode { get; set; }
        public TransactionalModel()
        {
            ErrorMessage = "";
            ReturnStatus = true;
            iTotalPageCount = 0;
            iRowCount = 0;
            PageSize = 1;
            IsAuthenicated = false;
        }
    }
}