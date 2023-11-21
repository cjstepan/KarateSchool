-- Insert sample member records with a mix of 2022 and 2023 dates
INSERT INTO [dbo].[Member] ([Member_UserID], [MemberFirstName], [MemberLastName], [MemberDateJoined], [MemberPhoneNumber], [MemberEmail])
VALUES
    (1, N'Ken', N'Magel', '2022-01-05', N'123-456-7890', N'ken.magel@example.com'),
    (4, N'Simone', N'Ludwig', '2022-02-15', N'987-654-3210', N'simone.ludwig@example.com'),
    (5, N'Calvin', N'Stepan', '2023-03-20', N'555-555-5555', N'calvin.stepan@example.com'),
    (6, N'Ryan', N'Gabler', '2022-04-10', N'555-123-4567', N'ryan.gabler@example.com'),
    (7, N'John', N'Wayne', '2022-05-08', N'555-987-6543', N'john.wayne@example.com'),
    (8, N'Carl', N'Jerome', '2023-06-25', N'555-111-2222', N'carl.jerome@example.com'),
    (9, N'Mark', N'Andrew', '2022-07-03', N'555-333-4444', N'mark.andrew@example.com'),
    (10, N'James', N'Andrews', '2023-08-12', N'555-555-6666', N'james.andrews@example.com'),
    (11, N'Roger', N'Green', '2022-09-30', N'555-777-8888', N'roger.green@example.com'),
    (12, N'New', N'User', '2023-09-30', N'170-777-8088', N'test.green@example.com'),
    (16, N'Jill', N'Stromsborg', '2023-10-15', N'555-999-0000', N'jill.stromsborg@example.com'),
    (17, N'Lan', N'Hu', '2022-11-22', N'555-222-3333', N'lan.hu@example.com'),
    (20, N'Ben', N'Braaten', '2023-1-05', N'555-444-5555', N'ben.braaten@example.com');