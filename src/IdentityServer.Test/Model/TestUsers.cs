// -----------------------------------------------------------------------
// <copyright file="TestUsers.cs" Author="Diego Pandiello" />
// -----------------------------------------------------------------------
namespace IdentityServer.Test.Model
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using IdentityModel;
    using IdentityServer4.Test;

    public class TestUsers
    {
            public static List<TestUser> Get()
            {
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                        Username = "scott",
                        Password = "password",
                        Claims = new List<Claim>
                        {
                            new Claim(JwtClaimTypes.Email, "scott@scottbrady91.com"),
                            new Claim(JwtClaimTypes.Role, "admin")
                        }
                    }
                };
            }
        }
    }
