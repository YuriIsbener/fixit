USE fixit_db;

ALTER TABLE `usuario`
  ADD COLUMN fk_tipouser INT DEFAULT(1),
  ADD FOREIGN KEY fk_tipouser(fk_tipouser) REFERENCES tipouser(idTipoUser) ON DELETE CASCADE;
  
INSERT INTO tipoUser (nomeTipoUser) VALUE (Usuario);
  
ALTER TABLE `usuario` 
ADD FOREIGN KEY(fk_tipoUser) REFERENCES tipouser(idTipoUser),
ADD FOREIGN KEY(fk_setor) REFERENCES setor(idSetor);

ALTER TABLE `chamada` 
ADD FOREIGN KEY(fk_statuschamada) REFERENCES statuschamada(idStatusChamada),
ADD FOREIGN KEY(fk_userColab) REFERENCES usuario(idUsuario),
ADD FOREIGN KEY(fk_userAtend) REFERENCES usuario(idUsuario);

ALTER TABLE `chamater` 
ADD FOREIGN KEY(fk_chamada) REFERENCES chamada(idChamada),
ADD FOREIGN KEY(fk_material) REFERENCES material(idMaterial);

ALTER TABLE chamater DROP COLUMN placeholder;

