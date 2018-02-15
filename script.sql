CREATE DATABASE Test
GO

USE Test
GO

CREATE TABLE [dbo].[Alumno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Sexo] [int] NOT NULL,
	[FechaNacimiento] [varchar](10) NOT NULL
    primary key (id))
GO