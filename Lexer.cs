namespace Luminor
{
    public enum TokenType
    {
        Keyword,
        Identifier,
        Number,
        Operator
    }

    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Token(TokenType type, string? value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Type}: {Value}";
        }
    }

    public class Lexer(string code)
    {
        private int cursor = 0;

        private readonly string[] keywords = new string[]
        {
            "lu", "le"
        };

        private readonly char[] operators = new char[]
        {
            '+', '-', '/', '*', '=' 
        };

        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();

            while (cursor < code.Length)
            {
                var character = code[cursor];

                if (char.IsWhiteSpace(character))
                {
                    cursor++;
                    continue;
                }

                if (char.IsLetter(character))
                {
                    var word = "";

                    while (char.IsLetterOrDigit(code[cursor]))
                    {
                        word += code[cursor];
                        cursor++;
                    }

                    tokens.Add(keywords.Contains(word)
                        ? new Token(TokenType.Keyword, word)
                        : new Token(TokenType.Identifier, word));
                    continue;
                }

                if (char.IsDigit(character))
                {
                    var number = "";
                    while (char.IsDigit(code[cursor]))
                    {
                        number += code[cursor];
                        cursor++;
                    }

                    tokens.Add(new Token(TokenType.Number, number));
                    continue;
                }

                if (operators.Contains(character))
                {
                    tokens.Add(new Token(TokenType.Operator, character.ToString()));
                    cursor++;
                    continue;
                }
                
                break;
            }

            return tokens;
        }
    }
}