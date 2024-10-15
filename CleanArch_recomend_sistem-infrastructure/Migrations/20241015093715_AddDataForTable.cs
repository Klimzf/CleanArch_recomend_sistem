using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArch_recomend_sistem_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDataForTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Genre", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("0530928a-68c5-4410-b2ba-6550fa312512"), "Fantasy", 9.0, "The Lord of the Rings: The Return of the King" },
                    { new Guid("1730ceae-ab41-4cd6-9f1d-29ae0b2b73e6"), "Drama", 8.8000000000000007, "Fight Club" },
                    { new Guid("1831a3d4-e9d9-4426-b0ab-411f6dd36930"), "Sci-Fi", 7.7999999999999998, "Avatar" },
                    { new Guid("1d7d3eef-c4e9-47e5-82ff-00c6fc63ce85"), "Drama", 9.3000000000000007, "The Shawshank Redemption" },
                    { new Guid("32264b01-4c41-4e4f-859a-22d49f4b6f10"), "Animation", 8.4000000000000004, "Spider-Man: Into the Spider-Verse" },
                    { new Guid("360c5381-c7d6-4dc0-8f2c-2de66fb18c7e"), "Action", 8.5, "Gladiator" },
                    { new Guid("3e298f3b-6cce-43ed-b974-9c50a341bf2a"), "Action", 8.4000000000000004, "Avengers: Endgame" },
                    { new Guid("45e060b9-ec4b-47aa-8215-cc5ec62ce777"), "Animation", 8.0999999999999996, "Finding Nemo" },
                    { new Guid("4fa59ada-2807-4efc-96e1-e3dc3238d6b8"), "Action", 8.0999999999999996, "Guardians of the Galaxy" },
                    { new Guid("7a04e74d-34e9-4852-b410-610d8fe3254e"), "Action", 8.3000000000000007, "Braveheart" },
                    { new Guid("83787952-14c5-4976-b36a-b4215ac3a58a"), "Sci-Fi", 8.6999999999999993, "Star Wars: The Empire Strikes Back" },
                    { new Guid("854bced5-98d0-4869-98b7-d28d52679f76"), "Sci-Fi", 8.3000000000000007, "Star Wars: Return of the Jedi" },
                    { new Guid("85c7c161-7753-40e0-876d-35b1cd0c5cbd"), "Thriller", 8.5999999999999996, "The Silence of the Lambs" },
                    { new Guid("88931daf-c327-487f-8777-ba81bc8dd3cc"), "Animation", 8.3000000000000007, "Toy Story 3" },
                    { new Guid("8c03ab67-163b-4e9f-84c7-1d7f38f3e275"), "Animation", 7.4000000000000004, "Frozen" },
                    { new Guid("91bc230d-7f9f-4220-a15e-17119c589107"), "Sci-Fi", 8.8000000000000007, "Inception" },
                    { new Guid("9616f9a6-a801-4b50-a3ea-ed74e1cdade3"), "Fantasy", 8.6999999999999993, "The Lord of the Rings: The Two Towers" },
                    { new Guid("a4aee975-d877-4799-8728-b560274f4c98"), "Sci-Fi", 8.5999999999999996, "Interstellar" },
                    { new Guid("a959652d-564b-4efe-bf93-ec33f6df1c31"), "Crime", 8.9000000000000004, "Pulp Fiction" },
                    { new Guid("aad436f8-c7d2-48d6-a2da-0b5ed1e32741"), "Sci-Fi", 8.5999999999999996, "Star Wars: A New Hope" },
                    { new Guid("c5928c96-1835-4ab0-a72d-f9c713cc3d7d"), "Action", 8.0, "The Avengers" },
                    { new Guid("d12fd5a1-df07-460e-900c-da1abe59b4ea"), "Crime", 9.0, "The Godfather: Part II" },
                    { new Guid("d8eea35a-c2e3-4d93-86ff-b60e69d3d332"), "Drama", 8.8000000000000007, "Forrest Gump" },
                    { new Guid("db330b5b-2b53-43fa-84a5-fdb7e2bcf929"), "Action", 9.0, "The Dark Knight" },
                    { new Guid("e45bcc5a-2afa-47bb-884d-fdb38a0c2a57"), "Sci-Fi", 8.6999999999999993, "The Matrix" },
                    { new Guid("e75e0679-8fa4-4dca-a18e-b66727bb9f45"), "Animation", 8.3000000000000007, "Toy Story" },
                    { new Guid("e87e4ffe-4d2b-4367-be68-23d02d878033"), "Fantasy", 8.8000000000000007, "The Lord of the Rings: The Fellowship of the Ring" },
                    { new Guid("ee86f00e-3a57-4c51-91ff-12f4cee5d794"), "Romance", 7.9000000000000004, "Titanic" },
                    { new Guid("f405fdc4-0f6b-46c6-bb28-3f1db3df08e6"), "Animation", 8.5, "The Lion King" },
                    { new Guid("f5c55b4f-f1be-4f6e-81f0-56cfcfab3d5f"), "Crime", 9.1999999999999993, "The Godfather" },
                    { new Guid("f7adf664-c93a-4e45-987a-671ccd115e8a"), "History", 9.0, "Schindler's List" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Number" },
                values: new object[,]
                {
                    { new Guid("0d655e31-e2fc-4962-a392-b5b1a41cdd01"), "sophia@example.com", "Sophia Baker", "246813579" },
                    { new Guid("29080d93-b401-4101-a368-54d6ab5096c2"), "olivia@example.com", "Olivia Wilson", "357951486" },
                    { new Guid("2fddc036-e338-4139-bf45-5329aa20db84"), "alicejohnson@example.com", "Alice Johnson", "789123456" },
                    { new Guid("39706cf4-c4bf-4a3b-bb35-09bc7868f1db"), "william@example.com", "William Scott", "159753486" },
                    { new Guid("93f4142c-8732-4d12-8518-48de933dc064"), "robertbrown@example.com", "Robert Brown", "456789123" },
                    { new Guid("9bfd9e1e-9a3e-46a3-99e4-ffd9d7e88391"), "davidclark@example.com", "David Clark", "321654987" },
                    { new Guid("ae816912-7d24-48ef-9a33-62509561d981"), "johndoe@example.com", "John Doe", "123456789" },
                    { new Guid("badd9a9d-e35c-47c3-b9fd-6821c2fe8587"), "janesmith@example.com", "Jane Smith", "987654321" },
                    { new Guid("d4b6b683-49d5-4eed-801d-68154243d3e2"), "michael@example.com", "Michael Adams", "135792468" },
                    { new Guid("fd42ecec-67d6-4f05-9187-346ddc438476"), "emma@example.com", "Emma Harris", "654987321" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("0530928a-68c5-4410-b2ba-6550fa312512"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("1730ceae-ab41-4cd6-9f1d-29ae0b2b73e6"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("1831a3d4-e9d9-4426-b0ab-411f6dd36930"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("1d7d3eef-c4e9-47e5-82ff-00c6fc63ce85"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("32264b01-4c41-4e4f-859a-22d49f4b6f10"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("360c5381-c7d6-4dc0-8f2c-2de66fb18c7e"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("3e298f3b-6cce-43ed-b974-9c50a341bf2a"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("45e060b9-ec4b-47aa-8215-cc5ec62ce777"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("4fa59ada-2807-4efc-96e1-e3dc3238d6b8"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("7a04e74d-34e9-4852-b410-610d8fe3254e"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("83787952-14c5-4976-b36a-b4215ac3a58a"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("854bced5-98d0-4869-98b7-d28d52679f76"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("85c7c161-7753-40e0-876d-35b1cd0c5cbd"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("88931daf-c327-487f-8777-ba81bc8dd3cc"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("8c03ab67-163b-4e9f-84c7-1d7f38f3e275"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("91bc230d-7f9f-4220-a15e-17119c589107"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("9616f9a6-a801-4b50-a3ea-ed74e1cdade3"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("a4aee975-d877-4799-8728-b560274f4c98"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("a959652d-564b-4efe-bf93-ec33f6df1c31"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("aad436f8-c7d2-48d6-a2da-0b5ed1e32741"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("c5928c96-1835-4ab0-a72d-f9c713cc3d7d"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("d12fd5a1-df07-460e-900c-da1abe59b4ea"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("d8eea35a-c2e3-4d93-86ff-b60e69d3d332"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("db330b5b-2b53-43fa-84a5-fdb7e2bcf929"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("e45bcc5a-2afa-47bb-884d-fdb38a0c2a57"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("e75e0679-8fa4-4dca-a18e-b66727bb9f45"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("e87e4ffe-4d2b-4367-be68-23d02d878033"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("ee86f00e-3a57-4c51-91ff-12f4cee5d794"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("f405fdc4-0f6b-46c6-bb28-3f1db3df08e6"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("f5c55b4f-f1be-4f6e-81f0-56cfcfab3d5f"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("f7adf664-c93a-4e45-987a-671ccd115e8a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0d655e31-e2fc-4962-a392-b5b1a41cdd01"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("29080d93-b401-4101-a368-54d6ab5096c2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2fddc036-e338-4139-bf45-5329aa20db84"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("39706cf4-c4bf-4a3b-bb35-09bc7868f1db"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("93f4142c-8732-4d12-8518-48de933dc064"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9bfd9e1e-9a3e-46a3-99e4-ffd9d7e88391"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ae816912-7d24-48ef-9a33-62509561d981"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("badd9a9d-e35c-47c3-b9fd-6821c2fe8587"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d4b6b683-49d5-4eed-801d-68154243d3e2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fd42ecec-67d6-4f05-9187-346ddc438476"));
        }
    }
}
