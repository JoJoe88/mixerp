// ReSharper disable All
/********************************************************************************
Copyright (C) MixERP Inc. (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.


MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/
// ReSharper disable All
using PetaPoco;
using System;

namespace MixERP.Net.Entities.Core
{
    [PrimaryKey("compound_item_id", autoIncrement = true)]
    [TableName("core.compound_items")]
    [ExplicitColumns]
    public sealed class CompoundItem : PetaPocoDB.Record<CompoundItem>, IPoco
    {
        [Column("compound_item_id")]
        [ColumnDbType("int4", 0, false, "nextval('core.compound_items_compound_item_id_seq'::regclass)")]
        public int CompoundItemId { get; set; }

        [Column("compound_item_code")]
        [ColumnDbType("varchar", 12, false, "")]
        public string CompoundItemCode { get; set; }

        [Column("compound_item_name")]
        [ColumnDbType("varchar", 150, false, "")]
        public string CompoundItemName { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}