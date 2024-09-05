using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios.Classes;
using Utilitarios.Modelo;

namespace Utilitarios.Entidades
{
    public class TableBase
    {
        public Int64? Id { get; set; }

        public void Insert()
        {
            (string, Hashtable) ObjInsert = Util.MontarInsert(this);

            DbHelper.ExecuteQueryNoReturn(ObjInsert.Item1, ObjInsert.Item2);
        }

        public virtual void Update()
        {
            (string, Hashtable) ObjInsert = Util.MontarUpdate(this);

            DbHelper.ExecuteQueryNoReturn(ObjInsert.Item1, ObjInsert.Item2);
        }

        public virtual void Delete()
        {

        }
       
    }
}
