using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;


#nullable disable

namespace ECommerce.Migrations
{
    public partial class RoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			string userRoleId = Guid.NewGuid().ToString();
			string adminRoleId = Guid.NewGuid().ToString();
			string rootRoleId = Guid.NewGuid().ToString();
			string userAccountId = Guid.NewGuid().ToString();
			string adminAccountId  = Guid.NewGuid().ToString();
			string rootAccountId = Guid.NewGuid().ToString();


			migrationBuilder.InsertData(
					table: "AspNetUsers",
					columns: new[] {
						"Id",
						"UserName",
						"NormalizedUserName",
						"Email",
						"PasswordHash",
						"ConcurrencyStamp"
					},
					values: new[] {
						userAccountId,
						Roles.User.Value,
						Roles.User.Value.ToUpper(),
						Emails.User.Value,
						hashPassword(Passwords.User.Value),
						Guid.NewGuid().ToString()
					});
			migrationBuilder.InsertData(
					table: "AspNetUsers",
					columns: new[] {
						"Id",
						"UserName",
						"NormalizedUserName",
						"Email",
						"PasswordHash",
						"ConcurrencyStamp"
					},
					values: new[] {
						adminAccountId,
						Roles.Admin.Value,
						Roles.Admin.Value.ToUpper(),
						Emails.Admin.Value,
						hashPassword(Passwords.Admin.Value),
						Guid.NewGuid().ToString()
					});
			migrationBuilder.InsertData(
					table: "AspNetUsers",
					columns: new[] {
						"Id",
						"UserName",
						"NormalizedUserName",
						"Email",
						"PasswordHash",
						"ConcurrencyStamp"
					},
					values: new[] {
						rootAccountId,
						Roles.Root.Value,
						Roles.Root.Value.ToUpper(),
						Emails.Root.Value,
						hashPassword(Passwords.Root.Value),
						Guid.NewGuid().ToString()
					});




			migrationBuilder.InsertData(
					table: "AspNetRoles",
					columns: new[] {
						"Id",
						"Name",
						"NormalizedName",
						"ConcurrencyStamp"
					},
					values: new[] {
						userRoleId,
						Roles.User.Value,
						Roles.User.Value.ToUpper(),
						Guid.NewGuid().ToString()
					});
			migrationBuilder.InsertData(
					table: "AspNetRoles",
					columns: new[] {
						"Id",
						"Name",
						"NormalizedName",
						"ConcurrencyStamp"
					},
					values: new[] {
						adminRoleId,
						Roles.Admin.Value,
						Roles.Admin.Value.ToUpper(),
						Guid.NewGuid().ToString()
					});
			migrationBuilder.InsertData(
					table: "AspNetRoles",
					columns: new[] {
						"Id",
						"Name",
						"NormalizedName",
						"ConcurrencyStamp"
					},
					values: new[] {
						rootRoleId,
						Roles.Root.Value,
						Roles.Root.Value.ToUpper(),
						Guid.NewGuid().ToString()
					});




			migrationBuilder.InsertData(
					table: "AspNetUserRoles",
					columns: new[] {
						"UserId",
						"RoleId"
					},
					values: new[] {
						userAccountId,
						userRoleId
					});
			migrationBuilder.InsertData(
					table: "AspNetUserRoles",
					columns: new[] {
						"UserId",
						"RoleId"
					},
					values: new[] {
						adminAccountId,
						adminRoleId
					});
			migrationBuilder.InsertData(
					table: "AspNetUserRoles",
					columns: new[] {
						"UserId",
						"RoleId"
					},
					values: new[] {
						rootAccountId,
						rootRoleId
					});

        }

		private string hashPassword(string pw){
			byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
			Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

			return Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: pw!,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA256,
				iterationCount: 100000,
				numBytesRequested: 256 / 8));
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DELET FRM [AspNetRoles]");

        }
    }
}
