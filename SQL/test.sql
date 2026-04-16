DROP DATABASE IF EXISTS company;
CREATE DATABASE company;
 
USE company;

CREATE TABLE department
(
    idDepartment INT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name         VARCHAR(80)  NOT NULL,
    description  VARCHAR(255) NULL DEFAULT ''
) COMMENT "Departments";

CREATE UNIQUE INDEX uniqueName ON department(name);

INSERT INTO department (name, description)
VALUEs ('Personeelszaken', 'De afdeling Personeelszaken'),
       ('Staalverwerking', 'De fabriek'),
       ('Sales', 'De afdeling verkoop'),
       ('Klantenservice', 'De ondersteuning voor klanten')
;

SELECT idDepartment INTO @Personeelszaken FROM department WHERE name='Personeelszaken';
SELECT idDepartment INTO @Sales FROM department WHERE name='Sales';
SELECT idDepartment INTO @CustomerService FROM department WHERE name='Klantenservice';
SELECT idDepartment INTO @Production FROM department WHERE name='Staalverwerking';

CREATE TABLE employees
(
    idEmployee INT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,
    firstname VARCHAR(50) NOT NULL,
    lastname VARCHAR(50) NOT NULL,
    middlename VARCHAR(20) NULL,
    fk_idDepartment INT UNSIGNED NOT NULL
);

CREATE UNIQUE INDEX unique_employee ON employees(firstname, lastname, middlename);

INSERT INTO employees (firstname, lastname, middlename, fk_idDepartment)
VALUES ('Kees', 'Wal', 'van der', @Sales),
       ('Jan Jaap','Vries','de', @Sales),
       ('Bertus','Hoor','ten', @Personeelszaken),
       ('Karel','Paardepoot','', @Personeelszaken),
       ('Mary','Poppins','', @Personeelszaken),
       ('Donald','Duck','', @Production),
       ('Kwik','Duck','', @Production),
       ('Kwak','Duck','', @Production),
       ('Dagobert','Duck','', @CustomerService),
       ('Guus','Geluk','', @CustomerService),
       ('Daisy','Duck','', @CustomerService)
;