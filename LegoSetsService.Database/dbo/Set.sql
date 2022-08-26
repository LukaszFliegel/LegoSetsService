CREATE TABLE [dbo].[Set]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SetNumber] NVARCHAR(16) NOT NULL, 
    [Name] NVARCHAR(200) NOT NULL, 
    [ManufacturerPrice] DECIMAL NOT NULL, 
    [ReleaseDate] DATETIME NOT NULL, 
    [RetireDate] DATETIME NULL, 
    [FigsCount] INT NOT NULL, 
    [UniqeFigsCount]INT NOT NULL
)
