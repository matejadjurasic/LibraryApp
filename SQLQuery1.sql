-- Create Korisnik table
CREATE TABLE Korisnik (
    KorisnikId INT IDENTITY(1,1) PRIMARY KEY,
    Ime NVARCHAR(50) NOT NULL,
    Prezime NVARCHAR(50) NOT NULL,
    KorisnickoIme NVARCHAR(50) NOT NULL UNIQUE,
    Sifra NVARCHAR(255) NOT NULL
);

-- Create Bibliotekar table
CREATE TABLE Bibliotekar (
    BibliotekarId INT IDENTITY(1,1) PRIMARY KEY,
    Ime NVARCHAR(50) NOT NULL,
    Prezime NVARCHAR(50) NOT NULL,
    KorisnickoIme NVARCHAR(50) NOT NULL UNIQUE,
    Sifra NVARCHAR(255) NOT NULL
);

-- Create Knjiga table
CREATE TABLE Knjiga (
    KnjigaId INT IDENTITY(1,1) PRIMARY KEY,
    Ime NVARCHAR(100) NOT NULL,
    BrojKopija INT NOT NULL,
    BrojDostupnihKopija INT NOT NULL
);

-- Create Pisac table
CREATE TABLE Pisac (
    PisacId INT IDENTITY(1,1) PRIMARY KEY,
    Ime NVARCHAR(50) NOT NULL,
    Prezime NVARCHAR(50) NOT NULL
);

-- Create KnjigaPisac table to represent many-to-many relationship
CREATE TABLE KnjigaPisac (
    KnjigaId INT NOT NULL,
    PisacId INT NOT NULL,
    PRIMARY KEY (KnjigaId, PisacId),
    FOREIGN KEY (KnjigaId) REFERENCES Knjiga(KnjigaId) ON DELETE CASCADE,
    FOREIGN KEY (PisacId) REFERENCES Pisac(PisacId) ON DELETE CASCADE
);

-- Create Potvrda table
CREATE TABLE Potvrda (
    PotvrdaId INT IDENTITY(1,1) PRIMARY KEY,
    DatumOd DATETIME NOT NULL,
    KorisnikId INT NOT NULL,
    BibliotekarId INT NOT NULL,
    FOREIGN KEY (KorisnikId) REFERENCES Korisnik(KorisnikId),
    FOREIGN KEY (BibliotekarId) REFERENCES Bibliotekar(BibliotekarId)
);

-- Create StavkaPotvrde table
CREATE TABLE StavkaPotvrde (
    StavkaId INT IDENTITY(1,1) PRIMARY KEY,
    Kolicina INT NOT NULL,
    KnjigaId INT NOT NULL,
    PotvrdaId INT NOT NULL,
	Returned BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (KnjigaId) REFERENCES Knjiga(KnjigaId),
    FOREIGN KEY (PotvrdaId) REFERENCES Potvrda(PotvrdaId)
);


-- Insert first Bibliotekar
INSERT INTO Bibliotekar (Ime, Prezime, KorisnickoIme, Sifra)
VALUES ('Marko', 'Petrovic', 'mpetrovic', 'securepassword1');

-- Insert second Bibliotekar
INSERT INTO Bibliotekar (Ime, Prezime, KorisnickoIme, Sifra)
VALUES ('Ana', 'Jovanovic', 'ajovanovic', 'securepassword2');