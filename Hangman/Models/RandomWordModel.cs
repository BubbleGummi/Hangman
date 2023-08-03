using System.Diagnostics.CodeAnalysis;
namespace Hangman.Models; 

public class RandomWordModel
{
    [NotNull]
    public string? Word { get; set; }
}
