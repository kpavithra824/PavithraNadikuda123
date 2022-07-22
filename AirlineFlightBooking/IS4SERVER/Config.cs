﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IS4SERVER
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[] {
            new ApiResource("BookingWebServices","BookingWebServices1 scope 1"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new Client[] {
             new Client
                {
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"BookingWebServices"},
                },
            };
        }
    }
}