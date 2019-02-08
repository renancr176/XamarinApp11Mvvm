using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace XamarinApp11Mvvm.Enums
{
    public abstract class BaseNivelEnum : IComparable
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        protected BaseNivelEnum()
        { }

        protected BaseNivelEnum(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public override string ToString() => Descricao;

        public static IEnumerable<T> GetAll<T>() where T : BaseNivelEnum
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as BaseNivelEnum;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Id.CompareTo(((BaseNivelEnum)other).Id);
    }
}
