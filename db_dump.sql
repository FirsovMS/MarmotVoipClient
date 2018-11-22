BEGIN TRANSACTION;
DROP TABLE IF EXISTS `Types`;
CREATE TABLE IF NOT EXISTS `Types` (
	`id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`description`	TEXT NOT NULL UNIQUE
);
INSERT INTO `Types` (id,description) VALUES (1,'Message'),
 (2,'Call
');
DROP TABLE IF EXISTS `Messages`;
CREATE TABLE IF NOT EXISTS `Messages` (
	`msg_id`	INTEGER NOT NULL,
	`from`	INTEGER NOT NULL,
	`to`	INTEGER NOT NULL,
	`text`	INTEGER NOT NULL,
	PRIMARY KEY(`msg_id`)
);
DROP TABLE IF EXISTS `History`;
CREATE TABLE IF NOT EXISTS `History` (
	`item_type`	INTEGER NOT NULL,
	`call_id`	INTEGER,
	`msg_id`	INTEGER
);
DROP TABLE IF EXISTS `Contacts`;
CREATE TABLE IF NOT EXISTS `Contacts` (
	`contact_id`	INTEGER NOT NULL,
	`first_name`	TEXT NOT NULL DEFAULT "",
	`last_name`	TEXT NOT NULL DEFAULT "",
	`sip`	TEXT NOT NULL,
	PRIMARY KEY(`contact_id`)
);
INSERT INTO `Contacts` (contact_id,first_name,last_name,sip) VALUES (0,'MockFirstName','MockLastName','mock@example'),
 (2,'f2','l2','sip2@example');
DROP TABLE IF EXISTS `Calls`;
CREATE TABLE IF NOT EXISTS `Calls` (
	`call_id`	INTEGER NOT NULL,
	`from_id`	INTEGER NOT NULL,
	`to_id`	INTEGER NOT NULL,
	`call_type`	INTEGER NOT NULL,
	`time_start`	TEXT NOT NULL,
	`time_end`	TEXT NOT NULL,
	PRIMARY KEY(`call_id`)
);
INSERT INTO `Calls` (call_id,from_id,to_id,call_type,time_start,time_end) VALUES (1,1,2,2,'2018-11-19 17:51:07','2018-11-19 17:52:41');
DROP TABLE IF EXISTS `CallType`;
CREATE TABLE IF NOT EXISTS `CallType` (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`description`	TEXT NOT NULL UNIQUE
);
INSERT INTO `CallType` (id,description) VALUES (1,'Incoming'),
 (2,'Outcoming'),
 (3,'Rejected');
COMMIT;
