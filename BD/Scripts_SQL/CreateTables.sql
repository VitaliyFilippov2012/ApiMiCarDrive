USE [MICARDRIVE]
GO

DROP TABLE [ACTION_AUDIT]
DROP TABLE [DETAILS]
DROP TABLE [CAR_SERVICES]
DROP TABLE [REFILL]
DROP TABLE [CAR_EVENTS]
DROP TABLE [AUTHENTICATION]
DROP TABLE [USERS_CARS_ROLES]
DROP TABLE [USERS_CARS_RIGHTS]
DROP TABLE [USERS_CARS]
DROP TABLE [CARS]
DROP TABLE [USERS]
DROP TABLE [PHOTO_PHOTO_ARCHIVE]
DROP TABLE [PHOTO_ARCHIVE]
DROP TABLE [PHOTO]
DROP TABLE [ROLES]
DROP TABLE [RIGHTS]
DROP TABLE [TRANSMISSION_TYPES]
DROP TABLE [FUEL_TYPES]
DROP TABLE [EVENT_TYPES]
DROP TABLE [SERVICE_TYPES]

CREATE TABLE [PHOTO](
	[PHOTO_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[NAME] VARCHAR(50) NOT NULL,
	[EXPANSION] VARCHAR(10) NOT NULL,
	CONSTRAINT PK_PHOTO PRIMARY KEY([PHOTO_ID])
);

CREATE TABLE [PHOTO_ARCHIVE](
	[PHOTO_ARCHIVE_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[PATH] VARCHAR(200) NOT NULL UNIQUE,
	CONSTRAINT PK_PHOTOARCHIVE PRIMARY KEY([PHOTO_ARCHIVE_ID])
);

CREATE TABLE [PHOTO_PHOTO_ARCHIVE](
	[PHOTO_ARCHIVE_ID] UNIQUEIDENTIFIER NOT NULL,
	[PHOTO_ID] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_PHOTO_PHOTOARCHIVE_PHOTO FOREIGN KEY([PHOTO_ARCHIVE_ID]) REFERENCES PHOTO_ARCHIVE([PHOTO_ARCHIVE_ID]),
	CONSTRAINT FK_PHOTO_PHOTOARCHIVE_PHOTOARCHIVE FOREIGN KEY([PHOTO_ID]) REFERENCES PHOTO([PHOTO_ID]),
	CONSTRAINT PK_PHOTO_PHOTOARCHIVE PRIMARY KEY([PHOTO_ARCHIVE_ID],[PHOTO_ID])
);

CREATE TABLE [ROLES](
	[ROLE_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[NAME] VARCHAR(50) NOT NULL UNIQUE,
	CONSTRAINT PK_ROLES PRIMARY KEY([ROLE_ID])
);

CREATE TABLE [RIGHTS](
	[RIGHT_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[NAME] VARCHAR(100) NOT NULL UNIQUE,
	CONSTRAINT PK_RIGHTS PRIMARY KEY([RIGHT_ID])
);

CREATE TABLE [FUEL_TYPES](
	[FUEL_TYPE_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[NAME] VARCHAR(50) NOT NULL UNIQUE,
	CONSTRAINT PK_FUEL_TYPES PRIMARY KEY([FUEL_TYPE_ID])
);

CREATE TABLE [TRANSMISSION_TYPES](
	[TRANSMISSION_TYPE_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[NAME] VARCHAR(50) NOT NULL UNIQUE,
	CONSTRAINT PK_TRANSMISSION_TYPES PRIMARY KEY([TRANSMISSION_TYPE_ID])
);

CREATE TABLE [EVENT_TYPES](
	[EVENT_TYPE_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[NAME] VARCHAR(50) NOT NULL UNIQUE,   
	CONSTRAINT PK_TYPE_EVENTS PRIMARY KEY([EVENT_TYPE_ID])
);

CREATE TABLE [SERVICE_TYPES](
	[SERVICE_TYPE_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[NAME] VARCHAR(20) NOT NULL UNIQUE,
	CONSTRAINT PK_TYPE_SERVICE PRIMARY KEY([SERVICE_TYPE_ID])
);

CREATE TABLE [USERS](
	[USER_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[GENDER] NVARCHAR(1) CHECK ([GENDER] IN ('M','F','m','f')) NOT NULL,
	[BIRTHDAY] DATE NOT NULL,
	[NAME] NVARCHAR(20) NOT NULL,
	[LASTNAME] NVARCHAR(20) NOT NULL,
	[PATRONYMIC] NVARCHAR(30) NOT NULL,
	[PHONE] NVARCHAR(20),
	[CITY] NVARCHAR(20) NOT NULL,
	[PHOTO_ARCHIVE_ID] UNIQUEIDENTIFIER,
	CONSTRAINT FK_USERS_PHOTOARCHIVE FOREIGN KEY([PHOTO_ARCHIVE_ID]) REFERENCES PHOTO_ARCHIVE([PHOTO_ARCHIVE_ID]),
	CONSTRAINT PK_USERS PRIMARY KEY([USER_ID])
);

CREATE TABLE [CARS](
	[CAR_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[FUEL_TYPE_ID] UNIQUEIDENTIFIER NOT NULL,
	[TRANSMISSION_TYPE_ID] UNIQUEIDENTIFIER NOT NULL,
	[MARK] VARCHAR(20) NOT NULL,
	[MODEL] VARCHAR(20) NOT NULL,
	[VOLUME_ENGINE] INT NOT NULL,
	[POWER] INT NOT NULL,
	[ACTIVE] BIT DEFAULT(1),
	[VIN] VARCHAR(17) UNIQUE NOT NULL,
	[COMMENT] VARCHAR(50),
	[PHOTO_ARCHIVE_ID] UNIQUEIDENTIFIER,
	[YEAR_ISSUE] INT NOT NULL CHECK ([YEAR_ISSUE] <= YEAR(GETDATE())),
	CONSTRAINT FK_CARS_FUELTYPE FOREIGN KEY([FUEL_TYPE_ID]) REFERENCES FUEL_TYPES([FUEL_TYPE_ID]),
	CONSTRAINT FK_CARS_PHOTOARCHIVE FOREIGN KEY([PHOTO_ARCHIVE_ID]) REFERENCES PHOTO_ARCHIVE([PHOTO_ARCHIVE_ID]),
	CONSTRAINT FK_CARS_TRANSMISSIONTYPE FOREIGN KEY([TRANSMISSION_TYPE_ID]) REFERENCES TRANSMISSION_TYPES([TRANSMISSION_TYPE_ID]),
	CONSTRAINT PK_CARS PRIMARY KEY([CAR_ID])
);

CREATE TABLE [USERS_CARS](
	[USER_CAR_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[USER_ID] UNIQUEIDENTIFIER NOT NULL,
	[CAR_ID] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_USERCARS_USER FOREIGN KEY([USER_ID]) REFERENCES USERS([USER_ID]),
	CONSTRAINT FK_USERCARS_CAR FOREIGN KEY([CAR_ID]) REFERENCES CARS([CAR_ID]),
	CONSTRAINT PK_USERSCARS PRIMARY KEY([USER_CAR_ID])
);

CREATE TABLE [USERS_CARS_RIGHTS](
	[RIGHT_ID] UNIQUEIDENTIFIER NOT NULL,
	[USER_CAR_ID] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_USERSCARS_RIGHTS_USER FOREIGN KEY([USER_CAR_ID]) REFERENCES USERS_CARS([USER_CAR_ID]),
	CONSTRAINT FK_USERSCARS_RIGHTS_RIGHT FOREIGN KEY([RIGHT_ID]) REFERENCES RIGHTS([RIGHT_ID]),
	CONSTRAINT PK_USERSCARS_RIGHTS PRIMARY KEY([USER_CAR_ID],[RIGHT_ID])
);

CREATE TABLE [USERS_CARS_ROLES](
	[ROLE_ID] UNIQUEIDENTIFIER NOT NULL,
	[USER_CAR_ID] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_USERSCARS_ROLES_USER FOREIGN KEY([USER_CAR_ID]) REFERENCES USERS_CARS([USER_CAR_ID]),
	CONSTRAINT FK_USERSCARS_ROLES_ROLE FOREIGN KEY([ROLE_ID]) REFERENCES ROLES([ROLE_ID]),
	CONSTRAINT PK_USERSCARS_ROLES PRIMARY KEY([USER_CAR_ID],[ROLE_ID])
);

CREATE TABLE [AUTHENTICATION](
	[USER_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[PASSWORD] NVARCHAR(32) NOT NULL,
	[LOGIN] NVARCHAR(50) NOT NULL
	CONSTRAINT PK_AUTHENTICATION PRIMARY KEY(LOGIN)
	CONSTRAINT FK_AUTHENTICATION_USER FOREIGN KEY([USER_ID]) REFERENCES USERS([USER_ID])
);

CREATE TABLE [CAR_EVENTS](
	[EVENT_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[EVENT_TYPE_ID] UNIQUEIDENTIFIER NOT NULL,
	[USER_CAR_ID] UNIQUEIDENTIFIER NOT NULL,
	[DATE] DATE NOT NULL,
	[COSTS] MONEY NOT NULL,
	[UNIT_PRICE] MONEY,
	[COMMENT] VARCHAR(200),
	[MILEAGE] BIGINT,
	[PHOTO_ARCHIVE_ID] UNIQUEIDENTIFIER,
	[ADDRESS_STATION] VARCHAR(100),
	CONSTRAINT FK_EVENTS_PHOTOARCHIVE FOREIGN KEY([PHOTO_ARCHIVE_ID]) REFERENCES PHOTO_ARCHIVE([PHOTO_ARCHIVE_ID]),
	CONSTRAINT FK_EVENTS_TYPEEVENTS FOREIGN KEY([EVENT_TYPE_ID]) REFERENCES [EVENT_TYPES]([EVENT_TYPE_ID]),
	CONSTRAINT FK_EVENTS_USERSCARS FOREIGN KEY([USER_CAR_ID]) REFERENCES [USERS_CARS]([USER_CAR_ID]),
	CONSTRAINT PK_EVENTS PRIMARY KEY([EVENT_ID])
);

CREATE TABLE [REFILL](
	[REFILL_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[EVENT_ID] UNIQUEIDENTIFIER NOT NULL,
	[VOLUME] REAL NOT NULL,
	CONSTRAINT FK_REFILL_EVENTS FOREIGN KEY([EVENT_ID]) REFERENCES [CAR_EVENTS]([EVENT_ID]) ON DELETE CASCADE,
	CONSTRAINT PK_REFILL PRIMARY KEY([REFILL_ID])
);

CREATE TABLE [CAR_SERVICES](
	[SERVICE_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[EVENT_ID] UNIQUEIDENTIFIER NOT NULL,
	[TYPE_SERVICE_ID] UNIQUEIDENTIFIER NOT NULL,
	[NAME] VARCHAR(100) NOT NULL,
	CONSTRAINT FK_SERVICES_EVENTS FOREIGN KEY([EVENT_ID]) REFERENCES [CAR_EVENTS]([EVENT_ID]) ON DELETE CASCADE,
	CONSTRAINT FK_SERVICES_TYPESERVICES FOREIGN KEY([TYPE_SERVICE_ID]) REFERENCES [SERVICE_TYPES]([SERVICE_TYPE_ID]),
	CONSTRAINT PK_SERVICE PRIMARY KEY([SERVICE_ID])
);

CREATE TABLE [DETAILS](
	[DETAIL_ID] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[CAR_ID] UNIQUEIDENTIFIER NOT NULL,
	[SERVICE_ID] UNIQUEIDENTIFIER NOT NULL,
	[NAME] VARCHAR(100),
	[TYPE] VARCHAR(100),
	CONSTRAINT FK_DETAILS_CARS FOREIGN KEY([CAR_ID]) REFERENCES CARS(CAR_ID),
	CONSTRAINT PK_DETAILS PRIMARY KEY([DETAIL_ID]),
	CONSTRAINT FK_DETAILS_SERVICE FOREIGN KEY([SERVICE_ID]) REFERENCES [CAR_SERVICES]([SERVICE_ID]) ON DELETE CASCADE,
);

CREATE TABLE [ACTION_AUDIT](
	[ENTITY] VARCHAR(50) NOT NULL,
	[ENTITY_ID] UNIQUEIDENTIFIER NOT NULL,
	[USER_ID] UNIQUEIDENTIFIER NOT NULL,
	[ACTION] VARCHAR(20) NOT NULL,
	[DATE_UPDATE] VARCHAR(50) NOT NULL
	CONSTRAINT PK_ACTIONAUDIT PRIMARY KEY([ENTITY_ID],[DATE_UPDATE],[USER_ID])
	CONSTRAINT FK_ACTIONAUDIT_USER FOREIGN KEY([USER_ID]) REFERENCES USERS([USER_ID]),
);
