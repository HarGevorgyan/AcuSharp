# 📦 AcuSharp

[![NuGet](https://img.shields.io/nuget/v/AcuSharp.svg)](https://www.nuget.org/packages/AcuSharp/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

🚀 **AcuSharp – Your New Foundation for High-Quality Acumatica Development** 🚀

> 💬 For questions, feedback, or suggestions, feel free to reach me directly on [LinkedIn](https://www.linkedin.com/in/har-gevorgyan).  
> Let's build the Acumatica developer community stronger together!

---

## 🔹 What is AcuSharp?

**AcuSharp** is a focused, practical, and community-driven helper library designed to bring real efficiency, structure, and professionalism to Acumatica ERP customization projects.

It’s not just another set of random utilities —  
**AcuSharp** is the beginning of a true foundation that saves time, reduces bugs, and raises the standard for Acumatica development.

---

## ✨ What's Included in the First Release?

- **`ACSPAuditableDAC`**  
  A standardized base class for DACs, automatically handling audit fields like `CreatedByID`, `CreatedDateTime`, `LastModifiedDateTime`, and `Tstamp` — so you never forget them again.

- **`ACSPRestSharp`**  
  A lightweight, fluent wrapper around RestSharp, enabling effortless and clean REST API calls inside your Acumatica customizations.

- **`ACSPWebhookHandlerWithLogin`**  
  ➡️ The highlight of this release.  
  Provides a clean, production-ready blueprint for handling incoming webhook requests inside Acumatica:
  - Full session management using `PXLoginScope`
  - Built-in security validation hooks
  - Asynchronous processing  
  Implement webhooks **the right way** — consistently, reliably, and safely.

- **`ACSPSessionDetails`**  
  Strongly-typed helper model for impersonating users, working with branch context, or operating at system level.

- **`ACSPExtensions`**  
  Helpful extension methods:
  - `.IsTrue()`, `.IsFalse()` for nullable booleans
  - `TryCastTo<T>()` for safe type casting of unknown objects (e.g., PXResult)

---

## 📦 Availability

✅ Available as a NuGet package (AcuSharp) for **Acumatica 2025 R1**.  
📦 Install it today and integrate it immediately with your Acumatica projects.

> Standalone DLLs for **24R2** and **24R1** versions will also be provided soon to support current live systems.

---

## 🌟 The Vision

**AcuSharp** is just getting started — and the future is even bigger.

The vision is to create a **powerful, community-owned library** that saves Acumatica developers hundreds of hours by offering reusable, production-ready patterns and eliminating repetitive, low-value work.

If every Acumatica developer contributes a helper or two —  
whether it’s a DAC, an extension method, or a best-practice integration wrapper —  
**together we can build an unparalleled foundation for faster, safer, and more professional Acumatica development**.

---

## 🤝 Contributions Welcome!

💬 **If you have ideas, suggestions, or want to create pull requests — you are warmly invited!**  

Together, let's grow **AcuSharp** into the standard toolkit we all deserve.

✅ Start faster.  
✅ Build cleaner.  
✅ Deliver stronger.

This is **AcuSharp**.  
Join the movement. 🚀

---

## 📜 License

AcuSharp is open-sourced under the [MIT License](./LICENSE).  
Feel free to use, modify, and contribute!
