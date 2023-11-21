-- Enable identity insert for the NetUser table
SET IDENTITY_INSERT [dbo].[NetUser] ON;

-- Insert data into the NetUser table
INSERT INTO [dbo].[NetUser] ([UserID], [UserName], [UserPassword], [UserType])
VALUES 
(1, N'kenmagel', N'user1', N'Member'),
(2, N'annedenton', N'user2', N'Instructor'),
(3, N'admin', N'admin', N'Administrator'),
(4, N'simoneludwig', N'user4', N'Member'),
(5, N'calvinstepan', N'user5', N'Member'),
(6, N'ryangabler', N'user6', N'Member'),
(7, N'johnwayne', N'user7', N'Member'),
(8, N'carljerome', N'user8', N'Member'),
(9, N'markandrew', N'user9', N'Member'),
(10, N'jamesandrews', N'user10', N'Member'),
(11, N'rogergreen', N'user11', N'Member'),
(12, N'newuser', N'user12', N'Member'),
(13, N'davidcook', N'user13', N'Instructor'),
(14, N'jeremystraub', N'user14', N'Instructor'),
(15, N'alexradermacher', N'user15', N'Instructor'),
(16, N'jillstromsborg', N'user16', N'Member'),
(17, N'lanhu', N'user17', N'Member'),
(18, N'joelatimer', N'user18', N'Instructor'),
(19, N'pratapkotala', N'user19', N'Instructor'),
(20, N'benbraaten', N'user20', N'Member');

-- Disable identity insert for the NetUser table
SET IDENTITY_INSERT [dbo].[NetUser] OFF;
