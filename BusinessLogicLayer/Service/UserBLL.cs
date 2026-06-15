using BCrypt.Net;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Templates;
using DataBaseLayer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.DTO.RabbitMQ;
using ModelLayer.DTO.User;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _UserDAl;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly IRabbitMQProducer _rabbitMQProducer;
        public UserBLL(
               IUserDAL userDAl,
               IEmailService emailService ,
            IConfiguration configuration ,
            IRabbitMQProducer rabbitMQProducer
         )
        {
            _UserDAl = userDAl;
            _emailService = emailService;
            _configuration = configuration;
            _rabbitMQProducer = rabbitMQProducer;
        }


        public async Task<UserResponse> RegisterUser(RegisterUserRequest userRequest)
        {
            User user = new User()
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password),
                CreatedAt = DateTime.UtcNow,
                ChangedAt = DateTime.UtcNow
            };
            user = _UserDAl.RegisterUser(user);

            string body = $@"
<div style='font-family:Arial,sans-serif;
            max-width:600px;
            margin:auto;
            border:1px solid #e0e0e0;
            border-radius:10px;
            overflow:hidden;'>

    <div style='background-color:#22c55e;
                color:white;
                padding:20px;
                text-align:center;'>

        <h1 style='margin:0;'>Fundoo Notes</h1>

        <p style='margin-top:10px;font-size:14px;'>
            Connecting Worlds, Creating History
        </p>

    </div>

    <div style='padding:25px;'>

        <h2>Hello {user.FirstName}! 👋</h2>

        <p>
            Your Fundoo Notes account has been created successfully.
        </p>

        <p>
            We're excited to have you on board.
            Every great journey begins with a single note. ✨
        </p>

        <div style='background:#f4f4f4;
                    padding:15px;
                    border-radius:8px;
                    margin-top:15px;'>

            <strong>Account Details</strong><br/>
            Name: {user.FirstName} {user.LastName}<br/>
            Email: {user.Email}

        </div>

        <p style='margin-top:20px;'>
            Thank you for joining Fundoo Notes.
            We look forward to helping you organize your ideas,
            memories, and goals.
        </p>

        <p>
            Best Wishes,<br/><br/>

            <strong>Amarnath Kolla</strong><br/>
            Cloud Researcher & .NET Trainee
        </p>

    </div>

    <div style='background:#f8f8f8;
                text-align:center;
                padding:12px;
                font-size:12px;
                color:#666;'>

        © Fundoo Notes | Welcome Aboard 🚀

    </div>

</div>";
            var emailMessage = new EmailMessageDTO
            {
                ToEmail = user.Email,
                Subject = "Welcome To Fundoo Notes",
                Body = body
            };
            await _rabbitMQProducer.PublishEmailMessage(emailMessage);

            //await _emailService.SendEmail(
            //user.Email,
            //"Welcome To Fundoo Notes",
            //body);

            UserResponse userResponse = new UserResponse()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            return userResponse;


        


         }

        public async Task<TokenResponse> LoginUser(LoginRequest loginRequest)
        {
            User user = _UserDAl.LoginUser(loginRequest.Email);

            if (user == null)
            {
                throw new ValidationException("Invalid Credentials");

            }
            bool result = BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password);
            if (!result)
            {
                throw new ValidationException("Invalid Credentials");

            }

            var claims = new[]
            {
              new Claim(ClaimTypes.Name, user.FirstName),
              new Claim(ClaimTypes.Email, user.Email),
              new Claim("UserId", user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return new TokenResponse
            {
                Token = tokenHandler.WriteToken(token),
                Message = "Login Successful"
            };
        }

        public async Task<bool> ForgotPassword(string email)
        {
            bool result = _UserDAl.ForgotPassword(email);

            if (!result)
            {
                throw new ValidationException("User not found");
            }

            string resetToken = GenerateResetToken(email);

            //string resetToken = Guid.NewGuid().ToString();



            string body =  ForgotPasswordTemplate.GetBody(resetToken);

            var emailMessage = new EmailMessageDTO
            {
                ToEmail = email,
                Subject = "Reset Password - Fundoo Notes",
                Body = body
            };

            await _rabbitMQProducer.PublishEmailMessage(emailMessage);

            return true;

        }

        public Task<bool> ResetPassword(string email, ResetPasswordRequest request)
        {
            if (request.NewPassword != request.ConfirmPassword)
            {
                throw new ValidationException(
                    "Passwords do not match");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

            bool result = _UserDAl.ResetPassword(email, hashedPassword);

            if (!result)
            {
                throw new ValidationException("User not found");
            }

            return Task.FromResult(true);
        }

        private string GenerateResetToken(string email)
        {
            var claims = new[]
          {
            new Claim(ClaimTypes.Email, email)


          };
            var key = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);

        }
    }
}

