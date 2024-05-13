CREATE SCHEMA trip;
GO

CREATE TABLE trip.Client
(
    IdClient  INT           NOT NULL,
    FirstName NVARCHAR(120) NOT NULL,
    LastName  NVARCHAR(120) NOT NULL,
    Email     NVARCHAR(120) NOT NULL,
    Telephone NVARCHAR(120) NOT NULL,
    Pesel     NVARCHAR(120) NOT NULL,
    CONSTRAINT Client_pk PRIMARY KEY (IdClient)
);

CREATE TABLE trip.Client_Trip
(
    IdClient     INT      NOT NULL,
    IdTrip       INT      NOT NULL,
    RegisteredAt DATETIME NOT NULL,
    PaymentDate  DATETIME NULL,
    CONSTRAINT Client_Trip_pk PRIMARY KEY (IdClient, IdTrip)
);

CREATE TABLE trip.Country
(
    IdCountry INT           NOT NULL,
    Name      NVARCHAR(120) NOT NULL,
    CONSTRAINT Country_pk PRIMARY KEY (IdCountry)
);

CREATE TABLE trip.Country_Trip
(
    IdCountry INT NOT NULL,
    IdTrip    INT NOT NULL,
    CONSTRAINT Country_Trip_pk PRIMARY KEY (IdCountry, IdTrip)
);

CREATE TABLE trip.Trip
(
    IdTrip      INT           NOT NULL,
    Name        NVARCHAR(120) NOT NULL,
    Description NVARCHAR(220) NOT NULL,
    DateFrom    DATETIME      NOT NULL,
    DateTo      DATETIME      NOT NULL,
    MaxPeople   INT           NOT NULL,
    CONSTRAINT Trip_pk PRIMARY KEY (IdTrip)
);

ALTER TABLE trip.Country_Trip
    ADD CONSTRAINT Country_Trip_Country
        FOREIGN KEY (IdCountry)
            REFERENCES trip.Country (IdCountry);

ALTER TABLE trip.Country_Trip
    ADD CONSTRAINT Country_Trip_Trip
        FOREIGN KEY (IdTrip)
            REFERENCES trip.Trip (IdTrip);

ALTER TABLE trip.Client_Trip
    ADD CONSTRAINT Table_5_Client
        FOREIGN KEY (IdClient)
            REFERENCES trip.Client (IdClient);

ALTER TABLE trip.Client_Trip
    ADD CONSTRAINT Table_5_Trip
        FOREIGN KEY (IdTrip)
            REFERENCES trip.Trip (IdTrip);

INSERT INTO trip.Client (IdClient, FirstName, LastName, Email, Telephone, Pesel)
VALUES (1, 'John', 'Doe', 'john.doe@example.com', '123-456-7890', '99010112345'),
       (2, 'Alice', 'Smith', 'alice.smith@example.com', '123-456-7891', '99010212346'),
       (3, 'Bob', 'Johnson', 'bob.johnson@example.com', '123-456-7892', '99010312347'),
       (4, 'Charlie', 'Brown', 'charlie.brown@example.com', '123-456-7893', '99010412348'),
       (5, 'David', 'Davis', 'david.davis@example.com', '123-456-7894', '99010512349');


INSERT INTO trip.Country (IdCountry, Name)
VALUES (1, 'Wonderland'),
       (2, 'Atlantis'),
       (3, 'Narnia'),
       (4, 'Neverland'),
       (5, 'Oz');


INSERT INTO trip.Trip (IdTrip, Name, Description, DateFrom, DateTo, MaxPeople)
VALUES (1, 'Adventure Trip', 'An exciting adventure trip to the mountains', '2023-05-01T00:00:00',
        '2023-05-10T00:00:00', 30),
       (2, 'Safari Expedition', 'Explore the wild on this amazing safari', '2023-06-01T00:00:00', '2023-06-15T00:00:00',
        20),
       (3, 'Beach Holiday', 'Relax on the sunny beaches of Paradise Island', '2023-07-01T00:00:00',
        '2023-07-08T00:00:00', 50),
       (4, 'Cultural Tour', 'Discover ancient sites and cultural marvels', '2023-08-01T00:00:00', '2023-08-12T00:00:00',
        25),
       (5, 'Ski Adventure', 'Enjoy the snowy slopes and cozy chalets', '2023-12-01T00:00:00', '2023-12-10T00:00:00',
        15);


INSERT INTO trip.Client_Trip (IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES (1, 1, '2023-04-01T00:00:00', '2023-04-05T00:00:00'),
       (2, 2, '2023-04-02T00:00:00', '2023-04-06T00:00:00'),
       (3, 3, '2023-04-03T00:00:00', '2023-04-07T00:00:00'),
       (4, 4, '2023-04-04T00:00:00', '2023-04-08T00:00:00'),
       (5, 5, '2023-04-05T00:00:00', '2023-04-09T00:00:00');


INSERT INTO trip.Country_Trip (IdCountry, IdTrip)
VALUES (1, 1),
       (2, 2),
       (3, 3),
       (4, 4),
       (5, 5);
