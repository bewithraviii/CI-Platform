INSERT INTO users (first_name, last_name, email, password, phone_number, city_id, country_id, status)
VALUES ('Ravi','Patel','ravi@123','aaaa1111',1111111111, 1,1,1);



INSERT INTO city (country_id, name)
VALUES (1,'Ahmedabad');


INSERT INTO country ( name)
VALUES ('India');

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