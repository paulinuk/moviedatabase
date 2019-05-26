namespace MovieDatabase.Common.Mappings
{
    using System;
    using System.Diagnostics;
    using AutoMapper;
    using Catel.Reflection;

    public static class AutoMapperInitializer
    {
        public static void Initialize()
        {

            try
            {
                var types = TypeCache.GetTypesImplementingInterface(typeof(IMappingInitializer));

                Mapper.Initialize(cfg =>
                {
                    foreach (var type in types)
                    {
                        if (type.IsAbstractEx())
                        {
                            continue;
                        }

                        var instance = Activator.CreateInstance(type) as IMappingInitializer;
                        if (instance != null)
                        {
                            instance.Initialize(cfg);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Mapper already initialized. You must call Initialize once per application domain/process.") == false)
                {
                    Debug.WriteLine(ex);
                    throw;
                }
            }
        }
    }
}