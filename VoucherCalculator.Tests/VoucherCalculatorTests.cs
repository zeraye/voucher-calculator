namespace VoucherCalculator.Tests
{
    public class VoucherCalculatorTests
    {
        private readonly VoucherCalculator sut;
        public VoucherCalculatorTests()
        {
            sut = new VoucherCalculator();
            sut.AddVoucher("SAVE10NOW", 10m);
            sut.AddVoucher("DISCOUNT20OFF", 20m);
        }

        [Fact]
        public void CalculateDiscount_EmptyVoucher_ShouldReturnBasePrice()
        {
            // Arrange
            string voucher = string.Empty;
            decimal basePrice = 100m;

            // Act
            var result = sut.CalculateDiscount(basePrice, voucher);

            // Assert
            Assert.Equal(basePrice, result);
        }

        [Fact]
        public void CalculateDiscount_ValidTokenFor10percentDiscount_ShouldReturnPrice10PercentLower()
        {
            // Arrange
            string voucher = "SAVE10NOW";
            decimal basePrice = 100m;

            // Act
            var result = sut.CalculateDiscount(basePrice, voucher);

            // Assert
            Assert.Equal(basePrice * 0.9m, result);
        }

        [Fact]
        public void CalculateDiscount_ValidTokenFor20percentDiscount_ShouldReturnPrice20PercentLower()
        {
            // Arrange
            string voucher = "DISCOUNT20OFF";
            decimal basePrice = 100m;

            // Act
            var result = sut.CalculateDiscount(basePrice, voucher);

            // Assert
            Assert.Equal(basePrice * 0.8m, result);
        }

        [Fact]
        public void CalculateDiscount_PriceLessThanZero_ShouldThrowArgumentExceptionWithNegativesNotAllowed()
        {
            // Arrange
            string voucher = "a";
            decimal basePrice = -1m;

            // Act
            Action act = () => sut.CalculateDiscount(basePrice, voucher);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CalculateDiscount_InvalidDiscountCode_ShouldThrowArgumentExceptionWithInvalidDiscountCode()
        {
            // Arrange
            string voucher = "a";
            decimal basePrice = 100m;

            // Act
            Action act = () => sut.CalculateDiscount(basePrice, voucher);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}