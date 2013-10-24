DECLARE @intFlag INT
DECLARE @xx nvarchar(20)
DECLARE @yy nvarchar(20)
DECLARE @zz nvarchar(20)
set @intFlag = 1
WHILE (@intFlag <=412)
BEGIN
	select @xx = 'User (' + CONVERT(varchar, @intFlag)  + ')';
	select @yy = 'NIC (' + CONVERT(varchar, @intFlag) + ')';
	select @zz = 'ADDRESS (' + CONVERT(varchar, @intFlag) + ')';
	INSERT INTO Person(Name,UserID,Address)
	VALUES(@xx, @yy, @zz)
	set @intFlag = @intFlag + 1;
END
GO


DECLARE @intFlag INT
DECLARE @xx nvarchar(20)
set @intFlag = 1
WHILE (@intFlag <=412)
BEGIN
	select @xx = 'User (' + CONVERT(varchar, @intFlag)  + ').jpg';
	INSERT INTO Image(Person_Id, Image_uri)
	VALUES(@intFlag,@xx)
	set @intFlag = @intFlag + 1;
END
GO

-- There is face shape missing.
DECLARE @intFlag INT
DECLARE @xx nvarchar(20)
set @intFlag = 41
WHILE (@intFlag <=60)
BEGIN
	select @xx = CONVERT(varchar, @intFlag)  + '.jpg';
	INSERT INTO ClassElementImages(Class_ClassId, Feature_img_uri)
	VALUES(10,@xx)
	set @intFlag = @intFlag + 1;
END
GO

DBCC CHECKIDENT('Person', RESEED, 0)
DBCC CHECKIDENT('Image', RESEED, 0)

DBCC CHECKIDENT('ClassElementImages', RESEED, 0)

delete from ClassElementImages where Class_ClassId = 3