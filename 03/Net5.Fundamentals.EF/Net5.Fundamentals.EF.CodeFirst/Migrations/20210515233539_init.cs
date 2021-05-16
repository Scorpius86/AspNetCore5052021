using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Net5.Fundamentals.EF.CodeFirst.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Blog");

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Blog",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Clave = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                schema: "Blog",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Contenido = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    UsuarioIdPropietario = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UsuarioIdActualizacion = table.Column<int>(type: "int", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_PostUsuarioActualizacion",
                        column: x => x.UsuarioIdActualizacion,
                        principalSchema: "Blog",
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostUsuarioCreacion",
                        column: x => x.UsuarioIdCreacion,
                        principalSchema: "Blog",
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostUsuarioPropietario",
                        column: x => x.UsuarioIdPropietario,
                        principalSchema: "Blog",
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                schema: "Blog",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Contenido = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    UsuarioIdPropietario = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UsuarioIdActualizacion = table.Column<int>(type: "int", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_ComentarioPost",
                        column: x => x.PostId,
                        principalSchema: "Blog",
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioUsuarioActualizacion",
                        column: x => x.UsuarioIdActualizacion,
                        principalSchema: "Blog",
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioUsuarioCreacion",
                        column: x => x.UsuarioIdCreacion,
                        principalSchema: "Blog",
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioUsuarioPropietario",
                        column: x => x.UsuarioIdPropietario,
                        principalSchema: "Blog",
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PostId",
                schema: "Blog",
                table: "Comentario",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioIdActualizacion",
                schema: "Blog",
                table: "Comentario",
                column: "UsuarioIdActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioIdCreacion",
                schema: "Blog",
                table: "Comentario",
                column: "UsuarioIdCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UsuarioIdPropietario",
                schema: "Blog",
                table: "Comentario",
                column: "UsuarioIdPropietario");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UsuarioIdActualizacion",
                schema: "Blog",
                table: "Post",
                column: "UsuarioIdActualizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UsuarioIdCreacion",
                schema: "Blog",
                table: "Post",
                column: "UsuarioIdCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UsuarioIdPropietario",
                schema: "Blog",
                table: "Post",
                column: "UsuarioIdPropietario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario",
                schema: "Blog");

            migrationBuilder.DropTable(
                name: "Post",
                schema: "Blog");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Blog");
        }
    }
}
