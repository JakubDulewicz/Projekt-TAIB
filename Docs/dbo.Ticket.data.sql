SET IDENTITY_INSERT [dbo].[Ticket] ON
INSERT INTO [dbo].[Ticket] ([TicketId], [Seat], [Class], [Price], [UserId], [FlightId], [AirlinesAirlineId]) VALUES (3, N'B43', 1, 200, 2, 7, 3)
INSERT INTO [dbo].[Ticket] ([TicketId], [Seat], [Class], [Price], [UserId], [FlightId], [AirlinesAirlineId]) VALUES (4, N'A32', 0, 150, 3, 5, 2)
INSERT INTO [dbo].[Ticket] ([TicketId], [Seat], [Class], [Price], [UserId], [FlightId], [AirlinesAirlineId]) VALUES (5, N'C12', 2, 300, 5, 7, 3)
SET IDENTITY_INSERT [dbo].[Ticket] OFF
