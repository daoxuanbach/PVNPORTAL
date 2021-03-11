/******SQL******/
/****** Object:  StoredProcedure [dbo].[sp_Add_CMS_SlideShowImg]  Script Date: 22/02/2018 ******/ 
/*
Bachdx's generation version 1.0
*/
		CREATE PROCEDURE [dbo].[sp_Add_CMS_SlideShowImg] 
			         @Id int output 
			         ,@TieuDe nvarchar (50) 
			         ,@NoiDung nvarchar (250) 
			         ,@STT int  
			         ,@TuNgay date  
			         ,@DenNgay date  
			         ,@HienThi bit  
			         ,@ImageURL nvarchar (512) 
			AS 
			BEGIN TRY 
			SET NOCOUNT ON 
			INSERT INTO  
			   [CMS_SlideShowImg]  
			(  
			    [TieuDe] 
			    ,[NoiDung] 
			    ,[STT] 
			    ,[TuNgay] 
			    ,[DenNgay] 
			    ,[HienThi] 
			    ,[ImageURL] 
			) 
			VALUES 
			(  
			       @TieuDe 
			       ,@NoiDung 
			       ,@STT 
			       ,@TuNgay 
			       ,@DenNgay 
			       ,@HienThi 
			       ,@ImageURL 
			) 
			   SET @Id = @@IDENTITY 
			RETURN 
			END TRY 
			BEGIN CATCH 
			       SELECT ERROR_MESSAGE() ErrorMessage
			END CATCH 
/****** Object:  StoredProcedure [dbo].[sp_UpdateByPK_CMS_SlideShowImg]  Script Date: 22/02/2018 ******/ 
/*
Bachdx's generation version 1.0
*/
Go
		CREATE PROCEDURE [dbo].[sp_UpdateByPK_CMS_SlideShowImg] 
			      @Id int 
			      ,@TieuDe nvarchar (50) 
			      ,@NoiDung nvarchar (250) 
			      ,@STT int  
			      ,@TuNgay date  
			      ,@DenNgay date  
			      ,@HienThi bit  
			      ,@ImageURL nvarchar (512) 
			AS 
			BEGIN TRY 
			SET NOCOUNT ON 
			UPDATE 
			   [CMS_SlideShowImg]  
			SET  
			       [TieuDe] = @TieuDe 
			       ,[NoiDung] = @NoiDung 
			       ,[STT] = @STT 
			       ,[TuNgay] = @TuNgay 
			       ,[DenNgay] = @DenNgay 
			       ,[HienThi] = @HienThi 
			       ,[ImageURL] = @ImageURL 
			WHERE 
			  [Id] = @Id 
			RETURN 
			END TRY 
			BEGIN CATCH 
			  SELECT ERROR_MESSAGE() ErrorMessage
			END CATCH 
/****** Object:  StoredProcedure [dbo].[sp_RemoveByPK_CMS_SlideShowImg]  Script Date: 22/02/2018 ******/ 
/*
Bachdx's generation version 1.0
*/
Go
		CREATE PROCEDURE [dbo].[sp_RemoveByPK_CMS_SlideShowImg] 
 			  @Id int 
			AS 
			BEGIN TRY 
			SET NOCOUNT ON 
			    DELETE 
			    FROM 
			        [CMS_SlideShowImg]  
			    WHERE 
			        [Id]=@Id  
			RETURN 
			END TRY 
			BEGIN CATCH 
			       SELECT ERROR_MESSAGE() ErrorMessage
			END CATCH 
/****** Object:  StoredProcedure [dbo].[sp_CMS_SlideShowImg_SearchPaging]  Script Date: 22/02/2018 ******/ 
/*
Bachdx's generation version 1.0
*/
Go
		CREATE PROCEDURE [dbo].[sp_CMS_SlideShowImg_SearchPaging] 
			@OrderByColumn NVARCHAR(200) = NULL
			, @p_search nvarchar(255) = NULL
			, @PageIndex int = 0
			, @RowsInPage int = 20
			, @TotalRows int output
			AS 
			SET NOCOUNT ON 
			IF(@OrderByColumn IS NULL OR @OrderByColumn = '') 
			SET @OrderByColumn = N'[Id] DESC' 
			DECLARE @StartRowIndex int
			SET @StartRowIndex = (@PageIndex * @RowsInPage) + 1;
			;WITH CMS_SlideShowImg_Limit AS
			(
			 SELECT *  FROM dbo.CMS_SlideShowImg   AS es 
			WHERE
			(@p_search IS NULL OR @p_search ='' OR es.TieuDe LIKE + '%' + @p_search + '%' )
			),
			CMS_SlideShowImg_Sort AS ( 
			SELECT 
			ROW_NUMBER() OVER  
			(
			ORDER BY
			CASE WHEN @OrderByColumn = N'[Id]' THEN Id END ASC
			,CASE WHEN @OrderByColumn = N'[Id] DESC' THEN Id END ASC
			) [STT]
			,COUNT(*) OVER () AS [TotalRows]
			,*
			FROM CMS_SlideShowImg_Limit
			)
			SELECT 
			QBC.* 
			FROM  
			 CMS_SlideShowImg_Sort QBC WITH (NOLOCK)  
			 WHERE 
			 [STT] BETWEEN @StartRowIndex AND @StartRowIndex + @RowsInPage - 1 
			 ORDER BY
			 [STT] ASC 
/****** Object:  StoredProcedure [dbo].[sp_CMS_SlideShowImg_GetAll]  Script Date: 22/02/2018 ******/ 
/*
Bachdx's generation version 1.0
*/
Go
		CREATE PROCEDURE [dbo].[sp_GetAll_CMS_SlideShowImg] 
			@HienThi int 
			AS 
			SET NOCOUNT ON 
			SELECT * FROM dbo.CMS_SlideShowImg AS rn
			 WHERE rn.HienThi=@HienThi
			 ORDER BY rn.NgaySua, rn.NgayTao 
/****** Object:  StoredProcedure [dbo].[sp_GetByPK_CMS_SlideShowImg]  Script Date: 22/02/2018 ******/ 
/*
Bachdx's generation version 1.0
*/
Go
		CREATE PROCEDURE [dbo].[sp_GetByPK_CMS_SlideShowImg] 
			@intItemID int 
			AS 
			SET NOCOUNT ON 
			SELECT * FROM dbo.CMS_SlideShowImg AS rn
			 WHERE rn.ID=@intItemID

