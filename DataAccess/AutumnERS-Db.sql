
-- Tickets by User
select * from tickets where author_fk = 4;

UPDATE tickets SET status = 'Approved' WHERE ticketID = 16;

-- OLD -- 

create schema AutumnERS;

--The constraint is found by running the second command and copy-pasting the specified constraint in the error msg

alter table users drop constraint PK__users__CBA1B257E40D9164;
alter table users drop column userid;

alter table tickets drop column author_fk;
alter table tickets drop constraint FK__tickets__author___7A3223E8;

alter table tickets drop column resolver_fk;
alter table tickets drop constraint FK__tickets__resolve__7B264821;

drop table users;

create table users(
	userID int identity (1,1) unique not null,
	userName varchar (50) unique not null,
	password varchar (50) not null,
	userRole varchar (50) default 'employee',
	primary key (userID)
);

drop table tickets;

create table tickets(
	ticketID int identity (1,1) not null,
	author_fk int foreign key references users(userID) not null,
	resolver_fk int foreign key references users(userID) default 2,
	description varchar (255) not null,
	status varchar (50) default 'pending',
	amount money not null,
	primary key(ticketID)
);

insert into users (userName, password, userRole) values ('paulstanley', 'kiss', 'manager');
insert into users (userName, password, userRole) values ('genesimmons', 'kiss', 'manager');
insert into users (userName, password) values ('petercriss', 'kiss');
insert into users (userName, password) values ('acefrehley', 'kiss');

insert into tickets (author_fk, resolver_fk, description, status, amount) values (3, 2, 'kitty litter', 'pending', 34.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (4, 2, 'cocaine', 'pending', 678.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (4, 2, 'guitar strings', 'pending', 22.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (4, 2, 'alcohol', 'pending', 965.32);

truncate table tickets;

insert into users (userName, password, userRole) values ('ericcarr', 'kiss', 'employee');		 -- ID = 5
insert into users (userName, password, userRole) values ('ericsinger', 'kiss', 'employee');	 -- ID = 6
insert into users (userName, password) values ('brucekulick', 'kiss');						 -- ID = 7
insert into users (userName, password) values ('markstjohn', 'kiss');							 -- ID = 8
insert into users (userName, password) values ('vinnievincent', 'kiss');						 -- ID = 9
insert into users (userName, password) values ('tommythayer', 'kiss');						 -- ID = 10

insert into tickets (author_fk, resolver_fk, description, status, amount) values (3, 2, 'drumsticks', 'pending', 9.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (4, 2, 'edibles', 'pending', 278.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (4, 2, 'heroin', 'pending', 122.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (5, 2, 'paper', 'pending', 9.32);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (10, 2, 'spoonguard', 'pending', 34.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (7, 2, 'sharpies', 'pending', 4.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (7, 2, 'razor', 'pending', 8.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (9, 2, 'doggie bags', 'pending', 49.32);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (9, 2, 'web hosting', 'pending', 5034.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (9, 2, 'selfie stick', 'pending', 5.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (9, 2, 'bail money', 'pending', 1000.99);
insert into tickets (author_fk, resolver_fk, description, status, amount) values (9, 2, 'scarves', 'pending', 65.32);
