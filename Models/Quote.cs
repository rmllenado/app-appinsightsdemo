using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Quote
{
    public int Id { get; set; }
    [DisplayName("Quotes")]
    public string? AQuote { get; set; }
}

public class IntegerResult
{
    public int Value { get; set; }
}