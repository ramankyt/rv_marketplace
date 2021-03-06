using System;
using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class ClassifiedAdId: Value<ClassifiedAdId>
    {
        private readonly Guid _value;
        public ClassifiedAdId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Classified Ad cannot be empty");
            _value = value;
        }

        public static implicit operator Guid(ClassifiedAdId self) => self._value;
    }
}