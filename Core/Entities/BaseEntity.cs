using System;

namespace Core.Entities;

public class BaseEntity<T> 
{
    public T Id { get; set; }

    // public bool Equals(BaseEntity<T>? other)
    // {
    //     if (other is null) return false;
    //     if (ReferenceEquals(this, other)) return true;
    //     return Id.Equals(other.Id);
    // }

    // public override int GetHashCode() => Id.GetHashCode();

    // public override bool Equals(object? obj) => Equals(obj as BaseEntity<T>);

}
