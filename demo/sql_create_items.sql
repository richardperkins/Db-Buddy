CREATE TABLE items
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name VARCHAR(64) NOT NULL,
    description VARCHAR(255)
);

INSERT INTO items
(name, description)
VALUES
("Suspicious Mushroom", "I wouldn't eat it if I were you"),
("Cubic Zirconium Ring", "Sounds expensive. Is not"),
("Saltpeter", "Saltiest of the Dynamite Three"),
("Sulfur", "Smelliest of the Dynamite Three"),
("Charcoal", "Dirtiest of the Dynamite Three"),
("Gunpowder", "Make things go BOOM."),
("Stave", "Probably belongs to a king or a wizard.");