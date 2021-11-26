USE fixit_db;

SELECT  colaborador.setorColab_fk, 
		usuario.nome, usuario.tipoUser, 
		usuario.email,
        setor.nomeSetor
	FROM colaborador
INNER JOIN usuario ON colaborador.usuario_fk = usuario.idUsuario
INNER JOIN setor ON colaborador.setorColab_fk = setor.idSetor;

SELECT 
		chamada.nomeChamado,
		statusChamada.nomeStatusChamada,
        prestador.usuario_fk, 
        colaborador.usuario_fk,
        usuario.nome
        FROM chamada
INNER JOIN statusChamada ON chamada.statusChamada_fk = statusChamada.idStatusChamada
INNER JOIN prestador ON chamada.prestador_fk = prestador.idPrestador
INNER JOIN colaborador ON chamada.colaborador_fk = colaborador.idColaborador
INNER JOIN usuario ON colaborador.usuario_fk = usuario.idusuario
WHERE colaborador.usuario_fk = 3 OR prestador.usuario_fk = 2;

SELECT * FROM colaborador
