using ASPBlog.Api.Core;
using ASPBlog.Application.UseCases.Commands;
using ASPBlog.Application.UseCases.Queries;
using ASPBlog.DataAccess;
using ASPBlog.Domain.Entities;
using ASPBlog.Implementation.UseCases.Commands;
using ASPBlog.Implementation.UseCases.Queries;
using ASPBlog.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace ASPBlog.Api.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<ASPBlogDbContext>();
                var settings = x.GetService<AppSettings>();

                return new JwtManager(context, settings.JwtSettings);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IRegistrationCommand, RegisterUserCommand>();
            services.AddTransient<IGetPostsQuery, GetPostsQuery>();
            services.AddTransient<IFindPostsQuery, FindPostsQuery>();
            services.AddTransient<IAddPostCommand, AddPostCommand>();
            services.AddTransient<IDeletePostCommand, DeletePostCommand>();
            services.AddTransient<IAddCommentCommand, AddCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, DeleteCommentCommand>();
            services.AddTransient<IAddTagCommand, AddTagCommand>();
            services.AddTransient<IDeleteTagCommand, DeleteTagCommand>();
            services.AddTransient<IAddCategoryCommand, AddCategoryCommand>();
            services.AddTransient<IFindCategoryQuery, FindCategoryQuery>();
            services.AddTransient<IDeleteCategoryCommand, DeleteCategoryCommand>();
            services.AddTransient<IAddGradeCommand, AddGradingCommand>();
            services.AddTransient<IDeleteGradingCommand, DeleteGradingCommand>();
            services.AddTransient<IFindUserQuery, FindUserQuery>();
            services.AddTransient<IUpdateUserRole, UpdateUserRole>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            #region Validators
            services.AddTransient<RegistrationValidator>();
            services.AddTransient<PostsValidator>();
            services.AddTransient<CommentsValidator>();
            services.AddTransient<TagValidator>();
            services.AddTransient<CategoryValidator>();
            services.AddTransient<GradingValidator>();
            services.AddTransient<UpdateUserRoleValidator>();
            #endregion
        }

        public static void AddAppUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                //Pristup payload-u
                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonimousUser();
                }

                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Username").Value,
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value),
                    RoleId = Int32.Parse(claims.FindFirst("RoleId").Value)
                };

                return actor;
            });
        }

        public static void AddASPBlogDbContext(this IServiceCollection services)
        {
            services.AddTransient(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var conString = x.GetService<AppSettings>().ConnString;

                optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();

                var options = optionsBuilder.Options;

                return new ASPBlogDbContext(options);
            });
        }
    }
}
