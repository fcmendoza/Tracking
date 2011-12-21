


  
using System;
using SubSonic;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Tracking.DataAccess{
	public partial class TrackinDB{

		public StoredProcedure SaveTransaction(long? TransactionID,string Description,decimal? Amount,DateTime? Date,string Tags){
			StoredProcedure sp=new StoredProcedure("SaveTransaction",this.Provider);
			sp.Command.AddParameter("TransactionID",TransactionID,DbType.Int64);
			sp.Command.AddParameter("Description",Description,DbType.AnsiString);
			sp.Command.AddParameter("Amount",Amount,DbType.Currency);
			sp.Command.AddParameter("Date",Date,DbType.DateTime);
			sp.Command.AddParameter("Tags",Tags,DbType.AnsiString);
			return sp;
		}
		public StoredProcedure SaveTransaction2(long? TransactionID,string Description,decimal? Amount,DateTime? Date,string Tags){
			StoredProcedure sp=new StoredProcedure("SaveTransaction2",this.Provider);
			sp.Command.AddParameter("TransactionID",TransactionID,DbType.Int64);
			sp.Command.AddParameter("Description",Description,DbType.AnsiString);
			sp.Command.AddParameter("Amount",Amount,DbType.Currency);
			sp.Command.AddParameter("Date",Date,DbType.DateTime);
			sp.Command.AddParameter("Tags",Tags,DbType.AnsiString);
			return sp;
		}
	
	}
	
}
 