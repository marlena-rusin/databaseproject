# databaseproject


# ElectronicStore



## How to run the application

(1) Clone the project 


```java
git clone https://github.com/marlena-rusin/databaseproject.git
```

(2) Open appsettings.json file and update ConnectionStrings set yout own DefaultConnection by changing Data Source name 

```java
"DefaultConnection": "Data Source=your-data-source;Initial Catalog=WebApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
```
(3) Delete Migration folder 

(4) Open Package Manager Console and run 
```java
Add-Migration FirstMigration
Update-Database
```
(5) Run the app in console with sample data 

```java
dotnet run seeddata
```

## How the application works 
