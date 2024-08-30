# SAOnlineMartMVC

SA Online Mart aims to promote local South African products by providing a seamless online shopping experience for customers nationwide. The platform features a diverse range of products, from handcrafted jewelry to locally-produced clothing. Designed to support South African artisans and small businesses, SA Online Mart helps them reach a wider audience and boost their sales.

## Features

- **Product Browsing:** Users can browse a variety of local products with detailed descriptions.
- **Shopping Cart:** Add products to a shopping cart with quantity management.
- **Checkout:** Complete purchases with secure checkout options.
- **Admin Dashboard:** Manage products with functionalities like add, edit, and delete.

## Setup Instructions

Follow these steps to set up SA Online Mart on your local machine:

1. Install Necessary Tools on the New Device
Before starting, ensure the new device has the necessary tools installed:
Git: Download and install Git from git-scm.com.
Visual Studio or Visual Studio Code: Download from Visual Studio or Visual Studio Code.
.NET SDK: If your project is a .NET project, ensure the appropriate .NET SDK is installed from dotnet.microsoft.com.
SQL Server / SQL Server Management Studio (SSMS): For database management, if required.

2. Clone the GitHub Repository
Open GitHub Desktop or Command Line:
If using GitHub Desktop, open it and sign in to your GitHub account.
If using the command line, open the terminal or command prompt.
Clone the Repository:
In GitHub Desktop:
Click File > Clone Repository.
Choose URL and paste the repository URL from GitHub (e.g., https://github.com/your-username/SA-Online-Mart.git).
Choose the local path where you want to save the project and click Clone.
In the command line:
git clone https://github.com/your-username/SA-Online-Mart.git
This will download the project files to the chosen directory on your device.

4. Open the Project in Visual Studio or Visual Studio Code
Open the Project:
In Visual Studio:
Open Visual Studio and select Open a project or solution.
Navigate to the cloned repository folder and select the .sln file if it's a Visual Studio solution.
In Visual Studio Code:
Open Visual Studio Code, click on File > Open Folder, and select the folder where the project was cloned.

5. Restore Dependencies
Restore NuGet Packages:
In Visual Studio:
Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
Click Restore to download all necessary packages.
In Visual Studio Code (or terminal):
dotnet restore

6. Set Up the Database
Set Up Your Database:
You will need to set it up on the new device.
Open SQL Server Management Studio (SSMS) and run the database setup script you have (CreateDatabaseScript.sql) to create and configure the database.
Update Connection Strings:
Check the appsettings.json or any configuration files for connection strings.
Update the connection strings if necessary to match the database setup on the new device.

7. Apply Migrations (If Using Entity Framework Core)
Apply Migrations:
If your project uses Entity Framework Core, run the migrations to set up the database schema.
Open the terminal or use the Package Manager Console in Visual Studio:
dotnet ef database update
This command will apply migrations and set up the database according to your models.

7. Build and Run the Project
Build the Project:
In Visual Studio, click Build > Build Solution or press Ctrl + Shift + B.
In Visual Studio Code (or terminal):
dotnet build

8.Run the Project:
In Visual Studio, click Start or press F5 to run the project.
In Visual Studio Code (or terminal):
dotnet run

9. Verify and Test
Check Application Functionality:
Test the application to ensure the new device's functionalities work as expected.
Verify database connections, API endpoints, and any third-party integrations.

Additional Tips
Environment Variables: Ensure any environment-specific settings (like API keys or secret values) are configured correctly on the new device.
Version Compatibility: Make sure the versions of .NET SDK, SQL Server, and other dependencies match the project's requirements.
Troubleshooting: If there are errors, review the output messages carefully and check that all dependencies are correctly installed and configured.!
Ensure that the database is connected when running the project to get the desired output.
