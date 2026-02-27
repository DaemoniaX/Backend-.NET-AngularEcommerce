# Angular-Ecommerce-Backend-.NET
This is the backend of my Angular project using ASP.NET Core Project.
  
The Angular frontend works independently from this Backend but is compatible, as I wanted people to be able to just download the front and the app to work with just that.
  
I have no idea about how cybersecurity works, and so I don't think any of the data is secured.
  
It works using ASP.NET Core project, WEBAPI, SQL Server Management Studio 21, and AWS RDS.
  
~~I plan on making this compatible with MySQL to beguin with, and then Azure/AWS.~~
I will not implement MySQL since it uses another type of SQL, AWS and Azure are now ready.
I found this relatively easy, following the tutorial, since I already have basis in C# and the little XML i had to edit was relatively simple.
-> Adding Failover/multi connection string was not hard but like it needed me to level up my understanding of .NET, since I couldn't find any tutorial on this.
  
## Table of Contents

* [🔧 Installation](#-installation)
* [💡 Usage](#-usage)
* [✨ Features](#-features)
* [🛠️ Tech Stack](#️-tech-stack)
* [🤝 Contributing](#-contributing)
* [✉️ Contact](#️-contact)
* [📄 License](#-license)

---

## 🔧 Installation LOCAL

1. **Clone the repository**

   ```bash
   git clone https://github.com/DaemoniaX/Angular-Ecommerce-Backend-.NET.git
   ```
2. **Open the project**
    * Navigate to the downloaded folder
    * Double-click to open the file **`WebApplication2.sln`** to open it in Visual Studio.(not VSCODE)
   
3. **Install dependencies**

   Install SQL Server Management Studio, login to the local '.', open and execute the Install.sql file.(this does not works by double-clicking, or on MySQL)  
   NOTE: Always read the content of .bat file before executing it, if an error occur, use admin.
   If like me you shutted down the autoboot of the Microsoft SQL Server service, you can use the .bat file if the service is set as manual.
   
4. **Serve locally**

   Click to start. 


## 🔧 Installation AWS RDS

1. **Setup AWS**

   I recommand watching this tutorial, and setup an API READER user and not an admin one like they did in the tutorial.
   https://www.youtube.com/watch?v=vp_uulb5phM
     
   The SQL query is in the github.

2. **Open the project**
    * Navigate to the downloaded folder
    * Double-click to open the file **`WebApplication2.sln`** to open it in Visual Studio.(not VSCODE)
   
3. **Add the server**

    * Open appsettings.json
    * Edit the password/link/username/port
   
4. **Serve**

   Click to start.


## 🔧 Installation Azure

1. **Setup Azure**

   I recommand watching this tutorial for the setup, don't forget the firewall.
   https://www.youtube.com/watch?v=pZHKS2MS1nU
     
   The SQL query is in the github.

2. **Open the project**
    * Navigate to the downloaded folder
    * Double-click to open the file **`WebApplication2.sln`** to open it in Visual Studio.(not VSCODE)
   
3. **Add the server**

    * Open appsettings.json
    * Edit the password/link/username/port
   
4. **Serve**

   Click to start.
AzureDB was way harder to setup than AWS.

## 💡 Usage

* Connect the backend to the frontend, using ASP.NET, Angular, and Microsoft SQL server.

---

## 🛠️ Tech Stack

* **Language**: .NET / C#, XML, SQL Server

---

## 🤝 Contributing

This was made following the tutorial of https://www.youtube.com/watch?v=4a9VxZjnT7E&t=2839s 'Learn Angular 10, Web API & SQL Server by Creating a Web Application from Scratch, Art of Engineer 2020 Youtube'.
Contributions, issues and feature requests are welcome! Please feel free to:

* Fork the repository

---

## ✉️ Contact

**Name**: Antonin Marolleau  
**School**: ESIEE Paris – Integrated Engineering Program second year  
**Email**: [antonin.marolleau@edu.esiee.fr](mailto:antonin.marolleau@edu.esiee.fr)  
**LinkedIn**: [https://www.linkedin.com/in/antonin-marolleau-7b5497339](https://www.linkedin.com/in/antonin-marolleau-7b5497339)  

---

## 📄 License

This project is licensed under the CC0 License.
