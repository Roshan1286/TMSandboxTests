## Requirements
 Using the API given below create an automated test with the listed acceptance criteria:
 ```https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false```

**Acceptance Criteria:**
 Name = "Carbon credits"
 CanRelist = true
 The Promotions element with Name = "Gallery" has a Description that contains the text "Good position in category"

## Assumptions and Considerations
- Happy to use Non-Specflow based test framework if requested. e.g. MSTest or Nunit etc or any other tools.
- No App.config/runsettings file provided considering limited scope of the tests.
- Only positive scenarios are automated and can add additional tests if requested.
- I have chosen .Net Core so that the tests can be easily run on mac/unix using command line (dotnet test) and required packages installed.
- Given acceptance criteria is converted into Gherkin syntax and mapped to step definitions however there could be alternate ways to achieve this using different formats.

# Cloning and Running a SpecFlow Test Project

This README.md file will guide you through the process of cloning a SpecFlow test project from a Git repository and running the tests using Visual Studio. SpecFlow is a popular framework for Behavior-Driven Development (BDD) that allows you to write and execute automated tests using plain text scenarios written in Gherkin.

## Prerequisites

Before you begin, make sure you have the following prerequisites installed on your system:

- [Git](https://git-scm.com/)
- [Visual Studio](https://visualstudio.microsoft.com/)
- [SpecFlow’s Visual Studio extension](https://docs.specflow.org/projects/getting-started/en/latest/GettingStarted/Step1.html)

## Step 1: Clone the SpecFlow Test Project

1. Open your command-line terminal or Git Bash or Visual Studio with Github Extension.
2. Navigate to the directory where you want to clone the SpecFlow test project.
3. Run the following command to clone the Git repository:

   ```bash
   git clone https://github.com/Roshan1286/TMSandboxTests.git
   ```
## Step 2: Open the Project in Visual Studio

1. Open Visual Studio.
2. Click on "File" > "Open" > "Project/Solution."
3. Navigate to the directory where you cloned the SpecFlow test project and select the solution file (usually with a `.sln` extension) and click "Open."

## Step 3: Build the Project

Before running the SpecFlow tests, ensure the project builds successfully:

1. Click on "Build" > "Build Solution" in the Visual Studio menu.
2. Make sure there are no build errors.

## Step 4: Install SpecFlow NuGet Packages

If the SpecFlow NuGet packages are not already installed in the project, you need to install them:

1. Right-click on your project in the Solution Explorer.
2. Select "Manage NuGet Packages..."
3. In the "Browse" tab, search for "SpecFlow" and install the necessary packages, including "SpecFlow" and any additional extensions your project requires.
 
## Step 5: Run the SpecFlow Tests

Now that the project is set up, you can run the SpecFlow tests:

1. Open the Test Explorer (View > Test Explorer).
2. Click the "Run All Tests" button in the Test Explorer window.

The SpecFlow tests will be executed, and you will see the results in the Test Explorer window. Any test failures or errors will be displayed, allowing you to investigate and resolve issues.

## Examples of Test Run
![image](https://github.com/Roshan1286/TMSandboxTests/assets/75067556/40aac5c3-d0d0-4af5-97b2-2138a15da92b)

