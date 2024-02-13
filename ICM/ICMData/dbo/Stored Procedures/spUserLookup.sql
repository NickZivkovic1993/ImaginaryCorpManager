CREATE PROCEDURE [dbo].[spUserLookup]
	@Id NVARCHAR(128)
AS
		--if cant select sql table add [] User might be a problem
Begin
	set nocount on;

	select Id , FirstName , LastName , EmailAddress , CreatedDate
	from [dbo].[User]
	where Id = @Id;

End