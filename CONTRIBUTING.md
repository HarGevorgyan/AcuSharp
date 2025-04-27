# 📚 CONTRIBUTING to AcuSharp

Thank you for considering contributing to **AcuSharp**!  
Our goal is to make Acumatica development simpler, faster, and cleaner for everyone.

## 🤝 How to Contribute

- **Bug Fixes**  
  Open a Pull Request with a clear description of the bug and how your fix resolves it.

- **New Helpers**  
  If you have a reusable pattern, extension method, or workflow that benefits Acumatica developers, feel free to propose or open a PR.

- **Enhancements**  
  Improve documentation, summaries, naming, project structure, or performance.

- **Ideas and Issues**  
  Open a GitHub Issue to discuss feature ideas, report bugs, or ask questions.

## 🧹 Coding Guidelines

We want AcuSharp to be clean, modern, and professional.

Please follow these standards:

- Use **C# 13** features where they improve code clarity (primary constructors, collection expressions, etc.).
- Prefer **expression-bodied members** (`=>`) for short methods and properties.
- Prefer **readonly** fields/properties whenever possible.
- Keep methods **small and focused**.
- Always **add XML documentation comments** (`///`) to all public members.
- Write **safe, null-guarded code** — avoid NullReferenceExceptions.
- Prefer **fail-fast** practices (throw early when arguments are invalid).

## 🌳 Branch Naming Convention

- All contribution branches **must start** with `Contribution/`
- Example branch names:
  - `Contribution/AddBulkInsertHelper`
  - `Contribution/FixNullableExtensions`
  - `Contribution/ImproveReadme`
- All Pull Requests must target the `dev` branch.
- Pull Requests will be reviewed before merging.

✅ **Summary:**  
Name your branch clearly, start with `Contribution/`, and open your PR to `dev`.

## 🚀 Pull Request Process

1. Fork the repository and create your branch from `dev`.
2. Use a branch name starting with `Contribution/`.
3. Add or modify code and documentation.
4. Add or update related tests if applicable.
5. Ensure there are no build warnings or errors.
6. Open a pull request describing your change clearly.

## 📜 License

By contributing to AcuSharp, you agree that your contributions will be licensed under the **MIT License**.

## 💬 Need Help?

Open an issue, or write in disscusions if you’re unsure about anything — ideas, questions, or improvements are always welcome!  
Let’s make Acumatica development sharper together. ✨