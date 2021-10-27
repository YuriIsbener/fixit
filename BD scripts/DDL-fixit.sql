CREATE DATABASE fixit_db;

USE fixit_db;

CREATE TABLE tipoUser(
idTipoUser INT PRIMARY KEY, 
nomeTipoUser VARCHAR(20) NOT NULL
);

CREATE TABLE setor(
idSetor INT PRIMARY KEY, 
nomeSetor VARCHAR(20) NOT NULL
);

CREATE TABLE material(
idMaterial INT PRIMARY KEY, 
nomeMaterial VARCHAR(40) NOT NULL, 
quantMaterial INT NOT NULL
);

CREATE TABLE statusChamada(
idStatusChamada INT PRIMARY KEY, 
nomeStatusChamada VARCHAR(40) NOT NULL
);

CREATE TABLE usuario(
idUsuario INT PRIMARY KEY,
nome VARCHAR(50) NOT NULL,
email VARCHAR(20) UNIQUE NOT NULL,
senha VARCHAR(20) NOT NULL
);

CREATE TABLE chamada(
idChamada INT PRIMARY KEY,
dataChamada DATETIME NOT NULL,
nomeChamado VARCHAR(40) NOT NULL
);

CREATE TABLE chaMater(
placeholder VARCHAR(10) NOT NULL
);