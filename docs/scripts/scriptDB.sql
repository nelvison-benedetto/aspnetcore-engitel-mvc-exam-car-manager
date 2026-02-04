
--ricordati sempre le ',' a fine riga!!! tsql altrimenti puo dare problemi.
--consigliato evitare parole risevate come 'Day' x tabs, ok e.g.CalendarDay, quindi evita usando e.g.[Day]

USE master;
GO
DROP DATABASE examEngitelDB;
go

go;
create database examEngitelDB;

use examEngitelDB;

create table dbo.[Famiglia](
	FamigliaId int identity(1,1),
	Nome nvarchar(50) not null,
	Componenti int not null,  -- 1-10max
	--ComponentiWCar int not null

	constraint PK_Famiglia
		primary key (FamigliaId),
);

create table dbo.[Veicolo](
	VeicoloId int identity(1,1),
	Targa nvarchar(50) not null,
	Modello nvarchar(50) not null,

	constraint PK_Veicolo 
		primary key (VeicoloId),
	constraint UQ_Veicolo_Targa
		unique (Targa),  --xk nel mondo reale non ci sono 2 targhe uguali !
);

create table dbo.[Person](
	PersonId int identity(1,1),
	Nome nvarchar(50),  --not null se in fututo voglio aggiungere un nome ai componenti della famiglia
	FamigliaId int not null,
	VeicoloId int null,  --ok, PERCHE PUO ESISTERE ANCHE SE NON HA NESSUNA MACCHINA!!

	constraint PK_Person
		primary key (PersonId),
	constraint FK_Person_Famiglia
		foreign key (FamigliaId) references [Famiglia](FamigliaId) on delete cascade, 
			--IMPORTANTE!! se cancello Famiglia allora vengono cancellate le Persone collegate
	constraint FK_Person_Veicolo
		foreign key (VeicoloId) references [Veicolo](VeicoloId) on delete set null, 
			--IMPORTANTE! se cancello Auto allora esplicito che qui VeicoloId si settera a null
);


create table dbo.[Day](  --oppure anche CalendarDay
	DayId int identity(1,1),
	TheDate date not null,  --no datetime2(3) xk intanto non servono ore millisecondi ect

	constraint PK_Day
		primary key (DayId),
	constraint UQ_Day_AttendanceDate
		unique (TheDate),  --non ci possono essere 
);

create table dbo.[Appuntamento](
	AppuntamentoId int identity(1,1),
	--IsAvailable bit not null,
	[Status] nvarchar(20) NOT NULL,
	DayId int not null,
	FamigliaId int null,  --xk puoi creare appuntamento, poi quando si presentera la famiglia allora completi tutti i datas

	constraint PK_Appuntamento
		primary key (AppuntamentoId),
	constraint FK_Appuntamento_Day
		foreign key (DayId) references dbo.[Day](DayId) on delete cascade,
	constraint FK_Appuntamento_Famiglia
		foreign key (FamigliaId) references dbo.[Famiglia](FamigliaId) on delete set null,
	constraint UQ_Appuntamento_Day_Famiglia
		unique (DayId, FamigliaId),

	constraint DF_Appuntamento_Status 
		default 'Booked' for [Status],
	 constraint CK_Appuntamento_Status
        check ([Status] in ('Booked', 'Cancelled', 'Completed'))
);
	
CREATE UNIQUE INDEX UX_Appuntamento_Day_Famiglia
ON dbo.Appuntamento (DayId, FamigliaId)
WHERE FamigliaId IS NOT NULL;
	
CREATE UNIQUE INDEX UX_Appuntamento_Day_Booked
ON dbo.Appuntamento (DayId)
WHERE Status = 'Booked'


select * from dbo.Famiglia;
select * from dbo.Person;
select * from dbo.Veicolo;
select * from dbo.[Day];
select * from dbo.Appuntamento;


--USE examEngitelDB;
--GO
---- Figlie
--DELETE FROM dbo.Appuntamento;
--DELETE FROM dbo.Person;
---- Dipendenti
--DELETE FROM dbo.Veicolo;
---- Padri
--DELETE FROM dbo.Day;
--DELETE FROM dbo.Famiglia;
--GO