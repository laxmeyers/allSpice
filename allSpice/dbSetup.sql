CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

-- SECTION recipes

CREATE Table
    recipes(
        id int AUTO_INCREMENT not Null PRIMARY KEY,
        title varchar(50) not NULL,
        instructions VARCHAR(500),
        img VARCHAR(255),
        category VARCHAR(50),
        creatorId VARCHAR(255) NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts(id) on Delete CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE recipes;

INSERT INTO
    recipes (
        title,
        instructions,
        img,
        category,
        `creatorId`
    )
VALUES (
        "pizza",
        "Add what you want to it",
        "https://images.unsplash.com/photo-1563281691-6aa6ef7357d9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8Y2hpY2tlbiUyMHBpbmt8ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60",
        "pastry",
        "63ff78d2164fbc90bd577399"
    );

Select
    recipes.*,
    accounts.name
from recipes
    join accounts on accounts.id = creatorId
where id = 1;

Update recipes
Set
    title = @title,
    instructions = @instructions id = @id,
    category = @category,
    creatorId = @creatorId,
where id = @id;

-- SECTION ingredients

CREATE Table
    ingredients(
        id int AUTO_INCREMENT PRIMARY KEY,
        name varchar(50) not null,
        quantity varchar(50) not null,
        recipeId int not NULL,
        Foreign Key (recipeId) REFERENCES recipes(id) on Delete CASCADE
    ) default charset utf8 COMMENT '';

drop Table ingredients;

-- SECTION favorites

create table
    favorites(
        id int AUTO_INCREMENT not NULL PRIMARY KEY,
        accountId VARCHAR(255) not null,
        recipeId int not NULL,
        Foreign Key (accountId) REFERENCES accounts(id) on Delete CASCADE,
        Foreign Key (recipeId) REFERENCES recipes(id) on Delete CASCADE
    ) default charset utf8 COMMENT '';

drop table favorites;