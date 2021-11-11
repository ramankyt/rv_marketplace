using Marketplace.Domain;
using Xunit;

namespace Marketplace
{
    public class MoneyTest
    {
        [Fact]
        public void
            Money_object_with_the_same_amount_should_be_equal()
        {
            var firstAmount = Money.FromDecimal(5);
            var secondAmount = Money.FromDecimal(5);
            Assert.Equal(firstAmount, secondAmount);
        }

        [Fact]
        public void Sum_of_money_gives_full_amount()
        {
            var coin1 = Money.FromDecimal(1);
            var coin2 =Money.FromDecimal(2);
            var coin3 = Money.FromDecimal(2);
            var banknote = Money.FromDecimal(5);
            Assert.Equal(banknote, coin1+coin2+coin3);
        }

        [Fact]
        public void Sum_of_money_with_different_currency_symbols()
        {
            var firstAmount = Money.FromDecimal(10, "USD");
            var secondAmount = Money.FromDecimal(20, "USD");
            var thirdAmount = Money.FromDecimal(30, "USD");
            Assert.Equal(thirdAmount, firstAmount+secondAmount);
        }
        
        [Fact]
        public void Subtraction_of_money_with_different_currency_symbols()
        {
            var firstAmount = Money.FromDecimal(10, "USD");
            var secondAmount = Money.FromDecimal(20, "USD");
            var thirdAmount = Money.FromDecimal(30, "USD");
            Assert.Equal(firstAmount, thirdAmount-secondAmount);
        }
    }
}