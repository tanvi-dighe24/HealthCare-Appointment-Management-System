/* Healthcare Project - Database Setup Script
   This script creates the table for storing patient appointments.
*/

CREATE DATABASE HospitalDB;
GO

USE HospitalDB;
GO

CREATE TABLE AppointmentTable (
    PatientId INT PRIMARY KEY IDENTITY(1,1), -- Automatically increments the ID
    PatientName VARCHAR(100) NOT NULL,
    PatientEmail VARCHAR(100),
    DoctorSpecialty VARCHAR(50),
    AppointmentDate DATETIME,
    IsConfirmed BIT DEFAULT 1 -- 1 for True, 0 for False
);

-- Adding a sample record so the table isn't empty
INSERT INTO AppointmentTable (PatientName, PatientEmail, DoctorSpecialty, AppointmentDate)
VALUES ('Rahul Sharma', 'rahul@email.com', 'Cardiology', '2026-02-10 10:30:00');

-- Query to check data
SELECT * FROM AppointmentTable;