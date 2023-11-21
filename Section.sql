-- Enable identity insert for the Section table
SET IDENTITY_INSERT [dbo].[Section] ON;

-- Insert data into the Section table
INSERT INTO [dbo].[Section] ([SectionID], [SectionName], [SectionStartDate], [Member_ID], [Instructor_ID], [SectionFee])
VALUES 
(1, N'Karate Age-Uke', '2023-11-12 00:00:00', 1, 2, 500.0000),
(2, N'Karate Chudan-Uke', '2023-11-20 00:00:00', 4, 2, 600.0000),
(3, N'Karate Age-Uke', '2023-12-05 00:00:00', 6, 15, 800.0000),
(4, N'Karate Age-Uke', '2023-05-07 00:00:00', 12, 19, 250.0000),
(5, N'Karate Age-Uke', '2023-08-17 00:00:00', 16, 18, 450.0000),
(6, N'Karate Age-Uke', '2023-09-12 00:00:00', 5, 13, 999.0000),
(7, N'Karate Age-Uke', '2023-12-12 00:00:00', 17, 14, 750.0000),
(9, N'Karate Chudan-Uke', '2023-06-07 00:00:00', 7, 2, 333.0000),
(10, N'Karate Chudan-Uke', '2023-07-04 00:00:00', 8, 14, 1300.0000),
(11, N'Karate Chudan-Uke', '2023-06-12 00:00:00', 9, 19, 780.0000),
(13, N'Karate Chudan-Uke', '2023-04-30 00:00:00', 11, 18, 900.0000),
(15, N'Karate Chudan-Uke', '2023-04-25 00:00:00', 12, 15, 125.0000);

-- Disable identity insert for the Section table
SET IDENTITY_INSERT [dbo].[Section] OFF;
