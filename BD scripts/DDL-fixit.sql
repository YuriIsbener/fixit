CREATE DATABASE fixit_db;

USE fixit_db;

CREATE TABLE tipoUser(
PRIMARY KEY(idTipoUser), 
nomeTipoUser VARCHAR(20) NOT NULL
);

CREATE TABLE setor(
PRIMARY KEY(idSetor), 
nomeSetor VARCHAR(20) NOT NULL
);

CREATE TABLE material(
PRIMARY KEY(idMaterial), 
nomeMaterial VARCHAR(40) NOT NULL, 
quantMaterial INT NOT NULL
);

CREATE TABLE statusChamada(
PRIMARY KEY(idStatusChamada), 
nomeStatusChamada VARCHAR(40) NOT NULL
);

CREATE TABLE usuario(
PRIMARY KEY(idUsuario),
FOREIGN KEY(idTipoUser) REFERENCES tipoUser(idTipoUser),
FOREIGN KEY(idSetor) REFERENCES setor(idSetor),
nome VARCHAR(50) NOT NULL,
email VARCHAR(20) UNIQUE NOT NULL,
senha VARCHAR(20) NOT NULL
);

CREATE TABLE chamada(
PRIMARY KEY(idChamada),
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