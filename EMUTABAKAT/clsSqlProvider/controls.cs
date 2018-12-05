using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorukProvider
{
    public class controls
    {

        public int typeID { get; set; }
        public int termId { get; set; }
        public int agYear { get; set; }
        private clsSqlProvider sqlProvider;

        public controls(string conStr)
        {

            sqlProvider = new clsSqlProvider(conStr);

        }

        public int termYearTypeCounter()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(AG.ID) FROM EMUTABAKAT.[dbo].[TBL_CURRENT_AGGREMENT] AG  WHERE ");
            sb.AppendFormat(" TYPE_ID={0} AND  " , this.typeID);
            sb.AppendFormat(" AG.TERMID={0} AND " , this.termId);
            sb.AppendFormat(" AG.AG_YEAR={0} ", this.agYear);

            int result = 0;


            result = Convert.ToInt32( sqlProvider.scalarMethod(sb.ToString(), false) );


            return result;
        }
    }
}
