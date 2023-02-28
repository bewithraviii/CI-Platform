
create table country 
(
country_id bigint Identity(1,1) Primary Key Not Null,
name varchar(255) Not Null,
ISO varchar(16),
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table city 
(
city_id bigint Identity(1,1) Primary Key Not Null,
country_id bigint FOREIGN KEY REFERENCES country(country_id) Not Null,
name varchar(255) Not Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table users
(
user_id bigint Identity(1,1) Primary Key Not Null,
first_name varchar(16) default Null,
last_name varchar(16) default Null,
email varchar(128) not Null,
password varchar(255) not Null,
phone_number int not Null,
avatar varchar(2048) default Null,
why_i_volunteer text default Null,
employee_id varchar(16) Default Null,
department varchar(16) default Null,
city_id bigint FOREIGN KEY REFERENCES city(city_id) Not Null,
country_id bigint FOREIGN KEY REFERENCES country(country_id) Not Null,
profile_text text default Null,
linked_in_url varchar(255) default Null,
title varchar(255) default Null,
status varchar(20) not null default 1,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table admin (
admin_id bigint Identity(1,1) Primary Key Not Null,
first_name varchar(16) default Null,
last_name varchar(16) default Null,
email varchar(128) Not Null,
password varchar(255) Not Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table banner (
banner_id bigint Identity(1,1) Primary Key Not Null,
image varchar(512) Not Null,
text text,
sort_order int default 0,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table mission_theme (
mission_theme_id bigint Identity(1,1) Primary Key Not Null,
title nvarchar(255),
status tinyint default 1 not Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table mission (
mission_id bigint Identity(1,1) Primary Key Not Null,
city_id bigint FOREIGN KEY REFERENCES city(city_id) Not Null,
country_id bigint FOREIGN KEY REFERENCES country(country_id) Not Null,
theme_id bigint FOREIGN KEY REFERENCES mission_theme(mission_theme_id) Not Null,
title varchar(128) Not Null,
short_description text,
description text default Null,
start_date datetime default Null,
end_date datetime default Null,
mission_type varchar(20) not null,
status varchar(20),
organization_name varchar(255) default Null,
organization_detail text default Null,
availability varchar(20) default Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table comment (
comment_id bigint Identity(1,1) Primary Key Not Null,
user_id bigint FOREIGN KEY REFERENCES users(user_id),
mission_id bigint FOREIGN KEY REFERENCES mission(mission_id) Not Null,
approval_status varchar(20) not null default 'pending',
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table cms_page (
cms_page_id bigint Identity(1,1) Primary Key Not Null,
title varchar(255),
description text,
slug varchar(255) Not Null,
status varchar(20) default 1,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table favorite_mission (
favourite_mission_id bigint Identity(1,1) Primary Key Not Null,
user_id bigint FOREIGN KEY REFERENCES users(user_id),
mission_id bigint FOREIGN KEY REFERENCES mission(mission_id) Not Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table goal_mission (
goal_mission_id bigint Identity(1,1) Primary Key Not Null,
mission_id bigint FOREIGN KEY REFERENCES mission(mission_id) Not Null,
goal_objective_text varchar(255) default Null,
goal_value varchar(11) Not Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table mission_application (
mission_application_id bigint Identity(1,1) Primary Key Not Null,
mission_id bigint FOREIGN KEY REFERENCES mission(mission_id) Not Null,
user_id bigint FOREIGN KEY REFERENCES users(user_id) not Null,
applied_at datetime not Null,
approval_status varchar(20) not null default 'pending',
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table mission_document (
mission_document_id bigint Identity(1,1) Primary Key Not Null,
mission_id bigint FOREIGN KEY REFERENCES mission(mission_id) Not Null,
document_name varchar(255) not Null,
document_type varchar(255) not Null,
document_path varchar(255),
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table mission_invite (
mission_invite_id bigint Identity(1,1) Primary Key Not Null,
mission_id bigint FOREIGN KEY REFERENCES mission(mission_id) Not Null,
from_user_id bigint FOREIGN KEY REFERENCES users(user_id) not Null,
to_user_id bigint FOREIGN KEY REFERENCES users(user_id) not null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table mission_media (
mission_media_id bigint Identity(1,1) Primary Key Not Null,
mission_id bigint FOREIGN KEY REFERENCES mission(mission_id) Not Null,
media_name nvarchar(255),
media_type nvarchar(255),
media_path nvarchar(255),
default_ nvarchar(20) default 0,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table mission_rating (
mission_rating_id bigint Identity(1,1) Primary Key Not Null,
mission_id bigint FOREIGN KEY REFERENCES mission(mission_id) Not Null,
user_id bigint FOREIGN KEY REFERENCES users(user_id) Not Null,
rating nvarchar(20) not Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table skill (
skill_id bigint Identity(1,1) Primary Key Not Null,
skill_name nvarchar(64),
status nvarchar(1) default 1 not Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table mission_skill (
mission_skill_id bigint Identity(1,1) Primary Key Not Null,
skill_id bigint FOREIGN KEY REFERENCES skill(skill_id) Not Null,
mission_id bigint FOREIGN KEY REFERENCES mission(mission_id) default Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table password_reset (
email nvarchar(191),
token nvarchar(191),
created_at datetime Not Null default CURRENT_TIMESTAMP,
)

create table story (
story_id bigint Identity(1,1) Primary Key Not Null,
mission_id bigint FOREIGN KEY REFERENCES mission(mission_id) Not Null,
user_id bigint FOREIGN KEY REFERENCES users(user_id) Not Null,
title varchar(255) default Null,
description text default Null,
status varchar(20) default 'draft',
published_at datetime default Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table story_invite (
story_invite_id bigint Identity(1,1) Primary Key Not Null,
story_id bigint FOREIGN KEY REFERENCES story(story_id) Not Null,
from_user_id bigint FOREIGN KEY REFERENCES users(user_id) Not Null,
to_user_id bigint FOREIGN KEY REFERENCES users(user_id) Not Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table story_media (
story_media_id bigint Identity(1,1) Primary Key Not Null,
story_id bigint FOREIGN KEY REFERENCES story(story_id) Not Null,
story_type varchar(8) not null,
story_path text not Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table timesheet (
timesheet_id bigint Identity(1,1) Primary Key Not Null,
mission_id bigint FOREIGN KEY REFERENCES mission(mission_id),
user_id bigint FOREIGN KEY REFERENCES users(user_id),
timesheet_time time,
action int,
date_volunteered datetime not Null,
notes text,
status varchar(20) default 'pending' not Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)

create table user_skill (
user_skill_id bigint Identity(1,1) Primary Key Not Null,
skill_id bigint FOREIGN KEY REFERENCES skill(skill_id) Not Null,
user_id bigint FOREIGN KEY REFERENCES users(user_id) Not Null,
created_at datetime Not Null default CURRENT_TIMESTAMP,
updated_at datetime default Null,
deleted_at datetime default Null,
)