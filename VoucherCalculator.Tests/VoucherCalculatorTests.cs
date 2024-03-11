namespace VoucherCalculator.Tests
{
    public class VoucherCalculatorTests
    {
        private readonly VoucherCalculator sut;
        public VoucherCalculatorTests()
        {
            sut = new VoucherCalculator();
            sut.AddVoucher("SAVE10NOW", 10.0);
            sut.AddVoucher("DISCOUNT20OFF", 20.0);
        }

        [Fact]
        public void CalculateDiscount_EmptyVoucher_ShouldReturnBasePrice()
        {
            // Arrange
            string voucher = string.Empty;
            double basePrice = 100.0;

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
            double basePrice = 100.0;

            // Act
            var result = sut.CalculateDiscount(basePrice, voucher);

            // Assert
            Assert.Equal(basePrice * 0.9, result);
        }

        [Fact]
        public void CalculateDiscount_ValidTokenFor20percentDiscount_ShouldReturnPrice20PercentLower()
        {
            // Arrange
            string voucher = "DISCOUNT20OFF";
            double basePrice = 100.0;

            // Act
            var result = sut.CalculateDiscount(basePrice, voucher);

            // Assert
            Assert.Equal(basePrice * 0.8, result);
        }

        [Fact]
        public void CalculateDiscount_PriceLessThanZero_ShouldThrowArgumentExceptionWithNegativesNotAllowed()
        {
            // Arrange
            string voucher = "a";
            double basePrice = -1.0;

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
            double basePrice = 100.0;

            // Act
            Action act = () => sut.CalculateDiscount(basePrice, voucher);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}