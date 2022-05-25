﻿using Autofac;
using eShopWithCodeFactory.Models;
using eShopWithCodeFactory.Models.Infrastructure;
using eShopWithCodeFactory.Services;

namespace eShopWithCodeFactory.Modules;

public class ApplicationModule : Module
{
    private bool useMockData;

    public ApplicationModule(bool useMockData)
    {
        this.useMockData = useMockData;
    }
    protected override void Load(ContainerBuilder builder)
    {
        if (this.useMockData)
        {
            builder.RegisterType<CatalogServiceMock>()
                .As<ICatalogService>()
                .SingleInstance();
        }
        else
        {
            builder.RegisterType<CatalogService>()
                .As<ICatalogService>()
                .InstancePerLifetimeScope();
        }

        builder.RegisterType<CatalogDBContext>()
            .InstancePerLifetimeScope();

        builder.RegisterType<CatalogDBInitializer>()
            .InstancePerLifetimeScope();

        builder.RegisterType<CatalogItemHiLoGenerator>()
            .SingleInstance();
    }
}
