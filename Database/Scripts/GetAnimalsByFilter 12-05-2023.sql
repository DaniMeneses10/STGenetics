SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].GetAnimalsByFilter
(
		@animalId nvarchar(MAX) = null,
		@name nvarchar(MAX)  = null,
		@sex nvarchar(MAX)  = null,
		@status nvarchar(MAX) = null
)

AS

BEGIN
	select a.Name,
			a.Breed, 
			a.BirthDate,
			a.Sex,
			a.Price, 
			a.Status,
			a.CreateDate,
			a.DeleteDate

	from Animals as a

	where (@name is null or a.Name like '%' + @name +'%')
	and (@sex is null or a.Sex like '%' + @sex +'%')
	and (@status is null or a.Status like '%' + @status +'%')
	and (@animalId is null or a.AnimalId like '%' + @animalId +'%')

END