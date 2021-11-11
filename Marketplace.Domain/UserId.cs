using System;

namespace Marketplace.Domain
{
    public class UserId
    {
        private readonly Guid _value;

        public UserId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Userid cannot be empty");
            _value = value;
        }
        
    }
}