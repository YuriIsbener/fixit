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
(4,"Aguardando");

INSERT INTO usuario(idUsuario, nome, tipoUser, email, senha) 
VALUES
(1,"Admin", true, "ADM@gmail.com", "dev@132");

INSERT INTO colaborador(usuario_fk, setorColab_fk)
VALUES(1, 4)

 

