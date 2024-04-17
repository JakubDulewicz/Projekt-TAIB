SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([UserId], [Name], [Pesel], [Email], [Password], [Date], [Phone], [Roles]) VALUES (2, N'Łukasz Prokop', N'78138912712', N'lukusikprokopusik@gmial.com', N'NaWrotkach', N'2024-04-17', N'123543223', 1)
INSERT INTO [dbo].[User] ([UserId], [Name], [Pesel], [Email], [Password], [Date], [Phone], [Roles]) VALUES (3, N'Wojciech Tworek', N'32142123122', N'wojctektw@poczta.fm', N'ToJaTenNiepokorny', N'2024-03-12', N'345342244', 1)
INSERT INTO [dbo].[User] ([UserId], [Name], [Pesel], [Email], [Password], [Date], [Phone], [Roles]) VALUES (5, N'Jakub Dulewicz', N'63423532234', N'jakudul42@gmail.com', N'OstatniaNiedziela', N'2024-02-09', N'765343566', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
