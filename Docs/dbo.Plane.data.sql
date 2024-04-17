SET IDENTITY_INSERT [dbo].[Plane] ON
INSERT INTO [dbo].[Plane] ([PlaneId], [Model], [YearOfProduction], [SeatCount], [HasPrivateCabins], [AirlinesAirlineId], [AirportId]) VALUES (1, N'Boeing767', N'2014-01-01', 200, 0, 3, 2)
INSERT INTO [dbo].[Plane] ([PlaneId], [Model], [YearOfProduction], [SeatCount], [HasPrivateCabins], [AirlinesAirlineId], [AirportId]) VALUES (2, N'SU-25K', N'2020-01-01', 1, 1, 3, 1)
INSERT INTO [dbo].[Plane] ([PlaneId], [Model], [YearOfProduction], [SeatCount], [HasPrivateCabins], [AirlinesAirlineId], [AirportId]) VALUES (4, N'Boeing747', N'2016-01-01', 300, 0, 2, 3)
SET IDENTITY_INSERT [dbo].[Plane] OFF
