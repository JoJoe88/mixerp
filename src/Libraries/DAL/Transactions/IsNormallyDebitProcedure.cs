// ReSharper disable All
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using MixERP.Net.Framework.Extensions;
using PetaPoco;
using MixERP.Net.Entities.Transactions;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Transactions.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "transactions.is_normally_debit(_account_id bigint)" on the database.
    /// </summary>
    public class IsNormallyDebitProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "transactions";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "is_normally_debit";
        /// <summary>
        /// Login id of application user accessing this PostgreSQL function.
        /// </summary>
        public long _LoginId { get; set; }
        /// <summary>
        /// User id of application user accessing this table.
        /// </summary>
        public int _UserId { get; set; }
        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string _Catalog { get; set; }

        /// <summary>
        /// Maps to "_account_id" argument of the function "transactions.is_normally_debit".
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.is_normally_debit(_account_id bigint)" on the database.
        /// </summary>
        public IsNormallyDebitProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.is_normally_debit(_account_id bigint)" on the database.
        /// </summary>
        /// <param name="accountId">Enter argument value for "_account_id" parameter of the function "transactions.is_normally_debit".</param>
        public IsNormallyDebitProcedure(long accountId)
        {
            this.AccountId = accountId;
        }
        /// <summary>
        /// Prepares and executes the function "transactions.is_normally_debit".
        /// </summary>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public bool Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"IsNormallyDebitProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            string query = "SELECT * FROM transactions.is_normally_debit(@AccountId);";

            query = query.ReplaceWholeWord("@AccountId", "@0::bigint");


            List<object> parameters = new List<object>();
            parameters.Add(this.AccountId);

            return Factory.Scalar<bool>(this._Catalog, query, parameters.ToArray());
        }


    }
}