use [Bazar];

CREATE TABLE Utente(
Email nvarchar(50) NOT NULL PRIMARY KEY,
Ruolo nvarchar(max) NOT NULL,
Psw nvarchar(max) NOT NULL,
CHECK(Ruolo in ('Admin','User'))
);


CREATE TABLE Prodotto(
IdProdotto int IDENTITY(1,1) NOT NULL PRIMARY KEY,
NomeProdotto nvarchar(max) NOT NULL,
DescrizioneProdotto nvarchar(max) NOT NULL,
Prezzo Decimal (9,2) NOT NULL,
Sconto tinyint NULL,
LinkImmagine nvarchar NULL,
Disponibile bit NOT NULL,
CHECK (Prodotto.Sconto >=0 AND Prodotto.Sconto <= 100)
);

CREATE TABLE Ordine(
IdOrdine int IDENTITY(1,1) NOT NULL PRIMARY KEY,
DataOrdine datetime2 (7) NOT NULL,
Stato nvarchar(max) NOT NULL,
DataSpedizione datetime2 (7) NULL,
Email nvarchar(50) FOREIGN KEY REFERENCES dbo.Utente (Email) on update cascade on delete cascade,
CHECK(Stato in ('Processato','Spedito'))
);

CREATE TABLE Carrello(
IdCarrello int IDENTITY(1,1) NOT NULL PRIMARY KEY,
DataCreazioneCarrello datetime2 (7) NOT NULL,
Email nvarchar(50) NULL FOREIGN KEY REFERENCES dbo.Utente (Email) on update cascade on delete cascade UNIQUE
);


CREATE TABLE Ordine_Prodotto(
IdOrdine int FOREIGN KEY REFERENCES dbo.Ordine (IdOrdine) on update cascade on delete cascade, 
IdProdotto int FOREIGN KEY REFERENCES dbo.Prodotto (IdProdotto) on update cascade on delete cascade, 
Quantita int not null,
primary key (IdProdotto, IdOrdine)
);


