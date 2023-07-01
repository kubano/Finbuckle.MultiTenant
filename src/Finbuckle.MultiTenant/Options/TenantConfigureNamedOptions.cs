﻿// Copyright Finbuckle LLC, Andrew White, and Contributors.
// Refer to the solution LICENSE file for more information.

using System;

namespace Finbuckle.MultiTenant.Options;

/// <inheritdoc />
public class TenantConfigureNamedOptions<TOptions, TTenantInfo> : ITenantConfigureNamedOptions<TOptions, TTenantInfo>
    where TOptions : class, new()
    where TTenantInfo : class, ITenantInfo, new()
{
    /// <summary>
    /// Gets the name of the named option for configuration.
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public string? Name { get; }
    private readonly Action<TOptions, TTenantInfo> configureOptions;

    /// <summary>
    /// Constructs a new instance of TenantConfigureNamedOptions.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="configureOptions"></param>
    public TenantConfigureNamedOptions(string? name, Action<TOptions, TTenantInfo> configureOptions)
    {
        Name = name;
        this.configureOptions = configureOptions;
    }

    /// <inheritdoc />
    public void Configure(string name, TOptions options, TTenantInfo tenantInfo)
    {
        // Null name is used to configure all named options.
        if (Name == null || name == Name)
        {
            configureOptions(options, tenantInfo);
        }
    }
}