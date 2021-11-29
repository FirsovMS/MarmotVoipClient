CREATE TABLE "Contacts" (
	"ContactId"	INTEGER,
	"PhoneNumber"	INTEGER,
	"Name"	TEXT NOT NULL,
	"Blocked"	INTEGER DEFAULT 0,
	PRIMARY KEY("ContactId" AUTOINCREMENT)
);

