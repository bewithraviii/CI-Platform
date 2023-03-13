
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





INSERT INTO mission(theme_id, city_id, country_id, title, short_description, description, start_date, end_date, mission_type, status, organization_name, organization_detail, availability)
VALUES
(15, 4, 5, 'Animal Welfare and Rescue', 'Volunteers will work with animals in a shelter', 'We are looking for volunteers to help us take care of animals in our shelter. Volunteers will be responsible for tasks such as feeding the animals, cleaning their cages, and taking them for walks. No prior experience is required, but volunteers should be comfortable working with animals.', '2023-05-01', '2023-08-30', 'Time', 1, 'Animal Welfare Society', 'Animal Welfare Society is a non-profit organization that works towards the welfare and protection of animals.', 100)
