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
FOREIGN KEY(idTipoUser) REFERENCES tipoUser(idTipoUser),
FOREIGN KEY(idSetor) REFERENCES setor(idSetor),
nome VARCHAR(50) NOT NULL,
email VARCHAR(20) UNIQUE NOT NULL,
senha VARCHAR(20) NOT NULL
);

CREATE TABLE chamada(
idChamada INT PRIMARY KEY,
FOREIGN KEY(UserCaller_id) REFERENCES usuario(idUsuario),
FOREIGN KEY(UserRespond_id) REFERENCES usuario(idUsuario),
FOREIGN KEY(statusChamada_id) REFERENCES statusChamada(idStatusChamada),
dataChamada DATETIME NOT NULL,
nomeChamado VARCHAR(40) NOT NULL,
descricao VARCHAR(150) NOT NULL
);

CREATE TABLE chamMater(
FOREIGN KEY(material_id) REFERENCES material(idMaterial),
FOREIGN KEY(chamada_id) REFERENCES cahamada(idChamada)
);