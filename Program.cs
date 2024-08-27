namespace Luminor
{
    public class Program
    {
        public static async Task Main()
        {
            var input = @"
                lu x = 10
                lu y =  x / 10
                le y
            ";

            var compiler = new Compiler(input);
            await compiler.Compile();
        }
    }
}