﻿namespace VoucherCalculator
{
    public class VoucherCalculator
    {
        private Dictionary<string, decimal> vouchers;

        public VoucherCalculator()
        {
            vouchers = new Dictionary<string, decimal>();
        }

        public void AddVoucher(string voucher, decimal discount)
        {
            vouchers[voucher] = discount;
        }

        public decimal CalculateDiscount(decimal basePrice, string voucher)
        {
            if (basePrice < 0)
            {
                throw new ArgumentException("Negatives not allowed");
            }

            if (string.IsNullOrEmpty(voucher))
            {
                return basePrice;
            }

            if (vouchers.TryGetValue(voucher, out decimal value))
            {
                return basePrice * (100m - value) /100m;
            }

            throw new ArgumentException("Invalid discount code");
        }

    }
}
