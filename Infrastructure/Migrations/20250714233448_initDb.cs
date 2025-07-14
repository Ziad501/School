using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HeadOfDepartmentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    CreditHours = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Period = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentCourses",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCoreRequirement = table.Column<bool>(type: "boolean", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCourses", x => new { x.DepartmentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_DepartmentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentCourses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CompletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Grade = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false, defaultValue: "Enrolled")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Capacity", "Code", "CreditHours", "Description", "EndDate", "Name", "Period", "StartDate", "TeacherId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000031"), 30, "MATH101", 4, "Differential and integral calculus", new DateTime(2025, 10, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(830), "Calculus I", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(830), null });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "Description", "HeadOfDepartmentId", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "CS", "", new Guid("00000000-0000-0000-0000-000000000201"), "Computer Science" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "EE", "", new Guid("00000000-0000-0000-0000-000000000202"), "Electrical Engineering" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentCourses",
                columns: new[] { "CourseId", "DepartmentId", "Id", "IsCoreRequirement" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("d32a6064-01f5-4704-8d38-f3c85a5c1f69"), true },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("f9cd37ca-1975-4f80-8659-6ba2e6edc256"), true }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DateOfBirth", "DepartmentId", "Email", "EnrollmentDate", "FirstName", "IsActive", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), "123 Tech Way", new DateTime(2000, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), "alice.johnson@student.edu", new DateTime(2024, 7, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(9474), "Alice", true, "Johnson", "555-0101" },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "456 Code Lane", new DateTime(2001, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), "bob.williams@student.edu", new DateTime(2024, 7, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(9479), "Bob", true, "Williams", "555-0102" },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "789 Logic Blvd", new DateTime(1999, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002"), "charlie.brown@student.edu", new DateTime(2025, 1, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(9482), "Charlie", true, "Brown", "555-0103" },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "101 Algorithm Ave", new DateTime(2002, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), "diana.miller@student.edu", new DateTime(2025, 1, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(9484), "Diana", true, "Miller", "555-0104" },
                    { new Guid("00000000-0000-0000-0000-000000000105"), "212 Circuit Cr", new DateTime(2000, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000002"), "eve.davis@student.edu", new DateTime(2023, 7, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(9487), "Eve", true, "Davis", "555-0105" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "HireDate", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000201"), new Guid("00000000-0000-0000-0000-000000000001"), "john.smith@university.edu", "John", new DateTime(2025, 7, 14, 23, 34, 48, 298, DateTimeKind.Utc).AddTicks(4632), "Smith", "555-0201" },
                    { new Guid("00000000-0000-0000-0000-000000000202"), new Guid("00000000-0000-0000-0000-000000000002"), "sarah.johnson@university.edu", "Sarah", new DateTime(2025, 7, 14, 23, 34, 48, 298, DateTimeKind.Utc).AddTicks(4641), "Johnson", "555-0202" },
                    { new Guid("00000000-0000-0000-0000-000000000203"), new Guid("00000000-0000-0000-0000-000000000001"), "michael.brown@university.edu", "Michael", new DateTime(2025, 7, 14, 23, 34, 48, 298, DateTimeKind.Utc).AddTicks(4643), "Brown", "555-0203" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Capacity", "Code", "CreditHours", "Description", "EndDate", "Name", "Period", "StartDate", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000011"), 30, "CS201", 4, "Fundamental data structures and algorithms", new DateTime(2025, 10, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(776), "Data Structures", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(768), new Guid("00000000-0000-0000-0000-000000000201") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), 30, "CS301", 3, "Advanced algorithm design and analysis", new DateTime(2025, 10, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(782), "Analysis of Algorithms", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(781), new Guid("00000000-0000-0000-0000-000000000201") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), 30, "CS202", 3, "Relational database design and implementation", new DateTime(2025, 10, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(814), "Database Systems", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(814), new Guid("00000000-0000-0000-0000-000000000203") },
                    { new Guid("00000000-0000-0000-0000-000000000021"), 30, "EE101", 4, "Basic circuit theory and analysis", new DateTime(2025, 10, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(817), "Circuit Analysis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(817), new Guid("00000000-0000-0000-0000-000000000202") },
                    { new Guid("00000000-0000-0000-0000-000000000022"), 30, "EE201", 3, "Digital systems and logic design principles", new DateTime(2025, 10, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(820), "Digital Logic Design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 34, 48, 297, DateTimeKind.Utc).AddTicks(820), new Guid("00000000-0000-0000-0000-000000000202") }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CompletionDate", "CourseId", "EnrollmentDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("2dcae727-bd0b-441a-b897-6fb4878a786f"), null, new Guid("00000000-0000-0000-0000-000000000031"), new DateTime(2025, 6, 14, 23, 34, 48, 298, DateTimeKind.Utc).AddTicks(3095), "", new Guid("00000000-0000-0000-0000-000000000101") },
                    { new Guid("38352581-6830-43dc-8171-8a17001c8276"), null, new Guid("00000000-0000-0000-0000-000000000031"), new DateTime(2025, 6, 14, 23, 34, 48, 298, DateTimeKind.Utc).AddTicks(3141), "", new Guid("00000000-0000-0000-0000-000000000105") }
                });

            migrationBuilder.InsertData(
                table: "DepartmentCourses",
                columns: new[] { "CourseId", "DepartmentId", "Id", "IsCoreRequirement" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("7ed84231-2814-4e06-ba29-c30073271b6f"), true },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("3d4556c7-5eb9-42b3-8ad2-8901c890050c"), true },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("cc945e49-8718-4576-8810-530ace87a140"), true },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("17d3c9d1-da1c-4d18-981f-1efddd30f6d4"), true },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("7dc7ffac-7212-4d16-af84-4af5f8e76b68"), false }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CompletionDate", "CourseId", "EnrollmentDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("15b2a4aa-45ef-4094-aa0c-831d9134c51d"), null, new Guid("00000000-0000-0000-0000-000000000022"), new DateTime(2025, 6, 14, 23, 34, 48, 298, DateTimeKind.Utc).AddTicks(3139), "", new Guid("00000000-0000-0000-0000-000000000105") },
                    { new Guid("22af58ab-cb52-49d0-93bf-8a1aa9505f15"), null, new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2025, 6, 14, 23, 34, 48, 298, DateTimeKind.Utc).AddTicks(3100), "", new Guid("00000000-0000-0000-0000-000000000102") },
                    { new Guid("2ad9c909-b70f-41cd-861f-17ceac503ce9"), null, new Guid("00000000-0000-0000-0000-000000000021"), new DateTime(2025, 6, 14, 23, 34, 48, 298, DateTimeKind.Utc).AddTicks(3133), "", new Guid("00000000-0000-0000-0000-000000000103") },
                    { new Guid("2d86cb73-0769-44ab-870e-7a59fb8acd9a"), null, new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2025, 6, 14, 23, 34, 48, 298, DateTimeKind.Utc).AddTicks(3137), "", new Guid("00000000-0000-0000-0000-000000000104") },
                    { new Guid("a3eb3f1f-94b8-4058-bdcb-34e727d881bd"), null, new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2025, 6, 14, 23, 34, 48, 298, DateTimeKind.Utc).AddTicks(3086), "", new Guid("00000000-0000-0000-0000-000000000101") },
                    { new Guid("f9731854-94ec-4ca3-a947-f5ef31f74d8f"), null, new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2025, 6, 14, 23, 34, 48, 298, DateTimeKind.Utc).AddTicks(3098), "", new Guid("00000000-0000-0000-0000-000000000102") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourses_CourseId",
                table: "DepartmentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DepartmentId",
                table: "Teacher",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentCourses");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
