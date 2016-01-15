// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Price.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.AdditionalClasses
{
    /// <summary>
    /// Class for providing price
    /// </summary>
    public class Price
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Price"/> class.
        /// </summary>
        public Price()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Price"/> class.
        /// </summary>
        /// <param name="value">
        /// Price value.
        /// </param>
        /// <param name="currencyId">
        /// Currency id.
        /// </param>
        public Price(decimal value, int currencyId)
        {
            this.Value = value;
            this.CurrencyId = currencyId;
        }

        /// <summary>
        /// Value in specified currency
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Currency id
        /// </summary>
        public int CurrencyId { get; set; }
    }
}
