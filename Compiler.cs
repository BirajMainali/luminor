using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace Luminor;

public class Compiler
{
    private readonly string sourceCode;

    public Compiler(string sourceCode)
    {
        this.sourceCode = sourceCode;
    }

    public async Task Compile()
    {
        var lexer = new Lexer(sourceCode);
        var tokens = lexer.Tokenize();
        var parser = new Parser(tokens);
        var ast = parser.Parse();
        var executable = GenerateCode(ast);
        await ExecuteCodeAsync(executable);
    }

    private string GenerateCode(Node node)
    {
        return node.Type switch
        {
            NodeType.Program => string.Join("\n", node.Body.Select(GenerateCode)),
            NodeType.Assignment => $"var {node.Name} = {node.Value};",
            NodeType.Print => $"Console.WriteLine({node.Value});",
            _ => throw new NotImplementedException()
        };
    }


    private async Task ExecuteCodeAsync(string code)
    {
        try
        {
            var options = ScriptOptions.Default
                .WithReferences(AppDomain.CurrentDomain.GetAssemblies())
                .WithImports("System", "System.Console");

            await CSharpScript.EvaluateAsync(code, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Execution Error: " + ex.Message);
        }
    }
}