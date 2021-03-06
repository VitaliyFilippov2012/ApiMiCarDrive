
--GENERATE RANDOM STRING
CREATE VIEW dbo.vRand(V) AS SELECT RAND();
GO

ALTER FUNCTION DBO.GetRandomString(@LengthStr int) 
RETURNS varchar(max) AS
BEGIN
	DECLARE @TEXT nvarchar(255);
	DECLARE @I int;
	DECLARE @RAND int;
	SET @i = 0
	SET @text = ''
	WHILE (@i < @LengthStr)
		BEGIN
			SET @RAND = (SELECT V*28 FROM dbo.vRand)
			SET @text = @text + CHAR(@RAND + 65)
			SET @i = @i + 1
		END
	RETURN @TEXT;
END
GO

--USERS

DECLARE @MIN DATETIME;
DECLARE @MAX DATETIME;
DECLARE @RANDOMDAY INT;
DECLARE @SECONDS INT;
DECLARE @BIRTHDAY DATETIME;
DECLARE @SEX VARCHAR(1);
DECLARE @NAME VARCHAR(40);
DECLARE @LASTNAME VARCHAR(50);
DECLARE @PATRONYMIC VARCHAR(40);
DECLARE @ADDRESS VARCHAR(50);
DECLARE @PHONE VARCHAR(18);
DECLARE @CITY VARCHAR(50);
DECLARE @I INT;
DECLARE @RANDOM INT;
SET @I = 0;
SET @MAX = CAST('2020-02-12' AS datetime);
SET @MIN = CAST('1960-01-01' AS datetime);
DECLARE @DAY INT = DATEDIFF(DAY, @MIN, @MAX)
SELECT @DAY
WHILE(@I < 200000)
	BEGIN
		SET @PHONE = '+375 (__) ___-__-__';
		SET @CITY = (SELECT dbo.GetRandomString(20));
		SET @ADDRESS = (SELECT dbo.GetRandomString(50));
		SET @NAME = (SELECT dbo.GetRandomString(20));
		SET @PATRONYMIC = (SELECT dbo.GetRandomString(25));
		SET @LASTNAME = (SELECT dbo.GetRandomString(20));
		SET @RANDOM = (SELECT RAND(60))
		SET @RANDOMDAY = ROUND(((@DAY-1) * RAND()), 0)
		SET @SECONDS = ROUND((999 * 24 * 60 * RAND()), 0)
		SET @BIRTHDAY = (SELECT DATEADD(SECOND, @SECONDS, DATEADD(DAY, @RANDOMDAY, @MIN)))
		IF(@RANDOM % 2 = 1)
			BEGIN
				SET @SEX = 'f'
			END
		ELSE
			BEGIN
				SET @SEX = 'm'
			END
		INSERT INTO [dbo].[Users](Sex,Birthday,Name,Lastname,Patronymic,Address,Phone,City) VALUES
			(@SEX,@BIRTHDAY,@NAME,@LASTNAME,@PATRONYMIC,@ADDRESS,@PHONE,@CITY)
	END
GO


--AUTHENTIFICATION

DECLARE @MIN DATETIME;
DECLARE @MAX DATETIME;
DECLARE @RANDOMDAY INT;
DECLARE @SECONDS INT;

DECLARE @USER_ID uniqueidentifier;
DECLARE @PASSWORD VARCHAR(32);
DECLARE @LOGIN VARCHAR(50);
DECLARE @LAST_MODIFY VARCHAR(50);

DECLARE @I INT;
DECLARE @RANDOM INT;
SET @I = 0;
SET @MAX = CAST('2020-01-04' AS datetime);
SET @MIN = CAST('2020-01-01' AS datetime);
DECLARE @DAY INT = DATEDIFF(DAY, @MIN, @MAX);
DECLARE USER_Ids CURSOR LOCAL FORWARD_ONLY FAST_FORWARD FOR
	SELECT UserId FROM Users
		OPEN USER_IdS;
		FETCH NEXT FROM USER_IDS INTO @USER_ID;
			WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @I =@I+1;
					PRINT(@i)
					SET @PASSWORD = (SELECT dbo.GetRandomString(30));
					SET @LOGIN = (SELECT dbo.GetRandomString(45));
					SET @RANDOMDAY = ROUND(((@DAY-1) * RAND()), 0)
					SET @SECONDS = ROUND((999 * 24 * 60 * RAND()), 0)
					SET @LAST_MODIFY = (SELECT DATEADD(SECOND, @SECONDS, DATEADD(DAY, @RANDOMDAY, @MIN)))
					INSERT INTO [dbo].[AUTHENTICATION]([idUser],[Password],[Login],[LastModify],[DisableUser])
						VALUES (@USER_ID,@PASSWORD,@LOGIN,@LAST_MODIFY,0)
					FETCH NEXT FROM USER_IDS INTO @USER_ID
				END
		CLOSE USER_IdS;
GO

--?ARS

DECLARE @MIN DATETIME;
DECLARE @MAX DATETIME;
DECLARE @RANDOMDAY INT;

DECLARE @SECONDS INT;
DECLARE @CAR_ID uniqueidentifier;
DECLARE @USER_ID uniqueidentifier;
DECLARE @TYPE_FUEL VARCHAR(10);
DECLARE @TYPE_TRANSM VARCHAR(10);
DECLARE @MARK VARCHAR(10);
DECLARE @MODEL VARCHAR(10);
DECLARE @VOLUME INT;
DECLARE @POWER INT;
DECLARE @YEAR INT;
DECLARE @VIN VARCHAR(17);

DECLARE @VIN_D DECIMAL(15,0);
SET @VIN_D = 122312452378346;
DECLARE @I INT;
DECLARE @RANDOM INT;
SET @I = 0;
SET @MAX = CAST('2020-01-04' AS datetime);
SET @MIN = CAST('1970-01-01' AS datetime);
DECLARE @DAY INT = DATEDIFF(DAY, @MIN, @MAX);
DECLARE USER_Ids CURSOR LOCAL FORWARD_ONLY FAST_FORWARD FOR
	SELECT UserId FROM Users
		OPEN USER_IdS;
		FETCH NEXT FROM USER_IDS INTO @USER_ID;
			WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @RANDOM = ROUND(RAND()*21412,0,0);
					SET @I =@I+1;
					PRINT(@i);
					SET @RANDOMDAY = ROUND(((@DAY-1) * RAND()), 0);
					SET @SECONDS = ROUND((999 * 24 * 60 * RAND()), 0);
					SET @YEAR = YEAR(DATEADD(SECOND, @SECONDS, DATEADD(DAY, @RANDOMDAY, @MIN)));
					SET @CAR_ID = NEWID();
					IF(@RANDOM % 2 = 1)
						BEGIN
							SET @TYPE_FUEL = 'DIESEL';
						END
					ELSE
						BEGIN
							SET @TYPE_FUEL = 'AI-95';
						END
					SET @RANDOM = ROUND(RAND()*2562,0,0);
					IF(@RANDOM = 1)
						BEGIN
							SET @TYPE_TRANSM = 'AKPP';
						END
					ELSE
						BEGIN
							SET @TYPE_TRANSM = 'MKP';
						END;
					SET @MARK = (SELECT dbo.GetRandomString(15));
					SET @MODEL = (SELECT dbo.GetRandomString(15));
					SET @POWER = RAND()*200+50
					SET @RANDOM = ABS(ROUND((RAND()*RAND()-RAND()*165654),0,0));
					SET @VOLUME = ROUND(AVG(RAND()*4),1,1)*1000 + 500
					SET @VIN = CAST(@VIN_D AS varchar) + REPLICATE(4,2);
					SET @VIN_D = @VIN_D + @I;
					INSERT INTO [dbo].[Cars]([CarId],[TypeFuel],[TypeTransmission],[Mark],[Model],[VolumeEngine],[Power],[VIN],[YearIssue])
						VALUES (@CAR_ID,@TYPE_FUEL,@TYPE_TRANSM,@MARK,@MODEL,@VOLUME,@POWER,@VIN,@YEAR);
					INSERT INTO [dbo].[UsersCars]([idUser],[idCar])
						VALUES (@USER_ID,@CAR_ID);
					FETCH NEXT FROM USER_IDS INTO @USER_ID
					IF(@RANDOM % 2 = 1)
						BEGIN
							INSERT INTO [dbo].[UsersCars]([idUser],[idCar])
								VALUES (@USER_ID,@CAR_ID);
						END
				END
		CLOSE USER_IdS;
GO


