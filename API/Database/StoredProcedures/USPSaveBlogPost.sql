IF OBJECT_ID('dbo.USPSaveBlogPost', 'P') IS NOT NULL
    DROP PROCEDURE dbo.USPSaveBlogPost;
GO

CREATE PROCEDURE dbo.USPSaveBlogPost
    @Id BIGINT OUTPUT,
    @BlogPostName NVARCHAR(200),
    @BlogPostDescription NVARCHAR(500),
    @BlogPostContent NVARCHAR(MAX),
    @FeaturedImageUrl VARCHAR(500),
    @Comments NVARCHAR(MAX),
    @IsPublished BIT,
    @IsActive BIT,
    @CreatedBy NVARCHAR(100),
    @CreatedOn DATETIMEOFFSET,
    @ModifiedBy NVARCHAR(100),
    @ModifiedOn DATETIMEOFFSET
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id > 0 AND EXISTS (SELECT 1 FROM dbo.BlogPosts WHERE Id = @Id)
    BEGIN
        UPDATE dbo.BlogPosts
        SET BlogPostName = @BlogPostName,
            BlogPostDescription = @BlogPostDescription,
            BlogPostContent = @BlogPostContent,
            FeaturedImageUrl = @FeaturedImageUrl,
            Comments = @Comments,
            IsPublished = @IsPublished,
            IsActive = @IsActive,
            ModifiedBy = @ModifiedBy,
            ModifiedOn = @ModifiedOn
        WHERE Id = @Id;
    END
    ELSE
    BEGIN
        INSERT INTO dbo.BlogPosts (
            BlogPostName,
            BlogPostDescription,
            BlogPostContent,
            FeaturedImageUrl,
            Comments,
            IsPublished,
            IsActive,
            CreatedBy,
            CreatedOn,
            ModifiedBy,
            ModifiedOn
        )
        VALUES (
            @BlogPostName,
            @BlogPostDescription,
            @BlogPostContent,
            @FeaturedImageUrl,
            @Comments,
            @IsPublished,
            @IsActive,
            @CreatedBy,
            @CreatedOn,
            @ModifiedBy,
            @ModifiedOn
        );

        SET @Id = CAST(SCOPE_IDENTITY() AS BIGINT);
    END
END
GO
