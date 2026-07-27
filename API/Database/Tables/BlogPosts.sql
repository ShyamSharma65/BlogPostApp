CREATE TABLE [dbo].[BlogPosts] (
    Id BIGINT IDENTITY(1,1) NOT NULL,                -- Use BIGINT for scalability
    BlogPostName NVARCHAR(200) NOT NULL,             -- Title, Unicode, larger length
    BlogPostDescription NVARCHAR(500) NULL,          -- Short description
    BlogPostContent NVARCHAR(MAX) NOT NULL,          -- Full blog content
    FeaturedImageUrl VARCHAR(500) NULL,              -- Image URL, ASCII only
    Comments NVARCHAR(MAX) NULL,                     -- User comments, Unicode
    IsPublished BIT NOT NULL DEFAULT 1,                -- Default visible
    IsActive BIT NOT NULL DEFAULT 1,                 -- Default active
    CreatedBy NVARCHAR(100) NULL,                    -- Creator name, Unicode
    CreatedOn DATETIMEOFFSET NOT NULL DEFAULT SYSUTCDATETIME(), -- UTC timestamp
    ModifiedBy NVARCHAR(100) NULL,                   -- Modifier name, Unicode
    ModifiedOn DATETIMEOFFSET NOT NULL DEFAULT SYSUTCDATETIME(), -- UTC timestamp
    CONSTRAINT PK_BlogPosts PRIMARY KEY CLUSTERED (Id)
);
