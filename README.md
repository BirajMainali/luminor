# Luminor

Luminor is a minimalist programming language built on top of C#. It is designed to handle basic calculations and simple scripting tasks, making it a great tool for learning and experimenting with language development.

## Features

- **Variable Declaration:** Simple syntax to define and manage variables.
- **Basic Arithmetic:** Supports basic arithmetic operations such as addition, subtraction, multiplication, and division.
- **Simple Syntax:** Designed to be easy to read and write, focusing on simplicity 😀.

## Getting Started

### Prerequisites

- .NET SDK (version 8.0.* or higher)

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/BirajMainali/luminor.git
    cd luminor
    ```

2. Build the project:
    ```bash
    dotnet build
    ```

3. Run a sample script:
    ```bash
    dotnet run
    ```

### Example Usage

Here's a simple example of a Luminor script:

```code
 lu x = 10
 lu y =  x / 10
 le y
```

This script declares two variables `x` and `y`, adds them together, and returns the result.

### Code Structure

- **Lexer.cs:** Handles tokenization of the source code.
- **Parser.cs:** Parses the tokens into an abstract syntax tree (AST).
- **Compiler.cs:** Compiles the AST into executable code.
- **Program.cs:** The entry point for running Luminor scripts.

## Contributing

Contributions are welcome! You can fix this repository, make changes, and submit a pull request.

## License

This project is licensed under the MIT License.

## Learn More

If you're interested in understanding how to create a programming language, you can check out this [article on language design](https://www.freecodecamp.org/news/the-programming-language-pipeline-91d3f449c919/) for more insights.
