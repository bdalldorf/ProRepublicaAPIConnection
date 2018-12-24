using System;
using System.Reflection;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ProRepCongressLookup.Models;
using System.Collections.Generic;

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

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
class JsonPropertyNameByTypeAttribute : Attribute
{
    public string PropertyName { get; set; }
    public Type ObjectType { get; set; }

    public JsonPropertyNameByTypeAttribute(string propertyName, Type objectType)
    {
        PropertyName = propertyName;
        ObjectType = objectType;
    }
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
class JsonPropertyListByTypeAttribute : Attribute
{
    public string PropertyName { get; set; }
    public Type ObjectType { get; set; }

    public JsonPropertyListByTypeAttribute(string propertyName, Type objectType)
    {
        PropertyName = propertyName;
        ObjectType = objectType;
    }
}

class JsonPropertyNameByResultAttribute : Attribute
{
    public string PropertyName { get; set; }

    public JsonPropertyNameByResultAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }
}

class JsonPropertyNameByBaseAttribute : Attribute
{
    public string PropertyName { get; set; }

    public JsonPropertyNameByBaseAttribute(string propertyName)
    {
        PropertyName = propertyName;
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

public class DynamicPropertyNameConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        Type Type = value.GetType();
        JObject JsonObject = new JObject();

        foreach (PropertyInfo propInfo in Type.GetProperties().Where(p => p.CanRead))
        {
            string PropertyName = propInfo.Name;
            object PropertyValue = propInfo.GetValue(value, null);
            JToken Token = (PropertyValue != null) ? JToken.FromObject(PropertyValue, serializer) : JValue.CreateNull();

            if (PropertyValue != null && propInfo.PropertyType == typeof(object))
            {
                JsonPropertyNameByTypeAttribute JsonPropertyName = propInfo.GetCustomAttributes<JsonPropertyNameByTypeAttribute>()
                    .FirstOrDefault(a => a.ObjectType.IsAssignableFrom(PropertyValue.GetType()));

                if (JsonPropertyName != null)
                    PropertyName = JsonPropertyName.PropertyName;
            }

            JsonObject.Add(PropertyName, Token);
        }

        JsonObject.WriteTo(writer);
    }

    public override bool CanRead
    {
        get { return true; }
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        object Instance = Activator.CreateInstance(objectType);
        var Properties = objectType.GetTypeInfo().DeclaredProperties.ToList();

        JObject JsonObject = JObject.Load(reader);
        foreach (JProperty JsonProperty in JsonObject.Properties())
        {
            
            PropertyInfo PropertyInfo = Properties.FirstOrDefault(pi =>
                pi.CanWrite && pi.GetCustomAttribute<JsonPropertyNameByTypeAttribute>()?.PropertyName == JsonProperty.Name);

            if (PropertyInfo == null)
                PropertyInfo = Properties.FirstOrDefault(pi =>
                pi.CanWrite && pi.GetCustomAttribute<JsonPropertyNameByResultAttribute>()?.PropertyName == JsonProperty.Name);

            if (PropertyInfo == null)
                PropertyInfo = Properties.FirstOrDefault(pi =>
                pi.CanWrite && pi.GetCustomAttribute<JsonPropertyNameByBaseAttribute>()?.PropertyName == JsonProperty.Name);

            PropertyInfo?.SetValue(Instance, JsonProperty.Value.ToObject(PropertyInfo.PropertyType, serializer));
        }

        return Instance;
    }

    public override bool CanConvert(Type objectType)
    {
        // CanConvert is not called if a [JsonConverter] attribute is used
        return false;
    }
}