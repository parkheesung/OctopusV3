using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopusV3.Builder
{
    public class SystemQuery
    {
        public const string TableViewSelect = @"
select 'TABLE' as ObjectType, [object_id],[name] from sys.tables where [name] <> '__RefactorLog'
union select 'VIEW',[object_id],[name] from sys.views
order by [name] asc
        ";

        public const string DatabaseSelect = "select * from sys.databases where [name] not in ('master','tempdb','model','msdb')";

        public const string SPSelect = "select [name] from sys.procedures order by [name] asc";

        public const string SPwithTable = @"select DISTINCT A.[name], B.[depid], C.[name] as TableName from SYSOBJECTS as A with(nolock)
inner join SYSDEPENDS as B with(nolock) on A.id = B.id
inner join SYSOBJECTS as C with (nolock) on C.id = B.depid and C.xtype = 'U'
where A.xtype = 'P'
order by A.[name] asc";

        public const string SPParamAll = @"
select
	A.[name]
,	B.[name] as [type]
,	A.max_length
,	A.is_output
,	A.has_default_value
,	A.is_nullable
,	C.[name] as SPName
from sys.parameters as A with (nolock)
inner join sys.types as B with (nolock) on A.system_type_id = B.system_type_id and A.user_type_id = B.user_type_id 
inner join sys.procedures as C with (nolock) on A.[object_id] = C.[object_id] 
order by A.parameter_id asc
";

        public const string tableColumnAll = @"
select
	A.TableID
,	A.TableName
,	B.[name] as ColumnName
,	B.column_id
,	C.[name] as ColumnType
,	C.max_length as ColumnMaxLength
,	(case when C.[name] = 'nvarchar' or C.[name] = 'nchar' then (B.max_length/2) else B.max_length end) as max_length
,	B.is_nullable
,	B.is_identity
,	D.[value] as [Description]
from (select [object_id] as TableID,[name] as TableName from sys.tables union select [object_id] as TableID,[name] as TableName from sys.views) as A
inner join sys.all_columns as B on A.TableID = B.[object_id]
inner join sys.types as C on B.[system_type_id] = C.[system_type_id] and B.user_type_id = C.user_type_id
left outer join sys.extended_properties as D on D.major_id = B.[object_id] and D.minor_id = B.column_id and D.[name] = 'MS_Description'
where A.TableName <> '__RefactorLog'
            ";

        public static string TableInfo(string tableName)
        {
            string query = $@"
select
	A.TableID
,	A.TableName
,	B.[name] as ColumnName
,	B.column_id
,	C.[name] as ColumnType
,	C.max_length as ColumnMaxLength
,	(case when C.[name] = 'nvarchar' or C.[name] = 'nchar' then (B.max_length/2) else B.max_length end) as max_length
,	B.is_nullable
,	B.is_identity
,	D.[value] as [Description]
from (select [object_id] as TableID,[name] as TableName from sys.tables union select [object_id] as TableID,[name] as TableName from sys.views) as A
inner join sys.all_columns as B on A.TableID = B.[object_id]
inner join sys.types as C on B.[system_type_id] = C.[system_type_id] and B.user_type_id = C.user_type_id
left outer join sys.extended_properties as D on D.major_id = B.[object_id] and D.minor_id = B.column_id and D.[name] = 'MS_Description'
where A.TableName = '{tableName}'
            ";

            return query;
        }
    }
}
