USE master
GO
IF NOT EXISTS (
    SELECT name
    FROM sys.databases
    WHERE name = N'usuarios'
)
CREATE DATABASE usuarios;

GO

USE usuarios;

IF OBJECT_ID('Pessoa', 'U') IS NULL 
CREATE TABLE Pessoa(
    idPessoa INT PRIMARY KEY IDENTITY NOT NULL,
    nome varchar(45) NOT NULL,
    sobrenome varchar(45) NOT NULL,
    email varchar(100) NOT NULL,
    telefone varchar(16) NOT NULL,
    data_nasc DATE NOT NULL
);

IF OBJECT_ID('Autenticacao', 'U') IS NULL 
CREATE TABLE Autenticacao(
    id INT PRIMARY KEY IDENTITY NOT NULL,
	idPessoa INT,
    FOREIGN KEY(idPessoa) REFERENCES Pessoa(idPessoa),
    senha VARCHAR(45),
    estado BIT NOT NULL
);

GO

INSERT INTO Pessoa (nome, sobrenome, email, telefone, data_nasc) VALUES (
    'André',
    'Stanlley',
    'andre.v@lyncas.net',
    '(84) 99674-4711',
    '26/03/1999'
);

INSERT INTO Autenticacao (idPessoa, senha, estado) VALUES (
	@@IDENTITY,
    '260399As',
    1
);

INSERT INTO Pessoa (nome, sobrenome, email, telefone, data_nasc) VALUES (
    'Anderson',
    'Frare',
    'anderson.f@lyncas.net',
    '(47) 99965-8818',
    '12/09/1985'
);

INSERT INTO Autenticacao (idPessoa, senha, estado) VALUES (
	@@IDENTITY,
    'EuAmoReact',
    1
);

INSERT INTO Pessoa (nome, sobrenome, email, telefone, data_nasc) VALUES (
    'Genara',
    'Sousa',
    'genara.s@lyncas.net',
    '(91) 99134-8827',
    '25/01/1998'
);

INSERT INTO Autenticacao (idPessoa, senha, estado) VALUES (
	@@IDENTITY,
    'EuOdeioReact',
    1
);

GO

DELETE FROM Autenticacao
WHERE idPessoa = @@IDENTITY

DELETE FROM Pessoa
WHERE idPessoa = @@IDENTITY

GO

UPDATE Pessoa
SET data_nasc = '12/09/1995'
WHERE idPessoa = 2

GO

SELECT id, estado, nome, sobrenome, email, senha, telefone, data_nasc
FROM Pessoa as P INNER JOIN Autenticacao as A
ON P.idPessoa = A.idPessoa AND estado = 1