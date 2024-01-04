# databaseproject


# ElectronicStore



## How to run the application

(1) Clone the project 


```java
...
```

(2) Open appsettings.json file and update connection string's data source=your server name

```java
...
```
(3) Delete Migration folder 

(4) Open Package manager console
```java
Add-Migration FirstMigration
Update-Database
```
(5) Run the app in console with sample data 

```java
dotnet run seeddata
```