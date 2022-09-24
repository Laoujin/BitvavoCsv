using CsvHelper;
using ConsoleApp1;

string path = Path.Combine(Directory.GetCurrentDirectory(), "transactions.csv");
using var reader = new StreamReader(path);
using var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
csv.Context.RegisterClassMap<TransactionLineMap>();
var records = csv.GetRecords<TransactionLine>().ToArray();

var moneySpent = records.Where(x => x.Type == TransactionType.Deposit).Select(x => x.Amount).Sum();
Console.WriteLine("Money Spent: " + moneySpent);
Console.ReadLine();
