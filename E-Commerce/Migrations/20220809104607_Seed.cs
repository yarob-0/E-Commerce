using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string userRoleId = Guid.NewGuid().ToString();
            string adminRoleId = Guid.NewGuid().ToString();
            string rootRoleId = Guid.NewGuid().ToString();
            string userAccountId = Guid.NewGuid().ToString();
            string adminAccountId = Guid.NewGuid().ToString();
            string rootAccountId = Guid.NewGuid().ToString();


            migrationBuilder.InsertData(
                    table: "AspNetUsers",
                    columns: new[] {
                        "Id",
                        "UserName",
                        "NormalizedUserName",
                        "Email",
						"NormalizedEmail",
                        "PasswordHash",
						"SecurityStamp",
                        "ConcurrencyStamp"
                    },
                    values: new[] {
                        userAccountId,
                        Roles.User.Value,
                        Roles.User.Value.ToUpper(),
                        Emails.User.Value,
                        Emails.User.Value.ToUpper(),
                        hashPassword(new IdentityUser(){
								Id = userAccountId,
								UserName = Roles.User.Value,
								Email = Emails.User.Value,
								},Passwords.User.Value),
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString()
						}
					);
            migrationBuilder.InsertData(
                    table: "AspNetUsers",
                    columns: new[] {
                        "Id",
                        "UserName",
                        "NormalizedUserName",
                        "Email",
						"NormalizedEmail",
                        "PasswordHash",
						"SecurityStamp",
                        "ConcurrencyStamp"
                    },
                    values: new[] {
                        adminAccountId,
                        Roles.Admin.Value,
                        Roles.Admin.Value.ToUpper(),
                        Emails.Admin.Value,
                        Emails.Admin.Value.ToUpper(),
                        hashPassword(new IdentityUser(){
								Id = adminAccountId,
								UserName = Roles.Admin.Value,
								Email = Emails.Admin.Value,
								},Passwords.Admin.Value),
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString()
                    });
            migrationBuilder.InsertData(
                    table: "AspNetUsers",
                    columns: new[] {
                        "Id",
                        "UserName",
                        "NormalizedUserName",
                        "Email",
						"NormalizedEmail",
                        "PasswordHash",
						"SecurityStamp",
                        "ConcurrencyStamp"
                    },
                    values: new[] {
                        rootAccountId,
                        Roles.Root.Value,
                        Roles.Root.Value.ToUpper(),
                        Emails.Root.Value,
                        Emails.Root.Value.ToUpper(),
                        hashPassword(new IdentityUser(){
								Id = rootAccountId,
								UserName = Roles.Root.Value,
								Email = Emails.Root.Value,
								},Passwords.Root.Value),
                        Guid.NewGuid().ToString(),
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

        private string hashPassword(IdentityUser user , string pw)
        {
			return new PasswordHasher<IdentityUser>().HashPassword(user ,pw);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELET FRM [AspNetRoles]");

        }
    }
}
