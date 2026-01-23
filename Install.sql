USE master;
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ProductsDB')
BEGIN
    CREATE DATABASE ProductsDB;
END
GO

USE ProductsDB;
GO

IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
DROP TABLE dbo.Products;
GO

CREATE TABLE Products (
    id INT PRIMARY KEY,
    title NVARCHAR(255),
    price DECIMAL(10,2),
    image NVARCHAR(MAX),
    stock INT
);
GO

INSERT INTO Products (id, title, price, image, stock) VALUES
(1, 'Brown & white cat - SRC national geopraghic Joel Sartore', 109.95, 'https://i.natgeofe.com/n/548467d8-c5f1-4551-9f58-6817a8d2c45e/NationalGeographic_2572187_16x9.jpg?w=1200', 1),
(2, 'Cute kitten sleeping - CC0', 199.99, 'https://images.pexels.com/photos/416160/pexels-photo-416160.jpeg?auto=compress&cs=tinysrgb&w=600', 0),
(3, 'Cute little kitten - CC0', 999999, 'https://images.pexels.com/photos/45201/kitty-cat-kitten-pet-45201.jpeg?cs=srgb&dl=pexels-pixabay-45201.jpg&fm=jpg', 999),
(4, 'Regular street cat - CC0', 15.99, 'https://images.pexels.com/photos/2071882/pexels-photo-2071882.jpeg?cs=srgb&dl=pexels-wojciech-kumpicki-1084687-2071882.jpg&fm=jpg', 7),
(5, 'Kitten - CC0', 11.99, 'https://cdn.stocksnap.io/img-thumbs/960w/animal-face_FSFNTYVLHH.jpg', 11),
(6, 'Leopard''s paw - CC0', 33.99, 'https://cdn.stocksnap.io/img-thumbs/960w/leopard-nature_Z9KWOGE8YS.jpg', 50),
(7, 'Yawn - CC0', 68.00, 'https://cdn.stocksnap.io/img-thumbs/960w/leopard-nature_3YWYBJ2TPW.jpg', 18),
(8, 'Bored stare - CC0', 75.75, 'https://cdn.stocksnap.io/img-thumbs/960w/animal-face_GZW89D8X6K.jpg', 14),
(9, 'black & white cat - CC0', 11000.00, 'https://cdn.stocksnap.io/img-thumbs/960w/cat-pet_VFQTYEC60T.jpg', 57);
GO