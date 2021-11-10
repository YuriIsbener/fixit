USE fixit_db;

SELECT  colaborador.setorColab_fk, 
		usuario.nome, usuario.tipoUser, 
		usuario.email,
        setor.nomeSetor
	FROM colaborador
INNER JOIN usuario ON colaborador.usuario_fk = usuario.idUsuario
INNER JOIN setor ON colaborador.setorColab_fk = setor.idSetor