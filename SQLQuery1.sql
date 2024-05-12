CREATE DATABASE Restify

CREATE TABLE Apartment(
 apartment_id int primary key identity not null,
 apartment_name nvarchar(100) not null,
 apartment_details nvarchar(100) not null,
 apartment_location nvarchar(100) not null,
 apartment_image varbinary(max),
 apartment_base nvarchar(100) not null

);
CREATE TABLE Landlord(
    landlord_id int primary key identity,
    landlord_firstname nvarchar(50) not null,
    landlord_lastname nvarchar(50) not null,
    landlord_email nvarchar(50) not null,
    landlord_contact nvarchar(50) not null,
    landlord_password nvarchar(50) not null
);


  