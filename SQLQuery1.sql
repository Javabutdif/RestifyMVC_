CREATE TABLE Apartment(
 apartment_id int primary key identity not null,
 apartment_name nvarchar(100) not null,
 apartment_details nvarchar(100) not null,
 apartment_location nvarchar(100) not null,
 apartment_image varbinary(max)

);