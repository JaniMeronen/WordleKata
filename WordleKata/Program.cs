using static System.Char;
using static System.Console;
using static System.String;

string Wordle(string answer, string guess)
{
    var used = new bool[answer.Length];

    return guess
        .Select((guessLetter, guessIndex) =>
            guessLetter == answer[guessIndex] && (used[guessIndex] = true)
                ? ToUpper(guessLetter)
                : answer.Where((answerLetter, answerIndex) => !used[answerIndex] && guess[answerIndex] != answerLetter && guessLetter == answerLetter && (used[answerIndex] = true)).Any()
                    ? ToLower(guessLetter)
                    : '.')
        .Aggregate(Empty, (left, right) => left + right);
}

WriteLine($"..... == {Wordle("aaaaa", "bbbbb")}");
WriteLine($"A.... == {Wordle("aaaaa", "abbbb")}");
WriteLine($".A... == {Wordle("aaaaa", "babbb")}");
WriteLine($"..A.. == {Wordle("aaaaa", "bbabb")}");
WriteLine($"...A. == {Wordle("aaaaa", "bbbab")}");
WriteLine($"....A == {Wordle("aaaaa", "bbbba")}");
WriteLine($".a... == {Wordle("abbbb", "caccc")}");
WriteLine($"..a.. == {Wordle("abbbb", "ccacc")}");
WriteLine($"...a. == {Wordle("abbbb", "cccac")}");
WriteLine($"....a == {Wordle("abbbb", "cccca")}");
WriteLine($"..A.. == {Wordle("bbabb", "aaaaa")}");
WriteLine($"A.... == {Wordle("abbbb", "accca")}");
WriteLine($"A.... == {Wordle("abbbb", "accaa")}");
WriteLine($"A..a. == {Wordle("aabbb", "accaa")}");
WriteLine($"AA... == {Wordle("aabbb", "aacaa")}");
WriteLine($"...aa == {Wordle("aabbb", "cccaa")}");
