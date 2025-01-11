# Contributing

We are happy to accept contributions from the community. Before contributing, please read these guidelines and the [code of conduct](CODE_OF_CONDUCT.md):

## Code style

- Please, leave a newline after a condition, loop, or function definition. For example:

	```csharp
	if (condition)
	{
		// Do something
	}
	```

- Use tabs that are 4 spaces wide for indentation.
- Use LF (Unix) line endings.
- Use UTF-8 encoding.
- Use the C# language version 7.3 or later.

We use [EditorConfig](https://editorconfig.org/) to enforce these rules. Please, make sure your editor supports it.

## About editors

We highly recommend using Visual Studio 2022, as it is the IDE we use to develop this project. However, you can use any editor that supports C# development (
like VSCode, IntelliJ IDEA, Rider, etc.).

## Languages & Frameworks

The project is written in C#, using .NET 8.0. Most of the work is done actually on the CLI, but we also have a web interface that uses React.

## Getting Started

1. Fork the repository: click on the "Fork" button on the top right corner of the page.
2. Clone your fork with HTTP or SSH:
	```bash
	git clone <your fork URL>
    ```
3. Do your changes.
4. Commit your changes:
	```bash
	git commit -m "Your message"
	```
5. Push your changes:
	```bash
	git push
	```
6. Create a pull request: go to the original repository and click on the "New pull request" button.
7. Fill the form and click on "Create pull request".