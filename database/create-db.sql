CREATE DATABASE TechRacingF1
ON PRIMARY(
	NAME = 'TechRacingF1_Data',
	FILENAME='C:\\SQLData\TechRacingF1_Data.mdf',
	SIZE=10MB,
	MAXSIZE=UNLIMITED,
	FILEGROWTH=20%
) 
LOG ON(
	NAME = 'TechRacingF1_Log',
	FILENAME='C:\\SQLData\TechRacingF1_Log.ldf',
	SIZE=10MB,
	MAXSIZE=UNLIMITED,
	FILEGROWTH=10%
);