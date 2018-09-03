-- ----------------------------------------------------------------------------------
USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='DbDomain')
	DROP DATABASE DbDomain
GO

CREATE DATABASE DbDomain
GO

USE DbDomain
GO

CREATE TABLE usuario (
	id INT IDENTITY(1,1) NOT NULL, -- ID
	nomape VARCHAR(20) NOT NULL,   -- nombre y apellido   
	nomuser VARCHAR(20) NOT NULL,  -- nombre usuario
	passuser VARCHAR(30) NOT NULL, -- clave
	email VARCHAR(50) NOT NULL,    -- Correo uuario
	ultLogin DATETIME NULL,		   -- ulitmo inicio de sesion
	idRol INT NOT NULL,            -- Id de Rol
	nomRol VARCHAR(50) NOT NULL,   -- Nombre rol (admin, supervisor, vendedor)
	fecreg DATETIME NOT NULL,	   -- fecha de registro
	CONSTRAINT [pk_usuario] PRIMARY KEY ( id )
)
GO

INSERT usuario (nomape, nomuser, passuser, email, ultLogin, idRol, nomRol, fecreg) VALUES (N'Marco Polo', N'marco', N'123456', N'marco@miweb.com', NULL, 1, N'admin', CAST(N'2018-07-16 16:26:03.340' AS DateTime))
GO
INSERT usuario (nomape, nomuser, passuser, email, ultLogin, idRol, nomRol, fecreg) VALUES (N'Carlos Fernandez', N'carlos', N'123456', N'carlos@miweb.com', NULL, 2, N'supervisor', CAST(N'2018-07-16 16:26:31.277' AS DateTime))
GO

-- select * from usuario
CREATE PROCEDURE pa_insertarusuario
	--pa_insertarusuario 'Marco Polo', 'carlos', '123456', 'carlos@miweb.com', 2, 'supervisor'
	@nomape NVARCHAR(20),
	@nomuser NVARCHAR(20),
	@passuser NVARCHAR(20),
	@email VARCHAR(50),
	@idRol INT,
	@nomRol VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS(SELECT id FROM usuario WHERE nomuser = @nomuser)
	BEGIN
		SELECT -1 -- Username exists.
	END
	ELSE IF EXISTS(SELECT id FROM usuario WHERE email = @email)
	BEGIN
		SELECT -2 -- Email exists.
	END
	ELSE
	BEGIN
		INSERT INTO usuario (nomape, nomuser, passuser, email, idRol, nomRol, fecreg)
		VALUES (@nomape ,@nomuser ,@passuser ,@email ,@idRol ,@nomRol ,GETDATE())
		SELECT SCOPE_IDENTITY() -- UserId			   
     END
END
GO


CREATE PROCEDURE pa_validarusuario
	-- pa_validarusuario 'marsco', '123456'
    @nomuser VARCHAR(20),
    @passuser VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @idusuario INT, @ultLogin DATETIME
    
	-- Guardando datos de usuario (suponiendo que usuario es unico)
	SELECT * INTO #usuario FROM usuario WHERE nomuser = @nomuser

	-- Seteando idusuario y ultlogin
	SELECT @idusuario=id, @ultLogin=ultLogin FROM #usuario

    -- Verificando que existe idusuario
	IF @idusuario IS NOT NULL
	BEGIN
		IF EXISTS (SELECT * FROM #usuario WHERE passuser = @passuser)
		BEGIN
			UPDATE usuario SET ultLogin = GETDATE() WHERE id = @idusuario
			SELECT @idusuario AS idusuario -- Usuario existe
		END
		ELSE
		BEGIN
			SELECT -1 -- password incorrecto
		END
	END
	ELSE
	BEGIN
		SELECT 0 -- Usuario no existe
	END
END
GO