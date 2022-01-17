SET IDENTITY_INSERT Destinacije ON;

INSERT INTO Destinacije (ID, Naziv, NazivHotela, BrojDana, Cena) VALUES (1, 'Maldivi', 'Hotel Raj', 7, 999);
INSERT INTO Destinacije (ID, Naziv, NazivHotela, BrojDana, Cena) VALUES (2, 'Tajland', 'Hotel Tajland', 7, 1100);
INSERT INTO Destinacije (ID, Naziv, NazivHotela, BrojDana, Cena) VALUES (3, 'Meksiko Siti', 'Hotel Takos', 10, 1050);
INSERT INTO Destinacije (ID, Naziv, NazivHotela, BrojDana, Cena) VALUES (4, 'Barselona', 'Hotel Barselona', 7, 250);
INSERT INTO Destinacije (ID, Naziv, NazivHotela, BrojDana, Cena) VALUES (5, 'London', 'Hotel London', 7, 340);
INSERT INTO Destinacije (ID, Naziv, NazivHotela, BrojDana, Cena) VALUES (6, 'Rim', 'Hotel Rim', 7, 240);
INSERT INTO Destinacije (ID, Naziv, NazivHotela, BrojDana, Cena) VALUES (7, 'Atina', 'Hotel Atina', 7, 210);
INSERT INTO Destinacije (ID, Naziv, NazivHotela, BrojDana, Cena) VALUES (8, 'Moskva', 'Hotel Moskva', 7, 450);
INSERT INTO Destinacije (ID, Naziv, NazivHotela, BrojDana, Cena) VALUES (9, 'Tokio', 'Hotel Tokio', 7, 950);

SET IDENTITY_INSERT Destinacije OFF;

SET IDENTITY_INSERT Avioni ON;

INSERT INTO Avioni (ID, UkupanBrojSedista, VremePoletanja, VremeSletanja) VALUES (1, 650, '30.01.2022 17:00', '31.01.2022 13:00');
INSERT INTO Avioni (ID, UkupanBrojSedista, VremePoletanja, VremeSletanja) VALUES (2, 600, '30.01.2022 12:00', '31.01.2022 10:00');
INSERT INTO Avioni (ID, UkupanBrojSedista, VremePoletanja, VremeSletanja) VALUES (3, 550, '30.01.2022 09:00', '31.01.2022 08:00');
INSERT INTO Avioni (ID, UkupanBrojSedista, VremePoletanja, VremeSletanja) VALUES (4, 650, '31.01.2022 14:00', '31.01.2022 17:00');
INSERT INTO Avioni (ID, UkupanBrojSedista, VremePoletanja, VremeSletanja) VALUES (5, 600, '31.01.2022 17:00', '31.01.2022 20:00');
INSERT INTO Avioni (ID, UkupanBrojSedista, VremePoletanja, VremeSletanja) VALUES (6, 550, '31.01.2022 12:00', '31.01.2022 14:00');
INSERT INTO Avioni (ID, UkupanBrojSedista, VremePoletanja, VremeSletanja) VALUES (7, 650, '31.01.2022 09:00', '31.01.2022 11:00');
INSERT INTO Avioni (ID, UkupanBrojSedista, VremePoletanja, VremeSletanja) VALUES (8, 600, '31.01.2022 14:00', '31.01.2022 17:00');
INSERT INTO Avioni (ID, UkupanBrojSedista, VremePoletanja, VremeSletanja) VALUES (9, 550, '30.01.2022 17:00', '31.01.2022 12:00');

SET IDENTITY_INSERT Avioni OFF;