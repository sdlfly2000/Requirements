create table Users (
	Id nvarchar(50),
    Name nvarchar(255),
    primary key (Id)
);

create table UserRequirements (
	Id nvarchar(50),
    Title nvarchar(255),
    Description nvarchar(255),
    OwnerId nvarchar(50),
    StartedOn datetime,
    Period time,
    Status nvarchar(20),
    ModifiedOn datetime,
    ModifiedById nvarchar(50),
	CreatedOn datetime,
    CreatedById nvarchar(50),

    primary key (Id),
    foreign key (OwnerId) references Users(Id),
    foreign key (ModifiedById) references Users(Id),
    foreign key (CreatedById) references Users(Id),
    
    INDEX ndx_OwnerId (OwnerId),
    INDEX ndx_ModifiedById (ModifiedById),
    INDEX ndx_CreatedById (CreatedById)
);

create table UserStories (
	Id nvarchar(50),
    Title nvarchar(255),
    Description nvarchar(255),
    OwnerId nvarchar(50),
    StartedOn datetime,
    Period time,
    Status nvarchar(20),
    ModifiedOn datetime,
    ModifiedById nvarchar(50),
	CreatedOn datetime,
    CreatedById nvarchar(50),
    UserRequirementId nvarchar(36),

    primary key (Id),
    foreign key (OwnerId) references Users(Id),
    foreign key (ModifiedById) references Users(Id),
    foreign key (CreatedById) references Users(Id),
    foreign key (UserRequirementId) references UserRequirements(Id),

    INDEX ndx_OwnerId (OwnerId),
    INDEX ndx_ModifiedById (ModifiedById),
    INDEX ndx_CreatedById (CreatedById),
    INDEX ndx_UserRequirementId (UserRequirementId)
);

create table Tasks (
	Id nvarchar(36),
    Title nvarchar(255),
    Description nvarchar(255),
    OwnerId nvarchar(36),
    StartedOn datetime,
    Period time,
    Status nvarchar(20),
    ModifiedOn datetime,
    ModifiedById nvarchar(36),
	CreatedOn datetime,
    CreatedById nvarchar(36),
    UserStoryId nvarchar(36),

    primary key (Id),
    foreign key (OwnerId) references Users(Id),
    foreign key (ModifiedById) references Users(Id),
    foreign key (CreatedById) references Users(Id),    
    foreign key (UserStoryId) references UserStories(Id),
    
    INDEX ndx_OwnerId (OwnerId),
    INDEX ndx_ModifiedById (ModifiedById),
    INDEX ndx_CreatedById (CreatedById),
    INDEX ndx_UserStoryId (UserStoryId)
);