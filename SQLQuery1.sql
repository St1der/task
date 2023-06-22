CREATE DATABASE ECommerceDb
GO
USE ECommerceDb
GO
create table Products(
[Id] int primary key identity(1,1) not null,
[Name] nvarchar(30) not null,
[Description] nvarchar(30),
[Price] money not null default(0),
[Discount] float not null default(0),
[Quantity] int not null default(10)
)
GO
insert into Products([Name],[Description],[Price],[Discount],[Quantity])
values('Samsung S21+','Normal Telefon',2555,5,100)