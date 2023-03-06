namespace ExampleWebApplication.DTOs.Instruments
{
    /// <summary>
    /// Ok response from instrument service
    /// </summary>
    public class InstrumentResponseDTO
    {
        public List<Data> Data { get; set; }
    }
    /// <summary>
    /// Data object used in instrument response
    /// </summary>
    public class Data
    {
        public string AssetType { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
        public string ExchangeId { get; set; }
        public int GroupId { get; set; }
        public int Identifier { get; set; }
        public string SummaryType { get; set; }
        public string Symbol { get; set; }
        public string[] TradableAs { get; set; }
    }
}
