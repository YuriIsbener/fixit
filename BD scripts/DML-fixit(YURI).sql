USE fixit_db;

INSERT INTO setor(idSetor, nomeSetor) 
VALUES
(1,"Limpeza"),
(2,"Manutenção"),
(3,"Suporte Técnico"),
(4,"Direção");

INSERT INTO statusChamada(idStatusChamada, nomeStatusChamada) 
VALUES
(1,"Em Andamento"),
(2,"Concluído"),
(3,"Cancelado"),
(4,"Aguardando"),
(5, "Inativo");

INSERT INTO usuario(idUsuario, nome, tipoUser, email, senha) 
VALUES
(1,"Admin", true, "ADM@gmail.com", "dev@132"),
(2, "Teste", false, "teste@gmail.com", "teste");

INSERT INTO colaborador(idColaborador, usuario_fk, setorColab_fk)
VALUES
(1, 1, 4);

INSERT INTO prestador(idPrestador, usuario_fk, setorPrest_fk)
VALUES
(1, 2, 3);

INSERT INTO chamada(idChamada, prestador_fk, colaborador_fk, statuschamada_fk, nomeChamado, dataChamada)
VALUES
(1, 1, 1, 2, "teste", '2011-12-18 13:17:17');





 

