﻿using Common.Core.AOP.Cache;

namespace Domain;

public abstract class Reference : IReference
{
    public string Code { get; set; }
    public string CacheFieldName { get; set; }

    public string CacheCode
    {
        get
        {
            return CacheFieldName.Equals(string.Empty)
                        ? string.Empty
                        : string.Concat(CacheFieldName, Code);
        }
    }

    public Reference(string code, string fieldName)
    {
        Code = code;
        CacheFieldName = fieldName;
    }

    public override bool Equals(object? obj)
    {
        return Code.Equals(((IReference)obj!).Code);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
