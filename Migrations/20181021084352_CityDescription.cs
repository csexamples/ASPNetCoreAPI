﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfoAPI.Migrations
{
    public partial class CityDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cities",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cities");
        }
    }
}
