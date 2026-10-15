# SauceDemo Happy Flow – Selenium C#

A simple end-to-end **happy-flow** UI test for [saucedemo.com](https://www.saucedemo.com/), written in **C#** with **Selenium WebDriver** and **NUnit**.

The test walks through a complete successful purchase, from login to order confirmation, with no negative or edge-case scenarios. It's meant as a clean, beginner-friendly example of Selenium automation in C#.

## What the test does

1. Opens https://www.saucedemo.com/
2. Logs in as `standard_user` / `secret_sauce`
3. Adds two products to the cart (Sauce Labs Backpack, Sauce Labs Bike Light)
4. Opens the cart and proceeds to checkout
5. Fills in first name, last name and postal code
6. Continues to the overview and clicks **Finish**
7. Asserts that the order-complete page is displayed

## Tech stack

| Tool | Purpose |
|------|---------|
| C# / .NET 6 or later | Language and runtime |
| Selenium WebDriver | Browser automation |
| Selenium.Support | `WebDriverWait` and other helpers |
| NUnit + NUnit3TestAdapter | Test framework and runner |
| Google Chrome | Browser under test |

## Project structure

```
SauceDemo-HappyFlow-Selenium-CSharp/
├── Happyflow.cs        # The happy-flow test (setup, test steps, teardown)
├── CustomMethods.cs    # Reusable helpers: Click() and EnterText()
└── *.csproj            # Project file with NuGet package references
```

**`CustomMethods.cs`** wraps common Selenium actions so the test reads like a list of steps:

- `Click(driver, locator)` finds an element and clicks it
- `EnterText(driver, locator, text)` clears a field and types into it

## Prerequisites

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
- [Google Chrome](https://www.google.com/chrome/) (latest version)
- Visual Studio 2022 (optional, you can also run from the command line)

You do **not** need to download ChromeDriver manually. Selenium 4.6+ includes Selenium Manager, which downloads the matching driver automatically on the first run.

## Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/omarshahid0005/SauceDemo-HappyFlow-Selenium-CSharp.git
   cd SauceDemo-HappyFlow-Selenium-CSharp
   ```

2. Restore NuGet packages:

   ```bash
   dotnet restore
   ```

   If you're setting the project up from scratch, these are the packages it needs:

   ```bash
   dotnet add package Microsoft.NET.Test.Sdk
   dotnet add package NUnit
   dotnet add package NUnit3TestAdapter
   dotnet add package Selenium.WebDriver
   dotnet add package Selenium.Support
   ```

## Running the test

### From Visual Studio

1. Open the `.sln` (or `.csproj`) file.
2. Build the solution (**Ctrl + Shift + B**).
3. Open **Test → Test Explorer**.
4. Right-click `happyFlow` and choose **Run**.

### From the command line

```bash
dotnet test
```

To run only this test:

```bash
dotnet test --filter "Name=happyFlow"
```

A Chrome window will open, run through the purchase flow, and close when the test finishes.

## Test data

| Field | Value |
|-------|-------|
| Username | `standard_user` |
| Password | `secret_sauce` |

These are the public demo credentials provided by saucedemo.com.

## Troubleshooting

**ChromeDriver / browser version mismatch:** update Chrome to the latest version and update the `Selenium.WebDriver` NuGet package. Selenium Manager will then fetch a matching driver.

**Test can't find an element:** saucedemo.com occasionally changes its page. Inspect the element in the browser (F12) and update the locator in `Happyflow.cs`.

**Test not showing in Test Explorer:** make sure `NUnit3TestAdapter` and `Microsoft.NET.Test.Sdk` are installed, then rebuild the solution.

