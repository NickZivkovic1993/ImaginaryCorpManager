--CREATE PROCEDURE [dbo].[spProduct_GetAll]
	
--AS
--begin
--	set nocount on;
	
--	SELECT [Id], [ProductName], [Description], [RetailPrice], [QuantityInStock] , [IsTaxable]
--	FROM dbo.Product
--	order by ProductName;
--end
CREATE PROCEDURE [dbo].[spProductGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxable
	FROM dbo.Product
	ORDER BY ProductName
END
