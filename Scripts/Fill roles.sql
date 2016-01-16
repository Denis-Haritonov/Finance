SET IDENTITY_INSERT dbo.webpages_Roles ON
insert into webpages_Roles(RoleName, RoleId)
values ('Admin', 1),
		('Client', 2),
		('Operator', 3),
		('SecurityWorker', 4)

SET IDENTITY_INSERT dbo.webpages_Roles OFF