namespace VoucherCalculator.Tests
{
    public class VoucherCalculatorTests
    {
        [Fact]
        public void CalculateDiscount_EmptyVoucher_ShouldReturnBasePrice()
        {
            // Arrange
            VoucherCalculator voucherCalculator = new VoucherCalculator();
            string voucher = string.Empty;
            double basePrice = 100.0;

            // Act
            var result = voucherCalculator.CalculateDiscount(basePrice, voucher);

            // Assert
            Assert.Equal(basePrice, result);
        }

        [Fact]
        public void CalculateDiscount_ValidTokenFor10percentDiscount_ShouldReturnPrice10PercentLower()
        {
            // Arrange
            VoucherCalculator voucherCalculator = new VoucherCalculator();
            string voucher = "SAVE10NOW";
            double basePrice = 100.0;

            // Act
            var result = voucherCalculator.CalculateDiscount(basePrice, voucher);

            // Assert
            Assert.Equal(basePrice * 0.9, result);
        }

        [Fact]
        public void CalculateDiscount_ValidTokenFor20percentDiscount_ShouldReturnPrice20PercentLower()
        {
            // Arrange
            VoucherCalculator voucherCalculator = new VoucherCalculator();
            string voucher = "DISCOUNT20OFF";
            double basePrice = 100.0;

            // Act
            var result = voucherCalculator.CalculateDiscount(basePrice, voucher);

            // Assert
            Assert.Equal(basePrice * 0.8, result);
        }
    }
}