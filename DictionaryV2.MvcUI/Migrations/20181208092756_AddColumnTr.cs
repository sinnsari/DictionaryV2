using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DictionaryV2.MvcUI.Migrations
{
    public partial class AddColumnTr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnglishWord",
                table: "EngDictionary",
                newName: "TrStr");

            migrationBuilder.AddColumn<string>(
                name: "EngStr",
                table: "EngDictionary",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngStr",
                table: "EngDictionary");

            migrationBuilder.RenameColumn(
                name: "TrStr",
                table: "EngDictionary",
                newName: "EnglishWord");
        }
    }
}
