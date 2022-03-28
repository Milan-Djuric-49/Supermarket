CREATE DATABASE supermarket

USE supermarket

CREATE TABLE proizvod (
ID INT PRIMARY KEY,
Naziv NVARCHAR(20) NOT NULL,
Cena INT NOT NULL,
)

CREATE TABLE kasir (
ID INT PRIMARY KEY,
Ime NVARCHAR(20) NOT NULL,
Prezime NVARCHAR(20) NOT NULL,
Imejl NVARCHAR(20) NOT NULL,
Sifra NVARCHAR(20) NOT NULL,
)

CREATE TABLE racun (
ID INT PRIMARY KEY,
ID_kasira INT FOREIGN KEY REFERENCES kasir(ID),
Datum DATE NOT NULL,
)

CREATE TABLE proizvod_racun (
ID INT PRIMARY KEY (ID_proizvod, ID_racun),
ID_proizvod INT FOREIGN KEY REFERENCES proizvod(ID),
ID_racun INT FOREIGN KEY REFERENCES racun(ID),
Kolicina_proizvoda INT NOT NULL
CHECK (Kolicina_proizvoda >= 1),
)

INSERT INTO kasir VALUES
(1, 'Marko', 'Petrovic','marko@gmail.com', '123'),
(2, 'Milos', 'Ilic','milos@gmail.com', '123'),
(3, 'Ana', 'Djordjevic','ana@gmail.com', '123'),
(4, 'Nina', 'Jovanovic','nina@gmail.com', '123')

INSERT INTO proizvod VALUES
(1, 'Cokolada', '100'),
(2, 'Kikiriki', '120'),
(3, 'Napolitanke', '200'),
(4, 'Sok od jabuke', '150')