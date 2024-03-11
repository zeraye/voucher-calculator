namespace VoucherCalculator.Tests
{
    public class VoucherCalculatorTests
    {
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
    }
}