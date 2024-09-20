CREATE DATABASE api_cs_test;


use api_cs_test;



-- Table Contacts
CREATE TABLE Contacts (
    ContactID INT PRIMARY KEY IDENTITY(1,1),   -- Unique identifier for the contact
    FirstName NVARCHAR(100) NOT NULL,          -- First name of the contact
    LastName NVARCHAR(100),                    -- Last name of the contact
    BirthDate DATE,                            -- Birth date of the contact
    Notes NVARCHAR(MAX),                       -- Additional notes about the contact
    CreatedAt DATETIME DEFAULT GETDATE()       -- Creation date of the record
);

-- Table Phones
CREATE TABLE Phones (
    PhoneID INT PRIMARY KEY IDENTITY(1,1),     -- Unique identifier for the phone number
    ContactID INT,                             -- Foreign key to the Contacts table
    PhoneNumber NVARCHAR(15) NOT NULL,         -- Phone number
    PhoneType NVARCHAR(50),                    -- Type of phone (e.g. Mobile, Home, Work)
    FOREIGN KEY (ContactID) REFERENCES Contacts(ContactID)
);

-- Table Emails
CREATE TABLE Emails (
    EmailID INT PRIMARY KEY IDENTITY(1,1),     -- Unique identifier for the email
    ContactID INT,                             -- Foreign key to the Contacts table
    Email NVARCHAR(255) NOT NULL,              -- Email address
    EmailType NVARCHAR(50),                    -- Type of email (e.g. Personal, Work)
    FOREIGN KEY (ContactID) REFERENCES Contacts(ContactID)
);

-- Table Addresses
CREATE TABLE Addresses (
    AddressID INT PRIMARY KEY IDENTITY(1,1),   -- Unique identifier for the address
    ContactID INT,                             -- Foreign key to the Contacts table
    Street NVARCHAR(255),                      -- Street address
    City NVARCHAR(100),                        -- City
    State NVARCHAR(100),                       -- State or province
    PostalCode NVARCHAR(20),                   -- Postal code
    Country NVARCHAR(100),                     -- Country
    FOREIGN KEY (ContactID) REFERENCES Contacts(ContactID)
);

-- Table Groups
CREATE TABLE Groups (
    GroupID INT PRIMARY KEY IDENTITY(1,1),     -- Unique identifier for the group
    GroupName NVARCHAR(100) NOT NULL           -- Name of the group (e.g. Friends, Family, Work)
);

-- Table ContactGroups (many-to-many relationship between Contacts and Groups)
CREATE TABLE ContactGroups (
    ContactID INT,                             -- Foreign key to the Contacts table
    GroupID INT,                               -- Foreign key to the Groups table
    PRIMARY KEY (ContactID, GroupID),
    FOREIGN KEY (ContactID) REFERENCES Contacts(ContactID),
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)
);
