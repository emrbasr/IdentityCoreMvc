using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mersin.Api.Migrations
{
    /// <inheritdoc />
    public partial class UserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "citizen",
                columns: table => new
                {
                    uid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nationalidentifier = table.Column<string>(name: "national_identifier", type: "text", nullable: false),
                    first = table.Column<string>(type: "text", nullable: false),
                    last = table.Column<string>(type: "text", nullable: false),
                    motherfirst = table.Column<string>(name: "mother_first", type: "text", nullable: false),
                    fatherfirst = table.Column<string>(name: "father_first", type: "text", nullable: false),
                    gender = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    birthcity = table.Column<string>(name: "birth_city", type: "text", nullable: false),
                    dateofbirth = table.Column<string>(name: "date_of_birth", type: "text", nullable: false),
                    idregistrationcity = table.Column<string>(name: "id_registration_city", type: "text", nullable: false),
                    idregistrationdistrict = table.Column<string>(name: "id_registration_district", type: "text", nullable: false),
                    addresscity = table.Column<string>(name: "address_city", type: "text", nullable: false),
                    addressdistrict = table.Column<string>(name: "address_district", type: "text", nullable: false),
                    addressneighborhood = table.Column<string>(name: "address_neighborhood", type: "text", nullable: false),
                    streetaddress = table.Column<string>(name: "street_address", type: "text", nullable: false),
                    doororentrancenumber = table.Column<string>(name: "door_or_entrance_number", type: "text", nullable: false),
                    misc = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("citizen_pkey", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenEndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "citizen_id_registration_city_idx",
                table: "citizen",
                column: "id_registration_city");

            migrationBuilder.CreateIndex(
                name: "citizen_last_idx",
                table: "citizen",
                column: "last");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "citizen");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
