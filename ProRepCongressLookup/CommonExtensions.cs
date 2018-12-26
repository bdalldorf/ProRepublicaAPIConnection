using System;
using System.Reflection;
using System.Linq;
using System.ComponentModel;
#region Attributes

public class TableFieldNameAttribute : Attribute
{
    public string FieldName { get; }

    internal TableFieldNameAttribute(string fieldName)
    {
        FieldName = fieldName;

        if (FieldName == null) FieldName = string.Empty;
    }
}

public class TableFieldExcludeFromUpdateAttribute : Attribute
{
    public bool ExcludeFromUpdate { get; }

    internal TableFieldExcludeFromUpdateAttribute(bool excludeFromUpdate)
    {
        ExcludeFromUpdate = excludeFromUpdate;
    }
}

public class TableFieldExcludeFromInsertAttribute : Attribute
{
    public bool ExcludeFromInsert { get; }

    internal TableFieldExcludeFromInsertAttribute(bool excludeFromInsert)
    {
        ExcludeFromInsert = excludeFromInsert;
    }
}

public class TableNameAttribute : Attribute
{
    public string TableName { get; }

    internal TableNameAttribute(string tableName)
    {
        TableName = tableName;

        if (TableName == null) TableName = string.Empty;
    }
}

#endregion

#region Class Extensions
public static class ClassExtension
{
}

#endregion

#region Integer Extensions

public static class IntegerExtension
{
    public static bool ExcludeFromUpdate(this bool value)
    {
        return value.GetType()
                        .GetCustomAttribute<TableFieldExcludeFromUpdateAttribute>()
                        .ExcludeFromUpdate;
    }

    public static bool ExcludeFromInsert(this bool value)
    {
        return value.GetType()
                        .GetCustomAttribute<TableFieldExcludeFromInsertAttribute>()
                        .ExcludeFromInsert;
    }
}
#endregion

#region String Extensions

public static class StringExtension
{
    public static bool ExcludeFromUpdate(this bool value)
    {
        return value.GetType()
                        .GetCustomAttribute<TableFieldExcludeFromUpdateAttribute>()
                        .ExcludeFromUpdate;
    }

    public static bool ExcludeFromInsert(this bool value)
    {
        return value.GetType()
                        .GetCustomAttribute<TableFieldExcludeFromInsertAttribute>()
                        .ExcludeFromInsert;
    }
}

#endregion

#region  Enumerations Extensions

public static class EnumerationExtension
{
    public static string Description(this Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DescriptionAttribute>()
                        .Description;
    }

    public static string TableFieldName(this Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<TableFieldNameAttribute>()
                        .FieldName;
    }
}

#endregion