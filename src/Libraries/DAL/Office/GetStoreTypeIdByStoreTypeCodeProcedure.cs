// ReSharper disable All
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using MixERP.Net.Framework.Extensions;
using PetaPoco;
using MixERP.Net.Entities.Office;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Office.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "office.get_store_type_id_by_store_type_code(_store_type_code text)" on the database.
    /// </summary>
    public class GetStoreTypeIdByStoreTypeCodeProcedure : DbAccess, IGetStoreTypeIdByStoreTypeCodeRepository
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "office";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "get_store_type_id_by_store_type_code";
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
        /// Maps to "_store_type_code" argument of the function "office.get_store_type_id_by_store_type_code".
        /// </summary>
        public string StoreTypeCode { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "office.get_store_type_id_by_store_type_code(_store_type_code text)" on the database.
        /// </summary>
        public GetStoreTypeIdByStoreTypeCodeProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "office.get_store_type_id_by_store_type_code(_store_type_code text)" on the database.
        /// </summary>
        /// <param name="storeTypeCode">Enter argument value for "_store_type_code" parameter of the function "office.get_store_type_id_by_store_type_code".</param>
        public GetStoreTypeIdByStoreTypeCodeProcedure(string storeTypeCode)
        {
            this.StoreTypeCode = storeTypeCode;
        }
        /// <summary>
        /// Prepares and executes the function "office.get_store_type_id_by_store_type_code".
        /// </summary>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public int Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"GetStoreTypeIdByStoreTypeCodeProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            string query = "SELECT * FROM office.get_store_type_id_by_store_type_code(@StoreTypeCode);";

            query = query.ReplaceWholeWord("@StoreTypeCode", "@0::text");


            List<object> parameters = new List<object>();
            parameters.Add(this.StoreTypeCode);

            return Factory.Scalar<int>(this._Catalog, query, parameters.ToArray());
        }


    }
}