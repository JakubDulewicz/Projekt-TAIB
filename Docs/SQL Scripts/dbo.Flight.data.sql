SET IDENTITY_INSERT [dbo].[Flight] ON
INSERT INTO [dbo].[Flight] ([FlightId], [Name], [Destination], [Departure], [Arrival], [Status], [AirportIdTo], [AirportIdFrom], [PlaneId], [AirportFromAirportId], [AirportToAirportId]) VALUES (5, N'DG2456', N'America', N'2024-04-17 18:00:00', N'2024-04-18 11:00:00', 1, 3, 1, 4, 1, 3)
INSERT INTO [dbo].[Flight] ([FlightId], [Name], [Destination], [Departure], [Arrival], [Status], [AirportIdTo], [AirportIdFrom], [PlaneId], [AirportFromAirportId], [AirportToAirportId]) VALUES (7, N'FR1412', N'Germany', N'2024-05-12 12:00:00', N'2024-05-12 13:30:00', 1, 3, 1, 1, 1, 3)
SET IDENTITY_INSERT [dbo].[Flight] OFF
