using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Должности",
                columns: table => new
                {
                    Код_должности = table.Column<int>(type: "INT", nullable: false),
                    Наименование_должности = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Оклад = table.Column<double>(type: "FLOAT", nullable: false),
                    Обязанности = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Требования = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Должности", x => x.Код_должности);
                });

            migrationBuilder.CreateTable(
                name: "Жанры",
                columns: table => new
                {
                    Код_жанра = table.Column<int>(type: "INT", nullable: false),
                    Наименование = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Описание = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Жанры", x => x.Код_жанра);
                });

            migrationBuilder.CreateTable(
                name: "Репертуар",
                columns: table => new
                {
                    Код_сеанса = table.Column<int>(type: "INT", nullable: false),
                    Дата = table.Column<DateTime>(type: "DATE", nullable: false),
                    Время_начала = table.Column<DateTime>(type: "DATE", nullable: false),
                    Время_окончания = table.Column<DateTime>(type: "DATE", nullable: false),
                    Цена_билета = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Репертуар", x => x.Код_сеанса);
                });

            migrationBuilder.CreateTable(
                name: "Сотрудники",
                columns: table => new
                {
                    Код_сотрудника = table.Column<int>(type: "INT", nullable: false),
                    Фио = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Возраст = table.Column<int>(type: "INT", nullable: false),
                    Пол = table.Column<string>(type: "CHAR(3)", nullable: false),
                    Адрес = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Телефон = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Паспортные_данные = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Код_должности = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сотрудники", x => x.Код_сотрудника);
                    table.ForeignKey(
                        name: "FK_Сотрудники_Должности_Код_должности",
                        column: x => x.Код_должности,
                        principalTable: "Должности",
                        principalColumn: "Код_должности",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Места",
                columns: table => new
                {
                    Номер_места = table.Column<int>(type: "INT", nullable: false),
                    Занятость = table.Column<string>(type: "CHAR(1)", nullable: false),
                    Код_сотрудника = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Места", x => x.Номер_места);
                    table.ForeignKey(
                        name: "FK_Места_Сотрудники_Код_сотрудника",
                        column: x => x.Код_сотрудника,
                        principalTable: "Сотрудники",
                        principalColumn: "Код_сотрудника",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Фильмы",
                columns: table => new
                {
                    Код_фильма = table.Column<int>(type: "INT", nullable: false),
                    Наименование = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Длительность = table.Column<double>(type: "FLOAT", nullable: false),
                    Фирма_производителя = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Страна_производителя = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Актеры = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Возрастные_ограничения = table.Column<string>(type: "CHAR(3)", nullable: false),
                    Описание = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Код_жанра = table.Column<int>(type: "INT", nullable: false),
                    Код_сеанса = table.Column<int>(type: "INT", nullable: false),
                    Номер_места = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Фильмы", x => x.Код_фильма);
                    table.ForeignKey(
                        name: "FK_Фильмы_Жанры_Код_жанра",
                        column: x => x.Код_жанра,
                        principalTable: "Жанры",
                        principalColumn: "Код_жанра",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Фильмы_Места_Номер_места",
                        column: x => x.Номер_места,
                        principalTable: "Места",
                        principalColumn: "Номер_места",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Фильмы_Репертуар_Код_сеанса",
                        column: x => x.Код_сеанса,
                        principalTable: "Репертуар",
                        principalColumn: "Код_сеанса",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Места_Код_сотрудника",
                table: "Места",
                column: "Код_сотрудника");

            migrationBuilder.CreateIndex(
                name: "IX_Сотрудники_Код_должности",
                table: "Сотрудники",
                column: "Код_должности");

            migrationBuilder.CreateIndex(
                name: "IX_Фильмы_Код_жанра",
                table: "Фильмы",
                column: "Код_жанра");

            migrationBuilder.CreateIndex(
                name: "IX_Фильмы_Код_сеанса",
                table: "Фильмы",
                column: "Код_сеанса");

            migrationBuilder.CreateIndex(
                name: "IX_Фильмы_Номер_места",
                table: "Фильмы",
                column: "Номер_места");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Фильмы");

            migrationBuilder.DropTable(
                name: "Жанры");

            migrationBuilder.DropTable(
                name: "Места");

            migrationBuilder.DropTable(
                name: "Репертуар");

            migrationBuilder.DropTable(
                name: "Сотрудники");

            migrationBuilder.DropTable(
                name: "Должности");
        }
    }
}
