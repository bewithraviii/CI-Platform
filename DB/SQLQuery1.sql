
INSERT INTO users (first_name, last_name, email, password, phone_number, city_id, country_id, status)
VALUES ('Ravi','Patel','ravi@123','aaaa1111',1111111111, 1,1,1);



INSERT INTO city (country_id, name)
VALUES (5,'Perth');


INSERT INTO country ( name)
VALUES ('Perth');

select * from city;
select * from country;
select * from users;

ALTER TABLE users 
ALTER COLUMN city_id bigint NULL
ALTER TABLE users 
ALTER COLUMN country_id bigint NULL



ALTER TABLE password_reset
ADD ResetFlag  bit DEFAULT '0';


ALTER TABLE users
ALTER COLUMN phone_number nvarchar(11);

DELETE FROM country WHERE country_id = 7;



INSERT INTO skill(skill_name, status)
VALUES ('Anthropology', 1),
('Archeology', 1),
('Astronomy', 1),
('Computer Science', 1),
('Environmental Science', 1),
('History', 1),
('Library Science', 1),
('Mathematics', 1),
('Music Theory', 1),
('Research', 1),
('Administrative Support', 1),
('Customer Services', 1),
('Data Entry', 1),
('Executive Admin', 1),
('Office Management', 1),
('Office Reception', 1),
('Program Management', 1),
('Transaction', 1),
('Agronomy', 1),
('Animal Care/Handeling', 1),
('Animal Therapy', 1),
('Aquarium Maintenance', 1),
('Botany', 1),
('Environmental Education', 1),
('Environmental Policy', 1),
('Farming', 1)
;