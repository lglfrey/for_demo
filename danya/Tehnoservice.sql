set ansi_nulls on
go
set ansi_padding on
go
SET ANSI_WARNINGS ON
go
set quoted_identifier on 
go

create database [OOO_Tehnoservice]
go
alter database [OOO_Tehnoservice] set Enable_Broker
go
use [OOO_Tehnoservice]
go

create table [ROLE]
(
	[ID_ROLE] int not null identity(1,1) primary key,
	[NAME_ROLE] varchar(50) not null,
) on [PRIMARY];
insert into [dbo].[ROLE] ([NAME_ROLE]) 
values ('Админ'), ('Клиент')
select * from [ROLE]

create table [USER]
(
	[ID_USER] int not null identity(1,1) primary key,
	[LOGIN_USER] varchar(50) not null,
	[PASSWORD_USER] varchar(50) not null,
	[FIRST_NAME_USER] varchar(100) not null,
	[SECOND_NAME_USER] varchar(100) not null,
	[MIDDLE_NAME_USER] varchar(100) null default('-'),
	[ROLE_ID] int not null,
	constraint [FK_ROLE] foreign key ([ROLE_ID])
	references [dbo].[ROLE] ([ID_ROLE])
) on [PRIMARY];
insert into [dbo].[USER] ([LOGIN_USER], [PASSWORD_USER], [FIRST_NAME_USER], [SECOND_NAME_USER], [MIDDLE_NAME_USER], [ROLE_ID]) 
values ('admin@yandex.ru','pa$$123', 'Админ', 'Админов','Админович',1), ('client@yandex.ru','pa$$123', 'Клиент', 'Клиентов','Клиентович',2)
select * from [user]


create table [ORDER] 
(
	[ID_ORDER] int not null identity(1,1) primary key,
	[DATE_ORDER] date not null default(getdate()),
	[NAME_EQUIPMENT] varchar(150) not null,
	[TYPE_PROBLEM] varchar(150) not null,
	[DESCRIPTION_PROBLEM] varchar(max) not null,
	[CLIENT_ID] int not null,
	[STATUS_ID] int not null,
	constraint [FK_CLIENT] foreign key ([CLIENT_ID])
	references [dbo].[USER] ([ID_USER]),
	constraint [FK_STATUS] foreign key ([STATUS_ID])
	references [dbo].[ORDER_STATUS] ([ID_ORDER_STATUS]),
) ON [PRIMARY];
insert into [dbo].[ORDER] ([NAME_EQUIPMENT], [TYPE_PROBLEM], [DESCRIPTION_PROBLEM], [CLIENT_ID], [STATUS_ID]) 
values ('Камера','Поломка', 'Все плохо', 1,1)
select * from [order]

create table [ORDER_STATUS]
(
	[ID_ORDER_STATUS] int not null identity(1,1) primary key,
	[NAME_ORDER_STATUS] varchar(50) not null,
) on [PRIMARY];
insert into [dbo].[ORDER_STATUS] ([NAME_ORDER_STATUS]) 
values ('В ожидании'), ('В работе'), ('Выполнено')
select * from [ORDER_STATUS]

SELECT 
                o.ID_ORDER, 
                o.DATE_ORDER, 
                o.NAME_EQUIPMENT, 
                o.TYPE_PROBLEM, 
                o.DESCRIPTION_PROBLEM, 
                u.NAME_USER AS CLIENT_NAME,
				os.NAME_STATUS AS STATUS_NAME
                FROM [DBO].[ORDER] o 
                inner join [dbo].[user] u on o.CLIENT_ID = u.ID_USER
                inner join [dbo].[ORDER_STATUS] os on o.STATUS_ID = os.ID_ORDER_STATUS