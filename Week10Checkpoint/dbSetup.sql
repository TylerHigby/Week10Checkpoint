CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        title VARCHAR(255) NOT NULL,
        instructions VARCHAR(1000) NOT NULL,
        img VARCHAR(1000) NOT NULL,
        category VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS ingredients(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        name VARCHAR(255) NOT NULL,
        quantity VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        img VARCHAR(1000) NOT NULL
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS favorites(
        id VARCHAR(255) NOT NULL PRIMARY KEY,
        accountId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL
    ) default charset utf8 COMMENT '';

INSERT INTO
    recipes(
        title,
        instructions,
        img,
        category,
        creatorId
    )
VALUES (
        'Mac and Cheese',
        'you add the mac to the cheese',
        'https://images.unsplash.com/photo-1543339494-b4cd4f7ba686?ixlib=rb-4.0.3ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8bWFjJTIwYW5kJTIwY2hlZXNlfGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60',
        'american',
        '65271d92c292afa88ed64a4c'
    );

DROP TABLE recipes;

DROP TABLE ingredients;

DELETE FROM recipes WHERE id=1;

-- DELETE FROM accounts WHERE id = '65271d92c292afa88ed64a4c'

SELECT * FROM recipes;

SELECT * FROM recipes JOIN accounts;

SELECT *
FROM recipes rec
    JOIN accounts act ON act.id = rec.creatorId;

DELETE FROM recipes WHERE id = 11;