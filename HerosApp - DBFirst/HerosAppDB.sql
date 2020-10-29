-- drop table enemies;
-- drop table powers;
-- drop table superpeople;
-- drop table charactertype;

-- creating the type of super person --
create table charactertype
(
	id serial primary key,
	chartype varchar(15)
);

-- creating the superpeople table --
create table superpeople
(
	id serial primary key,
	realname varchar(50) not null,
	workname varchar(50) unique not null,
	hideout varchar(50) not null,
	chartype int references charactertype (id)
);

-- creating the powers table --
create table powers
(
	id serial primary key,
	name varchar(20) not null,
	description varchar(100) not null,
	ownerid int references superpeople (id)
);

-- creating an enemies table to map enemies --
create table enemies
(
	id serial primary key,
	heroid int references superpeople(id),
	villainid int references superpeople (id)
);

-- inserting seed data --
insert into charactertype (chartype) values 
('Superhero'), 
('Supervillain');

insert into superpeople (realname, workname, hideout, chartype) values
('Peter Parker', 'Spiderman', 'His home', 1),
('Thor', 'Thor', 'Asgard', 1),
('Thanos', 'Thanos', 'Somewhere in the galaxy', 2),
('Otto Octavius', 'Doc Ock', 'His lab', 2);

insert into enemies (heroid, villainid) values
(1, 3),
(2, 3),
(1, 4);

insert into powers (name, description, ownerid) values
('Lightning Bearer', 'As a thunder god, he has the ability to weild lightning', 2),
('Spider senses', 'Alerts him that something is wrong', 1),
('Spider abilities', 'Spider man can do anything a spider can', 1),
('Snap', 'Using the infinity stone glove, in a snap he does population control', 3),
('Mechanical tentacles', 'Mechanical tentacles that shield and attack for him', 4);

