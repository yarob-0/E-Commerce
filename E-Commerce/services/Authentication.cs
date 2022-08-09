
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Mapper _mapper;
        private readonly Jwt _jwt;

        public Authentication(UserManager<User> userManager, IOptions<Jwt> jwt, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = new Mapper(new MapperConfiguration(c =>
            {
                c.CreateMap<User, RegisterationModel>().ReverseMap();
                c.CreateMap<User, AuthenticationModel>().ReverseMap();
                c.CreateMap<AuthenticationModel, RegisterationModel>().ReverseMap();
            }));
            _jwt = jwt.Value;
        }

        public async Task<AuthenticationModel> RegisterAsync(RegisterationModel model)
        {
            AuthenticationModel tmp = new AuthenticationModel();

            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                tmp.Message = "Email already exists\n";
                return tmp;
            }
            if (await _userManager.FindByNameAsync(model.UserName) is not null)
            {
                tmp.Message = "UserName already exists\n";
                return tmp;
            }

            User user = _mapper.Map<User>(model);
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                tmp.Message = result.ToString();
                return tmp;
            }
            await _userManager.AddToRoleAsync(user, Roles.User.Value);

            return Validate(user, await CreateJwtToken(user), new List<string> { Roles.User.Value });
        }

        public async Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model)
        {
            User user = await _userManager.FindByEmailAsync(model.Email);
            AuthenticationModel tmp = new AuthenticationModel();

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                tmp.Message = "Authentication Faild";
                return tmp;
            }

            return Validate(user, await CreateJwtToken(user), await _userManager.GetRolesAsync(user));
        }

        public async Task<string> SetRoleAsync(SetRoleModel model)
        {
            User user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _roleManager.RoleExistsAsync(model.RoleName))
                return "Invalid Email or Role";
            if (await _userManager.IsInRoleAsync(user, model.RoleName))
                return "Already Assigned";

            IdentityResult result = await _userManager.AddToRoleAsync(user, model.RoleName);

            return result.Succeeded ? string.Empty : "Unable to Assign Role";
        }

        private AuthenticationModel Validate(User user, JwtSecurityToken token, IList<String> roles)
        {
            AuthenticationModel validModel = new AuthenticationModel();

            validModel = _mapper.Map<AuthenticationModel>(user);
            validModel.Token = new JwtSecurityTokenHandler().WriteToken(token);
            validModel.ExpiresOn = token.ValidTo;
            validModel.Roles = roles.ToList();

            validModel.IsAuthenticated = true;

            return validModel;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }.Union(userClaims).Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        public async Task<AuthenticationModel> UnregisterAsync(TokenRequestModel model)
        {
            AuthenticationModel tmp = new AuthenticationModel();
            User user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password) )
            {
                tmp.Message = "incorrect Email or password";
				tmp.IsAuthenticated = false;
                return tmp;
            }
            IdentityResult result = await _userManager.DeleteAsync(user);
			tmp.Message = "User Unregistered";
			return tmp;
        }
    }
}

