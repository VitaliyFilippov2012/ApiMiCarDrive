using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBContext.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EVENT_TYPES",
                columns: table => new
                {
                    EVENT_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENT_TYPES", x => x.EVENT_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "FUEL_TYPES",
                columns: table => new
                {
                    FUEL_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUEL_TYPES", x => x.FUEL_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "PHOTO",
                columns: table => new
                {
                    PHOTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EXPANSION = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHOTO", x => x.PHOTO_ID);
                });

            migrationBuilder.CreateTable(
                name: "PHOTO_ARCHIVE",
                columns: table => new
                {
                    PHOTO_ARCHIVE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PATH = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHOTO_ARCHIVE", x => x.PHOTO_ARCHIVE_ID);
                });

            migrationBuilder.CreateTable(
                name: "RIGHTS",
                columns: table => new
                {
                    RIGHT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RIGHTS", x => x.RIGHT_ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ROLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ROLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE_TYPES",
                columns: table => new
                {
                    SERVICE_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE_TYPES", x => x.SERVICE_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "TRANSMISSION_TYPES",
                columns: table => new
                {
                    TRANSMISSION_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSMISSION_TYPES", x => x.TRANSMISSION_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "PHOTO_PHOTO_ARCHIVE",
                columns: table => new
                {
                    PHOTO_ARCHIVE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PHOTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHOTO_PHOTOARCHIVE", x => new { x.PHOTO_ARCHIVE_ID, x.PHOTO_ID });
                    table.ForeignKey(
                        name: "FK_PHOTO_PHOTOARCHIVE_PHOTO",
                        column: x => x.PHOTO_ARCHIVE_ID,
                        principalTable: "PHOTO_ARCHIVE",
                        principalColumn: "PHOTO_ARCHIVE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PHOTO_PHOTOARCHIVE_PHOTOARCHIVE",
                        column: x => x.PHOTO_ID,
                        principalTable: "PHOTO",
                        principalColumn: "PHOTO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    GENDER = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    BIRTHDAY = table.Column<DateTime>(type: "date", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LASTNAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PATRONYMIC = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PHOTO_ARCHIVE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_USERS_PHOTOARCHIVE",
                        column: x => x.PHOTO_ARCHIVE_ID,
                        principalTable: "PHOTO_ARCHIVE",
                        principalColumn: "PHOTO_ARCHIVE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CARS",
                columns: table => new
                {
                    CAR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    FUEL_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TRANSMISSION_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MARK = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MODEL = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    VOLUME_ENGINE = table.Column<int>(type: "int", nullable: false),
                    POWER = table.Column<int>(type: "int", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    VIN = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: false),
                    COMMENT = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PHOTO_ARCHIVE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    YEAR_ISSUE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARS", x => x.CAR_ID);
                    table.ForeignKey(
                        name: "FK_CARS_FUELTYPE",
                        column: x => x.FUEL_TYPE_ID,
                        principalTable: "FUEL_TYPES",
                        principalColumn: "FUEL_TYPE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CARS_PHOTOARCHIVE",
                        column: x => x.PHOTO_ARCHIVE_ID,
                        principalTable: "PHOTO_ARCHIVE",
                        principalColumn: "PHOTO_ARCHIVE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CARS_TRANSMISSIONTYPE",
                        column: x => x.TRANSMISSION_TYPE_ID,
                        principalTable: "TRANSMISSION_TYPES",
                        principalColumn: "TRANSMISSION_TYPE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACTION_AUDIT",
                columns: table => new
                {
                    ENTITY_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATE_UPDATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ENTITY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ACTION = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTIONAUDIT", x => new { x.ENTITY_ID, x.DATE_UPDATE, x.USER_ID });
                    table.ForeignKey(
                        name: "FK_ACTIONAUDIT_USER",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AUTHENTICATION",
                columns: table => new
                {
                    LOGIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PASSWORD = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHENTICATION", x => x.LOGIN);
                    table.ForeignKey(
                        name: "FK_AUTHENTICATION_USER",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USERS_CARS",
                columns: table => new
                {
                    USER_CAR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CAR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERSCARS", x => x.USER_CAR_ID);
                    table.ForeignKey(
                        name: "FK_USERCARS_CAR",
                        column: x => x.CAR_ID,
                        principalTable: "CARS",
                        principalColumn: "CAR_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USERCARS_USER",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CAR_EVENTS",
                columns: table => new
                {
                    EVENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EVENT_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_CAR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATE = table.Column<DateTime>(type: "date", nullable: false),
                    COSTS = table.Column<decimal>(type: "money", nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "money", nullable: true),
                    COMMENT = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    MILEAGE = table.Column<long>(type: "bigint", nullable: true),
                    PHOTO_ARCHIVE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ADDRESS_STATION = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTS", x => x.EVENT_ID);
                    table.ForeignKey(
                        name: "FK_EVENTS_PHOTOARCHIVE",
                        column: x => x.PHOTO_ARCHIVE_ID,
                        principalTable: "PHOTO_ARCHIVE",
                        principalColumn: "PHOTO_ARCHIVE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVENTS_TYPEEVENTS",
                        column: x => x.EVENT_TYPE_ID,
                        principalTable: "EVENT_TYPES",
                        principalColumn: "EVENT_TYPE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVENTS_USERSCARS",
                        column: x => x.USER_CAR_ID,
                        principalTable: "USERS_CARS",
                        principalColumn: "USER_CAR_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USERS_CARS_RIGHTS",
                columns: table => new
                {
                    RIGHT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_CAR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERSCARS_RIGHTS", x => new { x.USER_CAR_ID, x.RIGHT_ID });
                    table.ForeignKey(
                        name: "FK_USERSCARS_RIGHTS_RIGHT",
                        column: x => x.RIGHT_ID,
                        principalTable: "RIGHTS",
                        principalColumn: "RIGHT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USERSCARS_RIGHTS_USER",
                        column: x => x.USER_CAR_ID,
                        principalTable: "USERS_CARS",
                        principalColumn: "USER_CAR_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USERS_CARS_ROLES",
                columns: table => new
                {
                    ROLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_CAR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERSCARS_ROLES", x => new { x.USER_CAR_ID, x.ROLE_ID });
                    table.ForeignKey(
                        name: "FK_USERSCARS_ROLES_ROLE",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ROLE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USERSCARS_ROLES_USER",
                        column: x => x.USER_CAR_ID,
                        principalTable: "USERS_CARS",
                        principalColumn: "USER_CAR_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CAR_SERVICES",
                columns: table => new
                {
                    SERVICE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EVENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TYPE_SERVICE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE", x => x.SERVICE_ID);
                    table.ForeignKey(
                        name: "FK_SERVICES_EVENTS",
                        column: x => x.EVENT_ID,
                        principalTable: "CAR_EVENTS",
                        principalColumn: "EVENT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SERVICES_TYPESERVICES",
                        column: x => x.TYPE_SERVICE_ID,
                        principalTable: "SERVICE_TYPES",
                        principalColumn: "SERVICE_TYPE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REFILL",
                columns: table => new
                {
                    REFILL_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EVENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VOLUME = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFILL", x => x.REFILL_ID);
                    table.ForeignKey(
                        name: "FK_REFILL_EVENTS",
                        column: x => x.EVENT_ID,
                        principalTable: "CAR_EVENTS",
                        principalColumn: "EVENT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DETAILS",
                columns: table => new
                {
                    DETAIL_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CAR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SERVICE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TYPE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETAILS", x => x.DETAIL_ID);
                    table.ForeignKey(
                        name: "FK_DETAILS_CARS",
                        column: x => x.CAR_ID,
                        principalTable: "CARS",
                        principalColumn: "CAR_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DETAILS_SERVICE",
                        column: x => x.SERVICE_ID,
                        principalTable: "CAR_SERVICES",
                        principalColumn: "SERVICE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACTION_AUDIT_USER_ID",
                table: "ACTION_AUDIT",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AUTHENTICATION_USER_ID",
                table: "AUTHENTICATION",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_EVENTS_EVENT_TYPE_ID",
                table: "CAR_EVENTS",
                column: "EVENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_EVENTS_PHOTO_ARCHIVE_ID",
                table: "CAR_EVENTS",
                column: "PHOTO_ARCHIVE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_EVENTS_USER_CAR_ID",
                table: "CAR_EVENTS",
                column: "USER_CAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_SERVICES_EVENT_ID",
                table: "CAR_SERVICES",
                column: "EVENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_SERVICES_TYPE_SERVICE_ID",
                table: "CAR_SERVICES",
                column: "TYPE_SERVICE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CARS_FUEL_TYPE_ID",
                table: "CARS",
                column: "FUEL_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CARS_PHOTO_ARCHIVE_ID",
                table: "CARS",
                column: "PHOTO_ARCHIVE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CARS_TRANSMISSION_TYPE_ID",
                table: "CARS",
                column: "TRANSMISSION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__CARS__C5DF234C42AA39B9",
                table: "CARS",
                column: "VIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DETAILS_CAR_ID",
                table: "DETAILS",
                column: "CAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DETAILS_SERVICE_ID",
                table: "DETAILS",
                column: "SERVICE_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__EVENT_TY__D9C1FA00C38D47B7",
                table: "EVENT_TYPES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__FUEL_TYP__D9C1FA0073A5024B",
                table: "FUEL_TYPES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__PHOTO_AR__5985D08DF3D30FB3",
                table: "PHOTO_ARCHIVE",
                column: "PATH",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PHOTO_PHOTO_ARCHIVE_PHOTO_ID",
                table: "PHOTO_PHOTO_ARCHIVE",
                column: "PHOTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REFILL_EVENT_ID",
                table: "REFILL",
                column: "EVENT_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__RIGHTS__D9C1FA00F640D36A",
                table: "RIGHTS",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__ROLES__D9C1FA00A09C0DDE",
                table: "ROLES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__SERVICE___D9C1FA0079BFFBFF",
                table: "SERVICE_TYPES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__TRANSMIS__D9C1FA00560522F4",
                table: "TRANSMISSION_TYPES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_PHOTO_ARCHIVE_ID",
                table: "USERS",
                column: "PHOTO_ARCHIVE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_CARS_CAR_ID",
                table: "USERS_CARS",
                column: "CAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_CARS_USER_ID",
                table: "USERS_CARS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_CARS_RIGHTS_RIGHT_ID",
                table: "USERS_CARS_RIGHTS",
                column: "RIGHT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_CARS_ROLES_ROLE_ID",
                table: "USERS_CARS_ROLES",
                column: "ROLE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTION_AUDIT");

            migrationBuilder.DropTable(
                name: "AUTHENTICATION");

            migrationBuilder.DropTable(
                name: "DETAILS");

            migrationBuilder.DropTable(
                name: "PHOTO_PHOTO_ARCHIVE");

            migrationBuilder.DropTable(
                name: "REFILL");

            migrationBuilder.DropTable(
                name: "USERS_CARS_RIGHTS");

            migrationBuilder.DropTable(
                name: "USERS_CARS_ROLES");

            migrationBuilder.DropTable(
                name: "CAR_SERVICES");

            migrationBuilder.DropTable(
                name: "PHOTO");

            migrationBuilder.DropTable(
                name: "RIGHTS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "CAR_EVENTS");

            migrationBuilder.DropTable(
                name: "SERVICE_TYPES");

            migrationBuilder.DropTable(
                name: "EVENT_TYPES");

            migrationBuilder.DropTable(
                name: "USERS_CARS");

            migrationBuilder.DropTable(
                name: "CARS");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "FUEL_TYPES");

            migrationBuilder.DropTable(
                name: "TRANSMISSION_TYPES");

            migrationBuilder.DropTable(
                name: "PHOTO_ARCHIVE");
        }
    }
}
