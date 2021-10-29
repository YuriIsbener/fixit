USE fixit_db;

INSERT INTO setor(idSetor, nomeSetor) 
VALUES
(1,"Limpeza"),
(2,"Manutenção"),
(3,"Suporte Técnico");

INSERT INTO statusChamada(idStatusChamada, nomeStatusChamada) 
VALUES
(1,"Em Andamento"),
(2,"Concluído"),
(3,"Cancelado"),
(4,"Aguardando");
