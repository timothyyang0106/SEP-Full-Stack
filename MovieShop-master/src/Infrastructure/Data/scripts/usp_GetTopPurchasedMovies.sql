 
-- Create the stored procedure in the specified schema 
CREATE PROCEDURE [dbo].[usp_GetTopPurchasedMovies] 
    @fromDate DateTime = NULL, 
    @toDate  DateTime = NULL, 
    @pageIndex INT = 1, 
    @pageSize   INT = 30 
 
-- add more stored procedure parameters here 
AS 
BEGIN 
    -- Defaults to last 30 Days 
    IF @fromDate IS NULL AND @toDate IS NOT NULL BEGIN 
        SET @fromDate = dateadd(day,-30, GETDATE()); 
        SET @toDate =  GETDATE(); 
    END; 
 
    IF @fromDate IS NULL AND @toDate IS NULL  
    BEGIN 
        SET @fromDate = dateadd(day,-30, GETDATE()); 
        SET @toDate =  GETDATE(); 
    END; 
 
    IF @fromDate IS NOT NULL AND @toDate IS NULL  
    BEGIN 
        SET @toDate =  GETDATE(); 
    END; 
 
 
    WITH 
        TempResult 
        AS 
        ( 
            SELECT M.Id , M.Title, M.PosterUrl, M.ReleaseDate, COUNT(*) TotalPurchases 
            FROM [dbo].[Purchase] P 
                JOIN [dbo].[Movie] M 
                ON P.MovieId = M.Id 
            WHERE P.PurchaseDateTime   BETWEEN  
    CONVERT(datetime,@fromDate)  
    AND CONVERT(datetime,@toDate) 
            GROUP BY M.Id, M.Title, M.PosterUrl, M.ReleaseDate 
        ), 
 
        TempCount 
        AS 
        ( 
            SELECT COUNT(*) AS MaxRows 
            FROM TempResult 
        ) 
 
    SELECT * 
    FROM TempResult, TempCount 
    ORDER BY TempResult.TotalPurchases DESC 
    OFFSET (@pageIndex-1)*@PageSize ROWS 
    FETCH NEXT @pageSize ROWS ONLY 
END 