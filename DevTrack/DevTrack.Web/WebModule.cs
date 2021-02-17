﻿using Autofac;

namespace DevTrack.Web
{
    public class WebModule : Module
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}