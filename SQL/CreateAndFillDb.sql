DROP DATABASE IF EXISTS DbDemo;
CREATE DATABASE DbDemo;

USE DbDemo;


CREATE TABLE User (
                      Id INT PRIMARY KEY AUTO_INCREMENT,
                      Username VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE Todo (
                      Id INT PRIMARY KEY AUTO_INCREMENT,
                      Title VARCHAR(255) NOT NULL,
                      UserId INT REFERENCES User(Id),
                      Description TEXT,
                      IsCompleted BOOLEAN DEFAULT FALSE,
                      CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO User (Username) VALUES ('john_doe');
SET @userdid1 = LAST_INSERT_ID();

INSERT INTO User (Username) VALUES ('jane_doe');
SET @userdid2 = LAST_INSERT_ID();

INSERT INTO Todo (Title, UserId, Description) VALUES ('Buy groceries', @userdid1, 'Milk, Bread, Eggs');
INSERT INTO Todo (Title, UserId, Description) VALUES ('Finish project', @userdid1, 'Complete the SQL project by Friday');
INSERT INTO Todo (Title, UserId, Description) VALUES ('Call mom', @userdid2, 'Check in with mom about weekend plans');
INSERT INTO Todo (Title, UserId, Description) VALUES ('Read book', @userdid2, 'Finish reading the novel by next week');



