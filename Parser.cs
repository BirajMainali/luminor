namespace Luminor
{
    public enum NodeType
    {
        Program,
        Assignment,
        Print
    }

    public class Node
    {
        public NodeType Type { get; }
        public string? Name { get; }
        public object? Value { get; set; }
        public List<Node> Body { get; }

        public Node(NodeType type, string? name, object? value)
        {
            Type = type;
            Name = name;
            Value = value;
            Body = new List<Node>();
        }

        public override string ToString()
        {
            return $"{Type}: {Name} = {Value}";
        }
    }

    public class Parser(List<Token> tokens)
    {
        public Node Parse()
        {
            var cursor = 0;
            var program = new Node(NodeType.Program, string.Empty, null);

            while (cursor < tokens.Count)
            {
                var token = tokens[cursor];
                if (token.Type == TokenType.Keyword && token.Value == "lu")
                {
                    cursor++;
                    var declaration = new Node(NodeType.Assignment, tokens[cursor].Value, null);
                    cursor++;
                    var nextToken = tokens[cursor];
                    if (nextToken.Type == TokenType.Operator && nextToken.Value == "=")
                    {
                        cursor++;
                        var expression = string.Empty;
                        while (tokens.Count > 0 && tokens[cursor].Type != TokenType.Keyword)
                        {
                            expression += tokens[cursor].Value;
                            cursor++;
                        }

                        declaration.Value = expression;
                        program.Body.Add(declaration);
                    }

                    continue;
                }

                if (token.Type == TokenType.Keyword && token.Value == "le")
                {
                    cursor++;
                    var nextToken = tokens[cursor];
                    var print = new Node(NodeType.Print, name: null, nextToken.Value);
                    program.Body.Add(print);
                    continue;
                }

                break;
            }

            return program;
        }
    }
}