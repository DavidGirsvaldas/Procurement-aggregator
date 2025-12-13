---
apply: always
---

When asked to do a task, always break the task into details, explain them to me and then wait for me to confirm before applying the changes.

## Coding Standards

### C#

Coding standards:
- Use official naming conventions. If my instructions don't comply with the guidelines, inform me about it.
- Always prefer using modern .Net features.
- Always use nullable reference types.
- Always perform null checks using `is null` or `is not null` instead of equality operators.
- Use pattern matching when checking multiple constant values, for example `enumVar is MyEnum.Val1 or MyEnum.Val2`.
- When validating parameters, use exception helper methods such as `ArgumentNullException.ThrowIfNull(variable)` whenever available.
- Always include curly braces when they are optional.
- Always give enum members an explicit value.
- Enum member values must always start with 1 UNLESS the enum includes a member such as 'None' or 'Not Provided'.
- Use sealed classes or records unless the type is meant to be extended.

Tools:
- Always use `dotnet build` to get compiler feedback after making code changes.  The project uses nullable reference types, warnings as errors, and includes several Roslyn analyzer packages to enforce code quality.
- Always run tests using `dotnet test` after making changes.
- When you complete changes to C# code or project files, you should always run Csharpier to format them correct.
    - `dotnet csharpier check <file_or_directory>`: check formatting of files
    - `dotnet csharpier format <file_or_directory>`: apply formatting to files