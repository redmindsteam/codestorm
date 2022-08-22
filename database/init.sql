
/* Add admin User */
insert into "AspNetUsers"("Id", "FirstName", "MiddleName", "LastName", 
"IdentityFile", "CreatedDate", 
"UserName", "NormalizedUserName",
"Email", "NormalizedEmail",
"EmailConfirmed",
"PasswordHash", "SecurityStamp",
"ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed",
"TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount",
"MaxNumberOfProblemSets" )
values('029c8095-c6fc-4031-a046-929b8e82b603', 'O''tkirbek', 'Sodiqjonovich', 'Sobirjonov',
'92e6743d-6a60-43ee-a295-2b4f53b8fa1a', now(),
'SystemAdmin@gmail.com', 'SYSTEMADMIN@GMAIL.COM',
'SystemAdmin@gmail.com', 'SYSTEMADMIN@GMAIL.COM',
false,
'AQAAAAEAACcQAAAAEN2ZpchUiX/cSl5RpgaoSEEZCAlVZeHYXspSHlbu5RHhlz07Ai37D6xhkvhU8iOx3Q==','DKFVU3SHTQFSLHAWH3IQWSGIAHORESCM',
'fc646ba5-0048-4a66-90a6-fca4f962c706', '976260619' , false,
false, true,0,
1000);

/* Add Admin Role */
insert into "AspNetUserRoles" ("UserId", "RoleId")
Values (
	'029c8095-c6fc-4031-a046-929b8e82b603',
	(select "Id" from "AspNetRoles" where "Name"='Admin')
);

/* Add User */
insert into "AspNetUsers"("Id", "FirstName", "MiddleName", "LastName", 
"IdentityFile", "CreatedDate", 
"UserName", "NormalizedUserName",
"Email", "NormalizedEmail",
"EmailConfirmed",
"PasswordHash", "SecurityStamp",
"ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed",
"TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount",
"MaxNumberOfProblemSets" )
values('cfe33670-0b60-44ec-97af-5488b8e78854', 'Digital', 'Generation', 'Uzbekistan',
'92e6743d-6a60-43ee-a295-2b4f53b8fa0a', now(),
'RaqamliAvlod@gmail.com', 'RAQAMLIAVLOD@GMAIL.COM',
'RaqamliAvlod@gmail.com', 'RAQAMLIAVLOD@GMAIL.COM',
false,
'AQAAAAEAACcQAAAAEIZ5HLseH3804m3swDlJ/z9fMIZJbMhzMUvqvwvru0OKMxuFMTNdTieJ5Vpp7HOVmg==','TSRLLEBZLJA6J5KIDUICEXKJDAIPOGEX',
'3d8e7a28-38d4-4011-aa1c-26cc6b664666', '00 000 00 00' , false,
false, true,0,
1000);

/* Add User Role */
insert into "AspNetUserRoles" ("UserId", "RoleId")
Values (
	'cfe33670-0b60-44ec-97af-5488b8e78854',
	(select "Id" from "AspNetRoles" where "Name"='User')
);
