SELECT  colaborador.usuario_fk, colaborador.setorColab_fk, usuario.nome, usuario.tipoUser, usuario.email FROM colaborador
INNER JOIN usuario ON colaborador.usuario_fk = usuario.idUsuario