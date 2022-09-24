using CsvHelper.Configuration;

namespace ConsoleApp1
{
    /// <summary>
    /// Corresponds with one line from the CSV file
    /// </summary>
    internal class TransactionLine
    {
        public DateTime Timestamp { get; set; }
        public TransactionType Type { get; set; }
        public string Currency { get; set; } = "";
        public decimal Amount { get; set; }

        public override string ToString() => $"{Type}: {Currency} {Amount} @ {Timestamp:d}";
    }

    internal enum TransactionType
    {
        Trade,
        Deposit,
        Staking,
        Rebate,
    }

    /// <summary>
    /// Specific CSV mapping
    /// </summary>
    internal class TransactionLineMap : ClassMap<TransactionLine>
    {
        public TransactionLineMap()
        {
            Map(m => m.Timestamp)
                .Index(0)
                .TypeConverter<CsvHelper.TypeConversion.DateTimeConverter>()
                .TypeConverterOption.Format("ddd MMM dd yyyy HH:mm:ss\" GMT+0000 (Coordinated Universal Time)\"");

            Map(m => m.Type)
                .Index(1)
                .TypeConverterOption.EnumIgnoreCase();

            Map(m => m.Currency).Index(2);
            Map(m => m.Amount).Index(3);
        }
    }
}
