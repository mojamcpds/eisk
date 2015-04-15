SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_DeleteEmployees]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure deletes a set of Employees from the Employees database table.

Desgin Notes:
Since there is not built-in support for array in the SQL Server 2005, we have considered a 
special technique, where the list of Employee Id''s has been passed as XML, based on which the 
Employees are being deleted.

Stored procedure last modified on:
Modification notes:
*/

CREATE PROCEDURE [dbo].[Employees_DeleteEmployees]
@employeeIds xml 
AS
BEGIN

SET NOCOUNT ON;

--BEGIN TRAN

delete Employees Where EmployeeID in
(
	SELECT ParamValues.ID.value(''.'',''int'') as Id
	FROM @employeeIds.nodes(''/Id'') as ParamValues(ID) 
)

--COMMIT TRAN

-- returning the number of affected rows
Return @@ROWCOUNT

END



' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_DeleteEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/*
Stored procedure designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure deletes an record from the Employees database table.

Stored procedure last modified on:
Modification notes:
*/

CREATE PROCEDURE [dbo].[Employees_DeleteEmployee]
	@EmployeeID Int
AS

-- Deleting an employee from the database, based on primary key
DELETE Employees
WHERE EmployeeID=@EmployeeID

-- Returning the numbers of affected rows as return value
Return @@ROWCOUNT

' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetEmployeesByReportsTo_Paged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]

Functional Comment:
This stored procedure returns an specific segment of records from the main 
employee table, with respect to a starting index and number of maximum rows to be returned, 
according to a specific order, according to the foreign key ''ReportsTo''. 

Desgin Notes:
This stored procedure is extremently useful when we display tabulater data in paged manner,
where on each time during the data binding returning of all records for a given page not necessary,
and thus saving proessing time (db and web), memory (db and web ) and network traffic.
We have considered ASP.NET 2.0 object data source and SQL Server 2005 new functionalities to implement this concept.
*/
CREATE PROCEDURE [dbo].[Employees_GetEmployeesByReportsTo_Paged]
(@reportsTo Int, @orderby varchar(50),@startrow int,@pagesize int)
As

-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON

/* from the object data source control, the start index is ''0'' and 
the ''ROW_NUMBER()'' sql server function starts with ''1''. 
So we are updating the start index to match with sql server row index
*/
set @startrow = @startrow + 1;

declare @sql nvarchar(4000);


/*
In the sql statement below, using the ''WITH'' statement we are first populating a temporary table,
where we considered the ROW_NUMBER() function to creating ROW_Index. Note that, this is just a declation of the table, no select statement is executed here.
The temprary table is then is used to be qieried according to the row index and recored size, based on which the appropriate segment of recored is being returned.
*/
	set @sql=''
			WITH Employees_PageSegment AS ( 
				SELECT  EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath, 
				ROW_NUMBER() OVER ( ORDER BY '' + @orderby + '' ) as RowIndex
				FROM Employees
			)

			SELECT  EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath 
			FROM Employees_PageSegment
			WHERE 
			reportsTo = '' 
			+  CONVERT(nvarchar(10),@reportsTo)
			+ ''  AND 
			RowIndex BETWEEN '' 
			+  CONVERT(nvarchar(10),@startrow)  
			+ '' AND ('' 
			+ CONVERT(nvarchar(10),@startrow) + '' + '' + CONVERT(nvarchar(10),@pagesize)  
			+ '') - 1  order by '' 
			+ CONVERT(nvarchar(20),@orderby);

exec sp_executesql @sql

' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetEmployeesByReportsTo_Paged_Count]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure returns the total number of records of Employee database table, regarding the foreign key Reports to.

Desgin Notes:
This is a supporting stored procedure of Employees_GetAllEmployees_Paged stored procedure,
to faciliitate the paging operation in application end.

Stored procedure last modified on:
Modification notes:
*/

CREATE proc [dbo].[Employees_GetEmployeesByReportsTo_Paged_Count]
@reportsTo Int
As

-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON

DECLARE @ReturnVal Int

	select @ReturnVal = count(*) from Employees
	WHERE reportsTo = @ReportsTo


-- Returning the total number of records in the given query
Return @ReturnVal' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetEmployeesByReportsTo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/*
Stored procedure designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
Stored procedure written on: 08-05-2007

Functional Comment:
This stored procedure returns all employee records from Employee database table, regarding the foreign key ''ReportsTo''.

Stored procedure last modified on:
Modification notes:
*/
CREATE PROCEDURE [dbo].[Employees_GetEmployeesByReportsTo]
@reportsTo Int
AS
SET NOCOUNT ON

SELECT EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath
	FROM Employees
	WHERE reportsTo = @ReportsTo
	

' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetEmployeeByEmployeeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/*
Stored procedure designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure retunrns a record of employee table based on it''''s primary key

Stored procedure last modified on:
Modification notes:
*/

CREATE PROCEDURE [dbo].[Employees_GetEmployeeByEmployeeId]
@EmployeeId Int
AS

-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON

	SELECT EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath
		FROM Employees
		WHERE EmployeeId	=	@EmployeeId
' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Custom_Employees_GetTwoLevelBosses]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[Custom_Employees_GetTwoLevelBosses]
AS
	
-- get the company boss
declare @companyBoss int 
select @companyBoss = EmployeeId from employees where EmployeeId = ReportsTo

-- get the first level bosses (who has only one boss)
select EmployeeId, Title, FirstName, LastName from employees where ReportsTo = @companyBoss

-- get the second level bosses (whos boss has only one boss)
select EmployeeId, FirstName, LastName, Country from employees where ReportsTo in (select employeeId from employees where ReportsTo = @companyBoss)
	and employeeId not in (select employeeId from employees where ReportsTo = @companyBoss)


	RETURN

' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Custom_Employees_GetEmployeeFirstNameByEmployeeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Custom_Employees_GetEmployeeFirstNameByEmployeeId]
@employeeId Int,
@ReturnVal nvarchar(10) OUTPUT
AS

-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON

	select @ReturnVal = FirstName from Employees
	WHERE employeeId = @employeeId

	RETURN 
' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Custom_Employees_GetEmployeeBossByEmployeeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Custom_Employees_GetEmployeeBossByEmployeeId] 
@employeeId int
AS
	SELECT     
	Emp.EmployeeID, 
	Emp.FirstName, 
	Emp.LastName, 
	Bosses.EmployeeID as BossId, 
	Bosses.FirstName as BossFirstName,
	Bosses.LastName as BossLastName
	
	FROM         Employees AS Bosses INNER JOIN Employees AS Emp ON Bosses.EmployeeId = Emp.ReportsTo
	
	WHERE Emp.EmployeeId = @employeeId
	
	RETURN
' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Custom_Employees_GetAllEmployeeBosses]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Custom_Employees_GetAllEmployeeBosses] 
AS
	SELECT     
	Emp.EmployeeID, 
	Emp.FirstName, 
	Emp.LastName, 
	Bosses.EmployeeID as BossId, 
	Bosses.FirstName as BossFirstName,
	Bosses.LastName as BossLastName
	
	FROM         Employees AS Bosses INNER JOIN Employees AS Emp ON Bosses.EmployeeId = Emp.ReportsTo
	
	RETURN
' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_CreateNewEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure inserts a new record in the Employees database table.

Stored procedure last modified on:
Modification notes:
*/

CREATE PROCEDURE [dbo].[Employees_CreateNewEmployee]
@LastName NVarChar(20),
@FirstName NVarChar(10),
@Title NVarChar(30),
@TitleOfCourtesy NVarChar(25),
@BirthDate DateTime,
@HireDate DateTime,
@Address NVarChar(60),
@City NVarChar(15),
@Region NVarChar(15),
@PostalCode NVarChar(10),
@Country NVarChar(15),
@HomePhone NVarChar(24),
@Extension NVarChar(4),
@Photo Image,
@Notes NVarChar(1000),
@ReportsTo Int,
@PhotoPath NVarChar(255)

AS

-- Inserting a new employee record in the Employee database table
INSERT INTO Employees

(
	LastName,
	FirstName,
	Title,
	TitleOfCourtesy,
	BirthDate,
	HireDate,
	Address,
	City,
	Region,
	PostalCode,
	Country,
	HomePhone,
	Extension,
	Photo,
	Notes,
	ReportsTo,
	PhotoPath
)
VALUES(@LastName,@FirstName,@Title,@TitleOfCourtesy,@BirthDate,@HireDate,@Address,@City,@Region,@PostalCode,@Country,@HomePhone,@Extension,@Photo,@Notes,@ReportsTo,@PhotoPath)

-- retirning the newly generated id of the Employee table as the return value
Return (SCOPE_IDENTITY()) 


' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](10) NOT NULL,
	[Title] [nvarchar](30) NULL,
	[TitleOfCourtesy] [nvarchar](25) NULL,
	[BirthDate] [datetime] NULL,
	[HireDate] [datetime] NOT NULL,
	[Address] [nvarchar](60) NOT NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NOT NULL,
	[HomePhone] [nvarchar](24) NOT NULL,
	[Extension] [nvarchar](4) NULL,
	[Photo] [image] NULL,
	[Notes] [ntext] NULL,
	[ReportsTo] [int] NULL,
	[PhotoPath] [nvarchar](255) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_UpdateEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure updates a record from the Employees database table.

Stored procedure last modified on:
Modification notes:
*/

CREATE PROCEDURE [dbo].[Employees_UpdateEmployee]
@EmployeeID Int,
@LastName NVarChar(20),
@FirstName NVarChar(10),
@Title NVarChar(30),
@TitleOfCourtesy NVarChar(25),
@BirthDate DateTime,
@HireDate DateTime,
@Address NVarChar(60),
@City NVarChar(15),
@Region NVarChar(15),
@PostalCode NVarChar(10),
@Country NVarChar(15),
@HomePhone NVarChar(24),
@Extension NVarChar(4),
@Photo Image,
@Notes NVarChar(1000),
@ReportsTo Int,
@PhotoPath NVarChar(255)
AS

UPDATE Employees
SET
	LastName	=	@LastName,
	FirstName	=	@FirstName,
	Title		=	@Title,
	TitleOfCourtesy	=	@TitleOfCourtesy,
	BirthDate	=	@BirthDate,
	HireDate	=	@HireDate,
	Address		=	@Address,
	City		=	@City,
	Region		=	@Region,
	PostalCode	=	@PostalCode,
	Country		=	@Country,
	HomePhone	=	@HomePhone,
	Extension=@Extension,
	Photo		=	@Photo,
	Notes		=	@Notes,
	ReportsTo	=	@ReportsTo,
	PhotoPath	=	@PhotoPath
WHERE 
	EmployeeID	=	@EmployeeID

-- returning the number of affected rows
Return @@ROWCOUNT


' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetAllEmployees]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/*
Stored procedure designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure returns all emplyee records from Employee database table.

Desgin Notes:
Since there is not built-in support for array in the SQL Server 2005, we have considered a 
special technique, where the list of Employee Id''s has been passed as XML, based on which the 
Employees are being deleted.

Stored procedure last modified on:
Modification notes:
*/

CREATE PROCEDURE [dbo].[Employees_GetAllEmployees]
AS
SET NOCOUNT ON

SELECT EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath
FROM Employees

' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetAllEmployees_Paged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'/*
Stored procedure designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]

Functional Comment:
This stoed procedure returns an specific segment of records from the main 
employee table, with respect to a starting index and number of maximum rows to be returned, 
according to a specific order. 

Desgin Notes:
This stored procedure is extremently useful when we display tabulater data in paged manner,
where on each time during the data binding returning of all records for a given page not necessary,
and thus saving proessing time (db and web), memory (db and web ) and network traffic.
We have considered ASP.NET 2.0 object data source and SQL Server 2005 new functionalities to implement this concept.
*/
CREATE proc [dbo].[Employees_GetAllEmployees_Paged]
(@orderby varchar(50),@startrow int,@pagesize int)
As

-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON

/* from the object data source control, the start index is ''0'' and 
the ''ROW_NUMBER()'' sql server function starts with ''1''. 
So we are updating the start index to match with sql server row index
*/
set @startrow = @startrow + 1;

declare @sql nvarchar(4000);

/*
In the sql statement below, using the ''WITH'' statement we are first populating a temporary table,
where we considered the ROW_NUMBER() function to creating ROW_Index. Note that, this is just a declation of the table, no select statement is executed here.
The temprary table is then is used to be qieried according to the row index and recored size, based on which the appropriate segment of recored is being returned.
*/
set @sql=''
		WITH Employees_PageSegment AS ( 
			SELECT  EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath, 
			ROW_NUMBER() OVER ( ORDER BY '' + @orderby + '' ) as RowIndex
			FROM Employees
		)

		SELECT  EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath 
		FROM Employees_PageSegment
		WHERE 
		RowIndex BETWEEN '' 
		+  CONVERT(nvarchar(10),@startrow)  
		+ '' AND ('' 
		+ CONVERT(nvarchar(10),@startrow) + '' + '' + CONVERT(nvarchar(10),@pagesize)  
		+ '') - 1  order by '' 
		+ CONVERT(nvarchar(20),@orderby);

exec sp_executesql @sql
' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees_GetAllEmployees_Paged_Count]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
Stored procedure designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
Stored procedure written on: 07-29-2007

Functional Comment:
This stored procedure returns the total number of records of Employee database table.

Desgin Notes:
This is a supporting stored procedure of Employees_GetAllEmployees_Paged stored procedure,
to faciliitate the paging operation in application end.

Stored procedure last modified on:
Modification notes:
*/

CREATE proc [dbo].[Employees_GetAllEmployees_Paged_Count]
As

-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON

DECLARE @ReturnVal Int

select @ReturnVal = count(*) from Employees

-- Returning the total number of records in the given query
Return @ReturnVal' 
END

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Employees_Employees]') AND parent_object_id = OBJECT_ID(N'[dbo].[Employees]'))
ALTER TABLE [dbo].[Employees]  WITH NOCHECK ADD  CONSTRAINT [FK_Employees_Employees] FOREIGN KEY([ReportsTo])
REFERENCES [dbo].[Employees] ([EmployeeId])

ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees]
