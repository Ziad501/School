using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    EnrollmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
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
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000031"), 30, "MATH101", 4, "Differential and integral calculus", new DateTime(2025, 10, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6245), "Calculus I", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6244), null });

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
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("d5a2864f-09d7-478d-8c45-e05df612496b"), true },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("5e1c57ad-2d67-4e1f-a071-95db0a91d04c"), true }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DateOfBirth", "DepartmentId", "Email", "EnrollmentDate", "FirstName", "IsActive", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), "123 Tech Way", new DateTime(2000, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000001"), "alice.johnson@student.edu", new DateTime(2024, 7, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(3641), "Alice", true, "Johnson", "555-0101" },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "456 Code Lane", new DateTime(2001, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000001"), "bob.williams@student.edu", new DateTime(2024, 7, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(3646), "Bob", true, "Williams", "555-0102" },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "789 Logic Blvd", new DateTime(1999, 11, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000002"), "charlie.brown@student.edu", new DateTime(2025, 1, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(3652), "Charlie", true, "Brown", "555-0103" },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "101 Algorithm Ave", new DateTime(2002, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000001"), "diana.miller@student.edu", new DateTime(2025, 1, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(3655), "Diana", true, "Miller", "555-0104" },
                    { new Guid("00000000-0000-0000-0000-000000000105"), "212 Circuit Cr", new DateTime(2000, 7, 12, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000002"), "eve.davis@student.edu", new DateTime(2023, 7, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(3657), "Eve", true, "Davis", "555-0105" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "HireDate", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000201"), new Guid("00000000-0000-0000-0000-000000000001"), "john.smith@university.edu", "John", new DateTime(2025, 7, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(8251), "Smith", "555-0201" },
                    { new Guid("00000000-0000-0000-0000-000000000202"), new Guid("00000000-0000-0000-0000-000000000002"), "sarah.johnson@university.edu", "Sarah", new DateTime(2025, 7, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(8265), "Johnson", "555-0202" },
                    { new Guid("00000000-0000-0000-0000-000000000203"), new Guid("00000000-0000-0000-0000-000000000001"), "michael.brown@university.edu", "Michael", new DateTime(2025, 7, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(8267), "Brown", "555-0203" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Capacity", "Code", "CreditHours", "Description", "EndDate", "Name", "Period", "StartDate", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000011"), 30, "CS201", 4, "Fundamental data structures and algorithms", new DateTime(2025, 10, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6228), "Data Structures", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6217), new Guid("00000000-0000-0000-0000-000000000201") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), 30, "CS301", 3, "Advanced algorithm design and analysis", new DateTime(2025, 10, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6234), "Analysis of Algorithms", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6233), new Guid("00000000-0000-0000-0000-000000000201") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), 30, "CS202", 3, "Relational database design and implementation", new DateTime(2025, 10, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6237), "Database Systems", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6236), new Guid("00000000-0000-0000-0000-000000000203") },
                    { new Guid("00000000-0000-0000-0000-000000000021"), 30, "EE101", 4, "Basic circuit theory and analysis", new DateTime(2025, 10, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6239), "Circuit Analysis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6239), new Guid("00000000-0000-0000-0000-000000000202") },
                    { new Guid("00000000-0000-0000-0000-000000000022"), 30, "EE201", 3, "Digital systems and logic design principles", new DateTime(2025, 10, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6242), "Digital Logic Design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 14, 23, 49, 26, 46, DateTimeKind.Utc).AddTicks(6242), new Guid("00000000-0000-0000-0000-000000000202") }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CompletionDate", "CourseId", "EnrollmentDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("a98ad2ab-54f3-4cb0-bd3f-ab92dcf5baa7"), null, new Guid("00000000-0000-0000-0000-000000000031"), new DateTime(2025, 6, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(6672), "", new Guid("00000000-0000-0000-0000-000000000101") },
                    { new Guid("ef51b2aa-3b22-4c8f-bd1c-8cd66b92b392"), null, new Guid("00000000-0000-0000-0000-000000000031"), new DateTime(2025, 6, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(6690), "", new Guid("00000000-0000-0000-0000-000000000105") }
                });

            migrationBuilder.InsertData(
                table: "DepartmentCourses",
                columns: new[] { "CourseId", "DepartmentId", "Id", "IsCoreRequirement" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("1db8ab4a-841b-4ad8-b9d8-06bf39a11fc6"), true },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("32d31eff-3e41-4485-aa1f-02ea49aeb0d9"), true },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("89362f88-6990-44f1-849e-0d7cf1d9b7e2"), true },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("21580688-9af0-477a-8ff2-db7b46e17dca"), true },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("9ad734e0-2433-4cc4-838c-240830dc311a"), false }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CompletionDate", "CourseId", "EnrollmentDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("219f5997-9b0d-402a-af3e-dc2fcdebc94a"), null, new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2025, 6, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(6681), "", new Guid("00000000-0000-0000-0000-000000000102") },
                    { new Guid("30864863-cf8e-4073-a54e-34dad785da73"), null, new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2025, 6, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(6667), "", new Guid("00000000-0000-0000-0000-000000000101") },
                    { new Guid("50939d5f-2047-4c01-8de3-fafe93d62227"), null, new Guid("00000000-0000-0000-0000-000000000022"), new DateTime(2025, 6, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(6689), "", new Guid("00000000-0000-0000-0000-000000000105") },
                    { new Guid("6471c841-7973-4fc2-b07c-c406afd1c016"), null, new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2025, 6, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(6679), "", new Guid("00000000-0000-0000-0000-000000000102") },
                    { new Guid("c37deab2-0275-4010-a0cc-5be6a0334c10"), null, new Guid("00000000-0000-0000-0000-000000000021"), new DateTime(2025, 6, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(6683), "", new Guid("00000000-0000-0000-0000-000000000103") },
                    { new Guid("e2ceb1fb-9b53-4050-abed-8957e50f599d"), null, new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2025, 6, 14, 23, 49, 26, 47, DateTimeKind.Utc).AddTicks(6685), "", new Guid("00000000-0000-0000-0000-000000000104") }
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
