CREATE TABLE places
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name VARCHAR(64) NOT NULL,
    description VARCHAR(255)
);

INSERT INTO places
(name, description)
VALUES
(
    "Home",
    "Where I keep my heart."
),
(
    "Hell",
    "Where I am now. Please kill me."
);