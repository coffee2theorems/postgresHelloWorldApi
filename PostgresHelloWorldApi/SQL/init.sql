CREATE TABLE Todo (
    Id SERIAL PRIMARY KEY,
    Title VARCHAR(100) NOT NULL
);

INSERT INTO Todo VALUES (1, 'Test'), (2, 'Test 2')