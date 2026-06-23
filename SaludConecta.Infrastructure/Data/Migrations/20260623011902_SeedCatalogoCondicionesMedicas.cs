using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaludConecta.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCatalogoCondicionesMedicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CatalogoCondicionesMedicas",
                columns: new[] { "Id", "Categoria", "NombreCondicion", "Orden" },
                values: new object[,]
                {
                    { 1, "General", "Hipertensión arterial", 1 },
                    { 2, "General", "Obesidad", 2 },
                    { 3, "General", "Anemia", 3 },
                    { 4, "General", "Artritis", 4 },
                    { 5, "General", "Insuficiencia renal", 5 },
                    { 6, "Cardiaca", "Cardiopatía isquémica", 1 },
                    { 7, "Cardiaca", "Insuficiencia cardíaca", 2 },
                    { 8, "Cardiaca", "Arritmia cardíaca", 3 },
                    { 9, "Cardiaca", "Angina de pecho", 4 },
                    { 10, "Cardiaca", "Valvulopatía cardíaca", 5 },
                    { 11, "Pulmonar", "Asma", 1 },
                    { 12, "Pulmonar", "EPOC", 2 },
                    { 13, "Pulmonar", "Bronquitis crónica", 3 },
                    { 14, "Pulmonar", "Neumonía recurrente", 4 },
                    { 15, "Pulmonar", "Tuberculosis", 5 },
                    { 16, "Metabolica", "Diabetes mellitus tipo 1", 1 },
                    { 17, "Metabolica", "Diabetes mellitus tipo 2", 2 },
                    { 18, "Metabolica", "Dislipidemia", 3 },
                    { 19, "Metabolica", "Síndrome metabólico", 4 },
                    { 20, "Metabolica", "Gota", 5 },
                    { 21, "Endocrina", "Hipotiroidismo", 1 },
                    { 22, "Endocrina", "Hipertiroidismo", 2 },
                    { 23, "Endocrina", "Síndrome de Cushing", 3 },
                    { 24, "Endocrina", "Hiperparatiroidismo", 4 },
                    { 25, "Neurologica", "Epilepsia", 1 },
                    { 26, "Neurologica", "Migraña crónica", 2 },
                    { 27, "Neurologica", "Enfermedad de Parkinson", 3 },
                    { 28, "Neurologica", "Enfermedad de Alzheimer", 4 },
                    { 29, "Neurologica", "Esclerosis múltiple", 5 },
                    { 30, "Cancer", "Cáncer de mama", 1 },
                    { 31, "Cancer", "Cáncer colorrectal", 2 },
                    { 32, "Cancer", "Cáncer cervicouterino", 3 },
                    { 33, "Cancer", "Cáncer de próstata", 4 },
                    { 34, "Cancer", "Leucemia", 5 },
                    { 35, "Cancer", "Linfoma", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "CatalogoCondicionesMedicas",
                keyColumn: "Id",
                keyValue: 35);
        }
    }
}
