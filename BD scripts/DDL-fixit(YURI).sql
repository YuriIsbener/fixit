CREATE DATABASE fixit_db;

USE fixit_db;

CREATE TABLE setor(
idSetor INT NOT NULL AUTO_INCREMENT, 
nomeSetor VARCHAR(20) NOT NULL,
CONSTRAINT setor_pk PRIMARY KEY(idSetor)
);

CREATE TABLE material(
idMaterial INT NOT NULL AUTO_INCREMENT, 
nomeMaterial VARCHAR(40) NOT NULL, 
quantMaterial INT NOT NULL,
CONSTRAINT material_pk PRIMARY KEY(idMaterial)
);

CREATE TABLE statusChamada(
idStatusChamada INT NOT NULL AUTO_INCREMENT, 
nomeStatusChamada VARCHAR(40) NOT NULL,
CONSTRAINT statusChamada_pk PRIMARY KEY(idStatusChamada)
);

CREATE TABLE usuario(
idUsuario INT NOT NULL AUTO_INCREMENT,
nome VARCHAR(50) NOT NULL,
tipoUser BOOLEAN,
email VARCHAR(20) UNIQUE NOT NULL,
senha VARCHAR(20) NOT NULL,
CONSTRAINT usuario_pk PRIMARY KEY(idUsuario)
);
CREATE TABLE colaborador(
idColaborador INT NOT NULL AUTO_INCREMENT,
usuario_fk INT NOT NULL,
setorColab_fk INT NOT NULL,

FOREIGN KEY (usuario_fk)
        REFERENCES usuario(idUsuario)
        ON DELETE CASCADE,
        
FOREIGN KEY (setorColab_fk)
        REFERENCES setor(idSetor)
        ON DELETE CASCADE,

CONSTRAINT colaborador_pk PRIMARY KEY(idColaborador)
);

CREATE TABLE prestador(
idPrestador INT NOT NULL AUTO_INCREMENT,
usuario_fk INT NOT NULL,
setorPrest_fk INT NOT NULL,

FOREIGN KEY (usuario_fk)
        REFERENCES usuario(idUsuario)
        ON DELETE CASCADE,

FOREIGN KEY (setorPrest_fk)
        REFERENCES setor(idSetor)
        ON DELETE CASCADE,
        
CONSTRAINT prestador_pk PRIMARY KEY(idPrestador)
);

CREATE TABLE chamada(
idChamada INT NOT NULL AUTO_INCREMENT,
prestador_fk INT NOT NULL,
colaborador_fk INT NOT NULL,
statusChamada_fk INT NOT NULL,

FOREIGN KEY (prestador_fk)
        REFERENCES prestador(idPrestador)
        ON DELETE CASCADE,

FOREIGN KEY (colaborador_fk)
        REFERENCES colaborador(idColaborador)
        ON DELETE CASCADE,

FOREIGN KEY (statusChamada_fk)
        REFERENCES statusChamada(idStatusChamada)
        ON DELETE CASCADE,
        
nomeChamado VARCHAR(40) NOT NULL,
dataChamada DATETIME NOT NULL,
CONSTRAINT chamada_pk PRIMARY KEY(idChamada)
);

CREATE TABLE chaMater(
material_fk INT NOT NULL,
chamada_fk INT NOT NULL,

FOREIGN KEY (material_fk)
        REFERENCES material(idMaterial)
        ON DELETE CASCADE,
        
FOREIGN KEY (chamada_fk)
        REFERENCES chamada(idChamada)
        ON DELETE CASCADE
);