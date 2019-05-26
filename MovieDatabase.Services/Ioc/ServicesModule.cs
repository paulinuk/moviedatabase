using MovieDatabase.Services.Interfaces;

namespace MovieDatabase.Services.Ioc
{
    using Autofac;
    using Module = Autofac.Module;

    public class ServicesModule: Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieService>()
               .As<IMovieService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<RatingService>()
               .As<IRatingService>()
               .InstancePerLifetimeScope();


        }
    }
}
