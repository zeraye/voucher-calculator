namespace VoucherCalculator
{
    public class VoucherCalculator
    {
        private Dictionary<string, double> vouchers;

        public VoucherCalculator()
        {
            vouchers = new Dictionary<string, double>();
            vouchers["SAVE10NOW"] = 10.0;
            vouchers["DISCOUNT20OFF"] = 20.0;
        }

        public double CalculateDiscount(double basePrice, string voucher)
        {
            if (string.IsNullOrEmpty(voucher))
            {
                return basePrice;
            }

            if (vouchers.ContainsKey(voucher))
            {
                return basePrice * (100.0 - vouchers[voucher])/100.0;
            }

            throw new ArgumentException("Invalid discount code");
        }

    }
}
