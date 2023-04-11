using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class FillTbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.NaturalPersons (FirstName, LastName, Patronymic, Gender, Age, Place, Country, City, Address, Email, Phone, Birthday)  VALUES" +
               " (N'Иван', N'Петров', N'Петрович', 'male', 28, 'Some Company', N'Россия', N'Самара', 'Some address', 'some@email.com', '+79372110710', '1998-02-20')," +
               " (N'Петр', N'Петров', N'Иванович', 'male', 42, 'Some Company', N'Россия', N'Москва', 'Some address', 'some2@email.com', '+79372110710', '1998-02-20')," +
               " (N'София', N'Петрова', N'Ивановна', 'male', 65, 'Some Company', N'Россия', N'Казань', 'Some address', 'some3@email.com', '+79372110710', '1998-02-20')," +
               " (N'София', N'Петрова', N'Ивановна', 'male', 35, 'Some Company', N'Россия', N'Казань', 'Some address', 'some4@email.com', '+79372110710', '1998-02-20')," +
               " (N'София', N'Петрова', N'Ивановна', 'male', 62, 'Some Company', N'Россия', N'Казань', 'Some address', 'some5@email.com', '+79372110710', '1998-02-20')," +
               " (N'София', N'Петрова', N'Ивановна', 'male', 42, 'Some Company', N'Беларусь', N'Минск', 'Some address', 'some6@email.com', '+79372110710', '1998-02-20')," +
               " (N'София', N'Петрова', N'Ивановна', 'male', 35, 'Some Company', N'Россия', N'Казань', 'Some address', 'some7@email.com', '+79372110710', '1998-02-20')," +
               " (N'София', N'Петрова', N'Ивановна', 'male', 65, 'Some Company', N'Казахстан', N'Алма-Ата', 'Some address', 'some8@email.com', '+79372110710', '1998-02-20')," +
               " (N'София', N'Петрова', N'Ивановна', 'male', 70, 'Some Company', N'Россия', N'Москва', 'Some address', 'some9@email.com', '+79372110710', '1998-02-20')"
            );

            migrationBuilder.Sql("INSERT INTO dbo.LegalPersons (Name, Inn, Ogrn, Country, City, Address, Phone, Email)  VALUES" +
               " (N'ООО 1', 11, 11, N'Россия', N'Самара', 'Some address', 'some@email.com', '+79372110710')," +
               " (N'ООО 2', 12, 12, N'Россия', N'Москва', 'Some address', 'some1@email.com', '+79372110710')," +
               " (N'ООО 3', 13, 13, N'Россия', N'Самара', 'Some address', 'some2@email.com', '+79372110710')"
           );

            migrationBuilder.Sql("INSERT INTO dbo.Contracts (NaturalPersonId, LegalPersonId, Date, Contract_sum, Status)  VALUES" +
              " (1, 0, '2022-02-20', 35000, 'Signed')," +
              " (2, 0, '2021-02-15', 45000, 'Signed')," +
              " (3, 0, '2020-02-18', 22000, 'Signed')," +
              " (4, 0, '2023-03-10', 18000, 'Signed')," +
              " (5, 0, '2023-03-28', 73900, 'Signed')," +
              " (6, 0, '2023-03-30', 42000, 'Signed')," +
              " (7, 0, '2023-04-08', 38000, 'Signed')," +
              " (8, 0, '2023-04-02', 58000, 'Signed')," +
              " (9, 0, '2023-04-09', 45000, 'Signed')," +
              " (0, 1, '2023-03-15', 61000, 'Signed')," +
              " (0, 2, '2023-03-15', 44000, 'Signed')," +
              " (0, 3, '2023-03-15', 38000, 'Signed')"
          );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE dbo.NaturalPersons");
            migrationBuilder.Sql("TRUNCATE TABLE dbo.LegalPersons");
            migrationBuilder.Sql("TRUNCATE TABLE dbo.Contracts");
        }
    }
}
